using System;
using System.Data;
using System.Windows.Forms;

namespace PP
{
    public partial class CoachDetailForm : Form 
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private int? _coachId;
        public CoachDetailForm(int? coachId = null)
        {
            InitializeComponent();
            _coachId = coachId;

            if (_coachId.HasValue)
            {
                LoadCoachData();
            }
        }

        private void LoadCoachData()
        {
            DataRow coachData = dbHelper.GetCoachById(_coachId.Value); 
            if (coachData != null)
            {
                txtFullName.Text = coachData["FullName"].ToString();
                txtPhone.Text = coachData["Phone"].ToString();
                txtSpecialization.Text = coachData["Specialization"].ToString();
                dtpDateOfBirth.Value = DateTime.Parse(coachData["DateOfBirth"].ToString());
                numExperienceYears.Value = Convert.ToInt32(coachData["ExperienceYears"]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtSpecialization.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string fullName = txtFullName.Text;
            string phone = txtPhone.Text;
            string specialization = txtSpecialization.Text;
            string dateOfBirth = dtpDateOfBirth.Value.ToString("yyyy-MM-dd");
            int experienceYears = (int)numExperienceYears.Value;

            int result;
            if (_coachId.HasValue)
            {
                result = dbHelper.UpdateCoach(_coachId.Value, fullName, phone, specialization, dateOfBirth, experienceYears); 
            }
            else
            {
                result = dbHelper.AddCoach(fullName, phone, specialization, dateOfBirth, experienceYears);
            }

            if (result > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при сохранении тренера.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
