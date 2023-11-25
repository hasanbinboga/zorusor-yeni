namespace ZoruSor.UserControls
{
    partial class Fasikul
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.testLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dogumTarihEdit = new DevExpress.XtraEditors.TextEdit();
            this.adSoyadEdit = new DevExpress.XtraEditors.TextEdit();
            this.copyrightEdit = new DevExpress.XtraEditors.TextEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fasikulYukle = new System.Windows.Forms.Button();
            this.fasikulKaydet = new System.Windows.Forms.Button();
            this.testEkle = new System.Windows.Forms.Button();
            this.fasikulHazırla = new System.Windows.Forms.Button();
            this.fasikulEkle = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dogumTarihEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adSoyadEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.copyrightEdit.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // testLayoutPanel
            // 
            this.testLayoutPanel.AutoScroll = true;
            this.testLayoutPanel.AutoScrollMargin = new System.Drawing.Size(25, 25);
            this.testLayoutPanel.ColumnCount = 1;
            this.testLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.testLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testLayoutPanel.Location = new System.Drawing.Point(0, 102);
            this.testLayoutPanel.Name = "testLayoutPanel";
            this.testLayoutPanel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.testLayoutPanel.RowCount = 4;
            this.testLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.testLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.testLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.testLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.testLayoutPanel.Size = new System.Drawing.Size(601, 358);
            this.testLayoutPanel.TabIndex = 2;
            this.testLayoutPanel.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.testLayoutPanel_ControlRemoved);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 102);
            this.panel1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dogumTarihEdit, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.adSoyadEdit, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.copyrightEdit, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(601, 67);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 43);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 14);
            this.label11.TabIndex = 33;
            this.label11.Text = "Doğum Tarihi";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 23);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 14);
            this.label10.TabIndex = 32;
            this.label10.Text = "Adı Soyadı";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 3);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 14);
            this.label9.TabIndex = 31;
            this.label9.Text = "Copyright";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dogumTarihEdit
            // 
            this.dogumTarihEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dogumTarihEdit.Location = new System.Drawing.Point(100, 40);
            this.dogumTarihEdit.Margin = new System.Windows.Forms.Padding(0);
            this.dogumTarihEdit.Name = "dogumTarihEdit";
            this.dogumTarihEdit.Size = new System.Drawing.Size(501, 20);
            this.dogumTarihEdit.TabIndex = 10;
            // 
            // adSoyadEdit
            // 
            this.adSoyadEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adSoyadEdit.Location = new System.Drawing.Point(100, 20);
            this.adSoyadEdit.Margin = new System.Windows.Forms.Padding(0);
            this.adSoyadEdit.Name = "adSoyadEdit";
            this.adSoyadEdit.Size = new System.Drawing.Size(501, 20);
            this.adSoyadEdit.TabIndex = 9;
            // 
            // copyrightEdit
            // 
            this.copyrightEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copyrightEdit.Location = new System.Drawing.Point(100, 0);
            this.copyrightEdit.Margin = new System.Windows.Forms.Padding(0);
            this.copyrightEdit.Name = "copyrightEdit";
            this.copyrightEdit.Size = new System.Drawing.Size(501, 20);
            this.copyrightEdit.TabIndex = 8;
            this.copyrightEdit.EditValueChanged += new System.EventHandler(this.copyrightEdit_EditValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fasikulEkle);
            this.panel2.Controls.Add(this.fasikulYukle);
            this.panel2.Controls.Add(this.fasikulKaydet);
            this.panel2.Controls.Add(this.testEkle);
            this.panel2.Controls.Add(this.fasikulHazırla);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(601, 35);
            this.panel2.TabIndex = 26;
            // 
            // fasikulYukle
            // 
            this.fasikulYukle.Location = new System.Drawing.Point(84, 3);
            this.fasikulYukle.Name = "fasikulYukle";
            this.fasikulYukle.Size = new System.Drawing.Size(75, 23);
            this.fasikulYukle.TabIndex = 0;
            this.fasikulYukle.Text = "Yükle";
            this.fasikulYukle.UseVisualStyleBackColor = true;
            this.fasikulYukle.Click += new System.EventHandler(this.fasikulYukle_Click);
            // 
            // fasikulKaydet
            // 
            this.fasikulKaydet.Location = new System.Drawing.Point(165, 3);
            this.fasikulKaydet.Name = "fasikulKaydet";
            this.fasikulKaydet.Size = new System.Drawing.Size(75, 23);
            this.fasikulKaydet.TabIndex = 1;
            this.fasikulKaydet.Text = "Kaydet";
            this.fasikulKaydet.UseVisualStyleBackColor = true;
            this.fasikulKaydet.Click += new System.EventHandler(this.fasikulKaydet_Click);
            // 
            // testEkle
            // 
            this.testEkle.Location = new System.Drawing.Point(327, 3);
            this.testEkle.Name = "testEkle";
            this.testEkle.Size = new System.Drawing.Size(75, 23);
            this.testEkle.TabIndex = 3;
            this.testEkle.Text = "Test Ekle";
            this.testEkle.UseVisualStyleBackColor = true;
            this.testEkle.Click += new System.EventHandler(this.testEkle_Click);
            // 
            // fasikulHazırla
            // 
            this.fasikulHazırla.Location = new System.Drawing.Point(246, 3);
            this.fasikulHazırla.Name = "fasikulHazırla";
            this.fasikulHazırla.Size = new System.Drawing.Size(75, 23);
            this.fasikulHazırla.TabIndex = 2;
            this.fasikulHazırla.Text = "Hazirla";
            this.fasikulHazırla.UseVisualStyleBackColor = true;
            this.fasikulHazırla.Click += new System.EventHandler(this.fasikulHazırla_Click);
            // 
            // fasikulEkle
            // 
            this.fasikulEkle.Location = new System.Drawing.Point(6, 3);
            this.fasikulEkle.Name = "fasikulEkle";
            this.fasikulEkle.Size = new System.Drawing.Size(75, 23);
            this.fasikulEkle.TabIndex = 4;
            this.fasikulEkle.Text = "Ekle";
            this.fasikulEkle.UseVisualStyleBackColor = true;
            this.fasikulEkle.Click += new System.EventHandler(this.fasikulEkle_Click);
            // 
            // Fasikul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.testLayoutPanel);
            this.Controls.Add(this.panel1);
            this.Name = "Fasikul";
            this.Size = new System.Drawing.Size(601, 460);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dogumTarihEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adSoyadEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.copyrightEdit.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel testLayoutPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button testEkle;
        private System.Windows.Forms.Button fasikulHazırla;
        private System.Windows.Forms.Button fasikulKaydet;
        private System.Windows.Forms.Button fasikulYukle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.TextEdit dogumTarihEdit;
        private DevExpress.XtraEditors.TextEdit adSoyadEdit;
        private DevExpress.XtraEditors.TextEdit copyrightEdit;
        private System.Windows.Forms.Button fasikulEkle;
    }
}
