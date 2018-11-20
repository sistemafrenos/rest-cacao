﻿namespace HK.Formas
{
    partial class FrmRestaurant_Cotizaciones
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
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.btnEmail = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.txtFiltro = new System.Windows.Forms.ToolStripComboBox();
            this.txtBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRazonSocial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCedulaRif = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHora = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalon = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.BarraAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bs
            // 
            this.bs.DataSource = typeof(HK.Cotizacion);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::HK.Properties.Resources.note_edit;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(62, 50);
            this.btnEditar.Text = "Modificar";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::HK.Properties.Resources.note_add;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(46, 50);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // BarraAcciones
            // 
            this.BarraAcciones.AutoSize = false;
            this.BarraAcciones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnEditar,
            this.toolStripSeparator1,
            this.btnEliminar,
            this.toolStripSeparator2,
            this.btnImprimir,
            this.btnEmail,
            this.toolStripSeparator3,
            this.txtFiltro,
            this.txtBuscar,
            this.btnBuscar});
            this.BarraAcciones.Location = new System.Drawing.Point(0, 0);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(1018, 53);
            this.BarraAcciones.TabIndex = 17;
            this.BarraAcciones.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 53);
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
            // btnImprimir
            // 
            this.btnImprimir.Image = global::HK.Properties.Resources.printer;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(57, 50);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnEmail
            // 
            this.btnEmail.Image = global::HK.Properties.Resources.mail;
            this.btnEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(75, 50);
            this.btnEmail.Text = "Enviar Email";
            this.btnEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 53);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Items.AddRange(new object[] {
            "HOY",
            "AYER",
            "ESTE MES",
            "TODAS"});
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(121, 53);
            this.txtFiltro.Text = "HOY";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(104, 53);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::HK.Properties.Resources.note_find;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(46, 50);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            this.gridControl1.Size = new System.Drawing.Size(1018, 519);
            this.gridControl1.TabIndex = 18;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 50;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNumero,
            this.colFecha,
            this.colMontoTotal,
            this.colRazonSocial,
            this.colCedulaRif,
            this.colHora,
            this.colPersonas,
            this.colSalon});
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
            // colNumero
            // 
            this.colNumero.FieldName = "Numero";
            this.colNumero.Name = "colNumero";
            this.colNumero.OptionsColumn.FixedWidth = true;
            this.colNumero.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 0;
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.GroupFormat.FormatString = "d";
            this.colFecha.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.FixedWidth = true;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 1;
            // 
            // colMontoTotal
            // 
            this.colMontoTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colMontoTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMontoTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colMontoTotal.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMontoTotal.DisplayFormat.FormatString = "n2";
            this.colMontoTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontoTotal.FieldName = "MontoTotal";
            this.colMontoTotal.GroupFormat.FormatString = "n2";
            this.colMontoTotal.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontoTotal.Name = "colMontoTotal";
            this.colMontoTotal.OptionsColumn.FixedWidth = true;
            this.colMontoTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoTotal", "{0:n2}")});
            this.colMontoTotal.Visible = true;
            this.colMontoTotal.VisibleIndex = 7;
            // 
            // colRazonSocial
            // 
            this.colRazonSocial.FieldName = "RazonSocial";
            this.colRazonSocial.Name = "colRazonSocial";
            this.colRazonSocial.Visible = true;
            this.colRazonSocial.VisibleIndex = 6;
            this.colRazonSocial.Width = 489;
            // 
            // colCedulaRif
            // 
            this.colCedulaRif.FieldName = "CedulaRif";
            this.colCedulaRif.Name = "colCedulaRif";
            this.colCedulaRif.OptionsColumn.FixedWidth = true;
            this.colCedulaRif.Visible = true;
            this.colCedulaRif.VisibleIndex = 5;
            // 
            // colHora
            // 
            this.colHora.Caption = "Fecha Evento";
            this.colHora.DisplayFormat.FormatString = "d";
            this.colHora.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colHora.FieldName = "Hora";
            this.colHora.GroupFormat.FormatString = "d";
            this.colHora.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHora.Name = "colHora";
            this.colHora.OptionsColumn.FixedWidth = true;
            this.colHora.Visible = true;
            this.colHora.VisibleIndex = 2;
            this.colHora.Width = 86;
            // 
            // colPersonas
            // 
            this.colPersonas.FieldName = "Personas";
            this.colPersonas.Name = "colPersonas";
            this.colPersonas.OptionsColumn.FixedWidth = true;
            this.colPersonas.Visible = true;
            this.colPersonas.VisibleIndex = 4;
            this.colPersonas.Width = 64;
            // 
            // colSalon
            // 
            this.colSalon.FieldName = "Ubicacion";
            this.colSalon.Name = "colSalon";
            this.colSalon.OptionsColumn.FixedWidth = true;
            this.colSalon.Visible = true;
            this.colSalon.VisibleIndex = 3;
            this.colSalon.Width = 58;
            // 
            // FrmRestaurant_Cotizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 576);
            this.Controls.Add(this.BarraAcciones);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRestaurant_Cotizaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cotizaciones Restaurant";
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripButton btnEmail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.ToolStripComboBox txtFiltro;
        private System.Windows.Forms.ToolStripTextBox txtBuscar;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colRazonSocial;
        private DevExpress.XtraGrid.Columns.GridColumn colCedulaRif;
        private DevExpress.XtraGrid.Columns.GridColumn colHora;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonas;
        private DevExpress.XtraGrid.Columns.GridColumn colSalon;
    }
}