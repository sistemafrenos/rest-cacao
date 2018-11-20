namespace HK.Formas
{
    partial class FrmSeniat_LibroInventarios
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInicio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntradas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalidas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutoconsumo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.txtMes = new System.Windows.Forms.ToolStripComboBox();
            this.txtAno = new System.Windows.Forms.ToolStripComboBox();
            this.btnCargar = new System.Windows.Forms.ToolStripButton();
            this.Buscar = new System.Windows.Forms.ToolStripSeparator();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.BarraAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.ColumnPanelRowHeight = 45;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInicio,
            this.colEntradas,
            this.colSalidas,
            this.colAutoconsumo,
            this.colFinal,
            this.colCosto,
            this.colProducto,
            this.colCodigo});
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
            // colInicio
            // 
            this.colInicio.DisplayFormat.FormatString = "n2";
            this.colInicio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colInicio.FieldName = "Inicio";
            this.colInicio.GroupFormat.FormatString = "n2";
            this.colInicio.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colInicio.Name = "colInicio";
            this.colInicio.OptionsColumn.FixedWidth = true;
            this.colInicio.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Inicio", "{0:n2}")});
            this.colInicio.Visible = true;
            this.colInicio.VisibleIndex = 3;
            // 
            // colEntradas
            // 
            this.colEntradas.DisplayFormat.FormatString = "n2";
            this.colEntradas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEntradas.FieldName = "Entradas";
            this.colEntradas.GroupFormat.FormatString = "n2";
            this.colEntradas.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEntradas.Name = "colEntradas";
            this.colEntradas.OptionsColumn.FixedWidth = true;
            this.colEntradas.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Entradas", "{0:n2}")});
            this.colEntradas.Visible = true;
            this.colEntradas.VisibleIndex = 4;
            // 
            // colSalidas
            // 
            this.colSalidas.DisplayFormat.FormatString = "n2";
            this.colSalidas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSalidas.FieldName = "Salidas";
            this.colSalidas.GroupFormat.FormatString = "n2";
            this.colSalidas.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSalidas.Name = "colSalidas";
            this.colSalidas.OptionsColumn.FixedWidth = true;
            this.colSalidas.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Salidas", "{0:n2}")});
            this.colSalidas.Visible = true;
            this.colSalidas.VisibleIndex = 5;
            // 
            // colAutoconsumo
            // 
            this.colAutoconsumo.Caption = "Auto Consumo";
            this.colAutoconsumo.DisplayFormat.FormatString = "n2";
            this.colAutoconsumo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAutoconsumo.FieldName = "Autoconsumo";
            this.colAutoconsumo.GroupFormat.FormatString = "n2";
            this.colAutoconsumo.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAutoconsumo.Name = "colAutoconsumo";
            this.colAutoconsumo.OptionsColumn.FixedWidth = true;
            this.colAutoconsumo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Autoconsumo", "{0:n2}")});
            this.colAutoconsumo.Visible = true;
            this.colAutoconsumo.VisibleIndex = 6;
            // 
            // colFinal
            // 
            this.colFinal.DisplayFormat.FormatString = "n2";
            this.colFinal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFinal.FieldName = "Final";
            this.colFinal.GroupFormat.FormatString = "n2";
            this.colFinal.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFinal.Name = "colFinal";
            this.colFinal.OptionsColumn.FixedWidth = true;
            this.colFinal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Final", "{0:n2}")});
            this.colFinal.Visible = true;
            this.colFinal.VisibleIndex = 7;
            // 
            // colCosto
            // 
            this.colCosto.DisplayFormat.FormatString = "n2";
            this.colCosto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCosto.FieldName = "Costo";
            this.colCosto.GroupFormat.FormatString = "n2";
            this.colCosto.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCosto.Name = "colCosto";
            this.colCosto.Visible = true;
            this.colCosto.VisibleIndex = 2;
            // 
            // colProducto
            // 
            this.colProducto.FieldName = "Descripcion";
            this.colProducto.Name = "colProducto";
            this.colProducto.Visible = true;
            this.colProducto.VisibleIndex = 1;
            this.colProducto.Width = 329;
            // 
            // colCodigo
            // 
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 0;
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
            this.gridControl1.Size = new System.Drawing.Size(1015, 507);
            this.gridControl1.TabIndex = 22;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bs
            // 
            this.bs.DataSource = typeof(HK.LibroInventario);
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
            this.btnImprimir});
            this.BarraAcciones.Location = new System.Drawing.Point(0, 0);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(1016, 53);
            this.BarraAcciones.TabIndex = 21;
            this.BarraAcciones.Text = "toolStrip1";
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
            // btnNuevo
            // 
            this.btnNuevo.Image = global::HK.Properties.Resources.note_add;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(78, 50);
            this.btnNuevo.Text = "Nuevo";
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::HK.Properties.Resources.note_edit;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(73, 50);
            this.btnEditar.Text = "Editar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::HK.Properties.Resources.note_delete;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(86, 50);
            this.btnEliminar.Text = "Eliminar";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 53);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::HK.Properties.Resources.printer;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(119, 50);
            this.btnImprimir.Text = "Imprimir Libro";
            // 
            // FrmSeniat_LibroInventarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 566);
            this.Controls.Add(this.BarraAcciones);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmSeniat_LibroInventarios";
            this.Text = "Libro Inventarios";
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource bs;
        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private DevExpress.XtraGrid.Columns.GridColumn colInicio;
        private DevExpress.XtraGrid.Columns.GridColumn colEntradas;
        private DevExpress.XtraGrid.Columns.GridColumn colSalidas;
        private DevExpress.XtraGrid.Columns.GridColumn colFinal;
        private DevExpress.XtraGrid.Columns.GridColumn colCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colProducto;
        private System.Windows.Forms.ToolStripComboBox txtMes;
        private System.Windows.Forms.ToolStripComboBox txtAno;
        private System.Windows.Forms.ToolStripButton btnCargar;
        private System.Windows.Forms.ToolStripSeparator Buscar;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoconsumo;
    }
}