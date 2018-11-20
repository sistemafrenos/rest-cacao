namespace HK.Formas
{
    partial class FrmCierrePuntoDeVentas
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
            this.components = new System.ComponentModel.Container();
            this.cajaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHora = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarjetaCredito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarjetaDebito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComisionPunto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetoDepositar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.Aceptar = new System.Windows.Forms.ToolStripButton();
            this.Cancelar = new System.Windows.Forms.ToolStripButton();
            this.CuentaBancariaButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFecha = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnCargar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cajaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.BarraAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CuentaBancariaButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cajaBindingSource
            // 
            this.cajaBindingSource.DataSource = typeof(HK.Pago);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.cajaBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 61);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(591, 223);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFecha,
            this.colHora,
            this.colTarjetaCredito,
            this.colTarjetaDebito,
            this.colComisionPunto,
            this.colNetoDepositar});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colFecha
            // 
            this.colFecha.DisplayFormat.FormatString = "d";
            this.colFecha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFecha.FieldName = "Fecha";
            this.colFecha.GroupFormat.FormatString = "d";
            this.colFecha.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            this.colFecha.Width = 80;
            // 
            // colHora
            // 
            this.colHora.DisplayFormat.FormatString = "t";
            this.colHora.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colHora.FieldName = "Hora";
            this.colHora.GroupFormat.FormatString = "t";
            this.colHora.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colHora.Name = "colHora";
            this.colHora.Visible = true;
            this.colHora.VisibleIndex = 1;
            this.colHora.Width = 70;
            // 
            // colTarjetaCredito
            // 
            this.colTarjetaCredito.DisplayFormat.FormatString = "n2";
            this.colTarjetaCredito.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTarjetaCredito.FieldName = "TarjetaCredito";
            this.colTarjetaCredito.GroupFormat.FormatString = "n2";
            this.colTarjetaCredito.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTarjetaCredito.Name = "colTarjetaCredito";
            this.colTarjetaCredito.SummaryItem.DisplayFormat = "{0:n2}";
            this.colTarjetaCredito.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colTarjetaCredito.Visible = true;
            this.colTarjetaCredito.VisibleIndex = 2;
            this.colTarjetaCredito.Width = 102;
            // 
            // colTarjetaDebito
            // 
            this.colTarjetaDebito.DisplayFormat.FormatString = "n2";
            this.colTarjetaDebito.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTarjetaDebito.FieldName = "TarjetaDebito";
            this.colTarjetaDebito.GroupFormat.FormatString = "n2";
            this.colTarjetaDebito.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTarjetaDebito.Name = "colTarjetaDebito";
            this.colTarjetaDebito.SummaryItem.DisplayFormat = "{0:n2}";
            this.colTarjetaDebito.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colTarjetaDebito.Visible = true;
            this.colTarjetaDebito.VisibleIndex = 3;
            this.colTarjetaDebito.Width = 102;
            // 
            // colComisionPunto
            // 
            this.colComisionPunto.DisplayFormat.FormatString = "n2";
            this.colComisionPunto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colComisionPunto.FieldName = "ComisionPunto";
            this.colComisionPunto.GroupFormat.FormatString = "n2";
            this.colComisionPunto.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colComisionPunto.Name = "colComisionPunto";
            this.colComisionPunto.SummaryItem.DisplayFormat = "{0:n2}";
            this.colComisionPunto.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colComisionPunto.Visible = true;
            this.colComisionPunto.VisibleIndex = 4;
            this.colComisionPunto.Width = 102;
            // 
            // colNetoDepositar
            // 
            this.colNetoDepositar.DisplayFormat.FormatString = "n2";
            this.colNetoDepositar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNetoDepositar.FieldName = "NetoDepositar";
            this.colNetoDepositar.GroupFormat.FormatString = "n2";
            this.colNetoDepositar.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNetoDepositar.Name = "colNetoDepositar";
            this.colNetoDepositar.SummaryItem.DisplayFormat = "{0:n2}";
            this.colNetoDepositar.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colNetoDepositar.Visible = true;
            this.colNetoDepositar.VisibleIndex = 5;
            this.colNetoDepositar.Width = 114;
            // 
            // BarraAcciones
            // 
            this.BarraAcciones.AutoSize = false;
            this.BarraAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BarraAcciones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Aceptar,
            this.Cancelar});
            this.BarraAcciones.Location = new System.Drawing.Point(0, 288);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(615, 58);
            this.BarraAcciones.TabIndex = 43;
            this.BarraAcciones.Text = "toolStrip1";
            // 
            // Aceptar
            // 
            this.Aceptar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Aceptar.Image = global::HK.Properties.Resources.disk_blue_ok;
            this.Aceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(77, 55);
            this.Aceptar.Text = "Aceptar - F12";
            this.Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Cancelar
            // 
            this.Cancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Cancelar.Image = global::HK.Properties.Resources.disk_blue_error;
            this.Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(82, 55);
            this.Cancelar.Text = "Cancelar - ESC";
            this.Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // CuentaBancariaButtonEdit
            // 
            this.CuentaBancariaButtonEdit.Location = new System.Drawing.Point(116, 37);
            this.CuentaBancariaButtonEdit.Name = "CuentaBancariaButtonEdit";
            this.CuentaBancariaButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.CuentaBancariaButtonEdit.Size = new System.Drawing.Size(262, 20);
            this.CuentaBancariaButtonEdit.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Cuenta a Depositar";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(503, 35);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 47;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(460, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 48;
            this.labelControl1.Text = "Numero";
            // 
            // txtFecha
            // 
            this.txtFecha.EditValue = null;
            this.txtFecha.Location = new System.Drawing.Point(116, 9);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFecha.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtFecha.Size = new System.Drawing.Size(100, 20);
            this.txtFecha.TabIndex = 49;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(73, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(29, 13);
            this.labelControl2.TabIndex = 50;
            this.labelControl2.Text = "Fecha";
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(222, 8);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(156, 23);
            this.btnCargar.TabIndex = 51;
            this.btnCargar.Text = "Cargar";
            // 
            // FrmCierrePuntoDeVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 346);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CuentaBancariaButtonEdit);
            this.Controls.Add(this.BarraAcciones);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCierrePuntoDeVentas";
            this.Text = "Cierre Punto Ventas";
            ((System.ComponentModel.ISupportInitialize)(this.cajaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CuentaBancariaButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource cajaBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colHora;
        private DevExpress.XtraGrid.Columns.GridColumn colTarjetaCredito;
        private DevExpress.XtraGrid.Columns.GridColumn colTarjetaDebito;
        private DevExpress.XtraGrid.Columns.GridColumn colComisionPunto;
        private DevExpress.XtraGrid.Columns.GridColumn colNetoDepositar;
        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripButton Aceptar;
        private System.Windows.Forms.ToolStripButton Cancelar;
        private DevExpress.XtraEditors.ButtonEdit CuentaBancariaButtonEdit;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit txtFecha;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCargar;
    }
}