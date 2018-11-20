namespace HK.Formas
{
    partial class FrmAgenda
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
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgenda));
            this.viewSelector1 = new DevExpress.XtraScheduler.UI.ViewSelector();
            this.schedulerControl = new DevExpress.XtraScheduler.SchedulerControl();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.viewNavigatorBackwardItem1 = new DevExpress.XtraScheduler.UI.ViewNavigatorBackwardItem();
            this.viewNavigatorForwardItem1 = new DevExpress.XtraScheduler.UI.ViewNavigatorForwardItem();
            this.viewNavigatorTodayItem1 = new DevExpress.XtraScheduler.UI.ViewNavigatorTodayItem();
            this.viewNavigatorZoomInItem1 = new DevExpress.XtraScheduler.UI.ViewNavigatorZoomInItem();
            this.viewNavigatorZoomOutItem1 = new DevExpress.XtraScheduler.UI.ViewNavigatorZoomOutItem();
            this.viewSelectorItem1 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem2 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem3 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem4 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewSelectorItem5 = new DevExpress.XtraScheduler.UI.ViewSelectorItem();
            this.viewNavigatorRibbonPage1 = new DevExpress.XtraScheduler.UI.ViewNavigatorRibbonPage();
            this.viewNavigatorRibbonPageGroup1 = new DevExpress.XtraScheduler.UI.ViewNavigatorRibbonPageGroup();
            this.viewSelectorRibbonPageGroup1 = new DevExpress.XtraScheduler.UI.ViewSelectorRibbonPageGroup();
            this.schedulerStorage = new DevExpress.XtraScheduler.SchedulerStorage();
            this.agendaBindingSource = new System.Windows.Forms.BindingSource();
            this.ribbonViewNavigator1 = new DevExpress.XtraScheduler.UI.RibbonViewNavigator();
            this.ribbonViewSelector1 = new DevExpress.XtraScheduler.UI.RibbonViewSelector();
            this.LookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            ((System.ComponentModel.ISupportInitialize)(this.viewSelector1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViewNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViewSelector1)).BeginInit();
            this.SuspendLayout();
            // 
            // viewSelector1
            // 
            this.viewSelector1.SchedulerControl = this.schedulerControl;
            // 
            // schedulerControl
            // 
            this.schedulerControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.schedulerControl.Location = new System.Drawing.Point(0, 103);
            this.schedulerControl.MenuManager = this.ribbonControl1;
            this.schedulerControl.Name = "schedulerControl";
            this.schedulerControl.Size = new System.Drawing.Size(894, 627);
            this.schedulerControl.Start = new System.DateTime(2011, 12, 28, 0, 0, 0, 0);
            this.schedulerControl.Storage = this.schedulerStorage;
            this.schedulerControl.TabIndex = 1;
            this.schedulerControl.Text = "schedulerControl1";
            this.schedulerControl.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl.PreparePopupMenu += new DevExpress.XtraScheduler.PreparePopupMenuEventHandler(this.schedulerControl_PreparePopupMenu);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonText = null;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.viewNavigatorBackwardItem1,
            this.viewNavigatorForwardItem1,
            this.viewNavigatorTodayItem1,
            this.viewNavigatorZoomInItem1,
            this.viewNavigatorZoomOutItem1,
            this.viewSelectorItem1,
            this.viewSelectorItem2,
            this.viewSelectorItem3,
            this.viewSelectorItem4,
            this.viewSelectorItem5});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 10;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.viewNavigatorRibbonPage1});
            this.ribbonControl1.SelectedPage = this.viewNavigatorRibbonPage1;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(894, 97);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // viewNavigatorBackwardItem1
            // 
            this.viewNavigatorBackwardItem1.Caption = "Atraz";
            this.viewNavigatorBackwardItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorBackwardItem1.Glyph")));
            this.viewNavigatorBackwardItem1.GroupIndex = 1;
            this.viewNavigatorBackwardItem1.Id = 0;
            this.viewNavigatorBackwardItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorBackwardItem1.LargeGlyph")));
            this.viewNavigatorBackwardItem1.Name = "viewNavigatorBackwardItem1";
            // 
            // viewNavigatorForwardItem1
            // 
            this.viewNavigatorForwardItem1.Caption = "Adelante";
            this.viewNavigatorForwardItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorForwardItem1.Glyph")));
            this.viewNavigatorForwardItem1.GroupIndex = 1;
            this.viewNavigatorForwardItem1.Id = 1;
            this.viewNavigatorForwardItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorForwardItem1.LargeGlyph")));
            this.viewNavigatorForwardItem1.Name = "viewNavigatorForwardItem1";
            // 
            // viewNavigatorTodayItem1
            // 
            this.viewNavigatorTodayItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorTodayItem1.Glyph")));
            this.viewNavigatorTodayItem1.GroupIndex = 1;
            this.viewNavigatorTodayItem1.Id = 2;
            this.viewNavigatorTodayItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorTodayItem1.LargeGlyph")));
            this.viewNavigatorTodayItem1.Name = "viewNavigatorTodayItem1";
            // 
            // viewNavigatorZoomInItem1
            // 
            this.viewNavigatorZoomInItem1.Caption = "Acercar";
            this.viewNavigatorZoomInItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorZoomInItem1.Glyph")));
            this.viewNavigatorZoomInItem1.GroupIndex = 1;
            this.viewNavigatorZoomInItem1.Id = 3;
            this.viewNavigatorZoomInItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Add));
            this.viewNavigatorZoomInItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorZoomInItem1.LargeGlyph")));
            this.viewNavigatorZoomInItem1.Name = "viewNavigatorZoomInItem1";
            // 
            // viewNavigatorZoomOutItem1
            // 
            this.viewNavigatorZoomOutItem1.Caption = "Alejar";
            this.viewNavigatorZoomOutItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorZoomOutItem1.Glyph")));
            this.viewNavigatorZoomOutItem1.GroupIndex = 1;
            this.viewNavigatorZoomOutItem1.Id = 4;
            this.viewNavigatorZoomOutItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Subtract));
            this.viewNavigatorZoomOutItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewNavigatorZoomOutItem1.LargeGlyph")));
            this.viewNavigatorZoomOutItem1.Name = "viewNavigatorZoomOutItem1";
            // 
            // viewSelectorItem1
            // 
            this.viewSelectorItem1.Caption = "Diario";
            this.viewSelectorItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem1.Glyph")));
            this.viewSelectorItem1.GroupIndex = 1;
            this.viewSelectorItem1.Id = 5;
            this.viewSelectorItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D1));
            this.viewSelectorItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem1.LargeGlyph")));
            this.viewSelectorItem1.Name = "viewSelectorItem1";
            this.viewSelectorItem1.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Day;
            // 
            // viewSelectorItem2
            // 
            this.viewSelectorItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem2.Glyph")));
            this.viewSelectorItem2.GroupIndex = 1;
            this.viewSelectorItem2.Id = 6;
            this.viewSelectorItem2.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D2));
            this.viewSelectorItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem2.LargeGlyph")));
            this.viewSelectorItem2.Name = "viewSelectorItem2";
            this.viewSelectorItem2.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.WorkWeek;
            // 
            // viewSelectorItem3
            // 
            this.viewSelectorItem3.Caption = "Semanal";
            this.viewSelectorItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem3.Glyph")));
            this.viewSelectorItem3.GroupIndex = 1;
            this.viewSelectorItem3.Id = 7;
            this.viewSelectorItem3.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D3));
            this.viewSelectorItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem3.LargeGlyph")));
            this.viewSelectorItem3.Name = "viewSelectorItem3";
            this.viewSelectorItem3.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Week;
            // 
            // viewSelectorItem4
            // 
            this.viewSelectorItem4.Caption = "Mensual";
            this.viewSelectorItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem4.Glyph")));
            this.viewSelectorItem4.GroupIndex = 1;
            this.viewSelectorItem4.Id = 8;
            this.viewSelectorItem4.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D4));
            this.viewSelectorItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem4.LargeGlyph")));
            this.viewSelectorItem4.Name = "viewSelectorItem4";
            this.viewSelectorItem4.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            // 
            // viewSelectorItem5
            // 
            this.viewSelectorItem5.Caption = "Linea de Tiempo";
            this.viewSelectorItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem5.Glyph")));
            this.viewSelectorItem5.GroupIndex = 1;
            this.viewSelectorItem5.Id = 9;
            this.viewSelectorItem5.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                            | System.Windows.Forms.Keys.D5));
            this.viewSelectorItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("viewSelectorItem5.LargeGlyph")));
            this.viewSelectorItem5.Name = "viewSelectorItem5";
            this.viewSelectorItem5.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Timeline;
            // 
            // viewNavigatorRibbonPage1
            // 
            this.viewNavigatorRibbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.viewNavigatorRibbonPageGroup1,
            this.viewSelectorRibbonPageGroup1});
            this.viewNavigatorRibbonPage1.Name = "viewNavigatorRibbonPage1";
            // 
            // viewNavigatorRibbonPageGroup1
            // 
            this.viewNavigatorRibbonPageGroup1.ItemLinks.Add(this.viewNavigatorBackwardItem1);
            this.viewNavigatorRibbonPageGroup1.ItemLinks.Add(this.viewNavigatorForwardItem1);
            this.viewNavigatorRibbonPageGroup1.ItemLinks.Add(this.viewNavigatorTodayItem1);
            this.viewNavigatorRibbonPageGroup1.ItemLinks.Add(this.viewNavigatorZoomInItem1);
            this.viewNavigatorRibbonPageGroup1.ItemLinks.Add(this.viewNavigatorZoomOutItem1);
            this.viewNavigatorRibbonPageGroup1.Name = "viewNavigatorRibbonPageGroup1";
            this.viewNavigatorRibbonPageGroup1.Text = "Navegador";
            // 
            // viewSelectorRibbonPageGroup1
            // 
            this.viewSelectorRibbonPageGroup1.ItemLinks.Add(this.viewSelectorItem1);
            this.viewSelectorRibbonPageGroup1.ItemLinks.Add(this.viewSelectorItem3);
            this.viewSelectorRibbonPageGroup1.ItemLinks.Add(this.viewSelectorItem4);
            this.viewSelectorRibbonPageGroup1.ItemLinks.Add(this.viewSelectorItem5);
            this.viewSelectorRibbonPageGroup1.Name = "viewSelectorRibbonPageGroup1";
            this.viewSelectorRibbonPageGroup1.Text = "Seleccionar Vista";
            // 
            // schedulerStorage
            // 
            this.schedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("IdAgenda", "IdAgenda"));
            this.schedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("FechaInicio", "FechaInicio"));
            this.schedulerStorage.Appointments.CustomFieldMappings.Add(new DevExpress.XtraScheduler.AppointmentCustomFieldMapping("FechaFinal", "FechaFinal"));
            // 
            // agendaBindingSource
            // 
            this.agendaBindingSource.DataSource = typeof(HK.Agenda);
            // 
            // ribbonViewNavigator1
            // 
            this.ribbonViewNavigator1.RibbonControl = this.ribbonControl1;
            this.ribbonViewNavigator1.SchedulerControl = this.schedulerControl;
            // 
            // ribbonViewSelector1
            // 
            this.ribbonViewSelector1.RibbonControl = this.ribbonControl1;
            this.ribbonViewSelector1.SchedulerControl = this.schedulerControl;
            // 
            // LookAndFeel
            // 
            this.LookAndFeel.LookAndFeel.SkinName = "Foggy";
            // 
            // FrmAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 730);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.schedulerControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAgenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agenda ";
            ((System.ComponentModel.ISupportInitialize)(this.viewSelector1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agendaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViewNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViewSelector1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.UI.ViewSelector viewSelector1;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraScheduler.UI.ViewNavigatorBackwardItem viewNavigatorBackwardItem1;
        private DevExpress.XtraScheduler.UI.ViewNavigatorForwardItem viewNavigatorForwardItem1;
        private DevExpress.XtraScheduler.UI.ViewNavigatorTodayItem viewNavigatorTodayItem1;
        private DevExpress.XtraScheduler.UI.ViewNavigatorZoomInItem viewNavigatorZoomInItem1;
        private DevExpress.XtraScheduler.UI.ViewNavigatorZoomOutItem viewNavigatorZoomOutItem1;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem1;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem2;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem3;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem4;
        private DevExpress.XtraScheduler.UI.ViewSelectorItem viewSelectorItem5;
        private DevExpress.XtraScheduler.UI.ViewNavigatorRibbonPage viewNavigatorRibbonPage1;
        private DevExpress.XtraScheduler.UI.ViewNavigatorRibbonPageGroup viewNavigatorRibbonPageGroup1;
        private DevExpress.XtraScheduler.UI.ViewSelectorRibbonPageGroup viewSelectorRibbonPageGroup1;
        private DevExpress.XtraScheduler.UI.RibbonViewNavigator ribbonViewNavigator1;
        private DevExpress.XtraScheduler.UI.RibbonViewSelector ribbonViewSelector1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel LookAndFeel;
        private System.Windows.Forms.BindingSource agendaBindingSource;
    }
}