using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PP
{
    public partial class ClientHistoryForm : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private int _clientId;

        public ClientHistoryForm(int clientId)
        {
            InitializeComponent();
            _clientId = clientId;
            LoadClientInfo();
            SetupDataGridView();
            LoadClientSubscriptionsHistory();
        }
        private void LoadClientInfo()
        {
            DataRow client = dbHelper.GetClientById(_clientId);
            if (client != null)
            {
                this.Text = $"История абонементов клиента: {client["FullName"]}"; 
                lblClientName.Text = $"Клиент: {client["FullName"]}"; 
            }
            else
            {
                this.Text = "История абонементов";
                lblClientName.Text = "Клиент не найден.";
            }
        }

        private void SetupDataGridView()
        {
            dgvSubscriptionsHistory.DataSource = dbHelper.GetClientSubscriptionsHistory(_clientId);
            dgvSubscriptionsHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSubscriptionsHistory.RowHeadersVisible = false; 
            dgvSubscriptionsHistory.AllowUserToAddRows = false;
            dgvSubscriptionsHistory.RowHeadersVisible = false;
            dgvSubscriptionsHistory.EnableHeadersVisualStyles = false;
            dgvSubscriptionsHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue; 
            dgvSubscriptionsHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvSubscriptionsHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 10, FontStyle.Bold);
            dgvSubscriptionsHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubscriptionsHistory.BackgroundColor = Color.White;
            dgvSubscriptionsHistory.DefaultCellStyle.Font = new Font("Courier New", 10, FontStyle.Regular);
            dgvSubscriptionsHistory.RowTemplate.Height = 27;
            dgvSubscriptionsHistory.ClearSelection();
            dgvSubscriptionsHistory.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvSubscriptionsHistory.ColumnHeadersDefaultCellStyle.BackColor;
            dgvSubscriptionsHistory.DefaultCellStyle.SelectionBackColor = Color.LightCyan;
            dgvSubscriptionsHistory.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void LoadClientSubscriptionsHistory()
        {
            DataTable history = dbHelper.GetClientSubscriptionsHistory(_clientId);
            dgvSubscriptionsHistory.DataSource = history;
            if (dgvSubscriptionsHistory.Columns.Contains("Id")) dgvSubscriptionsHistory.Columns["Id"].Visible = false;
            if (dgvSubscriptionsHistory.Columns.Contains("AbonementName")) dgvSubscriptionsHistory.Columns["AbonementName"].HeaderText = "Тип абонемента";
            if (dgvSubscriptionsHistory.Columns.Contains("PurchaseDate")) dgvSubscriptionsHistory.Columns["PurchaseDate"].HeaderText = "Дата покупки";
            if (dgvSubscriptionsHistory.Columns.Contains("ExpiryDate")) dgvSubscriptionsHistory.Columns["ExpiryDate"].HeaderText = "Истекает";
            if (dgvSubscriptionsHistory.Columns.Contains("RemainingVisits")) dgvSubscriptionsHistory.Columns["RemainingVisits"].HeaderText = "Остаток визитов";
            if (dgvSubscriptionsHistory.Columns.Contains("Status")) dgvSubscriptionsHistory.Columns["Status"].HeaderText = "Статус";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
