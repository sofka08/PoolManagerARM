using PP;
using System;
using System.Windows.Forms;

namespace PP
{
    public partial class Menu : Form
    {
        private Authorization _authorizationForm;

        public Menu(Authorization authorizationForm)
        {
            InitializeComponent();
            _authorizationForm = authorizationForm;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            _authorizationForm.Show();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            this.Hide();
            Clients clientsForm = new Clients(this);
            clientsForm.Show();
        }

        private void btnCoaches_Click(object sender, EventArgs e)
        {
            this.Hide();
            Coaches coachesForm = new Coaches(this);
            coachesForm.Show();
        }

        private void btnAbonements_Click(object sender, EventArgs e)
        {
            this.Hide();
            Abonements abonomentsForm = new Abonements(this);
            abonomentsForm.Show();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            Schedule scheduleForm = new Schedule(this);
            scheduleForm.Show();
            this.Hide();
        }

        private void btnPoolLoad_Click(object sender, EventArgs e)
        {
            this.Hide();
            PoolLoad poolLoadForm = new PoolLoad(this);
            poolLoadForm.Show();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_authorizationForm.Visible)
            {
                Application.Exit();
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            Statistics statisticsForm = new Statistics(this); 
            statisticsForm.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if (UserSession.Role == "Coach")
            {
                btnStatistics.Visible = false; 
                btnCoaches.Visible = false;    
                lblWelcome.Text = $"Вы вошли как тренер: {UserSession.Username}";
            }
            else
            {
                lblWelcome.Text = "Режим: Администратор";
            }
        }
    }
}