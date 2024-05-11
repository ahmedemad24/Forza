namespace cypos.Forms
{
    partial class XtraForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraForm1));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            resources.ApplyResources(this.gridControl, "gridControl");
            this.gridControl.EmbeddedNavigator.AccessibleDescription = resources.GetString("gridControl.EmbeddedNavigator.AccessibleDescription");
            this.gridControl.EmbeddedNavigator.AccessibleName = resources.GetString("gridControl.EmbeddedNavigator.AccessibleName");
            this.gridControl.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("gridControl.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.gridControl.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gridControl.EmbeddedNavigator.Anchor")));
            this.gridControl.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControl.EmbeddedNavigator.BackgroundImage")));
            this.gridControl.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gridControl.EmbeddedNavigator.BackgroundImageLayout")));
            this.gridControl.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gridControl.EmbeddedNavigator.ImeMode")));
            this.gridControl.EmbeddedNavigator.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("gridControl.EmbeddedNavigator.Margin")));
            this.gridControl.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("gridControl.EmbeddedNavigator.MaximumSize")));
            this.gridControl.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("gridControl.EmbeddedNavigator.TextLocation")));
            this.gridControl.EmbeddedNavigator.ToolTip = resources.GetString("gridControl.EmbeddedNavigator.ToolTip");
            this.gridControl.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("gridControl.EmbeddedNavigator.ToolTipIconType")));
            this.gridControl.EmbeddedNavigator.ToolTipTitle = resources.GetString("gridControl.EmbeddedNavigator.ToolTipTitle");
            this.gridControl.MainView = this.cardView1;
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardView1});
            // 
            // cardView1
            // 
            this.cardView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(this.cardView1, "cardView1");
            this.cardView1.DetailHeight = 404;
            this.cardView1.GridControl = this.gridControl;
            this.cardView1.Name = "cardView1";
            this.cardView1.OptionsBehavior.Editable = false;
            this.cardView1.OptionsBehavior.ReadOnly = true;
            this.cardView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            // 
            // ribbonControl
            // 
            resources.ApplyResources(this.ribbonControl, "ribbonControl");
            this.ribbonControl.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35);
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.ExpandCollapseItem.ImageOptions.ImageIndex = ((int)(resources.GetObject("ribbonControl.ExpandCollapseItem.ImageOptions.ImageIndex")));
            this.ribbonControl.ExpandCollapseItem.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("ribbonControl.ExpandCollapseItem.ImageOptions.LargeImageIndex")));
            this.ribbonControl.ExpandCollapseItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ribbonControl.ExpandCollapseItem.ImageOptions.SvgImage")));
            this.ribbonControl.ExpandCollapseItem.SearchTags = resources.GetString("ribbonControl.ExpandCollapseItem.SearchTags");
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bbiPrintPreview,
            this.bsiRecordsCount,
            this.btnNew,
            this.bbiEdit,
            this.bbiDelete,
            this.bbiRefresh});
            this.ribbonControl.MaxItemId = 20;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.OptionsMenuMinWidth = 385;
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiPrintPreview
            // 
            resources.ApplyResources(this.bbiPrintPreview, "bbiPrintPreview");
            this.bbiPrintPreview.Id = 14;
            this.bbiPrintPreview.ImageOptions.ImageIndex = ((int)(resources.GetObject("bbiPrintPreview.ImageOptions.ImageIndex")));
            this.bbiPrintPreview.ImageOptions.ImageUri.Uri = "Preview";
            this.bbiPrintPreview.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("bbiPrintPreview.ImageOptions.LargeImageIndex")));
            this.bbiPrintPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiPrintPreview.ImageOptions.SvgImage")));
            this.bbiPrintPreview.Name = "bbiPrintPreview";
            this.bbiPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPrintPreview_ItemClick);
            // 
            // bsiRecordsCount
            // 
            resources.ApplyResources(this.bsiRecordsCount, "bsiRecordsCount");
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.ImageOptions.ImageIndex = ((int)(resources.GetObject("bsiRecordsCount.ImageOptions.ImageIndex")));
            this.bsiRecordsCount.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("bsiRecordsCount.ImageOptions.LargeImageIndex")));
            this.bsiRecordsCount.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bsiRecordsCount.ImageOptions.SvgImage")));
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // btnNew
            // 
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.Id = 16;
            this.btnNew.ImageOptions.ImageIndex = ((int)(resources.GetObject("btnNew.ImageOptions.ImageIndex")));
            this.btnNew.ImageOptions.ImageUri.Uri = "New";
            this.btnNew.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("btnNew.ImageOptions.LargeImageIndex")));
            this.btnNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNew.ImageOptions.SvgImage")));
            this.btnNew.Name = "btnNew";
            // 
            // bbiEdit
            // 
            resources.ApplyResources(this.bbiEdit, "bbiEdit");
            this.bbiEdit.Id = 17;
            this.bbiEdit.ImageOptions.ImageIndex = ((int)(resources.GetObject("bbiEdit.ImageOptions.ImageIndex")));
            this.bbiEdit.ImageOptions.ImageUri.Uri = "Edit";
            this.bbiEdit.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("bbiEdit.ImageOptions.LargeImageIndex")));
            this.bbiEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiEdit.ImageOptions.SvgImage")));
            this.bbiEdit.Name = "bbiEdit";
            // 
            // bbiDelete
            // 
            resources.ApplyResources(this.bbiDelete, "bbiDelete");
            this.bbiDelete.Id = 18;
            this.bbiDelete.ImageOptions.ImageIndex = ((int)(resources.GetObject("bbiDelete.ImageOptions.ImageIndex")));
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("bbiDelete.ImageOptions.LargeImageIndex")));
            this.bbiDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiDelete.ImageOptions.SvgImage")));
            this.bbiDelete.Name = "bbiDelete";
            // 
            // bbiRefresh
            // 
            resources.ApplyResources(this.bbiRefresh, "bbiRefresh");
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.ImageIndex = ((int)(resources.GetObject("bbiRefresh.ImageOptions.ImageIndex")));
            this.bbiRefresh.ImageOptions.ImageUri.Uri = "Refresh";
            this.bbiRefresh.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("bbiRefresh.ImageOptions.LargeImageIndex")));
            this.bbiRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiRefresh.ImageOptions.SvgImage")));
            this.bbiRefresh.Name = "bbiRefresh";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            resources.ApplyResources(this.ribbonPage1, "ribbonPage1");
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            resources.ApplyResources(this.ribbonPageGroup1, "ribbonPageGroup1");
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiPrintPreview);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            resources.ApplyResources(this.ribbonPageGroup2, "ribbonPageGroup2");
            // 
            // ribbonStatusBar
            // 
            resources.ApplyResources(this.ribbonStatusBar, "ribbonStatusBar");
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            // 
            // simpleButton1
            // 
            resources.ApplyResources(this.simpleButton1, "simpleButton1");
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // XtraForm1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonControl);
            this.Name = "XtraForm1";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiPrintPreview;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}