namespace HK.Formas
{
    partial class FrmSeniat_LibroCompras
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
            this.btnCargar = new System.Windows.Forms.ToolStripButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCedulaRif = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumeroControl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoExento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoGravable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTasaIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoGrabableB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTasaIvaB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRazonSocial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIvaRetenido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobanteRetencion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtAno = new System.Windows.Forms.ToolStripComboBox();
            this.Buscar = new System.Windows.Forms.ToolStripSeparator();
            this.txtMes = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.btnProcesarLibro = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.BarraAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCargar
            // 
            this.btnCargar.Image = global::HK.Properties.Resources.note_find;
            this.btnCargar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(78, 50);
            this.btnCargar.Text = "Cargar";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.bs;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Begin;
            this.gridControl1.Location = new System.Drawing.Point(0, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.Size = new System.Drawing.Size(1016, 507);
            this.gridControl1.TabIndex = 24;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bs
            // 
            this.bs.DataSource = typeof(HK.LibroCompra);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.ColumnPanelRowHeight = 45;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFecha,
            this.colNumero,
            this.colDireccion,
            this.colCedulaRif,
            this.colNumeroControl,
            this.colMontoExento,
            this.colMontoGravable,
            this.colTasaIva,
            this.colMontoGrabableB,
            this.colTasaIvaB,
            this.colMontoIva,
            this.colMontoTotal,
            this.colRazonSocial,
            this.colIvaRetenido,
            this.colComprobanteRetencion});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(808, 338, 216, 199);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            // 
            // colNumero
            // 
            this.colNumero.FieldName = "Numero";
            this.colNumero.Name = "colNumero";
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 1;
            this.colNumero.Width = 115;
            // 
            // colDireccion
            // 
            this.colDireccion.FieldName = "Direccion";
            this.colDireccion.Name = "colDireccion";
            // 
            // colCedulaRif
            // 
            this.colCedulaRif.FieldName = "CedulaRif";
            this.colCedulaRif.Name = "colCedulaRif";
            this.colCedulaRif.Visible = true;
            this.colCedulaRif.VisibleIndex = 3;
            this.colCedulaRif.Width = 115;
            // 
            // colNumeroControl
            // 
            this.colNumeroControl.FieldName = "NumeroControl";
            this.colNumeroControl.Name = "colNumeroControl";
            this.colNumeroControl.Visible = true;
            this.colNumeroControl.VisibleIndex = 2;
            this.colNumeroControl.Width = 99;
            // 
            // colMontoExento
            // 
            this.colMontoExento.FieldName = "MontoExento";
            this.colMontoExento.Name = "colMontoExento";
            this.colMontoExento.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoExento", "{0:n2}")});
            this.colMontoExento.Visible = true;
            this.colMontoExento.VisibleIndex = 5;
            // 
            // colMontoGravable
            // 
            this.colMontoGravable.FieldName = "MontoGravable";
            this.colMontoGravable.Name = "colMontoGravable";
            this.colMontoGravable.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoGravable", "{0:n2}")});
            this.colMontoGravable.Visible = true;
            this.colMontoGravable.VisibleIndex = 6;
            // 
            // colTasaIva
            // 
            this.colTasaIva.FieldName = "TasaIva";
            this.colTasaIva.Name = "colTasaIva";
            this.colTasaIva.Visible = true;
            this.colTasaIva.VisibleIndex = 9;
            // 
            // colMontoGrabableB
            // 
            this.colMontoGrabableB.FieldName = "MontoGrabableB";
            this.colMontoGrabableB.Name = "colMontoGrabableB";
            this.colMontoGrabableB.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoGrabableB", "{0:n2}")});
            // 
            // colTasaIvaB
            // 
            this.colTasaIvaB.FieldName = "TasaIvaB";
            this.colTasaIvaB.Name = "colTasaIvaB";
            // 
            // colMontoIva
            // 
            this.colMontoIva.FieldName = "MontoIva";
            this.colMontoIva.Name = "colMontoIva";
            this.colMontoIva.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoIva", "{0:n2}")});
            this.colMontoIva.Visible = true;
            this.colMontoIva.VisibleIndex = 7;
            // 
            // colMontoTotal
            // 
            this.colMontoTotal.FieldName = "MontoTotal";
            this.colMontoTotal.Name = "colMontoTotal";
            this.colMontoTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoTotal", "{0:n2}")});
            this.colMontoTotal.Visible = true;
            this.colMontoTotal.VisibleIndex = 8;
            // 
            // colRazonSocial
            // 
            this.colRazonSocial.FieldName = "RazonSocial";
            this.colRazonSocial.Name = "colRazonSocial";
            this.colRazonSocial.Visible = true;
            this.colRazonSocial.VisibleIndex = 4;
            this.colRazonSocial.Width = 168;
            // 
            // colIvaRetenido
            // 
            this.colIvaRetenido.FieldName = "IvaRetenido";
            this.colIvaRetenido.Name = "colIvaRetenido";
            this.colIvaRetenido.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "IvaRetenido", "{0:n2}")});
            this.colIvaRetenido.Visible = true;
            this.colIvaRetenido.VisibleIndex = 10;
            // 
            // colComprobanteRetencion
            // 
            this.colComprobanteRetencion.FieldName = "ComprobanteRetencion";
            this.colComprobanteRetencion.Name = "colComprobanteRetencion";
            this.colComprobanteRetencion.Width = 107;
            // 
            // txtAno
            // 
            this.txtAno.Items.AddRange(new object[] {
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015"});
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(75, 53);
            // 
            // Buscar
            // 
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(6, 53);
            // 
            // txtMes
            // 
            this.txtMes.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(75, 53);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 53);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::HK.Properties.Resources.note_add;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(78, 50);
            this.btnNuevo.Text = "Nuevo";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::HK.Properties.Resources.note_delete;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(86, 50);
            this.btnEliminar.Text = "Eliminar";
            // 
            // BarraAcciones
            // 
            this.BarraAcciones.AutoSize = false;
            this.BarraAcciones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtMes,
            this.txtAno,
            this.btnCargar,
            this.Buscar,
            this.btnNuevo,
            this.btnEditar,
            this.btnEliminar,
            this.toolStripSeparator3,
            this.btnImprimir,
            this.btnProcesarLibro});
            this.BarraAcciones.Location = new System.Drawing.Point(0, 0);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(1016, 53);
            this.BarraAcciones.TabIndex = 23;
            this.BarraAcciones.Text = "toolStrip1";
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::HK.Properties.Resources.note_edit;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(73, 50);
            this.btnEditar.Text = "Editar";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::HK.Properties.Resources.printer;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(119, 50);
            this.btnImprimir.Text = "Imprimir Libro";
            // 
            // btnProcesarLibro
            // 
            this.btnProcesarLibro.Image = global::HK.Properties.Resources.gears;
            this.btnProcesarLibro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProcesarLibro.Name = "btnProcesarLibro";
            this.btnProcesarLibro.Size = new System.Drawing.Size(118, 50);
            this.btnProcesarLibro.Text = "Procesar Libro";
            // 
            // FrmSeniat_LibroCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 566);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.BarraAcciones);
            this.Name = "FrmSeniat_LibroCompras";
            this.Text = "Libro Compras";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnCargar;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource bs;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ToolStripComboBox txtAno;
        private System.Windows.Forms.ToolStripSeparator Buscar;
        private System.Windows.Forms.ToolStripComboBox txtMes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colDireccion;
        private DevExpress.XtraGrid.Columns.GridColumn colCedulaRif;
        private DevExpress.XtraGrid.Columns.GridColumn colNumeroControl;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoExento;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoGravable;
        private DevExpress.XtraGrid.Columns.GridColumn colTasaIva;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoGrabableB;
        private DevExpress.XtraGrid.Columns.GridColumn colTasaIvaB;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoIva;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colRazonSocial;
        private DevExpress.XtraGrid.Columns.GridColumn colIvaRetenido;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobanteRetencion;
        private System.Windows.Forms.ToolStripButton btnProcesarLibro;
    }
}