namespace ZoruSor.UserControls
{
    partial class TestUc
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.soruTipCombo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.sayfaTipCombo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.baslikEdit = new DevExpress.XtraEditors.TextEdit();
            this.siraLbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.aciklamaLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soruTipCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sayfaTipCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baslikEdit.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.soruTipCombo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.sayfaTipCombo, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.baslikEdit, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(821, 335);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 44;
            this.label1.Text = "Başlık";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(423, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 24);
            this.label4.TabIndex = 26;
            this.label4.Text = "Sayfa Tipi";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 24);
            this.label3.TabIndex = 25;
            this.label3.Text = "Soru Tipi";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soruTipCombo
            // 
            this.soruTipCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soruTipCombo.EditValue = "Seçiniz";
            this.soruTipCombo.Location = new System.Drawing.Point(103, 5);
            this.soruTipCombo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.soruTipCombo.Name = "soruTipCombo";
            this.soruTipCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.soruTipCombo.Properties.NullText = "Seçiniz";
            this.soruTipCombo.Properties.Sorted = true;
            this.soruTipCombo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.soruTipCombo.Size = new System.Drawing.Size(294, 20);
            this.soruTipCombo.TabIndex = 2;
            this.soruTipCombo.SelectedIndexChanged += new System.EventHandler(this.soruTipCombo_SelectedIndexChanged);
            // 
            // sayfaTipCombo
            // 
            this.sayfaTipCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sayfaTipCombo.EditValue = "Seçiniz";
            this.sayfaTipCombo.Location = new System.Drawing.Point(523, 5);
            this.sayfaTipCombo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.sayfaTipCombo.Name = "sayfaTipCombo";
            this.sayfaTipCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sayfaTipCombo.Properties.NullText = "Seçiniz";
            this.sayfaTipCombo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.sayfaTipCombo.Size = new System.Drawing.Size(295, 20);
            this.sayfaTipCombo.TabIndex = 3;
            this.sayfaTipCombo.SelectedIndexChanged += new System.EventHandler(this.SayfaTipCombo_SelectedIndexChanged);
            // 
            // gridControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gridControl1, 6);
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 63);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(815, 250);
            this.gridControl1.TabIndex = 43;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // baslikEdit
            // 
            this.baslikEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baslikEdit.Location = new System.Drawing.Point(104, 35);
            this.baslikEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 4);
            this.baslikEdit.Name = "baslikEdit";
            this.baslikEdit.Size = new System.Drawing.Size(292, 20);
            this.baslikEdit.TabIndex = 45;
            this.baslikEdit.EditValueChanged += new System.EventHandler(this.baslikEdit_EditValueChanged);
            // 
            // siraLbl
            // 
            this.siraLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.siraLbl.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siraLbl.Location = new System.Drawing.Point(0, 0);
            this.siraLbl.Name = "siraLbl";
            this.siraLbl.Size = new System.Drawing.Size(82, 25);
            this.siraLbl.TabIndex = 26;
            this.siraLbl.Text = "1";
            this.siraLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(794, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 25);
            this.button1.TabIndex = 27;
            this.button1.Text = "Sil";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.aciklamaLbl);
            this.panel1.Controls.Add(this.siraLbl);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 25);
            this.panel1.TabIndex = 28;
            // 
            // aciklamaLbl
            // 
            this.aciklamaLbl.AutoSize = true;
            this.aciklamaLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.aciklamaLbl.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aciklamaLbl.Location = new System.Drawing.Point(82, 0);
            this.aciklamaLbl.Margin = new System.Windows.Forms.Padding(3, 5, 0, 0);
            this.aciklamaLbl.Name = "aciklamaLbl";
            this.aciklamaLbl.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.aciklamaLbl.Size = new System.Drawing.Size(0, 19);
            this.aciklamaLbl.TabIndex = 28;
            this.aciklamaLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TestUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(450, 150);
            this.Name = "TestUc";
            this.Size = new System.Drawing.Size(821, 360);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soruTipCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sayfaTipCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baslikEdit.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.ComboBoxEdit sayfaTipCombo;
        private DevExpress.XtraEditors.ComboBoxEdit soruTipCombo;
        private System.Windows.Forms.Label siraLbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label aciklamaLbl;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit baslikEdit;
    }
}
