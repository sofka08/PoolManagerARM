using System;
using System.Data;
using System.Windows.Forms;
using PP; // Namespace проекта

namespace PP
{
    public partial class ClientsDetail : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private int _clientId = 0; 
        public ClientsDetail()
        {
            InitializeComponent();
            this.Text = "Добавить клиента";
            dtpDateOfBirth.Value = DateTime.Today;
        }

        public ClientsDetail(int clientId) : this()
        {
            this.Text = "Редактировать клиента";
            _clientId = clientId;
            LoadClientData();
        }

        private void LoadClientData()
        {
            DataRow clientData = dbHelper.GetClientById(_clientId);
            if (clientData != null)
            {
                txtFullName.Text = clientData["FullName"].ToString();
                txtPhone.Text = clientData["Phone"].ToString();
                if (DateTime.TryParse(clientData["DateOfBirth"].ToString(), out DateTime dob))
                {
                    dtpDateOfBirth.Value = dob;
                }
                else
                {
                    dtpDateOfBirth.Value = DateTime.Today;
                }
            }
            else
            {
                MessageBox.Show("Клиент не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Пожалуйста, введите ФИО клиента.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Пожалуйста, введите телефон клиента.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullName = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string dateOfBirth = dtpDateOfBirth.Value.ToString("yyyy-MM-dd");

            int rowsAffected = 0;
            if (_clientId == 0)
            {
                rowsAffected = dbHelper.AddClient(fullName, phone, dateOfBirth);
            }
            else
            {
                rowsAffected = dbHelper.UpdateClient(_clientId, fullName, phone, dateOfBirth);
            }

            if (rowsAffected > 0)
            {
                MessageBox.Show("Данные клиента успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не удалось сохранить данные клиента.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
