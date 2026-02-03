using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PP
{
    public partial class PoolLoad : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private Menu _mainMenu;

        public PoolLoad(Menu mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;

            SetupDataGridView();
            LoadPoolAreasFilter();
            if (timerUpdateLoad == null) timerUpdateLoad = new System.Windows.Forms.Timer();

            timerUpdateLoad.Interval = 5000; // 5 секунд
            timerUpdateLoad.Tick -= timerUpdateLoad_Tick; 
            timerUpdateLoad.Tick += timerUpdateLoad_Tick;
            timerUpdateLoad.Start();

            this.FormClosing += PoolLoad_FormClosing;
        }

        private void SetupDataGridView()
        {
            dgvCurrentSessions.AutoGenerateColumns = false;
            dgvCurrentSessions.ReadOnly = true;
            dgvCurrentSessions.AllowUserToAddRows = false;
            dgvCurrentSessions.AllowUserToDeleteRows = false;
            dgvCurrentSessions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCurrentSessions.RowHeadersVisible = false;

            dgvCurrentSessions.Columns.Clear();

            dgvCurrentSessions.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ClientName",
                DataPropertyName = "ClientName",
                HeaderText = "Клиент",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCurrentSessions.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CoachName",
                DataPropertyName = "CoachName", 
                HeaderText = "Тренер",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCurrentSessions.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "StartTime",
                DataPropertyName = "StartTime",
                HeaderText = "Начало",
                Width = 80
            });

            dgvCurrentSessions.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "EndTime",
                DataPropertyName = "EndTime",
                HeaderText = "Окончание",
                Width = 80
            });

            dgvCurrentSessions.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "PoolArea",
                DataPropertyName = "PoolArea",
                HeaderText = "Зона",
                Width = 120
            });

            dgvCurrentSessions.EnableHeadersVisualStyles = false;
            dgvCurrentSessions.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
            dgvCurrentSessions.ColumnHeadersDefaultCellStyle.Font = new Font("Courier New", 10, FontStyle.Bold);
            dgvCurrentSessions.DefaultCellStyle.Font = new Font("Courier New", 10, FontStyle.Regular);
            dgvCurrentSessions.BackgroundColor = Color.White;
            dgvCurrentSessions.RowTemplate.Height = 30;
            dgvCurrentSessions.DefaultCellStyle.SelectionBackColor = Color.LightCyan;
            dgvCurrentSessions.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void LoadPoolAreasFilter()
        {
            try
            {
                DataTable dt = dbHelper.GetSchedule();
                var uniqueAreas = dt.AsEnumerable()
                                    .Where(row => !row.IsNull("PoolArea"))
                                    .Select(row => row.Field<string>("PoolArea"))
                                    .Where(a => !string.IsNullOrEmpty(a))
                                    .Distinct()
                                    .OrderBy(area => area)
                                    .ToList();

                cmbPoolAreaFilter.Items.Clear();
                cmbPoolAreaFilter.Items.Add("Все зоны");
                foreach (var area in uniqueAreas) cmbPoolAreaFilter.Items.Add(area);
                cmbPoolAreaFilter.SelectedIndex = 0;
            }
            catch { cmbPoolAreaFilter.Items.Add("Все зоны"); cmbPoolAreaFilter.SelectedIndex = 0; }
        }

        private void PoolLoad_Load(object sender, EventArgs e)
        {
            UpdatePoolLoadInfo();
        }

        private void timerUpdateLoad_Tick(object sender, EventArgs e)
        {
            UpdatePoolLoadInfo();
        }

        private void UpdatePoolLoadInfo()
        {
            lblCurrentTime.Text = "Текущее время: " + DateTime.Now.ToString("HH:mm:ss");

            string selectedPoolArea = cmbPoolAreaFilter.SelectedItem?.ToString();
            if (selectedPoolArea == "Все зоны") selectedPoolArea = "";
            DataTable currentSessions = dbHelper.GetCurrentPoolSessions(selectedPoolArea);
            dgvCurrentSessions.DataSource = currentSessions;

            lblActiveSessionsCount.Text = $"Активных сессий: {currentSessions.Rows.Count}";
            dgvCurrentSessions.ClearSelection();
        }

        private void dgvCurrentSessions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCurrentSessions.Rows[e.RowIndex].DataBoundItem != null)
            {
                var row = dgvCurrentSessions.Rows[e.RowIndex];

                string startStr = row.Cells["StartTime"].Value?.ToString();
                string endStr = row.Cells["EndTime"].Value?.ToString();
                string area = row.Cells["PoolArea"].Value?.ToString();

                if (string.IsNullOrEmpty(startStr) || string.IsNullOrEmpty(endStr)) return;

                if (DateTime.TryParse(startStr, out DateTime startT) && DateTime.TryParse(endStr, out DateTime endT))
                {
                    TimeSpan now = DateTime.Now.TimeOfDay;
                    TimeSpan start = startT.TimeOfDay;
                    TimeSpan end = endT.TimeOfDay;

                    if (now >= start && now <= end)
                    {
                        int countInZone = 0;
                        DataTable dt = (DataTable)dgvCurrentSessions.DataSource;
                        if (dt != null)
                        {
                            countInZone = dt.AsEnumerable().Count(r => r.Field<string>("PoolArea") == area);
                        }

                        if (countInZone > 5) // Макс вместимость
                        {
                            e.CellStyle.BackColor = Color.LightCoral;
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.LightGreen;
                        }
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.White;
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainMenu.Show();
        }

        private void PoolLoad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timerUpdateLoad != null)
            {
                timerUpdateLoad.Stop();
                timerUpdateLoad.Tick -= timerUpdateLoad_Tick;
            }
        }

        private void cmbPoolAreaFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePoolLoadInfo();
        }
    }
}

