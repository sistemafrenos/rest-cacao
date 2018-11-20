namespace HK.Formas
{
    partial class FrmSeniat_RetencionesISLR
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCedulaRif = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombreRazonSocial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriodo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaseImponible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPorcentajeRetencion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImpuestoRetenido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumeroFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.txtAño = new System.Windows.Forms.ToolStripComboBox();
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.txtMes = new System.Windows.Forms.ToolStripComboBox();
            this.btnRelacionRetenciones = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.BarraAcciones.SuspendLayout();
            this.SuspendLayout();
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
            this.gridControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(0, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.Size = new System.Drawing.Size(1013, 506);
            this.gridControl1.TabIndex = 23;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bs
            // 
            this.bs.DataSource = typeof(HK.Documento);
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 65;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNumero,
            this.colCedulaRif,
            this.colNombreRazonSocial,
            this.colPeriodo,
            this.colDireccion,
            this.colFecha,
            this.colMontoDocumento,
            this.colBaseImponible,
            this.colPorcentajeRetencion,
            this.colImpuestoRetenido,
            this.colNumeroFactura});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
            // 
            // colNumero
            // 
            this.colNumero.AppearanceHeader.Options.UseTextOptions = true;
            this.colNumero.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNumero.FieldName = "Numero";
            this.colNumero.Name = "colNumero";
            this.colNumero.OptionsColumn.FixedWidth = true;
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 0;
            this.colNumero.Width = 95;
            // 
            // colCedulaRif
            // 
            this.colCedulaRif.AppearanceHeader.Options.UseTextOptions = true;
            this.colCedulaRif.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCedulaRif.FieldName = "CedulaRif";
            this.colCedulaRif.Name = "colCedulaRif";
            this.colCedulaRif.OptionsColumn.FixedWidth = true;
            this.colCedulaRif.Visible = true;
            this.colCedulaRif.VisibleIndex = 1;
            this.colCedulaRif.Width = 93;
            // 
            // colNombreRazonSocial
            // 
            this.colNombreRazonSocial.AppearanceHeader.Options.UseTextOptions = true;
            this.colNombreRazonSocial.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNombreRazonSocial.FieldName = "NombreRazonSocial";
            this.colNombreRazonSocial.Name = "colNombreRazonSocial";
            this.colNombreRazonSocial.OptionsColumn.FixedWidth = true;
            this.colNombreRazonSocial.Visible = true;
            this.colNombreRazonSocial.VisibleIndex = 2;
            this.colNombreRazonSocial.Width = 236;
            // 
            // colPeriodo
            // 
            this.colPeriodo.AppearanceHeader.Options.UseTextOptions = true;
            this.colPeriodo.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPeriodo.FieldName = "Periodo";
            this.colPeriodo.Name = "colPeriodo";
            this.colPeriodo.OptionsColumn.FixedWidth = true;
            this.colPeriodo.Visible = true;
            this.colPeriodo.VisibleIndex = 3;
            this.colPeriodo.Width = 138;
            // 
            // colDireccion
            // 
            this.colDireccion.AppearanceHeader.Options.UseTextOptions = true;
            this.colDireccion.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDireccion.FieldName = "Direccion";
            this.colDireccion.Name = "colDireccion";
            this.colDireccion.OptionsColumn.FixedWidth = true;
            this.colDireccion.Visible = true;
            this.colDireccion.VisibleIndex = 10;
            this.colDireccion.Width = 120;
            // 
            // colFecha
            // 
            this.colFecha.AppearanceHeader.Options.UseTextOptions = true;
            this.colFecha.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colFecha.FieldName = "Fecha";
            this.colFecha.GroupFormat.FormatString = "d";
            this.colFecha.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.FixedWidth = true;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 5;
            this.colFecha.Width = 91;
            // 
            // colMontoDocumento
            // 
            this.colMontoDocumento.AppearanceHeader.Options.UseTextOptions = true;
            this.colMontoDocumento.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMontoDocumento.DisplayFormat.FormatString = "n2";
            this.colMontoDocumento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontoDocumento.FieldName = "MontoDocumento";
            this.colMontoDocumento.GroupFormat.FormatString = "n2";
            this.colMontoDocumento.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontoDocumento.Name = "colMontoDocumento";
            this.colMontoDocumento.OptionsColumn.FixedWidth = true;
            this.colMontoDocumento.Visible = true;
            this.colMontoDocumento.VisibleIndex = 6;
            this.colMontoDocumento.Width = 95;
            // 
            // colBaseImponible
            // 
            this.colBaseImponible.AppearanceHeader.Options.UseTextOptions = true;
            this.colBaseImponible.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colBaseImponible.DisplayFormat.FormatString = "n2";
            this.colBaseImponible.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBaseImponible.FieldName = "BaseImponible";
            this.colBaseImponible.GroupFormat.FormatString = "n2";
            this.colBaseImponible.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBaseImponible.Name = "colBaseImponible";
            this.colBaseImponible.OptionsColumn.FixedWidth = true;
            this.colBaseImponible.Visible = true;
            this.colBaseImponible.VisibleIndex = 7;
            this.colBaseImponible.Width = 95;
            // 
            // colPorcentajeRetencion
            // 
            this.colPorcentajeRetencion.AppearanceHeader.Options.UseTextOptions = true;
            this.colPorcentajeRetencion.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPorcentajeRetencion.DisplayFormat.FormatString = "n2";
            this.colPorcentajeRetencion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPorcentajeRetencion.FieldName = "PorcentajeRetencion";
            this.colPorcentajeRetencion.GroupFormat.FormatString = "n2";
            this.colPorcentajeRetencion.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPorcentajeRetencion.Name = "colPorcentajeRetencion";
            this.colPorcentajeRetencion.OptionsColumn.FixedWidth = true;
            this.colPorcentajeRetencion.Visible = true;
            this.colPorcentajeRetencion.VisibleIndex = 8;
            this.colPorcentajeRetencion.Width = 95;
            // 
            // colImpuestoRetenido
            // 
            this.colImpuestoRetenido.AppearanceHeader.Options.UseTextOptions = true;
            this.colImpuestoRetenido.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colImpuestoRetenido.DisplayFormat.FormatString = "n2";
            this.colImpuestoRetenido.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImpuestoRetenido.FieldName = "ImpuestoRetenido";
            this.colImpuestoRetenido.GroupFormat.FormatString = "n2";
            this.colImpuestoRetenido.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImpuestoRetenido.Name = "colImpuestoRetenido";
            this.colImpuestoRetenido.OptionsColumn.FixedWidth = true;
            this.colImpuestoRetenido.Visible = true;
            this.colImpuestoRetenido.VisibleIndex = 9;
            this.colImpuestoRetenido.Width = 95;
            // 
            // colNumeroFactura
            // 
            this.colNumeroFactura.AppearanceHeader.Options.UseTextOptions = true;
            this.colNumeroFactura.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNumeroFactura.FieldName = "NumeroFactura";
            this.colNumeroFactura.Name = "colNumeroFactura";
            this.colNumeroFactura.OptionsColumn.FixedWidth = true;
            this.colNumeroFactura.Visible = true;
            this.colNumeroFactura.VisibleIndex = 4;
            this.colNumeroFactura.Width = 95;
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
            // btnImprimir
            // 
            this.btnImprimir.Image = global::HK.Properties.Resources.printer;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(57, 50);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 53);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 53);
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
            // btnNuevo
            // 
            this.btnNuevo.Image = global::HK.Properties.Resources.note_new;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(46, 50);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 53);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::HK.Properties.Resources.note_view;
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(46, 50);
            this.btnBuscar.Text = "Cargar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            this.txtAño.Size = new System.Drawing.Size(100, 53);
            // 
            // BarraAcciones
            // 
            this.BarraAcciones.AutoSize = false;
            this.BarraAcciones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtMes,
            this.txtAño,
            this.btnBuscar,
            this.toolStripSeparator4,
            this.btnNuevo,
            this.btnEditar,
            this.btnEliminar,
            this.toolStripSeparator2,
            this.btnImprimir,
            this.btnRelacionRetenciones,
            this.toolStripSeparator3});
            this.BarraAcciones.Location = new System.Drawing.Point(0, 0);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(1016, 53);
            this.BarraAcciones.TabIndex = 24;
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
            // btnRelacionRetenciones
            // 
            this.btnRelacionRetenciones.Image = global::HK.Properties.Resources.printer;
            this.btnRelacionRetenciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRelacionRetenciones.Name = "btnRelacionRetenciones";
            this.btnRelacionRetenciones.Size = new System.Drawing.Size(123, 50);
            this.btnRelacionRetenciones.Text = "Relacion Retenciones";
            this.btnRelacionRetenciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // FrmSeniat_RetencionesISLR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 566);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.BarraAcciones);
            this.Name = "FrmSeniat_RetencionesISLR";
            this.Text = "Retenciones ISLR";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource bs;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.ToolStripComboBox txtAño;
        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripComboBox txtMes;
        private DevExpress.XtraGrid.Columns.GridColumn colNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colCedulaRif;
        private DevExpress.XtraGrid.Columns.GridColumn colNombreRazonSocial;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodo;
        private DevExpress.XtraGrid.Columns.GridColumn colDireccion;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseImponible;
        private DevExpress.XtraGrid.Columns.GridColumn colPorcentajeRetencion;
        private DevExpress.XtraGrid.Columns.GridColumn colImpuestoRetenido;
        private DevExpress.XtraGrid.Columns.GridColumn colNumeroFactura;
        private System.Windows.Forms.ToolStripButton btnRelacionRetenciones;
    }
}