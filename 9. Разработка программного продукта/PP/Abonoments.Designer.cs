namespace PP
{
    partial class Abonements
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
            this.lblAbonementDuration = new System.Windows.Forms.Label();
            this.pnlAbonomentDetails = new System.Windows.Forms.Panel();
            this.lblAbonementVisits = new System.Windows.Forms.Label();
            this.lbl_Client = new System.Windows.Forms.Label();
            this.lblAbonementPrice = new System.Windows.Forms.Label();
            this.lblAbonementName = new System.Windows.Forms.Label();
            this.btnDeleteAbonoment = new System.Windows.Forms.Button();
            this.btnEditAbonoment = new System.Windows.Forms.Button();
            this.lblClientFullName = new System.Windows.Forms.Label();
            this.dgvAbonements = new System.Windows.Forms.DataGridView();
            this.txtSearchAbonement = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddAbonement = new System.Windows.Forms.Button();
            this.pnlAbonomentDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbonements)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAbonementDuration
            // 
            this.lblAbonementDuration.AutoSize = true;
            this.lblAbonementDuration.Font = new System.Drawing.Font("Courier New", 9.2F);
            this.lblAbonementDuration.ForeColor = System.Drawing.Color.Navy;
            this.lblAbonementDuration.Location = new System.Drawing.Point(3, 126);
            this.lblAbonementDuration.Name = "lblAbonementDuration";
            this.lblAbonementDuration.Size = new System.Drawing.Size(68, 18);
            this.lblAbonementDuration.TabIndex = 2;
            this.lblAbonementDuration.Text = "label3";
            // 
            // pnlAbonomentDetails
            // 
            this.pnlAbonomentDetails.BackColor = System.Drawing.Color.White;
            this.pnlAbonomentDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAbonomentDetails.Controls.Add(this.lblAbonementVisits);
            this.pnlAbonomentDetails.Controls.Add(this.lbl_Client);
            this.pnlAbonomentDetails.Controls.Add(this.lblAbonementDuration);
            this.pnlAbonomentDetails.Controls.Add(this.lblAbonementPrice);
            this.pnlAbonomentDetails.Controls.Add(this.lblAbonementName);
            this.pnlAbonomentDetails.Location = new System.Drawing.Point(313, 71);
            this.pnlAbonomentDetails.Name = "pnlAbonomentDetails";
            this.pnlAbonomentDetails.Size = new System.Drawing.Size(412, 272);
            this.pnlAbonomentDetails.TabIndex = 38;
            this.pnlAbonomentDetails.Visible = false;
            this.pnlAbonomentDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAbonomentDetails_Paint);
            // 
            // lblAbonementVisits
            // 
            this.lblAbonementVisits.AutoSize = true;
            this.lblAbonementVisits.Font = new System.Drawing.Font("Courier New", 9.2F);
            this.lblAbonementVisits.ForeColor = System.Drawing.Color.Navy;
            this.lblAbonementVisits.Location = new System.Drawing.Point(3, 156);
            this.lblAbonementVisits.Name = "lblAbonementVisits";
            this.lblAbonementVisits.Size = new System.Drawing.Size(68, 18);
            this.lblAbonementVisits.TabIndex = 29;
            this.lblAbonementVisits.Text = "label4";
            // 
            // lbl_Client
            // 
            this.lbl_Client.AutoSize = true;
            this.lbl_Client.Font = new System.Drawing.Font("Courier New", 15.8F, System.Drawing.FontStyle.Bold);
            this.lbl_Client.ForeColor = System.Drawing.Color.Navy;
            this.lbl_Client.Location = new System.Drawing.Point(60, 20);
            this.lbl_Client.Name = "lbl_Client";
            this.lbl_Client.Size = new System.Drawing.Size(286, 31);
            this.lbl_Client.TabIndex = 3;
            this.lbl_Client.Text = "Детали абонемента";
            // 
            // lblAbonementPrice
            // 
            this.lblAbonementPrice.AutoSize = true;
            this.lblAbonementPrice.Font = new System.Drawing.Font("Courier New", 9.2F);
            this.lblAbonementPrice.ForeColor = System.Drawing.Color.Navy;
            this.lblAbonementPrice.Location = new System.Drawing.Point(3, 96);
            this.lblAbonementPrice.Name = "lblAbonementPrice";
            this.lblAbonementPrice.Size = new System.Drawing.Size(68, 18);
            this.lblAbonementPrice.TabIndex = 1;
            this.lblAbonementPrice.Text = "label2";
            // 
            // lblAbonementName
            // 
            this.lblAbonementName.AutoSize = true;
            this.lblAbonementName.Font = new System.Drawing.Font("Courier New", 9.2F);
            this.lblAbonementName.ForeColor = System.Drawing.Color.Navy;
            this.lblAbonementName.Location = new System.Drawing.Point(3, 66);
            this.lblAbonementName.Name = "lblAbonementName";
            this.lblAbonementName.Size = new System.Drawing.Size(68, 18);
            this.lblAbonementName.TabIndex = 0;
            this.lblAbonementName.Text = "label1";
            // 
            // btnDeleteAbonoment
            // 
            this.btnDeleteAbonoment.BackColor = System.Drawing.Color.PowderBlue;
            this.btnDeleteAbonoment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteAbonoment.Font = new System.Drawing.Font("Courier New", 9.2F);
            this.btnDeleteAbonoment.ForeColor = System.Drawing.Color.Navy;
            this.btnDeleteAbonoment.Location = new System.Drawing.Point(529, 348);
            this.btnDeleteAbonoment.Name = "btnDeleteAbonoment";
            this.btnDeleteAbonoment.Size = new System.Drawing.Size(196, 39);
            this.btnDeleteAbonoment.TabIndex = 28;
            this.btnDeleteAbonoment.Text = "Удалить";
            this.btnDeleteAbonoment.UseVisualStyleBackColor = false;
            this.btnDeleteAbonoment.Click += new System.EventHandler(this.btnDeleteAbonement_Click);
            // 
            // btnEditAbonoment
            // 
            this.btnEditAbonoment.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEditAbonoment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditAbonoment.Font = new System.Drawing.Font("Courier New", 9.2F);
            this.btnEditAbonoment.ForeColor = System.Drawing.Color.Navy;
            this.btnEditAbonoment.Location = new System.Drawing.Point(313, 349);
            this.btnEditAbonoment.Name = "btnEditAbonoment";
            this.btnEditAbonoment.Size = new System.Drawing.Size(193, 39);
            this.btnEditAbonoment.TabIndex = 27;
            this.btnEditAbonoment.Text = "Редактировать";
            this.btnEditAbonoment.UseVisualStyleBackColor = false;
            this.btnEditAbonoment.Click += new System.EventHandler(this.btnEditAbonement_Click);
            // 
            // lblClientFullName
            // 
            this.lblClientFullName.AutoSize = true;
            this.lblClientFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblClientFullName.Font = new System.Drawing.Font("Courier New", 9.2F);
            this.lblClientFullName.ForeColor = System.Drawing.Color.Navy;
            this.lblClientFullName.Location = new System.Drawing.Point(10, 47);
            this.lblClientFullName.Name = "lblClientFullName";
            this.lblClientFullName.Size = new System.Drawing.Size(68, 18);
            this.lblClientFullName.TabIndex = 40;
            this.lblClientFullName.Text = "поиск:";
            // 
            // dgvAbonements
            // 
            this.dgvAbonements.BackgroundColor = System.Drawing.Color.White;
            this.dgvAbonements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbonements.Location = new System.Drawing.Point(10, 106);
            this.dgvAbonements.Name = "dgvAbonements";
            this.dgvAbonements.RowHeadersWidth = 51;
            this.dgvAbonements.RowTemplate.Height = 24;
            this.dgvAbonements.Size = new System.Drawing.Size(290, 236);
            this.dgvAbonements.TabIndex = 37;
            this.dgvAbonements.SelectionChanged += new System.EventHandler(this.dgvAbonements_SelectionChanged);
            // 
            // txtSearchAbonement
            // 
            this.txtSearchAbonement.BackColor = System.Drawing.Color.PowderBlue;
            this.txtSearchAbonement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchAbonement.Font = new System.Drawing.Font("Courier New", 10.2F);
            this.txtSearchAbonement.ForeColor = System.Drawing.Color.Navy;
            this.txtSearchAbonement.Location = new System.Drawing.Point(10, 71);
            this.txtSearchAbonement.Name = "txtSearchAbonement";
            this.txtSearchAbonement.Size = new System.Drawing.Size(290, 27);
            this.txtSearchAbonement.TabIndex = 36;
            this.txtSearchAbonement.TextChanged += new System.EventHandler(this.txtSearchAbonement_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Navy;
            this.btnCancel.Location = new System.Drawing.Point(-3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 33);
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
            this.label1.Location = new System.Drawing.Point(237, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 40);
            this.label1.TabIndex = 34;
            this.label1.Text = "Абонементы";
            // 
            // btnAddAbonement
            // 
            this.btnAddAbonement.BackColor = System.Drawing.Color.PowderBlue;
            this.btnAddAbonement.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddAbonement.Font = new System.Drawing.Font("Courier New", 9.2F);
            this.btnAddAbonement.ForeColor = System.Drawing.Color.Navy;
            this.btnAddAbonement.Location = new System.Drawing.Point(10, 348);
            this.btnAddAbonement.Name = "btnAddAbonement";
            this.btnAddAbonement.Size = new System.Drawing.Size(290, 43);
            this.btnAddAbonement.TabIndex = 39;
            this.btnAddAbonement.Text = "Добавить новый абонемент";
            this.btnAddAbonement.UseVisualStyleBackColor = false;
            this.btnAddAbonement.Click += new System.EventHandler(this.btnAddAbonement_Click);
            // 
            // Abonements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PP.Properties.Resources.вод;
            this.ClientSize = new System.Drawing.Size(737, 399);
            this.Controls.Add(this.pnlAbonomentDetails);
            this.Controls.Add(this.btnDeleteAbonoment);
            this.Controls.Add(this.lblClientFullName);
            this.Controls.Add(this.btnEditAbonoment);
            this.Controls.Add(this.dgvAbonements);
            this.Controls.Add(this.txtSearchAbonement);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddAbonement);
            this.Name = "Abonements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abonements";
            this.Load += new System.EventHandler(this.Abonements_Load);
            this.pnlAbonomentDetails.ResumeLayout(false);
            this.pnlAbonomentDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbonements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAbonementDuration;
        private System.Windows.Forms.Panel pnlAbonomentDetails;
        private System.Windows.Forms.Label lblAbonementVisits;
        private System.Windows.Forms.Button btnDeleteAbonoment;
        private System.Windows.Forms.Button btnEditAbonoment;
        private System.Windows.Forms.Label lbl_Client;
        private System.Windows.Forms.Label lblAbonementPrice;
        private System.Windows.Forms.Label lblAbonementName;
        private System.Windows.Forms.Label lblClientFullName;
        private System.Windows.Forms.DataGridView dgvAbonements;
        private System.Windows.Forms.TextBox txtSearchAbonement;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddAbonement;
    }
}