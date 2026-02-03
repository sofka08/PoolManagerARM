using System;
using System.Data;
using System.Windows.Forms;

namespace PP
{
    public partial class AbonementDetailForm : Form 
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private int? _abonementId;

        public AbonementDetailForm(int? abonementId = null)
        {
            InitializeComponent();
            _abonementId = abonementId;

            if (_abonementId.HasValue)
            {
                LoadAbonementData();
            }
        }

        private void LoadAbonementData()
        {
            DataRow abonementData = dbHelper.GetAbonementById(_abonementId.Value); 
            if (abonementData != null)
            {
                txtName.Text = abonementData["Name"].ToString();
                txtPrice.Text = Convert.ToDecimal(abonementData["Price"]).ToString();
                numDurationDays.Value = Convert.ToInt32(abonementData["DurationDays"]);
                numVisitsCount.Value = Convert.ToInt32(abonementData["VisitsCount"]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string name = txtName.Text;
            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Пожалуйста, введите корректную цену.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int durationDays = (int)numDurationDays.Value;
            int visitsCount = (int)numVisitsCount.Value;

            int result;
            if (_abonementId.HasValue)
            {
                result = dbHelper.UpdateAbonement(_abonementId.Value, name, price, durationDays, visitsCount); 
            }
            else
            {
                result = dbHelper.AddAbonement(name, price, durationDays, visitsCount); 
            }
            if (result > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при сохранении абонемента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
