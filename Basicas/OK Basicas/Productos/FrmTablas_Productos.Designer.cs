namespace HK.Formas
{
    partial class FrmTablas_Productos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTablas_Productos));
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoProveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecio2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTasaIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExistencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMinimo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecioConIva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecioConIva2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.btnCopiar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEntradas = new System.Windows.Forms.ToolStripButton();
            this.btnSalidas = new System.Windows.Forms.ToolStripButton();
            this.btnMovimientos = new System.Windows.Forms.ToolStripButton();
            this.btnCalcularExistencias = new System.Windows.Forms.ToolStripButton();
            this.btnAjustePrecios = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.colPrecio3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecio4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecioConIva3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecioConIva4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.BarraAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(21, 22);
            this.bindingNavigatorCountItem.Text = "{0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.DataSource = this.bs;
            this.gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControl1.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Begin;
            this.gridControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(0, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.Size = new System.Drawing.Size(1103, 481);
            this.gridControl1.TabIndex = 26;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bs
            // 
            this.bs.DataSource = typeof(HK.Producto);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.ColumnPanelRowHeight = 45;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodigo,
            this.colCodigoProveedor,
            this.colDepartamento,
            this.colDescripcion,
            this.colCosto,
            this.colPrecio,
            this.colPrecio2,
            this.colPrecio3,
            this.colPrecio4,
            this.colTasaIva,
            this.colExistencia,
            this.colMinimo,
            this.colPrecioConIva,
            this.colPrecioConIva2,
            this.colPrecioConIva3,
            this.colPrecioConIva4});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colCodigo
            // 
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.OptionsColumn.FixedWidth = true;
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 0;
            // 
            // colCodigoProveedor
            // 
            this.colCodigoProveedor.FieldName = "CodigoProveedor";
            this.colCodigoProveedor.Name = "colCodigoProveedor";
            this.colCodigoProveedor.OptionsColumn.FixedWidth = true;
            this.colCodigoProveedor.Visible = true;
            this.colCodigoProveedor.VisibleIndex = 1;
            // 
            // colDepartamento
            // 
            this.colDepartamento.FieldName = "Departamento";
            this.colDepartamento.Name = "colDepartamento";
            this.colDepartamento.Visible = true;
            this.colDepartamento.VisibleIndex = 2;
            this.colDepartamento.Width = 150;
            // 
            // colDescripcion
            // 
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 3;
            this.colDescripcion.Width = 225;
            // 
            // colCosto
            // 
            this.colCosto.DisplayFormat.FormatString = "n2";
            this.colCosto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCosto.FieldName = "Costo";
            this.colCosto.GroupFormat.FormatString = "n2";
            this.colCosto.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCosto.Name = "colCosto";
            this.colCosto.OptionsColumn.FixedWidth = true;
            this.colCosto.Visible = true;
            this.colCosto.VisibleIndex = 4;
            // 
            // colPrecio
            // 
            this.colPrecio.DisplayFormat.FormatString = "N2";
            this.colPrecio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecio.FieldName = "Precio";
            this.colPrecio.GroupFormat.FormatString = "n2";
            this.colPrecio.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.OptionsColumn.FixedWidth = true;
            this.colPrecio.Visible = true;
            this.colPrecio.VisibleIndex = 5;
            // 
            // colPrecio2
            // 
            this.colPrecio2.DisplayFormat.FormatString = "N2";
            this.colPrecio2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecio2.FieldName = "Precio2";
            this.colPrecio2.GroupFormat.FormatString = "n2";
            this.colPrecio2.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecio2.Name = "colPrecio2";
            this.colPrecio2.OptionsColumn.FixedWidth = true;
            this.colPrecio2.Visible = true;
            this.colPrecio2.VisibleIndex = 6;
            // 
            // colTasaIva
            // 
            this.colTasaIva.DisplayFormat.FormatString = "n2";
            this.colTasaIva.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTasaIva.FieldName = "TasaIva";
            this.colTasaIva.GroupFormat.FormatString = "n2";
            this.colTasaIva.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTasaIva.Name = "colTasaIva";
            this.colTasaIva.OptionsColumn.FixedWidth = true;
            this.colTasaIva.Visible = true;
            this.colTasaIva.VisibleIndex = 9;
            // 
            // colExistencia
            // 
            this.colExistencia.DisplayFormat.FormatString = "n2";
            this.colExistencia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colExistencia.FieldName = "Existencia";
            this.colExistencia.GroupFormat.FormatString = "n2";
            this.colExistencia.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colExistencia.Name = "colExistencia";
            this.colExistencia.OptionsColumn.FixedWidth = true;
            this.colExistencia.Visible = true;
            this.colExistencia.VisibleIndex = 10;
            // 
            // colMinimo
            // 
            this.colMinimo.DisplayFormat.FormatString = "n2";
            this.colMinimo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMinimo.FieldName = "Minimo";
            this.colMinimo.GroupFormat.FormatString = "n2";
            this.colMinimo.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMinimo.Name = "colMinimo";
            this.colMinimo.OptionsColumn.FixedWidth = true;
            this.colMinimo.Visible = true;
            this.colMinimo.VisibleIndex = 11;
            // 
            // colPrecioConIva
            // 
            this.colPrecioConIva.Caption = "Precio con Iva";
            this.colPrecioConIva.DisplayFormat.FormatString = "N2";
            this.colPrecioConIva.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecioConIva.FieldName = "PrecioConIva";
            this.colPrecioConIva.GroupFormat.FormatString = "N2";
            this.colPrecioConIva.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecioConIva.Name = "colPrecioConIva";
            this.colPrecioConIva.OptionsColumn.FixedWidth = true;
            this.colPrecioConIva.Visible = true;
            this.colPrecioConIva.VisibleIndex = 12;
            // 
            // colPrecioConIva2
            // 
            this.colPrecioConIva2.DisplayFormat.FormatString = "N2";
            this.colPrecioConIva2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecioConIva2.FieldName = "PrecioConIva2";
            this.colPrecioConIva2.GroupFormat.FormatString = "N2";
            this.colPrecioConIva2.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecioConIva2.Name = "colPrecioConIva2";
            this.colPrecioConIva2.OptionsColumn.FixedWidth = true;
            this.colPrecioConIva2.Visible = true;
            this.colPrecioConIva2.VisibleIndex = 13;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::HK.Properties.Resources.note_new;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(46, 50);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bs;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "{0}";
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 539);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1103, 25);
            this.bindingNavigator1.TabIndex = 25;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(38, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::HK.Properties.Resources.note_edit;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(41, 50);
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // BarraAcciones
            // 
            this.BarraAcciones.AutoSize = false;
            this.BarraAcciones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnCopiar,
            this.btnEditar,
            this.btnEliminar,
            this.toolStripSeparator2,
            this.txtBuscar,
            this.btnBuscar,
            this.toolStripSeparator3,
            this.btnEntradas,
            this.btnSalidas,
            this.btnMovimientos,
            this.btnCalcularExistencias,
            this.btnAjustePrecios,
            this.btnImprimir});
            this.BarraAcciones.Location = new System.Drawing.Point(0, 0);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(1103, 53);
            this.BarraAcciones.TabIndex = 27;
            this.BarraAcciones.Text = "Productos";
            // 
            // btnCopiar
            // 
            this.btnCopiar.Image = global::HK.Properties.Resources.folder_document;
            this.btnCopiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(46, 50);
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::HK.Properties.Resources.note_delete;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(54, 50);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 53);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(100, 53);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::HK.Properties.Resources.note_find;
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(78, 50);
            this.btnBuscar.Text = "Buscar";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 53);
            // 
            // btnEntradas
            // 
            this.btnEntradas.Image = global::HK.Properties.Resources.Entrar;
            this.btnEntradas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEntradas.Name = "btnEntradas";
            this.btnEntradas.Size = new System.Drawing.Size(113, 50);
            this.btnEntradas.Text = "Entradas Productos";
            this.btnEntradas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnSalidas
            // 
            this.btnSalidas.Image = global::HK.Properties.Resources.Salir;
            this.btnSalidas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalidas.Name = "btnSalidas";
            this.btnSalidas.Size = new System.Drawing.Size(99, 50);
            this.btnSalidas.Text = "Salida Productos";
            this.btnSalidas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnMovimientos
            // 
            this.btnMovimientos.Image = global::HK.Properties.Resources.note_pinned;
            this.btnMovimientos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMovimientos.Name = "btnMovimientos";
            this.btnMovimientos.Size = new System.Drawing.Size(81, 50);
            this.btnMovimientos.Text = "Movimientos";
            this.btnMovimientos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnCalcularExistencias
            // 
            this.btnCalcularExistencias.Image = global::HK.Properties.Resources.gears;
            this.btnCalcularExistencias.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCalcularExistencias.Name = "btnCalcularExistencias";
            this.btnCalcularExistencias.Size = new System.Drawing.Size(113, 50);
            this.btnCalcularExistencias.Text = "Calcular Existencias";
            this.btnCalcularExistencias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnAjustePrecios
            // 
            this.btnAjustePrecios.Image = global::HK.Properties.Resources.calculator;
            this.btnAjustePrecios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAjustePrecios.Name = "btnAjustePrecios";
            this.btnAjustePrecios.Size = new System.Drawing.Size(85, 50);
            this.btnAjustePrecios.Text = "Ajuste Precios";
            this.btnAjustePrecios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::HK.Properties.Resources.printer;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(106, 50);
            this.btnImprimir.Text = "Listado Productos";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // colPrecio3
            // 
            this.colPrecio3.DisplayFormat.FormatString = "N2";
            this.colPrecio3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecio3.FieldName = "Precio3";
            this.colPrecio3.Name = "colPrecio3";
            this.colPrecio3.OptionsColumn.FixedWidth = true;
            this.colPrecio3.Visible = true;
            this.colPrecio3.VisibleIndex = 7;
            // 
            // colPrecio4
            // 
            this.colPrecio4.DisplayFormat.FormatString = "N2";
            this.colPrecio4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecio4.FieldName = "Precio4";
            this.colPrecio4.Name = "colPrecio4";
            this.colPrecio4.OptionsColumn.FixedWidth = true;
            this.colPrecio4.Visible = true;
            this.colPrecio4.VisibleIndex = 8;
            // 
            // colPrecioConIva3
            // 
            this.colPrecioConIva3.DisplayFormat.FormatString = "N2";
            this.colPrecioConIva3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecioConIva3.FieldName = "PrecioConIva3";
            this.colPrecioConIva3.GroupFormat.FormatString = "N2";
            this.colPrecioConIva3.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecioConIva3.Name = "colPrecioConIva3";
            this.colPrecioConIva3.OptionsColumn.FixedWidth = true;
            this.colPrecioConIva3.Visible = true;
            this.colPrecioConIva3.VisibleIndex = 14;
            // 
            // colPrecioConIva4
            // 
            this.colPrecioConIva4.DisplayFormat.FormatString = "N2";
            this.colPrecioConIva4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecioConIva4.FieldName = "PrecioConIva4";
            this.colPrecioConIva4.GroupFormat.FormatString = "N2";
            this.colPrecioConIva4.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecioConIva4.Name = "colPrecioConIva4";
            this.colPrecioConIva4.OptionsColumn.FixedWidth = true;
            this.colPrecioConIva4.Visible = true;
            this.colPrecioConIva4.VisibleIndex = 15;
            // 
            // FrmTablas_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 564);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.BarraAcciones);
            this.Name = "FrmTablas_Productos";
            this.Text = "Productos";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource bs;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton btnEditar;
        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripButton btnCopiar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox txtBuscar;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripButton btnMovimientos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartamento;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colCosto;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecio;
        private DevExpress.XtraGrid.Columns.GridColumn colTasaIva;
        private DevExpress.XtraGrid.Columns.GridColumn colExistencia;
        private DevExpress.XtraGrid.Columns.GridColumn colMinimo;
        private System.Windows.Forms.ToolStripButton btnAjustePrecios;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecio2;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecioConIva;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoProveedor;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecioConIva2;
        private System.Windows.Forms.ToolStripButton btnEntradas;
        private System.Windows.Forms.ToolStripButton btnSalidas;
        private System.Windows.Forms.ToolStripButton btnCalcularExistencias;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecio3;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecio4;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecioConIva3;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecioConIva4;
    }
}