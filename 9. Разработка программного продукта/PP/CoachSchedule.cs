using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PP
{
    public partial class CoachScheduleForm : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private int _coachId;
        private string _coachName;
        public CoachScheduleForm(int coachId, string coachName = "Неизвестный тренер")
        {
            InitializeComponent();
            _coachId = coachId;
            _coachName = coachName;
            this.Text = $"Расписание тренера: {_coachName}";
            dtpScheduleDate.Value = DateTime.Today;
            SetupDataGridViewStyle(); 
            LoadCoachSchedule(dtpScheduleDate.Value.ToString("yyyy-MM-dd"));
        }
        private void SetupDataGridViewStyle()
        {
            dgvCoachSchedule.AllowUserToAddRows = false;
            dgvCoachSchedule.RowHeadersVisible = false;
            dgvCoachSchedule.EnableHeadersVisualStyles = false;
            dgvCoachSchedule.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
            dgvCoachSchedule.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvCoachSchedule.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 10, FontStyle.Bold);
            dgvCoachSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCoachSchedule.BackgroundColor = Color.White;
            dgvCoachSchedule.DefaultCellStyle.Font = new Font("Courier New", 10, FontStyle.Regular);
            dgvCoachSchedule.RowTemplate.Height = 27;
            dgvCoachSchedule.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvCoachSchedule.ColumnHeadersDefaultCellStyle.BackColor;
            dgvCoachSchedule.DefaultCellStyle.SelectionBackColor = Color.LightCyan;
            dgvCoachSchedule.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCoachSchedule.CellFormatting += dgvCoachSchedule_CellFormatting;
            dgvCoachSchedule.ClearSelection();
        }

        private void LoadCoachSchedule(string date)
        {
            DataTable scheduleData = dbHelper.GetCoachSchedule(_coachId, date);
            dgvCoachSchedule.AutoGenerateColumns = true;
            dgvCoachSchedule.DataSource = scheduleData;

            if (dgvCoachSchedule.Columns.Count > 0)
            {
                HideColumn("Id");
                HideColumn("ClientId");
                HideColumn("CoachId"); 
                HideColumn("AbonementId");
                HideColumn("ClientSubscriptionId"); 

                SetColumnHeader("ClientName", "Клиент");
                HideColumn("CoachName"); 

                SetColumnHeader("AbonementName", "Абонемент");
                SetColumnHeader("ScheduleDate", "Дата");
                SetColumnHeader("StartTime", "Начало");
                SetColumnHeader("EndTime", "Окончание");
                SetColumnHeader("PoolArea", "Зона");
                SetColumnHeader("Status", "Статус");
            }

            dgvCoachSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCoachSchedule.ClearSelection();
        }

        // Вспомогательный метод для скрытия колонки
        private void HideColumn(string columnName)
        {
            if (dgvCoachSchedule.Columns.Contains(columnName))
            {
                dgvCoachSchedule.Columns[columnName].Visible = false;
            }
        }

        // Вспомогательный метод для установки заголовка колонки
        private void SetColumnHeader(string columnName, string headerText)
        {
            if (dgvCoachSchedule.Columns.Contains(columnName))
            {
                dgvCoachSchedule.Columns[columnName].HeaderText = headerText;
            }
        }

        private void dgvCoachSchedule_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvCoachSchedule.Columns[e.ColumnIndex].DataPropertyName == "Status")
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
        private void dtpScheduleDate_ValueChanged(object sender, EventArgs e)
        {
            LoadCoachSchedule(dtpScheduleDate.Value.ToString("yyyy-MM-dd"));
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
