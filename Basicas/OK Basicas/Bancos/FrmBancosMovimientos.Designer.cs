namespace HK.Formas
{
    partial class FrmBancosMovimientos
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnCargar = new System.Windows.Forms.ToolStripButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConcepto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCredito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConciliado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEjecutado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlanCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeneficiario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCedulaRif = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.txtMes = new System.Windows.Forms.ToolStripComboBox();
            this.txtAño = new System.Windows.Forms.ToolStripComboBox();
            this.Buscar = new System.Windows.Forms.ToolStripSeparator();
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.Cuenta = new System.Windows.Forms.ToolStripComboBox();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.btnEmitirCheque = new System.Windows.Forms.ToolStripButton();
            this.btnDeposito = new System.Windows.Forms.ToolStripButton();
            this.btnTransferencia = new System.Windows.Forms.ToolStripButton();
            this.btnNotaCredito = new System.Windows.Forms.ToolStripButton();
            this.btnNotaDebito = new System.Windows.Forms.ToolStripButton();
            this.btnVerTransaccion = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSaldoFinal = new DevExpress.XtraEditors.CalcEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSaldoInicial = new DevExpress.XtraEditors.CalcEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.BarraAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoInicial.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCargar
            // 
            this.btnCargar.Image = global::HK.Properties.Resources.note_find;
            this.btnCargar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(44, 50);
            this.btnCargar.Text = "Cargar";
            this.btnCargar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            this.gridControl1.Location = new System.Drawing.Point(0, 97);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.Size = new System.Drawing.Size(1008, 631);
            this.gridControl1.TabIndex = 28;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bs
            // 
            this.bs.DataSource = typeof(HK.BancosMovimiento);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.ColumnPanelRowHeight = 45;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFecha,
            this.colTipo,
            this.colNumero,
            this.colConcepto,
            this.colDebito,
            this.colCredito,
            this.colConciliado,
            this.colEjecutado,
            this.colPlanCuenta,
            this.colBeneficiario,
            this.colCedulaRif,
            this.colSaldo});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(808, 338, 216, 199);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.gridView1.Name = "gridView1";
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
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            // 
            // colTipo
            // 
            this.colTipo.FieldName = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.OptionsColumn.AllowEdit = false;
            this.colTipo.Visible = true;
            this.colTipo.VisibleIndex = 1;
            // 
            // colNumero
            // 
            this.colNumero.FieldName = "Numero";
            this.colNumero.Name = "colNumero";
            this.colNumero.OptionsColumn.AllowEdit = false;
            this.colNumero.Visible = true;
            this.colNumero.VisibleIndex = 2;
            // 
            // colConcepto
            // 
            this.colConcepto.FieldName = "Concepto";
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.OptionsColumn.AllowEdit = false;
            this.colConcepto.Visible = true;
            this.colConcepto.VisibleIndex = 3;
            this.colConcepto.Width = 210;
            // 
            // colDebito
            // 
            this.colDebito.DisplayFormat.FormatString = "n2";
            this.colDebito.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDebito.FieldName = "Debito";
            this.colDebito.GroupFormat.FormatString = "n2";
            this.colDebito.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDebito.Name = "colDebito";
            this.colDebito.OptionsColumn.AllowEdit = false;
            this.colDebito.SummaryItem.DisplayFormat = "{0:n2}";
            this.colDebito.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colDebito.Visible = true;
            this.colDebito.VisibleIndex = 7;
            // 
            // colCredito
            // 
            this.colCredito.DisplayFormat.FormatString = "n2";
            this.colCredito.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCredito.FieldName = "Credito";
            this.colCredito.GroupFormat.FormatString = "n2";
            this.colCredito.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCredito.Name = "colCredito";
            this.colCredito.OptionsColumn.AllowEdit = false;
            this.colCredito.SummaryItem.DisplayFormat = "{0:n2}";
            this.colCredito.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colCredito.Visible = true;
            this.colCredito.VisibleIndex = 8;
            // 
            // colConciliado
            // 
            this.colConciliado.FieldName = "Conciliado";
            this.colConciliado.Name = "colConciliado";
            this.colConciliado.Visible = true;
            this.colConciliado.VisibleIndex = 9;
            // 
            // colEjecutado
            // 
            this.colEjecutado.FieldName = "Ejecutado";
            this.colEjecutado.Name = "colEjecutado";
            this.colEjecutado.OptionsColumn.AllowEdit = false;
            this.colEjecutado.Visible = true;
            this.colEjecutado.VisibleIndex = 10;
            // 
            // colPlanCuenta
            // 
            this.colPlanCuenta.FieldName = "PlanCuenta";
            this.colPlanCuenta.Name = "colPlanCuenta";
            this.colPlanCuenta.OptionsColumn.AllowEdit = false;
            this.colPlanCuenta.Visible = true;
            this.colPlanCuenta.VisibleIndex = 6;
            // 
            // colBeneficiario
            // 
            this.colBeneficiario.FieldName = "Beneficiario";
            this.colBeneficiario.Name = "colBeneficiario";
            this.colBeneficiario.OptionsColumn.AllowEdit = false;
            this.colBeneficiario.Visible = true;
            this.colBeneficiario.VisibleIndex = 5;
            this.colBeneficiario.Width = 226;
            // 
            // colCedulaRif
            // 
            this.colCedulaRif.FieldName = "CedulaRif";
            this.colCedulaRif.Name = "colCedulaRif";
            this.colCedulaRif.OptionsColumn.AllowEdit = false;
            this.colCedulaRif.Visible = true;
            this.colCedulaRif.VisibleIndex = 4;
            // 
            // colSaldo
            // 
            this.colSaldo.DisplayFormat.FormatString = "n2";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.GroupFormat.FormatString = "n2";
            this.colSaldo.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.OptionsColumn.AllowEdit = false;
            this.colSaldo.OptionsColumn.FixedWidth = true;
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 11;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 53);
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
            // Buscar
            // 
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(6, 53);
            // 
            // BarraAcciones
            // 
            this.BarraAcciones.AutoSize = false;
            this.BarraAcciones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cuenta,
            this.txtMes,
            this.txtAño,
            this.btnCargar,
            this.btnImprimir,
            this.Buscar,
            this.btnEmitirCheque,
            this.btnDeposito,
            this.btnTransferencia,
            this.btnNotaCredito,
            this.btnNotaDebito,
            this.toolStripSeparator3,
            this.btnVerTransaccion,
            this.btnEliminar});
            this.BarraAcciones.Location = new System.Drawing.Point(0, 0);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(1008, 53);
            this.BarraAcciones.TabIndex = 27;
            this.BarraAcciones.Text = "toolStrip1";
            // 
            // Cuenta
            // 
            this.Cuenta.Name = "Cuenta";
            this.Cuenta.Size = new System.Drawing.Size(300, 53);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::HK.Properties.Resources.printer;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(49, 50);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnEmitirCheque
            // 
            this.btnEmitirCheque.Image = global::HK.Properties.Resources.note_add;
            this.btnEmitirCheque.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEmitirCheque.Name = "btnEmitirCheque";
            this.btnEmitirCheque.Size = new System.Drawing.Size(48, 50);
            this.btnEmitirCheque.Text = "Cheque";
            this.btnEmitirCheque.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnDeposito
            // 
            this.btnDeposito.Image = global::HK.Properties.Resources.note_add;
            this.btnDeposito.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeposito.Name = "btnDeposito";
            this.btnDeposito.Size = new System.Drawing.Size(53, 50);
            this.btnDeposito.Text = "Deposito";
            this.btnDeposito.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnTransferencia
            // 
            this.btnTransferencia.Image = global::HK.Properties.Resources.note_add;
            this.btnTransferencia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTransferencia.Name = "btnTransferencia";
            this.btnTransferencia.Size = new System.Drawing.Size(77, 50);
            this.btnTransferencia.Text = "Transferencia";
            this.btnTransferencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnNotaCredito
            // 
            this.btnNotaCredito.Image = global::HK.Properties.Resources.note_add;
            this.btnNotaCredito.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNotaCredito.Name = "btnNotaCredito";
            this.btnNotaCredito.Size = new System.Drawing.Size(55, 50);
            this.btnNotaCredito.Text = "Nota CR.";
            this.btnNotaCredito.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnNotaDebito
            // 
            this.btnNotaDebito.Image = global::HK.Properties.Resources.note_add;
            this.btnNotaDebito.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNotaDebito.Name = "btnNotaDebito";
            this.btnNotaDebito.Size = new System.Drawing.Size(54, 50);
            this.btnNotaDebito.Text = "Nota DB.";
            this.btnNotaDebito.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnVerTransaccion
            // 
            this.btnVerTransaccion.Image = global::HK.Properties.Resources.note_view;
            this.btnVerTransaccion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVerTransaccion.Name = "btnVerTransaccion";
            this.btnVerTransaccion.Size = new System.Drawing.Size(36, 50);
            this.btnVerTransaccion.Text = "Ver ";
            this.btnVerTransaccion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::HK.Properties.Resources.note_delete;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(47, 50);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnGuardarCambios);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtSaldoFinal);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtSaldoInicial);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 53);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1008, 41);
            this.panelControl1.TabIndex = 29;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCambios.Location = new System.Drawing.Point(218, 13);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(129, 23);
            this.btnGuardarCambios.TabIndex = 4;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(111, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Saldo Final";
            // 
            // txtSaldoFinal
            // 
            this.txtSaldoFinal.Enabled = false;
            this.txtSaldoFinal.Location = new System.Drawing.Point(111, 18);
            this.txtSaldoFinal.Name = "txtSaldoFinal";
            this.txtSaldoFinal.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Info;
            this.txtSaldoFinal.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtSaldoFinal.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSaldoFinal.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtSaldoFinal.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtSaldoFinal.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtSaldoFinal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtSaldoFinal.Properties.DisplayFormat.FormatString = "n2";
            this.txtSaldoFinal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSaldoFinal.Properties.EditFormat.FormatString = "n2";
            this.txtSaldoFinal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSaldoFinal.Properties.ReadOnly = true;
            this.txtSaldoFinal.Size = new System.Drawing.Size(100, 20);
            this.txtSaldoFinal.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Saldo Inicial";
            // 
            // txtSaldoInicial
            // 
            this.txtSaldoInicial.Enabled = false;
            this.txtSaldoInicial.Location = new System.Drawing.Point(5, 18);
            this.txtSaldoInicial.Name = "txtSaldoInicial";
            this.txtSaldoInicial.Properties.AppearanceDisabled.BackColor = System.Drawing.SystemColors.Info;
            this.txtSaldoInicial.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtSaldoInicial.Properties.AppearanceDisabled.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSaldoInicial.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtSaldoInicial.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtSaldoInicial.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtSaldoInicial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtSaldoInicial.Properties.DisplayFormat.FormatString = "n2";
            this.txtSaldoInicial.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSaldoInicial.Properties.EditFormat.FormatString = "n2";
            this.txtSaldoInicial.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSaldoInicial.Properties.ReadOnly = true;
            this.txtSaldoInicial.Size = new System.Drawing.Size(100, 20);
            this.txtSaldoInicial.TabIndex = 0;
            // 
            // FrmBancosMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.BarraAcciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmBancosMovimientos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bancos Movimientos";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoInicial.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnCargar;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource bs;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox txtMes;
        private System.Windows.Forms.ToolStripComboBox txtAño;
        private System.Windows.Forms.ToolStripSeparator Buscar;
        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripButton btnEmitirCheque;
        private System.Windows.Forms.ToolStripButton btnDeposito;
        private System.Windows.Forms.ToolStripButton btnTransferencia;
        private System.Windows.Forms.ToolStripButton btnNotaCredito;
        private System.Windows.Forms.ToolStripButton btnNotaDebito;
        private System.Windows.Forms.ToolStripButton btnVerTransaccion;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colNumero;
        private DevExpress.XtraGrid.Columns.GridColumn colConcepto;
        private DevExpress.XtraGrid.Columns.GridColumn colDebito;
        private DevExpress.XtraGrid.Columns.GridColumn colCredito;
        private DevExpress.XtraGrid.Columns.GridColumn colConciliado;
        private DevExpress.XtraGrid.Columns.GridColumn colEjecutado;
        private DevExpress.XtraGrid.Columns.GridColumn colPlanCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colBeneficiario;
        private DevExpress.XtraGrid.Columns.GridColumn colCedulaRif;
        private System.Windows.Forms.ToolStripComboBox Cuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CalcEdit txtSaldoInicial;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CalcEdit txtSaldoFinal;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.ToolStripButton btnImprimir;
    }
}