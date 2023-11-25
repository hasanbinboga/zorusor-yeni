using ZoruSor.Lib.Test.Analoji;

namespace ZoruSor.Reports
{
    partial class AnalojiSayfa2
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.xrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox3 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox4 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPictureBox6 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox7 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox7,
            this.xrLabel8,
            this.xrPictureBox6,
            this.xrLabel6,
            this.xrPictureBox3,
            this.xrLabel3,
            this.xrLabel4,
            this.xrPictureBox4,
            this.xrPictureBox2,
            this.xrLabel1});
            this.Detail.HeightF = 1198F;
            this.Detail.Controls.SetChildIndex(this.xrLine2, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel11, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel1, 0);
            this.Detail.Controls.SetChildIndex(this.xrPictureBox2, 0);
            this.Detail.Controls.SetChildIndex(this.xrPictureBox4, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel4, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel3, 0);
            this.Detail.Controls.SetChildIndex(this.xrPictureBox3, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel6, 0);
            this.Detail.Controls.SetChildIndex(this.xrPictureBox6, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel8, 0);
            this.Detail.Controls.SetChildIndex(this.xrPictureBox7, 0);
            // 
            // xrLabel11
            // 
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(10.36084F, 1137.82F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            // 
            // xrLine4
            // 
            this.xrLine4.StylePriority.UsePadding = false;
            // 
            // xrLine2
            // 
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1187.38F);
            this.xrLine2.StylePriority.UsePadding = false;
            // 
            // xrPictureBox2
            // 
            this.xrPictureBox2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPictureBox2.BorderWidth = 2F;
            this.xrPictureBox2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Image", null, "ReferansResim")});
            this.xrPictureBox2.Dpi = 254F;
            this.xrPictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(661.2903F, 14.94587F);
            this.xrPictureBox2.Name = "xrPictureBox2";
            this.xrPictureBox2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.xrPictureBox2.SizeF = new System.Drawing.SizeF(815F, 350F);
            this.xrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            this.xrPictureBox2.StylePriority.UseBorders = false;
            this.xrPictureBox2.StylePriority.UseBorderWidth = false;
            this.xrPictureBox2.StylePriority.UsePadding = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Id")});
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25.00001F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(94.65539F, 45.72F);
            this.xrLabel1.StyleName = "FieldCaption";
            xrSummary1.FormatString = "{0:#)}";
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel1.Summary = xrSummary1;
            // 
            // xrPictureBox3
            // 
            this.xrPictureBox3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Image", null, "SecenekA")});
            this.xrPictureBox3.Dpi = 254F;
            this.xrPictureBox3.LocationFloat = new DevExpress.Utils.PointFloat(47.79158F, 391.3333F);
            this.xrPictureBox3.Name = "xrPictureBox3";
            this.xrPictureBox3.SizeF = new System.Drawing.SizeF(815F, 350F);
            this.xrPictureBox3.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(7.912308F, 391.3333F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(55.56256F, 58.42F);
            this.xrLabel3.Text = "A)";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(1145.389F, 391.3333F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(55.56256F, 58.42F);
            this.xrLabel4.Text = "B)";
            // 
            // xrPictureBox4
            // 
            this.xrPictureBox4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Image", null, "SecenekB")});
            this.xrPictureBox4.Dpi = 254F;
            this.xrPictureBox4.LocationFloat = new DevExpress.Utils.PointFloat(1185.937F, 391.3333F);
            this.xrPictureBox4.Name = "xrPictureBox4";
            this.xrPictureBox4.SizeF = new System.Drawing.SizeF(815F, 350F);
            this.xrPictureBox4.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrPictureBox6
            // 
            this.xrPictureBox6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Image", null, "SecenekC")});
            this.xrPictureBox6.Dpi = 254F;
            this.xrPictureBox6.LocationFloat = new DevExpress.Utils.PointFloat(47.79158F, 769.2993F);
            this.xrPictureBox6.Name = "xrPictureBox6";
            this.xrPictureBox6.SizeF = new System.Drawing.SizeF(815F, 350F);
            this.xrPictureBox6.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 254F;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(3.676051F, 769.2993F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(55.5625F, 58.42F);
            this.xrLabel6.Text = "C)";
            // 
            // xrPictureBox7
            // 
            this.xrPictureBox7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Image", null, "SecenekD")});
            this.xrPictureBox7.Dpi = 254F;
            this.xrPictureBox7.LocationFloat = new DevExpress.Utils.PointFloat(1185.937F, 769.2993F);
            this.xrPictureBox7.Name = "xrPictureBox7";
            this.xrPictureBox7.SizeF = new System.Drawing.SizeF(815F, 350F);
            this.xrPictureBox7.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 254F;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(1145.389F, 769.2993F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(55.5625F, 58.42F);
            this.xrLabel8.Text = "D)";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(AnalojiIkili1Test2);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // AnalojiSayfa2
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }


        #endregion

        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox4;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
    }
}
