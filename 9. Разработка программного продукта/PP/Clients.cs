using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PP
{
    public partial class Clients : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private Menu _mainMenu; 
        public Clients(Menu mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;
            SetupDataGridView();
            LoadClients();

            txtSearchClient.TextChanged += txtSearchClient_TextChanged; // Поиск по ФИО
            txtSearchPhone.TextChanged += txtSearchPhone_TextChanged;   // Поиск по телефону
        }

        private void SetupDataGridView()
        {
            dgvClients.AutoGenerateColumns = false;
            dgvClients.ReadOnly = true;
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.ColumnHeadersVisible = true;
            dgvClients.RowHeadersVisible = false;
            dgvClients.Columns.Clear();
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { Name = "FullName", DataPropertyName = "FullName", HeaderText = "ФИО Клиента", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { Name = "Phone", DataPropertyName = "Phone", Visible = false });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { Name = "DateOfBirth", DataPropertyName = "DateOfBirth", Visible = false });
            dgvClients.EnableHeadersVisualStyles = false; 
            dgvClients.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue; 
            dgvClients.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvClients.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 10, FontStyle.Bold);
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.BackgroundColor = Color.White;
            dgvClients.DefaultCellStyle.Font = new Font("Courier New", 10, FontStyle.Regular);
            dgvClients.RowTemplate.Height = 27;
            dgvClients.ClearSelection();
            dgvClients.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvClients.ColumnHeadersDefaultCellStyle.BackColor;
            dgvClients.DefaultCellStyle.SelectionBackColor = Color.LightCyan;
        }

        private void LoadClients(string searchFullName = "", string searchPhone = "")
        {
            DataTable clientsData = dbHelper.GetClients(searchFullName, searchPhone);
            dgvClients.DataSource = clientsData;
            if (dgvClients.Columns.Contains("Id")) dgvClients.Columns["Id"].Visible = false;

            ClearClientDetails();
            if (clientsData.Rows.Count > 0)
            {
                dgvClients.Rows[0].Selected = true;
                DisplayClientDetails(Convert.ToInt32(dgvClients.Rows[0].Cells["Id"].Value));
            }
        }

        private void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count > 0)
            {
                int clientId = Convert.ToInt32(dgvClients.SelectedRows[0].Cells["Id"].Value);
                DisplayClientDetails(clientId);
            }
            else
            {
                ClearClientDetails();
            }
        }

        private void DisplayClientDetails(int clientId)
        {
            DataRow clientData = dbHelper.GetClientById(clientId);
            if (clientData != null)
            {
                lblClientFullName.Text = $"ФИО: {clientData["FullName"]}";
                lblClientPhone.Text = $"Телефон: {clientData["Phone"]}";
                lblClientDateOfBirth.Text = $"Дата рождения: {clientData["DateOfBirth"]}";
            }
        }

        private void ClearClientDetails()
        {
            lblClientFullName.Text = "ФИО: ";
            lblClientPhone.Text = "Телефон: ";
            lblClientDateOfBirth.Text = "Дата рождения: ";
            pnlClientDetails.Visible = true;
        }

        private void txtSearchClient_TextChanged(object sender, EventArgs e)
        {
            LoadClients(txtSearchClient.Text, txtSearchPhone.Text);
        }

        private void txtSearchPhone_TextChanged(object sender, EventArgs e)
        {
            LoadClients(txtSearchClient.Text, txtSearchPhone.Text);
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            ClientsDetail clientDetail = new ClientsDetail(); 
            if (clientDetail.ShowDialog() == DialogResult.OK)
            {
                LoadClients(txtSearchClient.Text, txtSearchPhone.Text);
            }
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count > 0)
            {
                int clientId = Convert.ToInt32(dgvClients.SelectedRows[0].Cells["Id"].Value);
                ClientsDetail clientDetail = new ClientsDetail(clientId);
                if (clientDetail.ShowDialog() == DialogResult.OK)
                {
                    LoadClients(txtSearchClient.Text, txtSearchPhone.Text);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите клиента для редактирования.");
            }
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить этого клиента?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int clientId = Convert.ToInt32(dgvClients.SelectedRows[0].Cells["Id"].Value);
                    dbHelper.DeleteClient(clientId);
                    LoadClients(txtSearchClient.Text, txtSearchPhone.Text);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите клиента для удаления.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainMenu.Show();
        }
        private void btnSellAbonement_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count > 0)
            {
                int clientId = Convert.ToInt32(dgvClients.SelectedRows[0].Cells["Id"].Value);
                SellAbonementForm sellForm = new SellAbonementForm(clientId);
                if (sellForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Абонемент успешно продан!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayClientDetails(clientId);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите клиента для продажи абонемента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnShowClientHistory_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count > 0)
            {
                int clientId = Convert.ToInt32(dgvClients.SelectedRows[0].Cells["Id"].Value);
                ClientHistoryForm historyForm = new ClientHistoryForm(clientId);
                historyForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите клиента для просмотра истории абонементов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            if (UserSession.Role == "Coach")
            {
                btnAddClient.Visible = false;
                btnEditClient.Visible = false;
                btnDeleteClient.Visible = false;
            }
            LoadClients(); 
        }
    }
}
