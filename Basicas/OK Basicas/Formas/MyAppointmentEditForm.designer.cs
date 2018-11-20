namespace DevExpress.XtraScheduler.Demos {
	partial class MyAppointmentEditForm {
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.lblSubject = new System.Windows.Forms.Label();
            this.edLabel = new DevExpress.XtraScheduler.UI.AppointmentLabelEdit();
            this.edStatus = new DevExpress.XtraScheduler.UI.AppointmentStatusEdit();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblLabel = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblCustomName = new System.Windows.Forms.Label();
            this.lblCustomStatus = new System.Windows.Forms.Label();
            this.txCustomStatus = new DevExpress.XtraEditors.TextEdit();
            this.dtStart = new DevExpress.XtraEditors.DateEdit();
            this.dtEnd = new DevExpress.XtraEditors.DateEdit();
            this.timeStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEnd = new DevExpress.XtraEditors.TimeEdit();
            this.checkAllDay = new DevExpress.XtraEditors.CheckEdit();
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.Aceptar = new System.Windows.Forms.ToolStripButton();
            this.Cancelar = new System.Windows.Forms.ToolStripButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.txSubject = new DevExpress.XtraEditors.ButtonEdit();
            this.txCustomName = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txCustomStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAllDay.Properties)).BeginInit();
            this.BarraAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txCustomName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSubject
            // 
            this.lblSubject.Location = new System.Drawing.Point(5, 81);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(48, 18);
            this.lblSubject.TabIndex = 4;
            this.lblSubject.Text = "Cliente:";
            // 
            // edLabel
            // 
            this.edLabel.Location = new System.Drawing.Point(93, 219);
            this.edLabel.Name = "edLabel";
            this.edLabel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edLabel.Size = new System.Drawing.Size(263, 20);
            this.edLabel.TabIndex = 7;
            // 
            // edStatus
            // 
            this.edStatus.Location = new System.Drawing.Point(93, 191);
            this.edStatus.Name = "edStatus";
            this.edStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edStatus.Size = new System.Drawing.Size(263, 20);
            this.edStatus.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(5, 191);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 18);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status:";
            // 
            // lblLabel
            // 
            this.lblLabel.Location = new System.Drawing.Point(5, 220);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(56, 19);
            this.lblLabel.TabIndex = 11;
            this.lblLabel.Text = "Prioridad:";
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(5, 113);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(56, 18);
            this.lblStart.TabIndex = 12;
            this.lblStart.Text = "Comienzo:";
            // 
            // lblEnd
            // 
            this.lblEnd.Location = new System.Drawing.Point(5, 141);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(48, 18);
            this.lblEnd.TabIndex = 13;
            this.lblEnd.Text = "Desde:";
            this.lblEnd.Visible = false;
            // 
            // lblCustomName
            // 
            this.lblCustomName.Location = new System.Drawing.Point(5, 48);
            this.lblCustomName.Name = "lblCustomName";
            this.lblCustomName.Size = new System.Drawing.Size(80, 19);
            this.lblCustomName.TabIndex = 15;
            this.lblCustomName.Text = "Numero Presupuesto:";
            // 
            // lblCustomStatus
            // 
            this.lblCustomStatus.Location = new System.Drawing.Point(5, 249);
            this.lblCustomStatus.Name = "lblCustomStatus";
            this.lblCustomStatus.Size = new System.Drawing.Size(80, 19);
            this.lblCustomStatus.TabIndex = 16;
            this.lblCustomStatus.Text = "Estado:";
            // 
            // txCustomStatus
            // 
            this.txCustomStatus.EditValue = "";
            this.txCustomStatus.Location = new System.Drawing.Point(93, 249);
            this.txCustomStatus.Name = "txCustomStatus";
            this.txCustomStatus.Size = new System.Drawing.Size(263, 20);
            this.txCustomStatus.TabIndex = 8;
            // 
            // dtStart
            // 
            this.dtStart.EditValue = new System.DateTime(2008, 6, 27, 0, 0, 0, 0);
            this.dtStart.Location = new System.Drawing.Point(93, 112);
            this.dtStart.Name = "dtStart";
            this.dtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtStart.Size = new System.Drawing.Size(119, 20);
            this.dtStart.TabIndex = 2;
            this.dtStart.EditValueChanged += new System.EventHandler(this.dtStart_EditValueChanged);
            // 
            // dtEnd
            // 
            this.dtEnd.EditValue = new System.DateTime(2008, 6, 27, 0, 0, 0, 0);
            this.dtEnd.Location = new System.Drawing.Point(189, 325);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEnd.Size = new System.Drawing.Size(96, 20);
            this.dtEnd.TabIndex = 3;
            this.dtEnd.Visible = false;
            this.dtEnd.EditValueChanged += new System.EventHandler(this.dtEnd_EditValueChanged);
            // 
            // timeStart
            // 
            this.timeStart.EditValue = new System.DateTime(2006, 3, 28, 0, 0, 0, 0);
            this.timeStart.Location = new System.Drawing.Point(93, 138);
            this.timeStart.Name = "timeStart";
            this.timeStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeStart.Size = new System.Drawing.Size(119, 20);
            this.timeStart.TabIndex = 3;
            this.timeStart.EditValueChanged += new System.EventHandler(this.timeStart_EditValueChanged);
            // 
            // timeEnd
            // 
            this.timeEnd.EditValue = new System.DateTime(2006, 3, 28, 0, 0, 0, 0);
            this.timeEnd.Location = new System.Drawing.Point(93, 164);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEnd.Size = new System.Drawing.Size(119, 20);
            this.timeEnd.TabIndex = 4;
            this.timeEnd.EditValueChanged += new System.EventHandler(this.timeEnd_EditValueChanged);
            // 
            // checkAllDay
            // 
            this.checkAllDay.Location = new System.Drawing.Point(218, 156);
            this.checkAllDay.Name = "checkAllDay";
            this.checkAllDay.Properties.Caption = "Reservar todo el dia";
            this.checkAllDay.Size = new System.Drawing.Size(138, 20);
            this.checkAllDay.TabIndex = 5;
            this.checkAllDay.CheckedChanged += new System.EventHandler(this.checkAllDay_CheckedChanged);
            // 
            // BarraAcciones
            // 
            this.BarraAcciones.AutoSize = false;
            this.BarraAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BarraAcciones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Aceptar,
            this.Cancelar});
            this.BarraAcciones.Location = new System.Drawing.Point(0, 302);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(447, 54);
            this.BarraAcciones.TabIndex = 41;
            this.BarraAcciones.Text = "toolStrip1";
            // 
            // Aceptar
            // 
            this.Aceptar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Aceptar.Image = global::HK.Properties.Resources.disk_blue_ok;
            this.Aceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(81, 51);
            this.Aceptar.Text = "Aceptar - F12";
            this.Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Cancelar
            // 
            this.Cancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Cancelar.Image = global::HK.Properties.Resources.disk_blue_error;
            this.Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(88, 51);
            this.Cancelar.Text = "Cancelar - ESC";
            this.Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.lblSubject);
            this.groupControl1.Controls.Add(this.checkAllDay);
            this.groupControl1.Controls.Add(this.edLabel);
            this.groupControl1.Controls.Add(this.timeEnd);
            this.groupControl1.Controls.Add(this.edStatus);
            this.groupControl1.Controls.Add(this.timeStart);
            this.groupControl1.Controls.Add(this.lblStatus);
            this.groupControl1.Controls.Add(this.dtEnd);
            this.groupControl1.Controls.Add(this.lblLabel);
            this.groupControl1.Controls.Add(this.dtStart);
            this.groupControl1.Controls.Add(this.lblStart);
            this.groupControl1.Controls.Add(this.txCustomStatus);
            this.groupControl1.Controls.Add(this.lblEnd);
            this.groupControl1.Controls.Add(this.lblCustomName);
            this.groupControl1.Controls.Add(this.lblCustomStatus);
            this.groupControl1.Controls.Add(this.txSubject);
            this.groupControl1.Controls.Add(this.txCustomName);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(423, 282);
            this.groupControl1.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Hasta:";
            this.label1.Visible = false;
            // 
            // txSubject
            // 
            this.txSubject.EditValue = "";
            this.txSubject.Location = new System.Drawing.Point(93, 80);
            this.txSubject.Name = "txSubject";
            this.txSubject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txSubject.Size = new System.Drawing.Size(263, 20);
            this.txSubject.TabIndex = 1;
            this.txSubject.TabStop = false;
            // 
            // txCustomName
            // 
            this.txCustomName.EditValue = "";
            this.txCustomName.Location = new System.Drawing.Point(93, 54);
            this.txCustomName.Name = "txCustomName";
            this.txCustomName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txCustomName.Size = new System.Drawing.Size(121, 20);
            this.txCustomName.TabIndex = 0;
            // 
            // MyAppointmentEditForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(447, 356);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.BarraAcciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyAppointmentEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reservacion";
            this.Activated += new System.EventHandler(this.MyAppointmentEditForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.edLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txCustomStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkAllDay.Properties)).EndInit();
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txCustomName.Properties)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.Container components = null;
		private DevExpress.XtraScheduler.UI.AppointmentLabelEdit edLabel;
		private DevExpress.XtraScheduler.UI.AppointmentStatusEdit edStatus;
		private System.Windows.Forms.Label lblSubject;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label lblLabel;
		private System.Windows.Forms.Label lblStart;
		private System.Windows.Forms.Label lblEnd;
		private System.Windows.Forms.Label lblCustomName;
        private System.Windows.Forms.Label lblCustomStatus;
		private DevExpress.XtraEditors.TextEdit txCustomStatus;
		private DevExpress.XtraEditors.DateEdit dtStart;
		private DevExpress.XtraEditors.DateEdit dtEnd;
		private DevExpress.XtraEditors.TimeEdit timeStart;
		private DevExpress.XtraEditors.TimeEdit timeEnd;
        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripButton Aceptar;
        private System.Windows.Forms.ToolStripButton Cancelar;
        private XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label1;
        private XtraEditors.ButtonEdit txSubject;
        private XtraEditors.ButtonEdit txCustomName;
	}
}
