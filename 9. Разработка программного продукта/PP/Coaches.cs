using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PP
{
    public partial class Coaches : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private Menu _mainMenu;

        public Coaches(Menu mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;
            SetupDataGridView();
            LoadCoaches();

            txtSearchCoach.TextChanged += txtSearchCoach_TextChanged; // Поиск по ФИО
            txtSearchPhone.TextChanged += txtSearchPhone_TextChanged; // Поиск по телефону
        }

        private void SetupDataGridView()
        {
            dgvCoaches.AllowUserToAddRows = false; 
            dgvCoaches.AutoGenerateColumns = false;
            dgvCoaches.ReadOnly = true;
            dgvCoaches.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCoaches.RowHeadersVisible = false;
            dgvCoaches.Columns.Clear();
            dgvCoaches.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvCoaches.Columns.Add(new DataGridViewTextBoxColumn { Name = "FullName", DataPropertyName = "FullName", HeaderText = "ФИО Тренера", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvCoaches.Columns.Add(new DataGridViewTextBoxColumn { Name = "Phone", DataPropertyName = "Phone", Visible = false });
            dgvCoaches.Columns.Add(new DataGridViewTextBoxColumn { Name = "Specialization", DataPropertyName = "Specialization", Visible = false });
            dgvCoaches.Columns.Add(new DataGridViewTextBoxColumn { Name = "DateOfBirth", DataPropertyName = "DateOfBirth", Visible = false });
            dgvCoaches.Columns.Add(new DataGridViewTextBoxColumn { Name = "ExperienceYears", DataPropertyName = "ExperienceYears", Visible = false });
            dgvCoaches.RowHeadersVisible = false;
            dgvCoaches.EnableHeadersVisualStyles = false;
            dgvCoaches.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue; 
            dgvCoaches.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvCoaches.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 10, FontStyle.Bold);
            dgvCoaches.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCoaches.BackgroundColor = Color.White;
            dgvCoaches.DefaultCellStyle.Font = new Font("Courier New", 10, FontStyle.Regular);
            dgvCoaches.RowTemplate.Height = 27;
            dgvCoaches.ClearSelection();
            dgvCoaches.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvCoaches.ColumnHeadersDefaultCellStyle.BackColor;
            dgvCoaches.DefaultCellStyle.SelectionBackColor = Color.LightCyan; 
            dgvCoaches.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void LoadCoaches(string searchFullName = "", string searchPhone = "")
        {
            DataTable coachesData = dbHelper.GetCoaches(searchFullName, searchPhone);
            dgvCoaches.DataSource = coachesData;

            if (dgvCoaches.Columns.Contains("Id")) dgvCoaches.Columns["Id"].Visible = false;

            ClearCoachDetails();
            if (coachesData.Rows.Count > 0)
            {
                dgvCoaches.Rows[0].Selected = true;
                DisplayCoachDetails(Convert.ToInt32(dgvCoaches.Rows[0].Cells["Id"].Value));
            }
        }

        private void dgvCoaches_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCoaches.SelectedRows.Count > 0)
            {
                int coachId = Convert.ToInt32(dgvCoaches.SelectedRows[0].Cells["Id"].Value);
                DisplayCoachDetails(coachId);
            }
            else
            {
                ClearCoachDetails();
            }
        }

        private void DisplayCoachDetails(int coachId)
        {
            DataRow coachData = dbHelper.GetCoachById(coachId);
            if (coachData != null)
            {
                lblCoachFullName.Text = $"ФИО: {coachData["FullName"]}";
                lblCoachPhone.Text = $"Телефон: {coachData["Phone"]}";
                lblCoachSpecialization.Text = $"Специализация: {coachData["Specialization"]}";
                lblCoachDateOfBirth.Text = $"Дата рождения: {coachData["DateOfBirth"]}";
                lblCoachExperienceYears.Text = $"Стаж: {coachData["ExperienceYears"]} лет";
                pnlCoachDetails.Visible = true;
            }
        }

        private void ClearCoachDetails()
        {
            lblCoachFullName.Text = "ФИО: ";
            lblCoachPhone.Text = "Телефон: ";
            lblCoachSpecialization.Text = "Специализация: ";
            lblCoachDateOfBirth.Text = "Дата рождения: ";
            lblCoachExperienceYears.Text = "Стаж: ";
        }

        private void txtSearchCoach_TextChanged(object sender, EventArgs e)
        {
            LoadCoaches(txtSearchCoach.Text, txtSearchPhone.Text);
        }

        private void txtSearchPhone_TextChanged(object sender, EventArgs e)
        {
            LoadCoaches(txtSearchCoach.Text, txtSearchPhone.Text);
        }

        private void btnAddCoach_Click(object sender, EventArgs e)
        {
            CoachDetailForm coachDetail = new CoachDetailForm(); 
            if (coachDetail.ShowDialog() == DialogResult.OK)
            {
                LoadCoaches(txtSearchCoach.Text, txtSearchPhone.Text);
            }
        }

        private void btnEditCoach_Click(object sender, EventArgs e)
        {
            if (dgvCoaches.SelectedRows.Count > 0)
            {
                int coachId = Convert.ToInt32(dgvCoaches.SelectedRows[0].Cells["Id"].Value);
                CoachDetailForm coachDetail = new CoachDetailForm(coachId);
                if (coachDetail.ShowDialog() == DialogResult.OK)
                {
                    LoadCoaches(txtSearchCoach.Text, txtSearchPhone.Text);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите тренера для редактирования.");
            }
        }

        private void btnDeleteCoach_Click(object sender, EventArgs e)
        {
            if (dgvCoaches.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить этого тренера?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int coachId = Convert.ToInt32(dgvCoaches.SelectedRows[0].Cells["Id"].Value);
                    dbHelper.DeleteCoach(coachId);
                    LoadCoaches(txtSearchCoach.Text, txtSearchPhone.Text);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите тренера для удаления.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainMenu.Show();
        }
        private void btnShowCoachSchedule_Click(object sender, EventArgs e)
        {
            if (dgvCoaches.SelectedRows.Count > 0)
            {
                // 1. Получаем ID выбранного тренера
                int coachId = Convert.ToInt32(dgvCoaches.SelectedRows[0].Cells["Id"].Value);
                // 2. Инициализируем DatabaseHelper
                DatabaseHelper dbHelper = new DatabaseHelper();
                // 3. Получаем данные тренера по ID
                DataRow coachInfo = dbHelper.GetCoachById(coachId);
                string coachName = "Неизвестный тренер"; 
                if (coachInfo != null)
                {
                    // Если тренер найден, берем его полное имя
                    coachName = coachInfo["FullName"].ToString();
                }
                // 4. Создаем форму, передавая ID И ПОЛУЧЕННОЕ ИМЯ
                CoachScheduleForm coachScheduleForm = new CoachScheduleForm(coachId, coachName);
                coachScheduleForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите тренера для просмотра расписания.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
