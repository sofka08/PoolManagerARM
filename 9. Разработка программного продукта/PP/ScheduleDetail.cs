using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PP
{
    public partial class ScheduleDetail : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private int? _scheduleId;
        private int? _initialClientSubscriptionId; // Для отслеживания абонемента до сохранения
        private string _initialStatus; // Для отслеживания статуса до сохранения

        public ScheduleDetail(int? scheduleId = null)
        {
            InitializeComponent();
            _scheduleId = scheduleId;
            LoadComboBoxes();

            dtpDate.Value = DateTime.Today; // Дата по умолчанию - сегодня
            dtpStartTime.Value = DateTime.Now; // Время начала по умолчанию - сейчас
            dtpEndTime.Value = DateTime.Now.AddHours(1); // Время окончания по умолчанию - через час

            if (_scheduleId.HasValue)
            {
                LoadScheduleData();
                cmbClient.Enabled = false; // Нельзя менять клиента при редактировании записи
            }
            else
            {
                cmbClient.SelectedIndexChanged += CmbClient_SelectedIndexChanged;
            }
        }

        private void LoadComboBoxes()
        {
            // Загрузка клиентов
            cmbClient.DataSource = dbHelper.GetClients();
            cmbClient.DisplayMember = "FullName";
            cmbClient.ValueMember = "Id";
            cmbClient.SelectedIndex = -1;

            // Загрузка тренеров
            cmbTrainer.DataSource = dbHelper.GetCoaches();
            cmbTrainer.DisplayMember = "FullName";
            cmbTrainer.ValueMember = "Id";
            cmbTrainer.SelectedIndex = -1;

            // Загрузка типов зон бассейна
            cmbPoolArea.Items.AddRange(new string[] { "Зона 1", "Зона 2", "Зона 3", "Детская зона", "Грудничковая зона", "VIP зона" });
            cmbPoolArea.SelectedIndex = -1;

            // Загрузка статусов
            cmbStatus.Items.AddRange(new string[] { "Запланировано", "Проведено", "Отменено" });
            cmbStatus.SelectedIndex = 0; // По умолчанию "Запланировано"

            cmbClientSubscription.DataSource = null;
            cmbClientSubscription.Items.Clear();
            cmbClientSubscription.Items.Add("Без абонемента");
            cmbClientSubscription.SelectedIndex = 0;
        }

        private void LoadScheduleData()
        {
            DataRow scheduleData = dbHelper.GetScheduleEntryById(_scheduleId.Value);
            if (scheduleData != null)
            {
                cmbClient.SelectedValue = scheduleData["ClientId"];
                cmbTrainer.SelectedValue = scheduleData["CoachId"];

                if (scheduleData["ClientId"] != DBNull.Value)
                {
                    LoadClientSubscriptionsForClient(Convert.ToInt32(scheduleData["ClientId"]));
                    if (scheduleData["AbonementId"] != DBNull.Value) 
                    {
                        cmbClientSubscription.SelectedValue = scheduleData["AbonementId"];
                        _initialClientSubscriptionId = Convert.ToInt32(scheduleData["AbonementId"]);
                    }
                    else
                    {
                        cmbClientSubscription.SelectedIndex = 0; 
                    }
                }
                else
                {
                    cmbClientSubscription.SelectedIndex = 0;
                }

                dtpDate.Value = DateTime.Parse(scheduleData["ScheduleDate"].ToString());
                dtpStartTime.Value = DateTime.Parse(scheduleData["StartTime"].ToString());
                dtpEndTime.Value = DateTime.Parse(scheduleData["EndTime"].ToString());
                cmbPoolArea.SelectedItem = scheduleData["PoolArea"].ToString();
                cmbStatus.SelectedItem = scheduleData["Status"].ToString();
                _initialStatus = scheduleData["Status"].ToString(); 
            }
        }

        private void CmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClient.SelectedValue != null && cmbClient.SelectedValue != DBNull.Value)
            {
                if (cmbClient.SelectedValue is DataRowView drv)
                {
                    int clientId = Convert.ToInt32(drv["Id"]); 
                    LoadClientSubscriptionsForClient(clientId);
                }
                else if (cmbClient.SelectedValue != null)
                {
                    int clientId = Convert.ToInt32(cmbClient.SelectedValue);
                    LoadClientSubscriptionsForClient(clientId);
                }
            }
            else
            {
                cmbClientSubscription.DataSource = null;
                cmbClientSubscription.Items.Clear();
                cmbClientSubscription.Items.Add("Без абонемента");
                cmbClientSubscription.SelectedIndex = 0;
            }
        }

        private void LoadClientSubscriptionsForClient(int clientId)
        {
            DataTable subs = dbHelper.GetActiveClientSubscriptions(clientId);

            DataRow noSubRow = subs.NewRow();
            noSubRow["Id"] = 0;
            noSubRow["AbonementName"] = "Без абонемента";
            noSubRow["RemainingVisits"] = 0;
            noSubRow["ExpiryDate"] = "2026-01-01";
            noSubRow["PurchaseDate"] = "2026-01-01";
            subs.Rows.InsertAt(noSubRow, 0);

            cmbClientSubscription.DataSource = subs;
            cmbClientSubscription.DisplayMember = "AbonementName";
            cmbClientSubscription.ValueMember = "Id";
            cmbClientSubscription.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbClient.SelectedValue == null || cmbTrainer.SelectedValue == null ||
                string.IsNullOrWhiteSpace(cmbPoolArea.Text) || string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clientId = Convert.ToInt32(cmbClient.SelectedValue);
            int coachId = Convert.ToInt32(cmbTrainer.SelectedValue);

            int? clientSubscriptionId = cmbClientSubscription.SelectedValue == DBNull.Value || cmbClientSubscription.SelectedValue == null
                                        ? (int?)null
                                        : Convert.ToInt32(cmbClientSubscription.SelectedValue);

            string date = dtpDate.Value.ToString("yyyy-MM-dd");
            string start = dtpStartTime.Value.ToString("HH:mm:ss");
            string end = dtpEndTime.Value.ToString("HH:mm:ss");

            string area = cmbPoolArea.SelectedItem.ToString();
            string status = cmbStatus.SelectedItem.ToString();

            if (clientSubscriptionId.HasValue && status == "Проведено") 
            {
                DataRow subscriptionInfo = dbHelper.GetClientSubscriptionById(clientSubscriptionId.Value);
                if (subscriptionInfo != null)
                {
                    int remainingVisits = Convert.ToInt32(subscriptionInfo["RemainingVisits"]);
                    DateTime expiryDate = DateTime.Parse(subscriptionInfo["ExpiryDate"].ToString());

                    if (remainingVisits <= 0)
                    {
                        MessageBox.Show("У выбранного абонемента закончились посещения!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (DateTime.Now > expiryDate)
                    {
                        MessageBox.Show("Срок действия выбранного абонемента истек!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Выбранный абонемент клиента не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Проверка на накладки (тренер или зона бассейна)
            if (dbHelper.CheckForOverlap(_scheduleId ?? -1, coachId, area, date, start, end))
            {
                MessageBox.Show("В это время тренер или зона бассейна уже заняты!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int result;

            if (_scheduleId.HasValue) 
            {
                result = dbHelper.UpdateScheduleEntry(_scheduleId.Value, clientId, coachId, clientSubscriptionId, date, start, end, area, status);
            }
            else 
            {
                result = dbHelper.AddScheduleEntry(clientId, coachId, clientSubscriptionId, date, start, end, area, status);
            }

            if (result > 0)
            {
                if (status == "Проведено" && _initialStatus != "Проведено" && clientSubscriptionId.HasValue)
                {
                    int visitsDeducted = dbHelper.DeductVisitFromClientSubscription(clientSubscriptionId.Value);
                    if (visitsDeducted <= 0)
                    {
                        MessageBox.Show("Занятие отмечено как проведенное, но списать посещение по абонементу не удалось (возможно, оно закончилось или истек срок).", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (status != "Проведено" && _initialStatus == "Проведено" && _initialClientSubscriptionId.HasValue
                         && _initialClientSubscriptionId == clientSubscriptionId) 
                {
                    dbHelper.ReturnVisitToClientSubscription(_initialClientSubscriptionId.Value);
                    MessageBox.Show("Занятие отменено, посещение по абонементу возвращено.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при сохранении в базу данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}