using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PP
{
    public partial class Schedule : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private Menu _mainMenu; 

        public Schedule(Menu mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;
            SetupDataGridView();

            // Устанавливаем месяц/дату календаря на сегодня
            try
            {
                monthCalendar1.SetDate(DateTime.Today);
            }
            catch
            {
                // Если monthCalendar1 отсутствует — ничего не делаем 
            }

            LoadSchedule(GetSelectedDateString());
        }

        private void SetupDataGridView()
        {
            dgvSchedule.AutoGenerateColumns = false;
            dgvSchedule.ReadOnly = true;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedule.RowHeadersVisible = false; 
            dgvSchedule.RowHeadersVisible = false;
            dgvSchedule.EnableHeadersVisualStyles = false; 
            dgvSchedule.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue; 
            dgvSchedule.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvSchedule.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 10, FontStyle.Bold);
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedule.BackgroundColor = Color.White;
            dgvSchedule.DefaultCellStyle.Font = new Font("Courier New", 10, FontStyle.Regular);
            dgvSchedule.RowTemplate.Height = 27;
            dgvSchedule.ClearSelection();
            dgvSchedule.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvSchedule.ColumnHeadersDefaultCellStyle.BackColor;
            dgvSchedule.DefaultCellStyle.SelectionBackColor = Color.LightCyan;
            dgvSchedule.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvSchedule.Columns.Clear();
            // ВАЖНО: Name должен совпадать с тем, что мы пишем в Cells["..."]
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "ClientName", DataPropertyName = "ClientName", HeaderText = "Клиент", Width = 150 });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "CoachName", DataPropertyName = "CoachName", HeaderText = "Тренер", Width = 150 });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "StartTime", DataPropertyName = "StartTime", HeaderText = "Начало", Width = 80 });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "EndTime", DataPropertyName = "EndTime", HeaderText = "Конец", Width = 80 });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "PoolArea", DataPropertyName = "PoolArea", HeaderText = "Зона", Width = 100 });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", DataPropertyName = "Status", HeaderText = "Статус", Width = 100 });
            // Скрытые колонки для ID
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "ClientId", DataPropertyName = "ClientId", Visible = false });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "CoachId", DataPropertyName = "CoachId", Visible = false });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "AbonementId", DataPropertyName = "AbonementId", Visible = false });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn { Name = "ScheduleDate", DataPropertyName = "ScheduleDate", Visible = false });
        }

        private string GetSelectedDateString()
        {
            try
            {
                DateTime selected = monthCalendar1.SelectionStart;
                return selected.ToString("yyyy-MM-dd");
            }
            catch
            {
                return DateTime.Today.ToString("yyyy-MM-dd");
            }
        }


        private void LoadSchedule(string date)
        {
            DataTable scheduleData = dbHelper.GetSchedule(date); 
            dgvSchedule.DataSource = scheduleData;

            if (dgvSchedule.Columns.Contains("Id")) dgvSchedule.Columns["Id"].Visible = false;
            if (dgvSchedule.Columns.Contains("ClientSubscriptionId")) dgvSchedule.Columns["ClientSubscriptionId"].Visible = false;

            if (dgvSchedule.Columns.Contains("ClientName")) dgvSchedule.Columns["ClientName"].HeaderText = "Клиент";
            if (dgvSchedule.Columns.Contains("CoachName")) dgvSchedule.Columns["CoachName"].HeaderText = "Тренер";
            if (dgvSchedule.Columns.Contains("AbonementName")) dgvSchedule.Columns["AbonementName"].HeaderText = "Абонемент";
            if (dgvSchedule.Columns.Contains("ScheduleDate")) dgvSchedule.Columns["ScheduleDate"].HeaderText = "Дата";
            if (dgvSchedule.Columns.Contains("StartTime")) dgvSchedule.Columns["StartTime"].HeaderText = "Начало";
            if (dgvSchedule.Columns.Contains("EndTime")) dgvSchedule.Columns["EndTime"].HeaderText = "Окончание";
            if (dgvSchedule.Columns.Contains("PoolArea")) dgvSchedule.Columns["PoolArea"].HeaderText = "Зона";
            if (dgvSchedule.Columns.Contains("Status")) dgvSchedule.Columns["Status"].HeaderText = "Статус";
        }

        private void dgvSchedule_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvSchedule.Columns[e.ColumnIndex].Name == "Status")
            {
                string status = e.Value?.ToString();
                switch (status)
                {
                    case "Запланировано":
                        e.CellStyle.BackColor = Color.LightBlue;
                        break;
                    case "Проведено":
                        e.CellStyle.BackColor = Color.LightGreen;
                        break;
                    case "Отменено":
                        e.CellStyle.BackColor = Color.LightCoral;
                        break;
                    default:
                        e.CellStyle.BackColor = Color.White;
                        break;
                }
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            LoadSchedule(GetSelectedDateString());
        }

        private void btnAddScheduleEntry_Click(object sender, EventArgs e)
        {
            ScheduleDetail scheduleDetail = new ScheduleDetail();
            if (scheduleDetail.ShowDialog() == DialogResult.OK)
            {
                LoadSchedule(GetSelectedDateString());
            }
        }

        private void btnEditScheduleEntry_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count > 0)
            {
                int scheduleId = Convert.ToInt32(dgvSchedule.SelectedRows[0].Cells["Id"].Value);
                ScheduleDetail scheduleDetail = new ScheduleDetail(scheduleId);
                if (scheduleDetail.ShowDialog() == DialogResult.OK)
                {
                    LoadSchedule(GetSelectedDateString());
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись для редактирования.");
            }
        }

        private void btnDeleteScheduleEntry_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int scheduleId = Convert.ToInt32(dgvSchedule.SelectedRows[0].Cells["Id"].Value);
                    dbHelper.DeleteScheduleEntry(scheduleId);
                    LoadSchedule(GetSelectedDateString());
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись для удаления.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainMenu.Show();
        }
    }
}