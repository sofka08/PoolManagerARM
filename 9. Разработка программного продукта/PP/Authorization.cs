using System;
using System.Windows.Forms;

namespace PP
{
    public partial class Authorization : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public Authorization()
        {
            InitializeComponent();
        }

        private void btnVhod_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string role = dbHelper.GetUserRole(login, password);

            if (role != null) 
            {
                UserSession.Role = role;
                UserSession.Username = login;
                MessageBox.Show($"Авторизация успешна! Роль: {role}", "Добро пожаловать", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Menu menu = new Menu(this); 
                menu.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
