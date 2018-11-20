namespace HK.Formas
{
    partial class FrmSeniat_LibroVentas
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
            this.Buscar = new System.Windows.Forms.ToolStripSeparator();
            this.txtAño = new System.Windows.Forms.ToolStripComboBox();
            this.txtMes = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.btnImprimirResumido = new System.Windows.Forms.ToolStripButton();
            this.btnPorNumeroZ = new System.Windows.Forms.ToolStripButton();
            this.btnProcesarLibro = new System.Windows.Forms.ToolStripButton();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotaCredito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotaDebito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumeroZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaquinaFiscal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRazonSocial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCedulaRif = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFacturaAfectada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoOperacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoGravable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoExento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIvaRetenido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoGravableContribuyentes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoGravableNoContribuyentes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoIvaContribuyentes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoIvaNoContribuyentes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTasaIvaContribuyentes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTasaIvaNoContribuyentes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.BarraAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
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
            // Buscar
            // 
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(6, 53);
            // 
            // txtAño
            // 
            this.txtAño.Items.AddRange(new object[] {
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015"});
            this.txtAño.Name = "txtAño";
            this.txtAño.Size = new System.Drawing.Size(75, 53);
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
            // btnEditar
            // 
            this.btnEditar.Image = global::HK.Properties.Resources.note_edit;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(73, 50);
            this.btnEditar.Text = "Editar";
            // 
            // BarraAcciones
            // 
            this.BarraAcciones.AutoSize = false;
            this.BarraAcciones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtMes,
            this.txtAño,
            this.btnCargar,
            this.Buscar,
            this.btnNuevo,
            this.btnEditar,
            this.btnEliminar,
            this.toolStripSeparator3,
            this.btnImprimir,
            this.btnImprimirResumido,
            this.btnPorNumeroZ,
            this.btnProcesarLibro});
            this.BarraAcciones.Location = new System.Drawing.Point(0, 0);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(1234, 53);
            this.BarraAcciones.TabIndex = 25;
            this.BarraAcciones.Text = "toolStrip1";
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
            // btnImprimir
            // 
            this.btnImprimir.Image = global::HK.Properties.Resources.printer;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(119, 50);
            this.btnImprimir.Text = "Imprimir Libro";
            // 
            // btnImprimirResumido
            // 
            this.btnImprimirResumido.Image = global::HK.Properties.Resources.printer;
            this.btnImprimirResumido.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimirResumido.Name = "btnImprimirResumido";
            this.btnImprimirResumido.Size = new System.Drawing.Size(145, 50);
            this.btnImprimirResumido.Text = "Imprimir Resumido";
            // 
            // btnPorNumeroZ
            // 
            this.btnPorNumeroZ.Image = global::HK.Properties.Resources.printer;
            this.btnPorNumeroZ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPorNumeroZ.Name = "btnPorNumeroZ";
            this.btnPorNumeroZ.Size = new System.Drawing.Size(118, 50);
            this.btnPorNumeroZ.Text = "Por Numero Z";
            // 
            // btnProcesarLibro
            // 
            this.btnProcesarLibro.Image = global::HK.Properties.Resources.gears;
            this.btnProcesarLibro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProcesarLibro.Name = "btnProcesarLibro";
            this.btnProcesarLibro.Size = new System.Drawing.Size(118, 50);
            this.btnProcesarLibro.Text = "Procesar Libro";
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.ColumnPanelRowHeight = 45;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFecha,
            this.colFactura,
            this.colNotaCredito,
            this.colNotaDebito,
            this.colNumeroZ,
            this.colMaquinaFiscal,
            this.colRazonSocial,
            this.colCedulaRif,
            this.colComprobante,
            this.colFacturaAfectada,
            this.colTipoOperacion,
            this.colMontoTotal,
            this.colMontoGravable,
            this.colMontoExento,
            this.colMontoIva,
            this.colIvaRetenido,
            this.colMontoGravableContribuyentes,
            this.colMontoGravableNoContribuyentes,
            this.colMontoIvaContribuyentes,
            this.colMontoIvaNoContribuyentes,
            this.colTasaIvaContribuyentes,
            this.colTasaIvaNoContribuyentes});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(808, 338, 216, 199);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
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
            this.colFecha.OptionsColumn.AllowEdit = false;
            this.colFecha.OptionsColumn.FixedWidth = true;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            // 
            // colFactura
            // 
            this.colFactura.FieldName = "Factura";
            this.colFactura.Name = "colFactura";
            this.colFactura.OptionsColumn.AllowEdit = false;
            this.colFactura.OptionsColumn.FixedWidth = true;
            this.colFactura.Visible = true;
            this.colFactura.VisibleIndex = 1;
            // 
            // colNotaCredito
            // 
            this.colNotaCredito.FieldName = "NotaCredito";
            this.colNotaCredito.Name = "colNotaCredito";
            this.colNotaCredito.OptionsColumn.AllowEdit = false;
            this.colNotaCredito.OptionsColumn.FixedWidth = true;
            this.colNotaCredito.Visible = true;
            this.colNotaCredito.VisibleIndex = 2;
            // 
            // colNotaDebito
            // 
            this.colNotaDebito.FieldName = "NotaDebito";
            this.colNotaDebito.Name = "colNotaDebito";
            this.colNotaDebito.OptionsColumn.AllowEdit = false;
            this.colNotaDebito.OptionsColumn.FixedWidth = true;
            this.colNotaDebito.Visible = true;
            this.colNotaDebito.VisibleIndex = 3;
            // 
            // colNumeroZ
            // 
            this.colNumeroZ.FieldName = "NumeroZ";
            this.colNumeroZ.Name = "colNumeroZ";
            this.colNumeroZ.OptionsColumn.AllowEdit = false;
            this.colNumeroZ.OptionsColumn.FixedWidth = true;
            this.colNumeroZ.Visible = true;
            this.colNumeroZ.VisibleIndex = 4;
            // 
            // colMaquinaFiscal
            // 
            this.colMaquinaFiscal.FieldName = "MaquinaFiscal";
            this.colMaquinaFiscal.Name = "colMaquinaFiscal";
            this.colMaquinaFiscal.OptionsColumn.AllowEdit = false;
            this.colMaquinaFiscal.OptionsColumn.FixedWidth = true;
            this.colMaquinaFiscal.Visible = true;
            this.colMaquinaFiscal.VisibleIndex = 5;
            // 
            // colRazonSocial
            // 
            this.colRazonSocial.FieldName = "RazonSocial";
            this.colRazonSocial.Name = "colRazonSocial";
            this.colRazonSocial.OptionsColumn.AllowEdit = false;
            this.colRazonSocial.Visible = true;
            this.colRazonSocial.VisibleIndex = 6;
            // 
            // colCedulaRif
            // 
            this.colCedulaRif.FieldName = "CedulaRif";
            this.colCedulaRif.Name = "colCedulaRif";
            this.colCedulaRif.OptionsColumn.AllowEdit = false;
            this.colCedulaRif.OptionsColumn.FixedWidth = true;
            this.colCedulaRif.Visible = true;
            this.colCedulaRif.VisibleIndex = 7;
            // 
            // colComprobante
            // 
            this.colComprobante.FieldName = "Comprobante";
            this.colComprobante.Name = "colComprobante";
            this.colComprobante.OptionsColumn.AllowEdit = false;
            this.colComprobante.OptionsColumn.FixedWidth = true;
            this.colComprobante.Visible = true;
            this.colComprobante.VisibleIndex = 8;
            // 
            // colFacturaAfectada
            // 
            this.colFacturaAfectada.FieldName = "FacturaAfectada";
            this.colFacturaAfectada.Name = "colFacturaAfectada";
            this.colFacturaAfectada.OptionsColumn.AllowEdit = false;
            this.colFacturaAfectada.OptionsColumn.FixedWidth = true;
            this.colFacturaAfectada.Visible = true;
            this.colFacturaAfectada.VisibleIndex = 9;
            // 
            // colTipoOperacion
            // 
            this.colTipoOperacion.FieldName = "TipoOperacion";
            this.colTipoOperacion.Name = "colTipoOperacion";
            this.colTipoOperacion.OptionsColumn.AllowEdit = false;
            this.colTipoOperacion.OptionsColumn.FixedWidth = true;
            this.colTipoOperacion.Visible = true;
            this.colTipoOperacion.VisibleIndex = 10;
            // 
            // colMontoTotal
            // 
            this.colMontoTotal.DisplayFormat.FormatString = "{0:n2)";
            this.colMontoTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontoTotal.FieldName = "MontoTotal";
            this.colMontoTotal.Name = "colMontoTotal";
            this.colMontoTotal.OptionsColumn.AllowEdit = false;
            this.colMontoTotal.OptionsColumn.FixedWidth = true;
            this.colMontoTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoTotal", "{0:n2}")});
            this.colMontoTotal.Visible = true;
            this.colMontoTotal.VisibleIndex = 11;
            // 
            // colMontoGravable
            // 
            this.colMontoGravable.DisplayFormat.FormatString = "{0:n2)";
            this.colMontoGravable.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontoGravable.FieldName = "MontoGravable";
            this.colMontoGravable.Name = "colMontoGravable";
            this.colMontoGravable.OptionsColumn.AllowEdit = false;
            this.colMontoGravable.OptionsColumn.FixedWidth = true;
            this.colMontoGravable.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoGravable", "{0:n2}")});
            this.colMontoGravable.Visible = true;
            this.colMontoGravable.VisibleIndex = 12;
            // 
            // colMontoExento
            // 
            this.colMontoExento.DisplayFormat.FormatString = "{0:n2)";
            this.colMontoExento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontoExento.FieldName = "MontoExento";
            this.colMontoExento.Name = "colMontoExento";
            this.colMontoExento.OptionsColumn.AllowEdit = false;
            this.colMontoExento.OptionsColumn.FixedWidth = true;
            this.colMontoExento.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoExento", "{0:n2}")});
            this.colMontoExento.Visible = true;
            this.colMontoExento.VisibleIndex = 13;
            // 
            // colMontoIva
            // 
            this.colMontoIva.DisplayFormat.FormatString = "{0:n2)";
            this.colMontoIva.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontoIva.FieldName = "MontoIva";
            this.colMontoIva.Name = "colMontoIva";
            this.colMontoIva.OptionsColumn.AllowEdit = false;
            this.colMontoIva.OptionsColumn.FixedWidth = true;
            this.colMontoIva.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoIva", "{0:n2}")});
            this.colMontoIva.Visible = true;
            this.colMontoIva.VisibleIndex = 14;
            // 
            // colIvaRetenido
            // 
            this.colIvaRetenido.DisplayFormat.FormatString = "{0:n2)";
            this.colIvaRetenido.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colIvaRetenido.FieldName = "IvaRetenido";
            this.colIvaRetenido.Name = "colIvaRetenido";
            this.colIvaRetenido.OptionsColumn.AllowEdit = false;
            this.colIvaRetenido.OptionsColumn.FixedWidth = true;
            this.colIvaRetenido.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "IvaRetenido", "{0:n2}")});
            this.colIvaRetenido.Visible = true;
            this.colIvaRetenido.VisibleIndex = 15;
            // 
            // colMontoGravableContribuyentes
            // 
            this.colMontoGravableContribuyentes.DisplayFormat.FormatString = "{0:n2)";
            this.colMontoGravableContribuyentes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontoGravableContribuyentes.FieldName = "MontoGravableContribuyentes";
            this.colMontoGravableContribuyentes.Name = "colMontoGravableContribuyentes";
            this.colMontoGravableContribuyentes.OptionsColumn.AllowEdit = false;
            this.colMontoGravableContribuyentes.OptionsColumn.FixedWidth = true;
            this.colMontoGravableContribuyentes.Visible = true;
            this.colMontoGravableContribuyentes.VisibleIndex = 16;
            // 
            // colMontoGravableNoContribuyentes
            // 
            this.colMontoGravableNoContribuyentes.DisplayFormat.FormatString = "{0:n2)";
            this.colMontoGravableNoContribuyentes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontoGravableNoContribuyentes.FieldName = "MontoGravableNoContribuyentes";
            this.colMontoGravableNoContribuyentes.Name = "colMontoGravableNoContribuyentes";
            this.colMontoGravableNoContribuyentes.OptionsColumn.AllowEdit = false;
            this.colMontoGravableNoContribuyentes.OptionsColumn.FixedWidth = true;
            this.colMontoGravableNoContribuyentes.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoGravableNoContribuyentes", "{0:n2}")});
            this.colMontoGravableNoContribuyentes.Visible = true;
            this.colMontoGravableNoContribuyentes.VisibleIndex = 17;
            // 
            // colMontoIvaContribuyentes
            // 
            this.colMontoIvaContribuyentes.DisplayFormat.FormatString = "{0:n2)";
            this.colMontoIvaContribuyentes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontoIvaContribuyentes.FieldName = "MontoIvaContribuyentes";
            this.colMontoIvaContribuyentes.Name = "colMontoIvaContribuyentes";
            this.colMontoIvaContribuyentes.OptionsColumn.AllowEdit = false;
            this.colMontoIvaContribuyentes.OptionsColumn.FixedWidth = true;
            this.colMontoIvaContribuyentes.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoIvaContribuyentes", "{0:n2}")});
            this.colMontoIvaContribuyentes.Visible = true;
            this.colMontoIvaContribuyentes.VisibleIndex = 18;
            // 
            // colMontoIvaNoContribuyentes
            // 
            this.colMontoIvaNoContribuyentes.DisplayFormat.FormatString = "{0:n2)";
            this.colMontoIvaNoContribuyentes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontoIvaNoContribuyentes.FieldName = "MontoIvaNoContribuyentes";
            this.colMontoIvaNoContribuyentes.Name = "colMontoIvaNoContribuyentes";
            this.colMontoIvaNoContribuyentes.OptionsColumn.AllowEdit = false;
            this.colMontoIvaNoContribuyentes.OptionsColumn.FixedWidth = true;
            this.colMontoIvaNoContribuyentes.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoIvaNoContribuyentes", "{0:n2}")});
            this.colMontoIvaNoContribuyentes.Visible = true;
            this.colMontoIvaNoContribuyentes.VisibleIndex = 19;
            // 
            // colTasaIvaContribuyentes
            // 
            this.colTasaIvaContribuyentes.DisplayFormat.FormatString = "{0:n2)";
            this.colTasaIvaContribuyentes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTasaIvaContribuyentes.FieldName = "TasaIvaContribuyentes";
            this.colTasaIvaContribuyentes.Name = "colTasaIvaContribuyentes";
            this.colTasaIvaContribuyentes.OptionsColumn.AllowEdit = false;
            this.colTasaIvaContribuyentes.OptionsColumn.FixedWidth = true;
            this.colTasaIvaContribuyentes.Visible = true;
            this.colTasaIvaContribuyentes.VisibleIndex = 20;
            // 
            // colTasaIvaNoContribuyentes
            // 
            this.colTasaIvaNoContribuyentes.DisplayFormat.FormatString = "{0:n2)";
            this.colTasaIvaNoContribuyentes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTasaIvaNoContribuyentes.FieldName = "TasaIvaNoContribuyentes";
            this.colTasaIvaNoContribuyentes.Name = "colTasaIvaNoContribuyentes";
            this.colTasaIvaNoContribuyentes.OptionsColumn.AllowEdit = false;
            this.colTasaIvaNoContribuyentes.OptionsColumn.FixedWidth = true;
            this.colTasaIvaNoContribuyentes.Visible = true;
            this.colTasaIvaNoContribuyentes.VisibleIndex = 21;
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
            this.gridControl1.Size = new System.Drawing.Size(1233, 507);
            this.gridControl1.TabIndex = 26;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bs
            // 
            this.bs.DataSource = typeof(HK.LibroVenta);
            // 
            // FrmSeniat_LibroVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 566);
            this.Controls.Add(this.BarraAcciones);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmSeniat_LibroVentas";
            this.Text = "Libro Ventas";
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnCargar;
        private System.Windows.Forms.ToolStripSeparator Buscar;
        private System.Windows.Forms.ToolStripComboBox txtAño;
        private System.Windows.Forms.ToolStripComboBox txtMes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnEditar;
        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.ToolStripButton btnImprimirResumido;
        private System.Windows.Forms.ToolStripButton btnPorNumeroZ;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colNotaCredito;
        private DevExpress.XtraGrid.Columns.GridColumn colNotaDebito;
        private DevExpress.XtraGrid.Columns.GridColumn colNumeroZ;
        private DevExpress.XtraGrid.Columns.GridColumn colMaquinaFiscal;
        private DevExpress.XtraGrid.Columns.GridColumn colRazonSocial;
        private DevExpress.XtraGrid.Columns.GridColumn colCedulaRif;
        private DevExpress.XtraGrid.Columns.GridColumn colComprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colFacturaAfectada;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoOperacion;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoGravable;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoExento;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoIva;
        private DevExpress.XtraGrid.Columns.GridColumn colIvaRetenido;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoGravableContribuyentes;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoGravableNoContribuyentes;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoIvaContribuyentes;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoIvaNoContribuyentes;
        private DevExpress.XtraGrid.Columns.GridColumn colTasaIvaContribuyentes;
        private DevExpress.XtraGrid.Columns.GridColumn colTasaIvaNoContribuyentes;
        private System.Windows.Forms.ToolStripButton btnProcesarLibro;
    }
}