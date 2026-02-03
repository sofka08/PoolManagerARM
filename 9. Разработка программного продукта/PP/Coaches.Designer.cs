namespace PP
{
    partial class Coaches
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
            this.pnlCoachDetails = new System.Windows.Forms.Panel();
            this.btnShowCoachSchedule = new System.Windows.Forms.Button();
            this.lblCoachPhone = new System.Windows.Forms.Label();
            this.lblCoachExperienceYears = new System.Windows.Forms.Label();
            this.lbl_Client = new System.Windows.Forms.Label();
            this.lblCoachDateOfBirth = new System.Windows.Forms.Label();
            this.lblCoachSpecialization = new System.Windows.Forms.Label();
            this.lblCoachFullName = new System.Windows.Forms.Label();
            this.btnDeleteCoach = new System.Windows.Forms.Button();
            this.btnEditCoach = new System.Windows.Forms.Button();
            this.dgvCoaches = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddCoach = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchPhone = new System.Windows.Forms.TextBox();
            this.txtSearchCoach = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlCoachDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoaches)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCoachDetails
            // 
            this.pnlCoachDetails.BackColor = System.Drawing.Color.White;
            this.pnlCoachDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCoachDetails.Controls.Add(this.btnShowCoachSchedule);
            this.pnlCoachDetails.Controls.Add(this.lblCoachPhone);
            this.pnlCoachDetails.Controls.Add(this.lblCoachExperienceYears);
            this.pnlCoachDetails.Controls.Add(this.lbl_Client);
            this.pnlCoachDetails.Controls.Add(this.lblCoachDateOfBirth);
            this.pnlCoachDetails.Controls.Add(this.lblCoachSpecialization);
            this.pnlCoachDetails.Controls.Add(this.lblCoachFullName);
            this.pnlCoachDetails.Location = new System.Drawing.Point(314, 71);
            this.pnlCoachDetails.Name = "pnlCoachDetails";
            this.pnlCoachDetails.Size = new System.Drawing.Size(415, 272);
            this.pnlCoachDetails.TabIndex = 40;
            this.pnlCoachDetails.Visible = false;
            // 
            // btnShowCoachSchedule
            // 
            this.btnShowCoachSchedule.BackColor = System.Drawing.Color.Transparent;
            this.btnShowCoachSchedule.FlatAppearance.BorderSize = 0;
            this.btnShowCoachSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowCoachSchedule.Font = new System.Drawing.Font("Courier New", 9.2F);
            this.btnShowCoachSchedule.ForeColor = System.Drawing.Color.IndianRed;
            this.btnShowCoachSchedule.Location = new System.Drawing.Point(-1, 214);
            this.btnShowCoachSchedule.Name = "btnShowCoachSchedule";
            this.btnShowCoachSchedule.Size = new System.Drawing.Size(226, 39);
            this.btnShowCoachSchedule.TabIndex = 43;
            this.btnShowCoachSchedule.Text = "График работы";
            this.btnShowCoachSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowCoachSchedule.UseVisualStyleBackColor = false;
            this.btnShowCoachSchedule.Click += new System.EventHandler(this.btnShowCoachSchedule_Click);
            // 
            // lblCoachPhone
            // 
            this.lblCoachPhone.AutoSize = true;
            this.lblCoachPhone.Font = new System.Drawing.Font("Courier New", 9.8F);
            this.lblCoachPhone.ForeColor = System.Drawing.Color.Navy;
            this.lblCoachPhone.Location = new System.Drawing.Point(3, 93);
            this.lblCoachPhone.Name = "lblCoachPhone";
            this.lblCoachPhone.Size = new System.Drawing.Size(69, 20);
            this.lblCoachPhone.TabIndex = 30;
            this.lblCoachPhone.Text = "label2";
            // 
            // lblCoachExperienceYears
            // 
            this.lblCoachExperienceYears.AutoSize = true;
            this.lblCoachExperienceYears.Font = new System.Drawing.Font("Courier New", 9.8F);
            this.lblCoachExperienceYears.ForeColor = System.Drawing.Color.Navy;
            this.lblCoachExperienceYears.Location = new System.Drawing.Point(3, 191);
            this.lblCoachExperienceYears.Name = "lblCoachExperienceYears";
            this.lblCoachExperienceYears.Size = new System.Drawing.Size(69, 20);
            this.lblCoachExperienceYears.TabIndex = 29;
            this.lblCoachExperienceYears.Text = "label5";
            // 
            // lbl_Client
            // 
            this.lbl_Client.AutoSize = true;
            this.lbl_Client.Font = new System.Drawing.Font("Courier New", 15.8F, System.Drawing.FontStyle.Bold);
            this.lbl_Client.ForeColor = System.Drawing.Color.Navy;
            this.lbl_Client.Location = new System.Drawing.Point(83, 16);
            this.lbl_Client.Name = "lbl_Client";
            this.lbl_Client.Size = new System.Drawing.Size(238, 31);
            this.lbl_Client.TabIndex = 3;
            this.lbl_Client.Text = "Детали тренера";
            // 
            // lblCoachDateOfBirth
            // 
            this.lblCoachDateOfBirth.AutoSize = true;
            this.lblCoachDateOfBirth.Font = new System.Drawing.Font("Courier New", 9.8F);
            this.lblCoachDateOfBirth.ForeColor = System.Drawing.Color.Navy;
            this.lblCoachDateOfBirth.Location = new System.Drawing.Point(3, 158);
            this.lblCoachDateOfBirth.Name = "lblCoachDateOfBirth";
            this.lblCoachDateOfBirth.Size = new System.Drawing.Size(69, 20);
            this.lblCoachDateOfBirth.TabIndex = 2;
            this.lblCoachDateOfBirth.Text = "label4";
            // 
            // lblCoachSpecialization
            // 
            this.lblCoachSpecialization.AutoSize = true;
            this.lblCoachSpecialization.Font = new System.Drawing.Font("Courier New", 9.8F);
            this.lblCoachSpecialization.ForeColor = System.Drawing.Color.Navy;
            this.lblCoachSpecialization.Location = new System.Drawing.Point(3, 125);
            this.lblCoachSpecialization.Name = "lblCoachSpecialization";
            this.lblCoachSpecialization.Size = new System.Drawing.Size(69, 20);
            this.lblCoachSpecialization.TabIndex = 1;
            this.lblCoachSpecialization.Text = "label3";
            // 
            // lblCoachFullName
            // 
            this.lblCoachFullName.AutoSize = true;
            this.lblCoachFullName.Font = new System.Drawing.Font("Courier New", 9.8F);
            this.lblCoachFullName.ForeColor = System.Drawing.Color.Navy;
            this.lblCoachFullName.Location = new System.Drawing.Point(3, 62);
            this.lblCoachFullName.Name = "lblCoachFullName";
            this.lblCoachFullName.Size = new System.Drawing.Size(69, 20);
            this.lblCoachFullName.TabIndex = 0;
            this.lblCoachFullName.Text = "label1";
            // 
            // btnDeleteCoach
            // 
            this.btnDeleteCoach.BackColor = System.Drawing.Color.PowderBlue;
            this.btnDeleteCoach.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteCoach.Font = new System.Drawing.Font("Courier New", 9.2F);
            this.btnDeleteCoach.ForeColor = System.Drawing.Color.Navy;
            this.btnDeleteCoach.Location = new System.Drawing.Point(527, 349);
            this.btnDeleteCoach.Name = "btnDeleteCoach";
            this.btnDeleteCoach.Size = new System.Drawing.Size(202, 36);
            this.btnDeleteCoach.TabIndex = 28;
            this.btnDeleteCoach.Text = "Удалить";
            this.btnDeleteCoach.UseVisualStyleBackColor = false;
            this.btnDeleteCoach.Click += new System.EventHandler(this.btnDeleteCoach_Click);
            // 
            // btnEditCoach
            // 
            this.btnEditCoach.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEditCoach.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditCoach.Font = new System.Drawing.Font("Courier New", 9.2F);
            this.btnEditCoach.ForeColor = System.Drawing.Color.Navy;
            this.btnEditCoach.Location = new System.Drawing.Point(314, 349);
            this.btnEditCoach.Name = "btnEditCoach";
            this.btnEditCoach.Size = new System.Drawing.Size(195, 36);
            this.btnEditCoach.TabIndex = 27;
            this.btnEditCoach.Text = "Редактировать";
            this.btnEditCoach.UseVisualStyleBackColor = false;
            this.btnEditCoach.Click += new System.EventHandler(this.btnEditCoach_Click);
            // 
            // dgvCoaches
            // 
            this.dgvCoaches.BackgroundColor = System.Drawing.Color.White;
            this.dgvCoaches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCoaches.Location = new System.Drawing.Point(10, 107);
            this.dgvCoaches.Name = "dgvCoaches";
            this.dgvCoaches.RowHeadersWidth = 51;
            this.dgvCoaches.RowTemplate.Height = 24;
            this.dgvCoaches.Size = new System.Drawing.Size(290, 236);
            this.dgvCoaches.TabIndex = 39;
            this.dgvCoaches.Click += new System.EventHandler(this.dgvCoaches_SelectionChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.ForeColor = System.Drawing.Color.Navy;
            this.btnCancel.Location = new System.Drawing.Point(-4, -3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 37);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Назад";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.TextChanged += new System.EventHandler(this.btnBack_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(280, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 40);
            this.label1.TabIndex = 36;
            this.label1.Text = "Тренеры";
            // 
            // btnAddCoach
            // 
            this.btnAddCoach.BackColor = System.Drawing.Color.PowderBlue;
            this.btnAddCoach.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddCoach.Font = new System.Drawing.Font("Courier New", 9.2F);
            this.btnAddCoach.ForeColor = System.Drawing.Color.Navy;
            this.btnAddCoach.Location = new System.Drawing.Point(10, 349);
            this.btnAddCoach.Name = "btnAddCoach";
            this.btnAddCoach.Size = new System.Drawing.Size(290, 36);
            this.btnAddCoach.TabIndex = 41;
            this.btnAddCoach.Text = "Добавить нового тренера";
            this.btnAddCoach.UseVisualStyleBackColor = false;
            this.btnAddCoach.Click += new System.EventHandler(this.btnAddCoach_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Courier New", 8.2F);
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(155, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 17);
            this.label3.TabIndex = 47;
            this.label3.Text = "поиск по номеру:";
            // 
            // txtSearchPhone
            // 
            this.txtSearchPhone.BackColor = System.Drawing.Color.PowderBlue;
            this.txtSearchPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchPhone.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearchPhone.ForeColor = System.Drawing.Color.Navy;
            this.txtSearchPhone.Location = new System.Drawing.Point(158, 71);
            this.txtSearchPhone.Name = "txtSearchPhone";
            this.txtSearchPhone.Size = new System.Drawing.Size(142, 27);
            this.txtSearchPhone.TabIndex = 46;
            this.txtSearchPhone.TextChanged += new System.EventHandler(this.txtSearchPhone_TextChanged);
            // 
            // txtSearchCoach
            // 
            this.txtSearchCoach.BackColor = System.Drawing.Color.PowderBlue;
            this.txtSearchCoach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchCoach.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearchCoach.ForeColor = System.Drawing.Color.Navy;
            this.txtSearchCoach.Location = new System.Drawing.Point(7, 71);
            this.txtSearchCoach.Name = "txtSearchCoach";
            this.txtSearchCoach.Size = new System.Drawing.Size(142, 27);
            this.txtSearchCoach.TabIndex = 44;
            this.txtSearchCoach.TextChanged += new System.EventHandler(this.txtSearchCoach_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Courier New", 8.2F);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(4, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 45;
            this.label2.Text = "поиск по фио:";
            // 
            // Coaches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PP.Properties.Resources.вод;
            this.ClientSize = new System.Drawing.Size(737, 399);
            this.Controls.Add(this.pnlCoachDetails);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearchPhone);
            this.Controls.Add(this.txtSearchCoach);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDeleteCoach);
            this.Controls.Add(this.dgvCoaches);
            this.Controls.Add(this.btnEditCoach);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddCoach);
            this.Name = "Coaches";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coaches";
            this.pnlCoachDetails.ResumeLayout(false);
            this.pnlCoachDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoaches)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCoachDetails;
        private System.Windows.Forms.Label lblCoachPhone;
        private System.Windows.Forms.Label lblCoachExperienceYears;
        private System.Windows.Forms.Button btnDeleteCoach;
        private System.Windows.Forms.Button btnEditCoach;
        private System.Windows.Forms.Label lbl_Client;
        private System.Windows.Forms.Label lblCoachDateOfBirth;
        private System.Windows.Forms.Label lblCoachSpecialization;
        private System.Windows.Forms.Label lblCoachFullName;
        private System.Windows.Forms.DataGridView dgvCoaches;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddCoach;
        private System.Windows.Forms.Button btnShowCoachSchedule;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchPhone;
        private System.Windows.Forms.TextBox txtSearchCoach;
        private System.Windows.Forms.Label label2;
    }
}