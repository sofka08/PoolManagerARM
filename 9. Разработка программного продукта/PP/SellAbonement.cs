using System;
using System.Data;
using System.Windows.Forms;

namespace PP
{
    public partial class SellAbonementForm : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private int _clientId;

        public SellAbonementForm(int clientId)
        {
            InitializeComponent();
            _clientId = clientId;
            LoadClientInfo();
            LoadAbonementTemplates();
            dtpPurchaseDate.Value = DateTime.Today; 
            UpdateExpiryDate(); 
        }

        private void LoadClientInfo()
        {
            DataRow client = dbHelper.GetClientById(_clientId);
            if (client != null)
            {
                lblClientName.Text = $"Клиент: {client["FullName"]}"; 
            }
            else
            {
                lblClientName.Text = "Клиент не найден.";
            }
        }

        private void LoadAbonementTemplates()
        {
            DataTable templates = dbHelper.GetAbonementTemplatesForDropdown();
            cmbAbonementTemplate.DataSource = templates;
            cmbAbonementTemplate.DisplayMember = "Name";
            cmbAbonementTemplate.ValueMember = "Id";
            cmbAbonementTemplate.SelectedIndex = -1; 
            cmbAbonementTemplate.SelectedIndexChanged += CmbAbonementTemplate_SelectedIndexChanged;
        }

        private void CmbAbonementTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateExpiryDate();
        }

        private void UpdateExpiryDate()
        {
            if (cmbAbonementTemplate.SelectedValue != null && cmbAbonementTemplate.SelectedValue != DBNull.Value)
            {
                DataRowView selectedTemplate = (DataRowView)cmbAbonementTemplate.SelectedItem;
                int durationDays = Convert.ToInt32(selectedTemplate["DurationDays"]);
                int visitsCount = Convert.ToInt32(selectedTemplate["VisitsCount"]);
                decimal price = Convert.ToDecimal(selectedTemplate["Price"]);

                DateTime purchaseDate = dtpPurchaseDate.Value;
                DateTime expiryDate = purchaseDate.AddDays(durationDays);

                lblExpiryDate.Text = $"Действует до: {expiryDate.ToString("dd.MM.yyyy")}";
                lblVisitsInfo.Text = $"Посещений в шаблоне: {visitsCount}"; 
                lblPrice.Text = $"Цена: {price:C2}"; 
            }
            else
            {
                lblExpiryDate.Text = "Действует до: Не выбрано";
                lblVisitsInfo.Text = "Посещений: Не выбрано";
                lblPrice.Text = "Цена: ";
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            if (cmbAbonementTemplate.SelectedValue == null || cmbAbonementTemplate.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Пожалуйста, выберите тип абонемента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем, есть ли у клиента уже активные подписки
            DataTable activeSubs = dbHelper.GetActiveClientSubscriptions(_clientId);
            if (activeSubs != null && activeSubs.Rows.Count > 0)
            {
                MessageBox.Show("У клиента уже есть действующий абонемент. Нельзя оформить второй, пока не истечет срок текущего.",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            int abonementTemplateId = Convert.ToInt32(cmbAbonementTemplate.SelectedValue);
            DataRowView selectedTemplate = (DataRowView)cmbAbonementTemplate.SelectedItem;
            int initialVisits = Convert.ToInt32(selectedTemplate["VisitsCount"]);
            int durationDays = Convert.ToInt32(selectedTemplate["DurationDays"]);

            string purchaseDate = dtpPurchaseDate.Value.ToString("yyyy-MM-dd");
            string expiryDate = dtpPurchaseDate.Value.AddDays(durationDays).ToString("yyyy-MM-dd");

            int result = dbHelper.AddClientSubscription(_clientId, abonementTemplateId, purchaseDate, expiryDate, initialVisits);

            if (result > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при продаже абонемента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dtpPurchaseDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateExpiryDate(); 
        }
    }
}
