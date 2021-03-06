﻿namespace HK.Formas
{
    partial class FrmRestaurant_ConsultarFacturas
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.VerFactura = new System.Windows.Forms.ToolStripButton();
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.Duplicar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Eliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtDesde = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtHasta = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.txtBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.Buscar = new System.Windows.Forms.ToolStripButton();
            this.btnReporteFacturas = new System.Windows.Forms.ToolStripButton();
            this.btnMail = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bs = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHora = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCedulaRif = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRazonSocial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEfectivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarjeta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPagos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumeroZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnulado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCestaTickets = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BarraAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // VerFactura
            // 
            this.VerFactura.Image = global::HK.Properties.Resources.note_view;
            this.VerFactura.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.VerFactura.Name = "VerFactura";
            this.VerFactura.Size = new System.Drawing.Size(70, 50);
            this.VerFactura.Text = "Ver Factura";
            this.VerFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // BarraAcciones
            // 
            this.BarraAcciones.AutoSize = false;
            this.BarraAcciones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Duplicar,
            this.toolStripSeparator3,
            this.VerFactura,
            this.toolStripSeparator1,
            this.Eliminar,
            this.toolStripLabel1,
            this.txtDesde,
            this.toolStripLabel2,
            this.txtHasta,
            this.toolStripSeparator4,
            this.txtBuscar,
            this.Buscar,
            this.btnReporteFacturas,
            this.btnMail,
            this.btnCancelar});
            this.BarraAcciones.Location = new System.Drawing.Point(0, 0);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(1008, 53);
            this.BarraAcciones.TabIndex = 17;
            this.BarraAcciones.Text = "toolStrip1";
            // 
            // Duplicar
            // 
            this.Duplicar.Image = global::HK.Properties.Resources.printer;
            this.Duplicar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Duplicar.Name = "Duplicar";
            this.Duplicar.Size = new System.Drawing.Size(91, 50);
            this.Duplicar.Text = "Imprimir Copia";
            this.Duplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 53);
            this.toolStripSeparator3.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 53);
            this.toolStripSeparator1.Visible = false;
            // 
            // Eliminar
            // 
            this.Eliminar.Image = global::HK.Properties.Resources.note_delete;
            this.Eliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(88, 50);
            this.Eliminar.Text = "Anular Factura";
            this.Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 50);
            this.toolStripLabel1.Text = "Desde";
            // 
            // txtDesde
            // 
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(100, 53);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(37, 50);
            this.toolStripLabel2.Text = "Hasta";
            // 
            // txtHasta
            // 
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(100, 53);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 53);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(104, 53);
            // 
            // Buscar
            // 
            this.Buscar.Image = global::HK.Properties.Resources.note_find;
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(46, 50);
            this.Buscar.Text = "Buscar";
            this.Buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnReporteFacturas
            // 
            this.btnReporteFacturas.Image = global::HK.Properties.Resources.printer;
            this.btnReporteFacturas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReporteFacturas.Name = "btnReporteFacturas";
            this.btnReporteFacturas.Size = new System.Drawing.Size(57, 50);
            this.btnReporteFacturas.Text = "Imprimir";
            this.btnReporteFacturas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnMail
            // 
            this.btnMail.Image = global::HK.Properties.Resources.mail;
            this.btnMail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(47, 50);
            this.btnMail.Text = "Correo";
            this.btnMail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::HK.Properties.Resources.disk_blue_error;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(57, 50);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.ToolTipText = "Cancelar";
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
            this.gridControl1.Size = new System.Drawing.Size(1008, 698);
            this.gridControl1.TabIndex = 18;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bs
            // 
            this.bs.DataSource = typeof(HK.MesasCerrada);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFecha,
            this.colHora,
            this.colNumero,
            this.colCedulaRif,
            this.colRazonSocial,
            this.colMontoTotal,
            this.colEfectivo,
            this.colTarjeta,
            this.colPagos,
            this.colSaldo,
            this.colNumeroZ,
            this.colAnulado,
            this.colCestaTickets});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(808, 338, 216, 199);
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Expression = "[Anulado]";
            styleFormatCondition1.Value1 = "True";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.FixedWidth = true;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            this.colFecha.Width = 65;
            // 
            // colHora
            // 
            this.colHora.DisplayFormat.FormatString = "t";
            this.colHora.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colHora.FieldName = "Cierre";
            this.colHora.Name = "colHora";
            this.colHora.OptionsColumn.FixedWidth = true;
            this.colHora.Visible = true;
            this.colHora.VisibleIndex = 2;
            this.colHora.Width = 55;
            // 
            // colNumero
            // 
            this.colNumero.FieldName = "Factura";
            this.colNumero.Name = "colNumero";
            this.colNumero.OptionsColumn.FixedWidth = true;
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 1;
            // 
            // colCedulaRif
            // 
            this.colCedulaRif.FieldName = "CedulaRif";
            this.colCedulaRif.Name = "colCedulaRif";
            this.colCedulaRif.OptionsColumn.FixedWidth = true;
            this.colCedulaRif.Visible = true;
            this.colCedulaRif.VisibleIndex = 3;
            this.colCedulaRif.Width = 95;
            // 
            // colRazonSocial
            // 
            this.colRazonSocial.FieldName = "RazonSocial";
            this.colRazonSocial.Name = "colRazonSocial";
            this.colRazonSocial.Visible = true;
            this.colRazonSocial.VisibleIndex = 4;
            this.colRazonSocial.Width = 106;
            // 
            // colMontoTotal
            // 
            this.colMontoTotal.Caption = "Monto";
            this.colMontoTotal.DisplayFormat.FormatString = "n2";
            this.colMontoTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontoTotal.FieldName = "MontoTotal";
            this.colMontoTotal.Name = "colMontoTotal";
            this.colMontoTotal.OptionsColumn.FixedWidth = true;
            this.colMontoTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoTotal", "{0:n2}")});
            this.colMontoTotal.Visible = true;
            this.colMontoTotal.VisibleIndex = 5;
            // 
            // colEfectivo
            // 
            this.colEfectivo.DisplayFormat.FormatString = "n2";
            this.colEfectivo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEfectivo.FieldName = "Efectivo";
            this.colEfectivo.Name = "colEfectivo";
            this.colEfectivo.OptionsColumn.FixedWidth = true;
            this.colEfectivo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pagos.Efectivo", "{0:n2}")});
            this.colEfectivo.Visible = true;
            this.colEfectivo.VisibleIndex = 6;
            // 
            // colTarjeta
            // 
            this.colTarjeta.Caption = "TarjetaCR";
            this.colTarjeta.DisplayFormat.FormatString = "n2";
            this.colTarjeta.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTarjeta.FieldName = "TarjetaCR";
            this.colTarjeta.Name = "colTarjeta";
            this.colTarjeta.OptionsColumn.FixedWidth = true;
            this.colTarjeta.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pagos.TarjetaCredito", "{0:n2}")});
            this.colTarjeta.Visible = true;
            this.colTarjeta.VisibleIndex = 7;
            // 
            // colPagos
            // 
            this.colPagos.Caption = "TarjetaDB";
            this.colPagos.DisplayFormat.FormatString = "n2";
            this.colPagos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPagos.FieldName = "TarjetaDB";
            this.colPagos.Name = "colPagos";
            this.colPagos.OptionsColumn.FixedWidth = true;
            this.colPagos.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pagos.TarjetaDebito", "{0:n2}")});
            this.colPagos.Visible = true;
            this.colPagos.VisibleIndex = 8;
            // 
            // colSaldo
            // 
            this.colSaldo.DisplayFormat.FormatString = "n2";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.GroupFormat.FormatString = "n2";
            this.colSaldo.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.OptionsColumn.FixedWidth = true;
            this.colSaldo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Saldo", "{0:n2}")});
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 10;
            // 
            // colNumeroZ
            // 
            this.colNumeroZ.Caption = "Nro.Z";
            this.colNumeroZ.FieldName = "NumeroZ";
            this.colNumeroZ.Name = "colNumeroZ";
            this.colNumeroZ.OptionsColumn.FixedWidth = true;
            this.colNumeroZ.Visible = true;
            this.colNumeroZ.VisibleIndex = 11;
            this.colNumeroZ.Width = 55;
            // 
            // colAnulado
            // 
            this.colAnulado.Caption = "Anulado";
            this.colAnulado.FieldName = "Anulado";
            this.colAnulado.Name = "colAnulado";
            this.colAnulado.Width = 45;
            // 
            // colCestaTickets
            // 
            this.colCestaTickets.DisplayFormat.FormatString = "n2";
            this.colCestaTickets.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCestaTickets.FieldName = "CestaTickets";
            this.colCestaTickets.Name = "colCestaTickets";
            this.colCestaTickets.OptionsColumn.FixedWidth = true;
            this.colCestaTickets.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CestaTickets", "{0:n2}")});
            this.colCestaTickets.Visible = true;
            this.colCestaTickets.VisibleIndex = 9;
            // 
            // FrmRestaurant_ConsultarFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 754);
            this.Controls.Add(this.BarraAcciones);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmRestaurant_ConsultarFacturas";
            this.Text = "Facturas";
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.ToolStripButton VerFactura;
        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Eliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton Buscar;
        private System.Windows.Forms.ToolStripTextBox txtBuscar;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ToolStripButton Duplicar;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colCedulaRif;
        private DevExpress.XtraGrid.Columns.GridColumn colRazonSocial;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colEfectivo;
        private DevExpress.XtraGrid.Columns.GridColumn colTarjeta;
        private DevExpress.XtraGrid.Columns.GridColumn colNumeroZ;
        private DevExpress.XtraGrid.Columns.GridColumn colHora;
        private DevExpress.XtraGrid.Columns.GridColumn colAnulado;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
        private System.Windows.Forms.ToolStripButton btnReporteFacturas;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ToolStripButton btnMail;
        private DevExpress.XtraGrid.Columns.GridColumn colPagos;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtDesde;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtHasta;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private DevExpress.XtraGrid.Columns.GridColumn colCestaTickets;
    }
}