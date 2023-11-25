namespace ZoruSor.UserControls
{
    partial class Donusum2Uc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Donusum2Uc));
            this.celdiriciLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DogruCevap = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DonusumResim = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.soruNoLabel = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DogruCevap)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DonusumResim)).BeginInit();
            this.SuspendLayout();
            // 
            // celdiriciLayoutPanel
            // 
            this.celdiriciLayoutPanel.AutoScroll = true;
            this.celdiriciLayoutPanel.ColumnCount = 5;
            this.celdiriciLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.celdiriciLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.celdiriciLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.celdiriciLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.celdiriciLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.celdiriciLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.celdiriciLayoutPanel.Location = new System.Drawing.Point(412, 0);
            this.celdiriciLayoutPanel.Name = "celdiriciLayoutPanel";
            this.celdiriciLayoutPanel.RowCount = 3;
            this.celdiriciLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.celdiriciLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.celdiriciLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.celdiriciLayoutPanel.Size = new System.Drawing.Size(566, 304);
            this.celdiriciLayoutPanel.TabIndex = 38;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DogruCevap);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(245, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(167, 304);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Doğru Cevap";
            // 
            // DogruCevap
            // 
            this.DogruCevap.Location = new System.Drawing.Point(6, 19);
            this.DogruCevap.Name = "DogruCevap";
            this.DogruCevap.Size = new System.Drawing.Size(150, 150);
            this.DogruCevap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DogruCevap.TabIndex = 13;
            this.DogruCevap.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DonusumResim);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(78, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(167, 304);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dönüşümler";
            // 
            // DonusumResim
            // 
            this.DonusumResim.Location = new System.Drawing.Point(6, 19);
            this.DonusumResim.Name = "DonusumResim";
            this.DonusumResim.Size = new System.Drawing.Size(155, 274);
            this.DonusumResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DonusumResim.TabIndex = 13;
            this.DonusumResim.TabStop = false;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(40, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 304);
            this.button1.TabIndex = 35;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // soruNoLabel
            // 
            this.soruNoLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.soruNoLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soruNoLabel.Location = new System.Drawing.Point(0, 0);
            this.soruNoLabel.Name = "soruNoLabel";
            this.soruNoLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.soruNoLabel.Size = new System.Drawing.Size(40, 304);
            this.soruNoLabel.TabIndex = 36;
            this.soruNoLabel.Text = "1";
            this.soruNoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Donusum2Uc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.celdiriciLayoutPanel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.soruNoLabel);
            this.Name = "Donusum2Uc";
            this.Size = new System.Drawing.Size(978, 304);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DogruCevap)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DonusumResim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel celdiriciLayoutPanel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox DogruCevap;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox DonusumResim;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label soruNoLabel;
    }
}
