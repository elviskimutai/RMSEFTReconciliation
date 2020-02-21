namespace EFTReconciliation
{
    partial class Form1
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
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.cmbworksheet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAuthCode = new System.Windows.Forms.DataGridView();
            this.dataGridViewlogs = new System.Windows.Forms.DataGridView();
            this.btnstatement = new System.Windows.Forms.Button();
            this.btnLogs = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtAuthCode = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.ComboBox();
            this.txtRRN = new System.Windows.Forms.ComboBox();
            this.chkAuth = new System.Windows.Forms.CheckBox();
            this.chkAmount = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnReconcile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAuthCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewlogs)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(6, 34);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(129, 23);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select Statements";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbworksheet
            // 
            this.cmbworksheet.FormattingEnabled = true;
            this.cmbworksheet.Location = new System.Drawing.Point(10, 87);
            this.cmbworksheet.Name = "cmbworksheet";
            this.cmbworksheet.Size = new System.Drawing.Size(238, 21);
            this.cmbworksheet.TabIndex = 2;
            this.cmbworksheet.SelectedIndexChanged += new System.EventHandler(this.cmbworksheet_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Worksheet";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(7, 114);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(129, 23);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load Statements";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnReconcile_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(159, 177);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.chkAuthCode);
            this.panel1.Controls.Add(this.dataGridViewlogs);
            this.panel1.Location = new System.Drawing.Point(282, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 446);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // chkAuthCode
            // 
            this.chkAuthCode.AllowUserToAddRows = false;
            this.chkAuthCode.AllowUserToDeleteRows = false;
            this.chkAuthCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chkAuthCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkAuthCode.Location = new System.Drawing.Point(0, 0);
            this.chkAuthCode.Name = "chkAuthCode";
            this.chkAuthCode.ReadOnly = true;
            this.chkAuthCode.Size = new System.Drawing.Size(645, 446);
            this.chkAuthCode.TabIndex = 1;
            // 
            // dataGridViewlogs
            // 
            this.dataGridViewlogs.AllowUserToAddRows = false;
            this.dataGridViewlogs.AllowUserToDeleteRows = false;
            this.dataGridViewlogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewlogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewlogs.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewlogs.Name = "dataGridViewlogs";
            this.dataGridViewlogs.ReadOnly = true;
            this.dataGridViewlogs.Size = new System.Drawing.Size(645, 446);
            this.dataGridViewlogs.TabIndex = 0;
            // 
            // btnstatement
            // 
            this.btnstatement.Location = new System.Drawing.Point(201, -1);
            this.btnstatement.Name = "btnstatement";
            this.btnstatement.Size = new System.Drawing.Size(115, 23);
            this.btnstatement.TabIndex = 1;
            this.btnstatement.Text = "Bank Statements";
            this.btnstatement.UseVisualStyleBackColor = true;
            this.btnstatement.Click += new System.EventHandler(this.btn_Statement);
            // 
            // btnLogs
            // 
            this.btnLogs.Location = new System.Drawing.Point(313, -1);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(131, 23);
            this.btnLogs.TabIndex = 2;
            this.btnLogs.Text = "EFT Logs";
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnlogsClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1, -1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Home";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(83, -1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Database";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(1, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 429);
            this.panel2.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.btnLoad);
            this.panel4.Controls.Add(this.txtFilePath);
            this.panel4.Controls.Add(this.cmbworksheet);
            this.panel4.Controls.Add(this.btnSelectFile);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(3, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(272, 157);
            this.panel4.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(218, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "Import Bank Statement";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(141, 37);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(100, 20);
            this.txtFilePath.TabIndex = 6;
            this.txtFilePath.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtAuthCode);
            this.panel3.Controls.Add(this.txtAmount);
            this.panel3.Controls.Add(this.txtRRN);
            this.panel3.Controls.Add(this.chkAuth);
            this.panel3.Controls.Add(this.chkAmount);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.btnReconcile);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(3, 175);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(275, 217);
            this.panel3.TabIndex = 7;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // txtAuthCode
            // 
            this.txtAuthCode.FormattingEnabled = true;
            this.txtAuthCode.Location = new System.Drawing.Point(69, 117);
            this.txtAuthCode.Name = "txtAuthCode";
            this.txtAuthCode.Size = new System.Drawing.Size(171, 21);
            this.txtAuthCode.TabIndex = 19;
            // 
            // txtAmount
            // 
            this.txtAmount.FormattingEnabled = true;
            this.txtAmount.Location = new System.Drawing.Point(69, 87);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(171, 21);
            this.txtAmount.TabIndex = 18;
            // 
            // txtRRN
            // 
            this.txtRRN.FormattingEnabled = true;
            this.txtRRN.Location = new System.Drawing.Point(69, 56);
            this.txtRRN.Name = "txtRRN";
            this.txtRRN.Size = new System.Drawing.Size(171, 21);
            this.txtRRN.TabIndex = 17;
            // 
            // chkAuth
            // 
            this.chkAuth.AutoSize = true;
            this.chkAuth.Location = new System.Drawing.Point(246, 120);
            this.chkAuth.Name = "chkAuth";
            this.chkAuth.Size = new System.Drawing.Size(15, 14);
            this.chkAuth.TabIndex = 15;
            this.chkAuth.UseVisualStyleBackColor = true;
            // 
            // chkAmount
            // 
            this.chkAmount.AutoSize = true;
            this.chkAmount.Location = new System.Drawing.Point(246, 92);
            this.chkAmount.Name = "chkAmount";
            this.chkAmount.Size = new System.Drawing.Size(15, 14);
            this.chkAmount.TabIndex = 14;
            this.chkAmount.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(91, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Excelsheet Column";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // btnReconcile
            // 
            this.btnReconcile.Location = new System.Drawing.Point(61, 177);
            this.btnReconcile.Name = "btnReconcile";
            this.btnReconcile.Size = new System.Drawing.Size(92, 23);
            this.btnReconcile.TabIndex = 10;
            this.btnReconcile.Text = "Reconcile";
            this.btnReconcile.UseVisualStyleBackColor = true;
            this.btnReconcile.Click += new System.EventHandler(this.btnReconcile_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "AuthCode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "RRN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search Criteria";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 464);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnLogs);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnstatement);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAuthCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewlogs)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.ComboBox cmbworksheet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewlogs;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Button btnstatement;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.DataGridView chkAuthCode;
        private System.Windows.Forms.Button btnReconcile;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkAuth;
        private System.Windows.Forms.CheckBox chkAmount;
        private System.Windows.Forms.ComboBox txtAuthCode;
        private System.Windows.Forms.ComboBox txtAmount;
        private System.Windows.Forms.ComboBox txtRRN;
    }
}

