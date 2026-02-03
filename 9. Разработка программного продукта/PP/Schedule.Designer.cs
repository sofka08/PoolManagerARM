namespace PP
{
    partial class Schedule
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
            this.pnlScheduleDetails = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPoolArea = new System.Windows.Forms.Label();
            this.lbl_Client = new System.Windows.Forms.Label();
            this.lblScheduleTime = new System.Windows.Forms.Label();
            this.lblCoachFullName = new System.Windows.Forms.Label();
            this.lblClientFullName = new System.Windows.Forms.Label();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.btnDeleteSchedule = new System.Windows.Forms.Button();
            this.btnEditSchedule = new System.Windows.Forms.Button();
            this.pnlScheduleDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlScheduleDetails
            // 
            this.pnlScheduleDetails.BackColor = System.Drawing.Color.Transparent;
            this.pnlScheduleDetails.Controls.Add(this.lblStatus);
            this.pnlScheduleDetails.Controls.Add(this.lblPoolArea);
            this.pnlScheduleDetails.Controls.Add(this.lbl_Client);
            this.pnlScheduleDetails.Controls.Add(this.lblScheduleTime);
            this.pnlScheduleDetails.Controls.Add(this.lblCoachFullName);
            this.pnlScheduleDetails.Controls.Add(this.lblClientFullName);
            this.pnlScheduleDetails.Location = new System.Drawing.Point(783, 9);
            this.pnlScheduleDetails.Name = "pnlScheduleDetails";
            this.pnlScheduleDetails.Size = new System.Drawing.Size(55, 21);
            this.pnlScheduleDetails.TabIndex = 40;
            this.pnlScheduleDetails.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Ink Free", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.ForeColor = System.Drawing.Color.Navy;
            this.lblStatus.Location = new System.Drawing.Point(3, 178);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(57, 22);
            this.lblStatus.TabIndex = 30;
            this.lblStatus.Text = "label2";
            // 
            // lblPoolArea
            // 
            this.lblPoolArea.AutoSize = true;
            this.lblPoolArea.Font = new System.Drawing.Font("Ink Free", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPoolArea.ForeColor = System.Drawing.Color.Navy;
            this.lblPoolArea.Location = new System.Drawing.Point(3, 146);
            this.lblPoolArea.Name = "lblPoolArea";
            this.lblPoolArea.Size = new System.Drawing.Size(57, 22);
            this.lblPoolArea.TabIndex = 29;
            this.lblPoolArea.Text = "label2";
            // 
            // lbl_Client
            // 
            this.lbl_Client.AutoSize = true;
            this.lbl_Client.Font = new System.Drawing.Font("Ink Free", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Client.ForeColor = System.Drawing.Color.Navy;
            this.lbl_Client.Location = new System.Drawing.Point(91, 9);
            this.lbl_Client.Name = "lbl_Client";
            this.lbl_Client.Size = new System.Drawing.Size(92, 29);
            this.lbl_Client.TabIndex = 3;
            this.lbl_Client.Text = "Детали";
            // 
            // lblScheduleTime
            // 
            this.lblScheduleTime.AutoSize = true;
            this.lblScheduleTime.Font = new System.Drawing.Font("Ink Free", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScheduleTime.ForeColor = System.Drawing.Color.Navy;
            this.lblScheduleTime.Location = new System.Drawing.Point(3, 116);
            this.lblScheduleTime.Name = "lblScheduleTime";
            this.lblScheduleTime.Size = new System.Drawing.Size(57, 22);
            this.lblScheduleTime.TabIndex = 2;
            this.lblScheduleTime.Text = "label2";
            // 
            // lblCoachFullName
            // 
            this.lblCoachFullName.AutoSize = true;
            this.lblCoachFullName.Font = new System.Drawing.Font("Ink Free", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCoachFullName.ForeColor = System.Drawing.Color.Navy;
            this.lblCoachFullName.Location = new System.Drawing.Point(3, 86);
            this.lblCoachFullName.Name = "lblCoachFullName";
            this.lblCoachFullName.Size = new System.Drawing.Size(57, 22);
            this.lblCoachFullName.TabIndex = 1;
            this.lblCoachFullName.Text = "label2";
            // 
            // lblClientFullName
            // 
            this.lblClientFullName.AutoSize = true;
            this.lblClientFullName.Font = new System.Drawing.Font("Ink Free", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblClientFullName.ForeColor = System.Drawing.Color.Navy;
            this.lblClientFullName.Location = new System.Drawing.Point(3, 56);
            this.lblClientFullName.Name = "lblClientFullName";
            this.lblClientFullName.Size = new System.Drawing.Size(57, 22);
            this.lblClientFullName.TabIndex = 0;
            this.lblClientFullName.Text = "label2";
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Location = new System.Drawing.Point(227, 67);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.RowHeadersWidth = 51;
            this.dgvSchedule.RowTemplate.Height = 24;
            this.dgvSchedule.Size = new System.Drawing.Size(541, 276);
            this.dgvSchedule.TabIndex = 37;
            this.dgvSchedule.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSchedule_CellFormatting);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monthCalendar1.Location = new System.Drawing.Point(8, 67);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 36;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Navy;
            this.btnCancel.Location = new System.Drawing.Point(-7, -3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 33);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Назад";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(284, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 40);
            this.label1.TabIndex = 34;
            this.label1.Text = "Расписание";
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.BackColor = System.Drawing.Color.PowderBlue;
            this.btnAddSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddSchedule.Font = new System.Drawing.Font("Courier New", 10.2F);
            this.btnAddSchedule.ForeColor = System.Drawing.Color.Navy;
            this.btnAddSchedule.Location = new System.Drawing.Point(8, 286);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(192, 57);
            this.btnAddSchedule.TabIndex = 41;
            this.btnAddSchedule.Text = "Добавить новую \r\nзапись";
            this.btnAddSchedule.UseVisualStyleBackColor = false;
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddScheduleEntry_Click);
            // 
            // btnDeleteSchedule
            // 
            this.btnDeleteSchedule.BackColor = System.Drawing.Color.PowderBlue;
            this.btnDeleteSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteSchedule.Font = new System.Drawing.Font("Courier New", 10.2F);
            this.btnDeleteSchedule.ForeColor = System.Drawing.Color.Navy;
            this.btnDeleteSchedule.Location = new System.Drawing.Point(501, 349);
            this.btnDeleteSchedule.Name = "btnDeleteSchedule";
            this.btnDeleteSchedule.Size = new System.Drawing.Size(267, 33);
            this.btnDeleteSchedule.TabIndex = 39;
            this.btnDeleteSchedule.Text = "Удалить";
            this.btnDeleteSchedule.UseVisualStyleBackColor = false;
            this.btnDeleteSchedule.Click += new System.EventHandler(this.btnDeleteScheduleEntry_Click);
            // 
            // btnEditSchedule
            // 
            this.btnEditSchedule.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEditSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditSchedule.Font = new System.Drawing.Font("Courier New", 10.2F);
            this.btnEditSchedule.ForeColor = System.Drawing.Color.Navy;
            this.btnEditSchedule.Location = new System.Drawing.Point(227, 349);
            this.btnEditSchedule.Name = "btnEditSchedule";
            this.btnEditSchedule.Size = new System.Drawing.Size(267, 33);
            this.btnEditSchedule.TabIndex = 38;
            this.btnEditSchedule.Text = "Редактировать";
            this.btnEditSchedule.UseVisualStyleBackColor = false;
            this.btnEditSchedule.Click += new System.EventHandler(this.btnEditScheduleEntry_Click);
            // 
            // Schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PP.Properties.Resources.вод;
            this.ClientSize = new System.Drawing.Size(778, 405);
            this.Controls.Add(this.pnlScheduleDetails);
            this.Controls.Add(this.dgvSchedule);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddSchedule);
            this.Controls.Add(this.btnDeleteSchedule);
            this.Controls.Add(this.btnEditSchedule);
            this.Name = "Schedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule";
            this.pnlScheduleDetails.ResumeLayout(false);
            this.pnlScheduleDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlScheduleDetails;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPoolArea;
        private System.Windows.Forms.Label lbl_Client;
        private System.Windows.Forms.Label lblScheduleTime;
        private System.Windows.Forms.Label lblCoachFullName;
        private System.Windows.Forms.Label lblClientFullName;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Button btnDeleteSchedule;
        private System.Windows.Forms.Button btnEditSchedule;
    }
}