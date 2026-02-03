#pragma warning disable 618 // Отключаем предупреждения о устаревших методах, если они есть

namespace PP
{
    partial class Statistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.lblTodaySessions = new System.Windows.Forms.Label();
            this.lblApproxIncome = new System.Windows.Forms.Label();
            this.lblConductedSessions = new System.Windows.Forms.Label();
            this.lblNewClientsMonth = new System.Windows.Forms.Label();
            this.lblTotalClients = new System.Windows.Forms.Label();
            this.lblTomorrowSessions = new System.Windows.Forms.Label();
            this.lblTopTrainer = new System.Windows.Forms.Label();
            this.lblMostPopularAbonement = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMainTitle.Font = new System.Drawing.Font("Verdana", 18.2F, System.Drawing.FontStyle.Bold);
            this.lblMainTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblMainTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMainTitle.Location = new System.Drawing.Point(258, 20);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(232, 38);
            this.lblMainTitle.TabIndex = 30;
            this.lblMainTitle.Text = "Статистика";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.Navy;
            this.btnBack.Location = new System.Drawing.Point(-7, -3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(94, 33);
            this.btnBack.TabIndex = 31;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CalendarFont = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpStartDate.Font = new System.Drawing.Font("Courier New", 8.8F);
            this.dtpStartDate.Location = new System.Drawing.Point(12, 92);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(262, 24);
            this.dtpStartDate.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Courier New", 10.2F);
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(8, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 20);
            this.label5.TabIndex = 78;
            this.label5.Text = "начало периода:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Courier New", 10.2F);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(8, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 79;
            this.label2.Text = "конец периода:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CalendarFont = new System.Drawing.Font("Courier New", 12.2F);
            this.dtpEndDate.Font = new System.Drawing.Font("Courier New", 8.8F);
            this.dtpEndDate.Location = new System.Drawing.Point(12, 142);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(262, 24);
            this.dtpEndDate.TabIndex = 34;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.BackColor = System.Drawing.Color.PowderBlue;
            this.btnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApplyFilter.Font = new System.Drawing.Font("Courier New", 10.2F);
            this.btnApplyFilter.ForeColor = System.Drawing.Color.Navy;
            this.btnApplyFilter.Location = new System.Drawing.Point(12, 174);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(262, 37);
            this.btnApplyFilter.TabIndex = 80;
            this.btnApplyFilter.Text = "Применить фильтр";
            this.btnApplyFilter.UseVisualStyleBackColor = false;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // lblTodaySessions
            // 
            this.lblTodaySessions.AutoSize = true;
            this.lblTodaySessions.BackColor = System.Drawing.Color.Transparent;
            this.lblTodaySessions.Font = new System.Drawing.Font("Courier New", 10.8F);
            this.lblTodaySessions.ForeColor = System.Drawing.Color.Black;
            this.lblTodaySessions.Location = new System.Drawing.Point(307, 144);
            this.lblTodaySessions.Name = "lblTodaySessions";
            this.lblTodaySessions.Size = new System.Drawing.Size(218, 20);
            this.lblTodaySessions.TabIndex = 6;
            this.lblTodaySessions.Text = "Записей на сегодня:";
            // 
            // lblApproxIncome
            // 
            this.lblApproxIncome.AutoSize = true;
            this.lblApproxIncome.BackColor = System.Drawing.Color.Transparent;
            this.lblApproxIncome.Font = new System.Drawing.Font("Courier New", 10.8F);
            this.lblApproxIncome.ForeColor = System.Drawing.Color.Black;
            this.lblApproxIncome.Location = new System.Drawing.Point(305, 192);
            this.lblApproxIncome.Name = "lblApproxIncome";
            this.lblApproxIncome.Size = new System.Drawing.Size(185, 20);
            this.lblApproxIncome.TabIndex = 7;
            this.lblApproxIncome.Text = "Расчётный доход:";
            // 
            // lblConductedSessions
            // 
            this.lblConductedSessions.AutoSize = true;
            this.lblConductedSessions.BackColor = System.Drawing.Color.Transparent;
            this.lblConductedSessions.Font = new System.Drawing.Font("Courier New", 10.8F);
            this.lblConductedSessions.ForeColor = System.Drawing.Color.Black;
            this.lblConductedSessions.Location = new System.Drawing.Point(307, 120);
            this.lblConductedSessions.Name = "lblConductedSessions";
            this.lblConductedSessions.Size = new System.Drawing.Size(196, 20);
            this.lblConductedSessions.TabIndex = 5;
            this.lblConductedSessions.Text = "Занятий за месяц:";
            // 
            // lblNewClientsMonth
            // 
            this.lblNewClientsMonth.AutoSize = true;
            this.lblNewClientsMonth.BackColor = System.Drawing.Color.Transparent;
            this.lblNewClientsMonth.Font = new System.Drawing.Font("Courier New", 10.8F);
            this.lblNewClientsMonth.ForeColor = System.Drawing.Color.Black;
            this.lblNewClientsMonth.Location = new System.Drawing.Point(307, 96);
            this.lblNewClientsMonth.Name = "lblNewClientsMonth";
            this.lblNewClientsMonth.Size = new System.Drawing.Size(262, 20);
            this.lblNewClientsMonth.TabIndex = 81;
            this.lblNewClientsMonth.Text = "Новые клиенты за месяц:";
            // 
            // lblTotalClients
            // 
            this.lblTotalClients.AutoSize = true;
            this.lblTotalClients.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalClients.Font = new System.Drawing.Font("Courier New", 10.8F);
            this.lblTotalClients.ForeColor = System.Drawing.Color.Black;
            this.lblTotalClients.Location = new System.Drawing.Point(306, 74);
            this.lblTotalClients.Name = "lblTotalClients";
            this.lblTotalClients.Size = new System.Drawing.Size(174, 20);
            this.lblTotalClients.TabIndex = 4;
            this.lblTotalClients.Text = "Всего клиентов:";
            // 
            // lblTomorrowSessions
            // 
            this.lblTomorrowSessions.AutoSize = true;
            this.lblTomorrowSessions.BackColor = System.Drawing.Color.Transparent;
            this.lblTomorrowSessions.Font = new System.Drawing.Font("Courier New", 10.8F);
            this.lblTomorrowSessions.ForeColor = System.Drawing.Color.Black;
            this.lblTomorrowSessions.Location = new System.Drawing.Point(307, 168);
            this.lblTomorrowSessions.Name = "lblTomorrowSessions";
            this.lblTomorrowSessions.Size = new System.Drawing.Size(207, 20);
            this.lblTomorrowSessions.TabIndex = 83;
            this.lblTomorrowSessions.Text = "Записей на завтра:";
            // 
            // lblTopTrainer
            // 
            this.lblTopTrainer.AutoSize = true;
            this.lblTopTrainer.BackColor = System.Drawing.Color.Transparent;
            this.lblTopTrainer.Font = new System.Drawing.Font("Courier New", 10.8F);
            this.lblTopTrainer.ForeColor = System.Drawing.Color.Black;
            this.lblTopTrainer.Location = new System.Drawing.Point(8, 229);
            this.lblTopTrainer.Name = "lblTopTrainer";
            this.lblTopTrainer.Size = new System.Drawing.Size(251, 20);
            this.lblTopTrainer.TabIndex = 84;
            this.lblTopTrainer.Text = "Востребованный тренер:";
            // 
            // lblMostPopularAbonement
            // 
            this.lblMostPopularAbonement.AutoSize = true;
            this.lblMostPopularAbonement.BackColor = System.Drawing.Color.Transparent;
            this.lblMostPopularAbonement.Font = new System.Drawing.Font("Courier New", 10.8F);
            this.lblMostPopularAbonement.ForeColor = System.Drawing.Color.Black;
            this.lblMostPopularAbonement.Location = new System.Drawing.Point(8, 258);
            this.lblMostPopularAbonement.Name = "lblMostPopularAbonement";
            this.lblMostPopularAbonement.Size = new System.Drawing.Size(317, 20);
            this.lblMostPopularAbonement.TabIndex = 85;
            this.lblMostPopularAbonement.Text = "Самый продаваемый абонемент:";
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = global::PP.Properties.Resources.вод;
            this.ClientSize = new System.Drawing.Size(732, 304);
            this.Controls.Add(this.lblMostPopularAbonement);
            this.Controls.Add(this.lblTopTrainer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnApplyFilter);
            this.Controls.Add(this.lblTomorrowSessions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblTotalClients);
            this.Controls.Add(this.lblNewClientsMonth);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblConductedSessions);
            this.Controls.Add(this.lblMainTitle);
            this.Controls.Add(this.lblApproxIncome);
            this.Controls.Add(this.lblTodaySessions);
            this.Name = "Statistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Статистика";
            this.Load += new System.EventHandler(this.Statistics_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Label lblTodaySessions;
        private System.Windows.Forms.Label lblApproxIncome;
        private System.Windows.Forms.Label lblConductedSessions;
        private System.Windows.Forms.Label lblNewClientsMonth;
        private System.Windows.Forms.Label lblTotalClients;
        private System.Windows.Forms.Label lblTomorrowSessions;
        private System.Windows.Forms.Label lblTopTrainer;
        private System.Windows.Forms.Label lblMostPopularAbonement;
    }
}
