namespace PP
{
    partial class SellAbonementForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.cmbAbonementTemplate = new System.Windows.Forms.ComboBox();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.lblVisitsInfo = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 18.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(77, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 38);
            this.label1.TabIndex = 32;
            this.label1.Text = "Продажа абонемента";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.BackColor = System.Drawing.Color.Transparent;
            this.lblClientName.Font = new System.Drawing.Font("Courier New", 9.8F);
            this.lblClientName.ForeColor = System.Drawing.Color.Navy;
            this.lblClientName.Location = new System.Drawing.Point(22, 97);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(69, 20);
            this.lblClientName.TabIndex = 34;
            this.lblClientName.Text = "label1";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.CalendarFont = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpPurchaseDate.CustomFormat = "dd.MM.yyyy";
            this.dtpPurchaseDate.Font = new System.Drawing.Font("Courier New", 10.2F);
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(27, 183);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(478, 27);
            this.dtpPurchaseDate.TabIndex = 74;
            this.dtpPurchaseDate.ValueChanged += new System.EventHandler(this.dtpPurchaseDate_ValueChanged);
            // 
            // cmbAbonementTemplate
            // 
            this.cmbAbonementTemplate.Font = new System.Drawing.Font("Courier New", 10.2F);
            this.cmbAbonementTemplate.FormattingEnabled = true;
            this.cmbAbonementTemplate.Location = new System.Drawing.Point(26, 133);
            this.cmbAbonementTemplate.Name = "cmbAbonementTemplate";
            this.cmbAbonementTemplate.Size = new System.Drawing.Size(479, 28);
            this.cmbAbonementTemplate.TabIndex = 82;
            this.cmbAbonementTemplate.SelectedIndexChanged += new System.EventHandler(this.CmbAbonementTemplate_SelectedIndexChanged);
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.BackColor = System.Drawing.Color.Transparent;
            this.lblExpiryDate.Font = new System.Drawing.Font("Courier New", 9.8F);
            this.lblExpiryDate.ForeColor = System.Drawing.Color.Navy;
            this.lblExpiryDate.Location = new System.Drawing.Point(23, 232);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(69, 20);
            this.lblExpiryDate.TabIndex = 83;
            this.lblExpiryDate.Text = "label2";
            // 
            // lblVisitsInfo
            // 
            this.lblVisitsInfo.AutoSize = true;
            this.lblVisitsInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblVisitsInfo.Font = new System.Drawing.Font("Courier New", 9.8F);
            this.lblVisitsInfo.ForeColor = System.Drawing.Color.Navy;
            this.lblVisitsInfo.Location = new System.Drawing.Point(22, 268);
            this.lblVisitsInfo.Name = "lblVisitsInfo";
            this.lblVisitsInfo.Size = new System.Drawing.Size(69, 20);
            this.lblVisitsInfo.TabIndex = 84;
            this.lblVisitsInfo.Text = "label3";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.Font = new System.Drawing.Font("Courier New", 9.8F);
            this.lblPrice.ForeColor = System.Drawing.Color.Navy;
            this.lblPrice.Location = new System.Drawing.Point(23, 303);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(69, 20);
            this.lblPrice.TabIndex = 85;
            this.lblPrice.Text = "label4";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Courier New", 10.2F);
            this.btnCancel.ForeColor = System.Drawing.Color.Navy;
            this.btnCancel.Location = new System.Drawing.Point(272, 338);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(233, 34);
            this.btnCancel.TabIndex = 87;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSell
            // 
            this.btnSell.BackColor = System.Drawing.Color.PowderBlue;
            this.btnSell.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSell.Font = new System.Drawing.Font("Courier New", 10.2F);
            this.btnSell.ForeColor = System.Drawing.Color.Navy;
            this.btnSell.Location = new System.Drawing.Point(27, 338);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(233, 34);
            this.btnSell.TabIndex = 86;
            this.btnSell.Text = "Продать";
            this.btnSell.UseVisualStyleBackColor = false;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // SellAbonementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PP.Properties.Resources.вод;
            this.ClientSize = new System.Drawing.Size(532, 399);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblVisitsInfo);
            this.Controls.Add(this.lblExpiryDate);
            this.Controls.Add(this.cmbAbonementTemplate);
            this.Controls.Add(this.dtpPurchaseDate);
            this.Controls.Add(this.lblClientName);
            this.Controls.Add(this.label1);
            this.Name = "SellAbonementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SellAbonement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.ComboBox cmbAbonementTemplate;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.Label lblVisitsInfo;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSell;
    }
}