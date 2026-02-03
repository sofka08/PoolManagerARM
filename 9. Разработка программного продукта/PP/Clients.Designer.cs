namespace PP
{
    partial class Clients
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
            this.pnlClientDetails = new System.Windows.Forms.Panel();
            this.lbl_Client = new System.Windows.Forms.Label();
            this.btnSellAbonement = new System.Windows.Forms.Button();
            this.btnShowClientHistory = new System.Windows.Forms.Button();
            this.lblClientDateOfBirth = new System.Windows.Forms.Label();
            this.lblClientPhone = new System.Windows.Forms.Label();
            this.lblClientFullName = new System.Windows.Forms.Label();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.btnEditClient = new System.Windows.Forms.Button();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.txtSearchClient = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.txtSearchPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlClientDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClientDetails
            // 
            this.pnlClientDetails.BackColor = System.Drawing.Color.White;
            this.pnlClientDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlClientDetails.Controls.Add(this.lbl_Client);
            this.pnlClientDetails.Controls.Add(this.btnSellAbonement);
            this.pnlClientDetails.Controls.Add(this.btnShowClientHistory);
            this.pnlClientDetails.Controls.Add(this.lblClientDateOfBirth);
            this.pnlClientDetails.Controls.Add(this.lblClientPhone);
            this.pnlClientDetails.Controls.Add(this.lblClientFullName);
            this.pnlClientDetails.Location = new System.Drawing.Point(314, 88);
            this.pnlClientDetails.Name = "pnlClientDetails";
            this.pnlClientDetails.Size = new System.Drawing.Size(415, 272);
            this.pnlClientDetails.TabIndex = 39;
            this.pnlClientDetails.Visible = false;
            // 
            // lbl_Client
            // 
            this.lbl_Client.AutoSize = true;
            this.lbl_Client.Font = new System.Drawing.Font("Courier New", 15.8F, System.Drawing.FontStyle.Bold);
            this.lbl_Client.ForeColor = System.Drawing.Color.Navy;
            this.lbl_Client.Location = new System.Drawing.Point(80, 20);
            this.lbl_Client.Name = "lbl_Client";
            this.lbl_Client.Size = new System.Drawing.Size(238, 31);
            this.lbl_Client.TabIndex = 3;
            this.lbl_Client.Text = "Детали клиента";
            // 
            // btnSellAbonement
            // 
            this.btnSellAbonement.BackColor = System.Drawing.Color.Transparent;
            this.btnSellAbonement.FlatAppearance.BorderSize = 0;
            this.btnSellAbonement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSellAbonement.Font = new System.Drawing.Font("Courier New", 9.2F);
            this.btnSellAbonement.ForeColor = System.Drawing.Color.Purple;
            this.btnSellAbonement.Location = new System.Drawing.Point(-1, 185);
            this.btnSellAbonement.Name = "btnSellAbonement";
            this.btnSellAbonement.Size = new System.Drawing.Size(222, 33);
            this.btnSellAbonement.TabIndex = 44;
            this.btnSellAbonement.Text = "Продать абонемент";
            this.btnSellAbonement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSellAbonement.UseVisualStyleBackColor = false;
            this.btnSellAbonement.Click += new System.EventHandler(this.btnSellAbonement_Click);
            // 
            // btnShowClientHistory
            // 
            this.btnShowClientHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnShowClientHistory.FlatAppearance.BorderSize = 0;
            this.btnShowClientHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowClientHistory.Font = new System.Drawing.Font("Courier New", 9.2F);
            this.btnShowClientHistory.ForeColor = System.Drawing.Color.IndianRed;
            this.btnShowClientHistory.Location = new System.Drawing.Point(-1, 155);
            this.btnShowClientHistory.Name = "btnShowClientHistory";
            this.btnShowClientHistory.Size = new System.Drawing.Size(268, 33);
            this.btnShowClientHistory.TabIndex = 43;
            this.btnShowClientHistory.Text = "История абонементов";
            this.btnShowClientHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowClientHistory.UseVisualStyleBackColor = false;
            this.btnShowClientHistory.Click += new System.EventHandler(this.btnShowClientHistory_Click);
            // 
            // lblClientDateOfBirth
            // 
            this.lblClientDateOfBirth.AutoSize = true;
            this.lblClientDateOfBirth.Font = new System.Drawing.Font("Courier New", 9.8F);
            this.lblClientDateOfBirth.ForeColor = System.Drawing.Color.Navy;
            this.lblClientDateOfBirth.Location = new System.Drawing.Point(3, 132);
            this.lblClientDateOfBirth.Name = "lblClientDateOfBirth";
            this.lblClientDateOfBirth.Size = new System.Drawing.Size(69, 20);
            this.lblClientDateOfBirth.TabIndex = 2;
            this.lblClientDateOfBirth.Text = "label3";
            // 
            // lblClientPhone
            // 
            this.lblClientPhone.AutoSize = true;
            this.lblClientPhone.Font = new System.Drawing.Font("Courier New", 9.8F);
            this.lblClientPhone.ForeColor = System.Drawing.Color.Navy;
            this.lblClientPhone.Location = new System.Drawing.Point(3, 98);
            this.lblClientPhone.Name = "lblClientPhone";
            this.lblClientPhone.Size = new System.Drawing.Size(69, 20);
            this.lblClientPhone.TabIndex = 1;
            this.lblClientPhone.Text = "label2";
            // 
            // lblClientFullName
            // 
            this.lblClientFullName.AutoSize = true;
            this.lblClientFullName.Font = new System.Drawing.Font("Courier New", 9.8F);
            this.lblClientFullName.ForeColor = System.Drawing.Color.Navy;
            this.lblClientFullName.Location = new System.Drawing.Point(3, 66);
            this.lblClientFullName.Name = "lblClientFullName";
            this.lblClientFullName.Size = new System.Drawing.Size(69, 20);
            this.lblClientFullName.TabIndex = 0;
            this.lblClientFullName.Text = "label1";
            // 
            // btnDeleteClient
            // 
            this.btnDeleteClient.BackColor = System.Drawing.Color.PowderBlue;
            this.btnDeleteClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteClient.Font = new System.Drawing.Font("Courier New", 9.2F);
            this.btnDeleteClient.ForeColor = System.Drawing.Color.Navy;
            this.btnDeleteClient.Location = new System.Drawing.Point(516, 366);
            this.btnDeleteClient.Name = "btnDeleteClient";
            this.btnDeleteClient.Size = new System.Drawing.Size(213, 39);
            this.btnDeleteClient.TabIndex = 28;
            this.btnDeleteClient.Text = "Удалить";
            this.btnDeleteClient.UseVisualStyleBackColor = false;
            this.btnDeleteClient.TextChanged += new System.EventHandler(this.btnDeleteClient_Click);
            this.btnDeleteClient.Click += new System.EventHandler(this.btnDeleteClient_Click);
            // 
            // btnEditClient
            // 
            this.btnEditClient.BackColor = System.Drawing.Color.PowderBlue;
            this.btnEditClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditClient.Font = new System.Drawing.Font("Courier New", 9.2F);
            this.btnEditClient.ForeColor = System.Drawing.Color.Navy;
            this.btnEditClient.Location = new System.Drawing.Point(314, 366);
            this.btnEditClient.Name = "btnEditClient";
            this.btnEditClient.Size = new System.Drawing.Size(188, 39);
            this.btnEditClient.TabIndex = 27;
            this.btnEditClient.Text = "Редактировать";
            this.btnEditClient.UseVisualStyleBackColor = false;
            this.btnEditClient.TextChanged += new System.EventHandler(this.btnEditClient_Click);
            this.btnEditClient.Click += new System.EventHandler(this.btnEditClient_Click);
            // 
            // dgvClients
            // 
            this.dgvClients.BackgroundColor = System.Drawing.Color.White;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Location = new System.Drawing.Point(7, 123);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.RowHeadersWidth = 51;
            this.dgvClients.RowTemplate.Height = 24;
            this.dgvClients.Size = new System.Drawing.Size(293, 236);
            this.dgvClients.TabIndex = 38;
            this.dgvClients.SelectionChanged += new System.EventHandler(this.dgvClients_SelectionChanged);
            // 
            // txtSearchClient
            // 
            this.txtSearchClient.BackColor = System.Drawing.Color.PowderBlue;
            this.txtSearchClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchClient.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearchClient.ForeColor = System.Drawing.Color.Navy;
            this.txtSearchClient.Location = new System.Drawing.Point(7, 88);
            this.txtSearchClient.Name = "txtSearchClient";
            this.txtSearchClient.Size = new System.Drawing.Size(142, 27);
            this.txtSearchClient.TabIndex = 37;
            this.txtSearchClient.Click += new System.EventHandler(this.txtSearchClient_TextChanged);
            this.txtSearchClient.TextChanged += new System.EventHandler(this.txtSearchClient_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Navy;
            this.btnCancel.Location = new System.Drawing.Point(-7, -1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 33);
            this.btnCancel.TabIndex = 36;
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
            this.label1.Location = new System.Drawing.Point(266, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 40);
            this.label1.TabIndex = 35;
            this.label1.Text = "Клиенты";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Courier New", 8.2F);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(4, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 41;
            this.label2.Text = "поиск по фио:";
            // 
            // btnAddClient
            // 
            this.btnAddClient.BackColor = System.Drawing.Color.PowderBlue;
            this.btnAddClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddClient.Font = new System.Drawing.Font("Courier New", 9.2F);
            this.btnAddClient.ForeColor = System.Drawing.Color.Navy;
            this.btnAddClient.Location = new System.Drawing.Point(7, 365);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(293, 39);
            this.btnAddClient.TabIndex = 40;
            this.btnAddClient.Text = "Добавить нового клиента";
            this.btnAddClient.UseVisualStyleBackColor = false;
            this.btnAddClient.TextChanged += new System.EventHandler(this.btnAddClient_Click);
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // txtSearchPhone
            // 
            this.txtSearchPhone.BackColor = System.Drawing.Color.PowderBlue;
            this.txtSearchPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchPhone.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearchPhone.ForeColor = System.Drawing.Color.Navy;
            this.txtSearchPhone.Location = new System.Drawing.Point(158, 88);
            this.txtSearchPhone.Name = "txtSearchPhone";
            this.txtSearchPhone.Size = new System.Drawing.Size(142, 27);
            this.txtSearchPhone.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Courier New", 8.2F);
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(155, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 17);
            this.label3.TabIndex = 43;
            this.label3.Text = "поиск по номеру:";
            // 
            // Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PP.Properties.Resources.вод;
            this.ClientSize = new System.Drawing.Size(741, 421);
            this.Controls.Add(this.pnlClientDetails);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearchPhone);
            this.Controls.Add(this.btnDeleteClient);
            this.Controls.Add(this.btnEditClient);
            this.Controls.Add(this.dgvClients);
            this.Controls.Add(this.txtSearchClient);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddClient);
            this.Name = "Clients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clients";
            this.Load += new System.EventHandler(this.Clients_Load);
            this.TextChanged += new System.EventHandler(this.txtSearchPhone_TextChanged);
            this.pnlClientDetails.ResumeLayout(false);
            this.pnlClientDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlClientDetails;
        private System.Windows.Forms.Button btnDeleteClient;
        private System.Windows.Forms.Button btnEditClient;
        private System.Windows.Forms.Label lbl_Client;
        private System.Windows.Forms.Label lblClientDateOfBirth;
        private System.Windows.Forms.Label lblClientPhone;
        private System.Windows.Forms.Label lblClientFullName;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.TextBox txtSearchClient;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.TextBox txtSearchPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSellAbonement;
        private System.Windows.Forms.Button btnShowClientHistory;
    }
}