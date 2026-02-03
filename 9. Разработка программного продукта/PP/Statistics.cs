using System;
using System.Data;
using System.Drawing; 
using System.Linq;
using System.Windows.Forms;

namespace PP
{
    public partial class Statistics : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private Form _mainMenu;

        public Statistics(Form mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;

            Font kpiFont = new Font("Courier New", 11, FontStyle.Regular);
            Color kpiColor = Color.MidnightBlue; 

            lblTotalClients.Font = kpiFont; lblTotalClients.ForeColor = kpiColor;
            lblNewClientsMonth.Font = kpiFont; lblNewClientsMonth.ForeColor = kpiColor;
            lblConductedSessions.Font = kpiFont; lblConductedSessions.ForeColor = kpiColor;
            lblTodaySessions.Font = kpiFont; lblTodaySessions.ForeColor = kpiColor;
            lblTomorrowSessions.Font = kpiFont; lblTomorrowSessions.ForeColor = kpiColor;
            lblApproxIncome.Font = kpiFont; lblApproxIncome.ForeColor = kpiColor;

            Font leaderFont = new Font("Arial", 12, FontStyle.Bold); 
            Color leaderColor = Color.RoyalBlue;

            lblTopTrainer.Font = leaderFont; lblTopTrainer.ForeColor = leaderColor;
            lblMostPopularAbonement.Font = leaderFont; lblMostPopularAbonement.ForeColor = leaderColor;
            dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpEndDate.Value = DateTime.Today;
        }

        private void LoadStatistics()
        {
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания.", "Ошибка дат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Основные показатели (KPI)
                lblTotalClients.Text = $"Всего клиентов в базе: {dbHelper.GetTotalClients()}";
                lblNewClientsMonth.Text = $"Новых клиентов за период: +{dbHelper.GetNewClientsCount(startDate, endDate)}";

                int conductedSessions = dbHelper.GetConductedSessionsCount(startDate, endDate);
                lblConductedSessions.Text = $"Проведено занятий за период: {conductedSessions}";

                lblTodaySessions.Text = $"Записей на сегодня ({DateTime.Today:dd.MM}): {dbHelper.GetTodaySessionsCount()}";
                lblTomorrowSessions.Text = $"Записей на завтра ({DateTime.Today.AddDays(1):dd.MM}): {dbHelper.GetTomorrowSessionsCount()}";

                decimal income = dbHelper.GetApproximateIncome(startDate, endDate);
                lblApproxIncome.Text = $"Приблизительный доход: {income:C2}";

                // 2. Дополнительная статистика текстом (Лидеры)
                LoadTopStats(startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTopStats(DateTime start, DateTime end)
        {
            DataTable trainerData = dbHelper.GetTrainerUsageStats(start, end);
            DataTable abonementData = dbHelper.GetAbonementUsageStats(start, end);

            // Самый активный тренер
            if (trainerData.Rows.Count > 0)
            {
                string name = trainerData.Rows[0]["TrainerName"].ToString();
                string count = trainerData.Rows[0]["SessionCount"].ToString();
                lblTopTrainer.Text = $"🏆 Лидер среди тренеров: {name}";
            }
            else
            {
                lblTopTrainer.Text = "🏆 Лидер среди тренеров: нет данных за период";
                lblTopTrainer.ForeColor = Color.Gray; 
            }

            // Самый популярный абонемент
            if (abonementData.Rows.Count > 0)
            {
                string name = abonementData.Rows[0]["AbonementName"].ToString();
                string count = abonementData.Rows[0]["Count"].ToString();
                lblMostPopularAbonement.Text = $"🎫 Популярный абонемент: {name}";
            }
            else
            {
                lblMostPopularAbonement.Text = "🎫 Популярный абонемент: нет данных за период";
                lblMostPopularAbonement.ForeColor = Color.Gray; 
            }
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainMenu.Show();
        }

        private void Statistics_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainMenu.Show();
        }
    }
}
