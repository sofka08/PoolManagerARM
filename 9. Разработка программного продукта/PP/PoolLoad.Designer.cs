namespace PP
{
    partial class PoolLoad
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
            this.dgvCurrentSessions = new System.Windows.Forms.DataGridView();
            this.lblActiveSessionsCount = new System.Windows.Forms.Label();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPoolAreaFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentSessions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCurrentSessions
            // 
            this.dgvCurrentSessions.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvCurrentSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentSessions.Location = new System.Drawing.Point(46, 102);
            this.dgvCurrentSessions.Name = "dgvCurrentSessions";
            this.dgvCurrentSessions.RowHeadersWidth = 51;
            this.dgvCurrentSessions.RowTemplate.Height = 24;
            this.dgvCurrentSessions.Size = new System.Drawing.Size(661, 210);
            this.dgvCurrentSessions.TabIndex = 32;
            // 
            // lblActiveSessionsCount
            // 
            this.lblActiveSessionsCount.AutoSize = true;
            this.lblActiveSessionsCount.BackColor = System.Drawing.Color.Transparent;
            this.lblActiveSessionsCount.Font = new System.Drawing.Font("Courier New", 10.8F);
            this.lblActiveSessionsCount.ForeColor = System.Drawing.Color.Navy;
            this.lblActiveSessionsCount.Location = new System.Drawing.Point(42, 388);
            this.lblActiveSessionsCount.Name = "lblActiveSessionsCount";
            this.lblActiveSessionsCount.Size = new System.Drawing.Size(75, 20);
            this.lblActiveSessionsCount.TabIndex = 31;
            this.lblActiveSessionsCount.Text = "label2";
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentTime.Font = new System.Drawing.Font("Courier New", 16.8F);
            this.lblCurrentTime.ForeColor = System.Drawing.Color.Navy;
            this.lblCurrentTime.Location = new System.Drawing.Point(40, 59);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(116, 31);
            this.lblCurrentTime.TabIndex = 30;
            this.lblCurrentTime.Text = "label1";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.Navy;
            this.btnBack.Location = new System.Drawing.Point(-1, -3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(94, 33);
            this.btnBack.TabIndex = 29;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 18.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(204, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 38);
            this.label1.TabIndex = 28;
            this.label1.Text = "Загрузка бассейна";
            // 
            // cmbPoolAreaFilter
            // 
            this.cmbPoolAreaFilter.Font = new System.Drawing.Font("Courier New", 10.2F);
            this.cmbPoolAreaFilter.FormattingEnabled = true;
            this.cmbPoolAreaFilter.Location = new System.Drawing.Point(46, 347);
            this.cmbPoolAreaFilter.Name = "cmbPoolAreaFilter";
            this.cmbPoolAreaFilter.Size = new System.Drawing.Size(661, 28);
            this.cmbPoolAreaFilter.TabIndex = 82;
            this.cmbPoolAreaFilter.SelectedIndexChanged += new System.EventHandler(this.cmbPoolAreaFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Courier New", 10.8F);
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(42, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 20);
            this.label3.TabIndex = 83;
            this.label3.Text = "Фильтр по зоне:";
            // 
            // PoolLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PP.Properties.Resources.вод;
            this.ClientSize = new System.Drawing.Size(737, 431);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPoolAreaFilter);
            this.Controls.Add(this.dgvCurrentSessions);
            this.Controls.Add(this.lblActiveSessionsCount);
            this.Controls.Add(this.lblCurrentTime);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Name = "PoolLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PoolLoad";
            this.Load += new System.EventHandler(this.PoolLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentSessions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCurrentSessions;
        private System.Windows.Forms.Label lblActiveSessionsCount;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerUpdateLoad;
        private System.Windows.Forms.ComboBox cmbPoolAreaFilter;
        private System.Windows.Forms.Label label3;
    }
}