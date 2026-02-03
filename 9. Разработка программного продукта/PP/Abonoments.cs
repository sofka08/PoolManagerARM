using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PP
{
    public partial class Abonements : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private Menu _mainMenu;

        public Abonements(Menu mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;
            SetupDataGridView();
            LoadAbonements();

            txtSearchAbonement.TextChanged += txtSearchAbonement_TextChanged; // Поиск по названию
        }

        private void SetupDataGridView()
        {
            dgvAbonements.AutoGenerateColumns = false;
            dgvAbonements.ReadOnly = true;
            dgvAbonements.AllowUserToAddRows = false;
            dgvAbonements.AllowUserToDeleteRows = false;
            dgvAbonements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAbonements.ColumnHeadersVisible = true;
            dgvAbonements.RowHeadersVisible = false;
            dgvAbonements.Columns.Clear();
            dgvAbonements.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvAbonements.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Name", DataPropertyName = "Name", HeaderText = "Название абонемента", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvAbonements.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Price", DataPropertyName = "Price", HeaderText = "Цена", Visible = false });
            dgvAbonements.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DurationDays", DataPropertyName = "DurationDays", HeaderText = "Дни", Visible = false });
            dgvAbonements.Columns.Add(new DataGridViewTextBoxColumn() { Name = "VisitsCount", DataPropertyName = "VisitsCount", HeaderText = "Посещения", Visible = false });
            dgvAbonements.RowHeadersVisible = false;
            dgvAbonements.EnableHeadersVisualStyles = false;
            dgvAbonements.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue; 
            dgvAbonements.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvAbonements.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 10, FontStyle.Bold);
            dgvAbonements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAbonements.BackgroundColor = Color.White;
            dgvAbonements.DefaultCellStyle.Font = new Font("Courier New", 10, FontStyle.Regular);
            dgvAbonements.RowTemplate.Height = 27;
            dgvAbonements.ClearSelection();
            dgvAbonements.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvAbonements.ColumnHeadersDefaultCellStyle.BackColor;
            dgvAbonements.DefaultCellStyle.SelectionBackColor = Color.LightCyan; 
            dgvAbonements.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void LoadAbonements(string searchTerm = "")
        {
            DataTable abonementsData = dbHelper.GetAbonements(searchTerm);
            dgvAbonements.DataSource = abonementsData;
            if (dgvAbonements.Columns.Contains("Id")) dgvAbonements.Columns["Id"].Visible = false;
            ClearAbonementDetails();
            if (abonementsData.Rows.Count > 0)
            {
                dgvAbonements.Rows[0].Selected = true;
                DisplayAbonementDetails(Convert.ToInt32(dgvAbonements.Rows[0].Cells["Id"].Value));
            }
        }

        private void dgvAbonements_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAbonements.SelectedRows.Count > 0)
            {
                int abonementId = Convert.ToInt32(dgvAbonements.SelectedRows[0].Cells["Id"].Value);
                DisplayAbonementDetails(abonementId);
            }
        }

        private void DisplayAbonementDetails(int abonementId)
        {
           DataRow abonementData = dbHelper.GetAbonementById(abonementId);
    if (abonementData != null)
    {
        lblAbonementName.Text = $"Название: {abonementData["Name"]}";
        lblAbonementPrice.Text = $"Цена: {Convert.ToDecimal(abonementData["Price"]):N2} ₽";
        lblAbonementDuration.Text = $"Срок действия: {abonementData["DurationDays"]} дней";
        lblAbonementVisits.Text = $"Посещений: {abonementData["VisitsCount"]}";
    }
        }

        private void ClearAbonementDetails()
        {
            lblAbonementName.Text = "Название: ";
            lblAbonementPrice.Text = "Цена: ";
            lblAbonementDuration.Text = "Срок действия: ";
            lblAbonementVisits.Text = "Посещений: ";
            pnlAbonomentDetails.Visible = true;
        }

        private void txtSearchAbonement_TextChanged(object sender, EventArgs e)
        {
            LoadAbonements(txtSearchAbonement.Text);
        }

        private void btnAddAbonement_Click(object sender, EventArgs e)
        {
            AbonementDetailForm abonementDetail = new AbonementDetailForm();
            if (abonementDetail.ShowDialog() == DialogResult.OK)
            {
                LoadAbonements(txtSearchAbonement.Text);
            }
        }

        private void btnEditAbonement_Click(object sender, EventArgs e)
        {
            if (dgvAbonements.SelectedRows.Count > 0)
            {
                int abonementId = Convert.ToInt32(dgvAbonements.SelectedRows[0].Cells["Id"].Value);
                AbonementDetailForm abonementDetail = new AbonementDetailForm(abonementId);
                if (abonementDetail.ShowDialog() == DialogResult.OK)
                {
                    LoadAbonements(txtSearchAbonement.Text);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите абонемент для редактирования.");
            }
        }

        private void btnDeleteAbonement_Click(object sender, EventArgs e)
        {
            if (dgvAbonements.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить этот абонемент?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int abonementId = Convert.ToInt32(dgvAbonements.SelectedRows[0].Cells["Id"].Value);
                    dbHelper.DeleteAbonement(abonementId);
                    LoadAbonements(txtSearchAbonement.Text);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите абонемент для удаления.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainMenu.Show();
        }

        private void pnlAbonomentDetails_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Abonements_Load(object sender, EventArgs e)
        {
            if (UserSession.Role == "Coach")
            {
                btnAddAbonement.Visible = false;
                btnEditAbonoment.Visible = false;
                btnDeleteAbonoment.Visible = false;
            }
            LoadAbonements();
        }
    }
}
