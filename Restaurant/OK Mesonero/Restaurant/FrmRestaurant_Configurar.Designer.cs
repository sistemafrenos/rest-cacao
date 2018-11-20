namespace HK.Formas
{
    partial class FrmRestaurant_Configurar
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
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.Aceptar = new System.Windows.Forms.ToolStripButton();
            this.Cancelar = new System.Windows.Forms.ToolStripButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.ImpresoraComandasComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.PedirMesoneroCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.ConceptoServicioTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ImpresoraCorteCuentasComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForImpresoraComandas = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForConceptoServicio = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPedirMesonero = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForImpresoraCorteCuentas = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.BarraAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImpresoraComandasComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PedirMesoneroCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConceptoServicioTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImpresoraCorteCuentasComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForImpresoraComandas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForConceptoServicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPedirMesonero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForImpresoraCorteCuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // BarraAcciones
            // 
            this.BarraAcciones.AutoSize = false;
            this.BarraAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BarraAcciones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Aceptar,
            this.Cancelar});
            this.BarraAcciones.Location = new System.Drawing.Point(0, 211);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(450, 54);
            this.BarraAcciones.TabIndex = 36;
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
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup1.Size = new System.Drawing.Size(452, 142);
            this.layoutControlGroup1.Text = "Configuracion Correo";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup1";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup2.Size = new System.Drawing.Size(444, 117);
            this.layoutControlGroup2.Text = "Configuracion Correo";
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup1";
            this.layoutControlGroup3.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup3.Size = new System.Drawing.Size(452, 142);
            this.layoutControlGroup3.Text = "Configuracion Correo";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.checkEdit1);
            this.dataLayoutControl1.Controls.Add(this.ImpresoraComandasComboBoxEdit);
            this.dataLayoutControl1.Controls.Add(this.PedirMesoneroCheckEdit);
            this.dataLayoutControl1.Controls.Add(this.ConceptoServicioTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ImpresoraCorteCuentasComboBoxEdit);
            this.dataLayoutControl1.DataSource = this.bindingSource2;
            this.dataLayoutControl1.Location = new System.Drawing.Point(13, 13);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup4;
            this.dataLayoutControl1.Size = new System.Drawing.Size(422, 138);
            this.dataLayoutControl1.TabIndex = 37;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // checkEdit1
            // 
            this.checkEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource2, "IncluirMontoEnCorteCuenta", true));
            this.checkEdit1.Location = new System.Drawing.Point(2, 105);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Imprimir Montos en El Corte";
            this.checkEdit1.Size = new System.Drawing.Size(418, 19);
            this.checkEdit1.StyleController = this.dataLayoutControl1;
            this.checkEdit1.TabIndex = 8;
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataSource = typeof(HK.BussinessLogic.RestaurantConfig);
            // 
            // ImpresoraComandasComboBoxEdit
            // 
            this.ImpresoraComandasComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource2, "ImpresoraComandas", true));
            this.ImpresoraComandasComboBoxEdit.Location = new System.Drawing.Point(2, 41);
            this.ImpresoraComandasComboBoxEdit.Name = "ImpresoraComandasComboBoxEdit";
            this.ImpresoraComandasComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImpresoraComandasComboBoxEdit.Size = new System.Drawing.Size(206, 20);
            this.ImpresoraComandasComboBoxEdit.StyleController = this.dataLayoutControl1;
            this.ImpresoraComandasComboBoxEdit.TabIndex = 4;
            // 
            // PedirMesoneroCheckEdit
            // 
            this.PedirMesoneroCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource2, "PedirMesonero", true));
            this.PedirMesoneroCheckEdit.Location = new System.Drawing.Point(2, 2);
            this.PedirMesoneroCheckEdit.Name = "PedirMesoneroCheckEdit";
            this.PedirMesoneroCheckEdit.Properties.Caption = "Pedir Mesonero";
            this.PedirMesoneroCheckEdit.Size = new System.Drawing.Size(418, 19);
            this.PedirMesoneroCheckEdit.StyleController = this.dataLayoutControl1;
            this.PedirMesoneroCheckEdit.TabIndex = 5;
            // 
            // ConceptoServicioTextEdit
            // 
            this.ConceptoServicioTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource2, "ConceptoServicio", true));
            this.ConceptoServicioTextEdit.Location = new System.Drawing.Point(2, 81);
            this.ConceptoServicioTextEdit.Name = "ConceptoServicioTextEdit";
            this.ConceptoServicioTextEdit.Size = new System.Drawing.Size(418, 20);
            this.ConceptoServicioTextEdit.StyleController = this.dataLayoutControl1;
            this.ConceptoServicioTextEdit.TabIndex = 6;
            // 
            // ImpresoraCorteCuentasComboBoxEdit
            // 
            this.ImpresoraCorteCuentasComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource2, "ImpresoraCorteCuentas", true));
            this.ImpresoraCorteCuentasComboBoxEdit.Location = new System.Drawing.Point(212, 41);
            this.ImpresoraCorteCuentasComboBoxEdit.Name = "ImpresoraCorteCuentasComboBoxEdit";
            this.ImpresoraCorteCuentasComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImpresoraCorteCuentasComboBoxEdit.Size = new System.Drawing.Size(208, 20);
            this.ImpresoraCorteCuentasComboBoxEdit.StyleController = this.dataLayoutControl1;
            this.ImpresoraCorteCuentasComboBoxEdit.TabIndex = 7;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "layoutControlGroup4";
            this.layoutControlGroup4.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup4.GroupBordersVisible = false;
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup5,
            this.layoutControlItem1});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup4.Size = new System.Drawing.Size(422, 138);
            this.layoutControlGroup4.Text = "layoutControlGroup4";
            this.layoutControlGroup4.TextVisible = false;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.AllowDrawBackground = false;
            this.layoutControlGroup5.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup5.GroupBordersVisible = false;
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForImpresoraComandas,
            this.ItemForConceptoServicio,
            this.ItemForPedirMesonero,
            this.ItemForImpresoraCorteCuentas});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup5.Name = "autoGeneratedGroup0";
            this.layoutControlGroup5.Size = new System.Drawing.Size(422, 103);
            this.layoutControlGroup5.Text = "autoGeneratedGroup0";
            // 
            // ItemForImpresoraComandas
            // 
            this.ItemForImpresoraComandas.Control = this.ImpresoraComandasComboBoxEdit;
            this.ItemForImpresoraComandas.CustomizationFormText = "Impresora Comandas";
            this.ItemForImpresoraComandas.Location = new System.Drawing.Point(0, 23);
            this.ItemForImpresoraComandas.Name = "ItemForImpresoraComandas";
            this.ItemForImpresoraComandas.Size = new System.Drawing.Size(210, 40);
            this.ItemForImpresoraComandas.Text = "Impresora Comandas";
            this.ItemForImpresoraComandas.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForImpresoraComandas.TextSize = new System.Drawing.Size(122, 13);
            // 
            // ItemForConceptoServicio
            // 
            this.ItemForConceptoServicio.Control = this.ConceptoServicioTextEdit;
            this.ItemForConceptoServicio.CustomizationFormText = "Concepto Servicio";
            this.ItemForConceptoServicio.Location = new System.Drawing.Point(0, 63);
            this.ItemForConceptoServicio.Name = "ItemForConceptoServicio";
            this.ItemForConceptoServicio.Size = new System.Drawing.Size(422, 40);
            this.ItemForConceptoServicio.Text = "Concepto Servicio";
            this.ItemForConceptoServicio.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForConceptoServicio.TextSize = new System.Drawing.Size(122, 13);
            // 
            // ItemForPedirMesonero
            // 
            this.ItemForPedirMesonero.Control = this.PedirMesoneroCheckEdit;
            this.ItemForPedirMesonero.CustomizationFormText = "Pedir Mesonero";
            this.ItemForPedirMesonero.Location = new System.Drawing.Point(0, 0);
            this.ItemForPedirMesonero.Name = "ItemForPedirMesonero";
            this.ItemForPedirMesonero.Size = new System.Drawing.Size(422, 23);
            this.ItemForPedirMesonero.Text = "Pedir Mesonero";
            this.ItemForPedirMesonero.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForPedirMesonero.TextToControlDistance = 0;
            this.ItemForPedirMesonero.TextVisible = false;
            // 
            // ItemForImpresoraCorteCuentas
            // 
            this.ItemForImpresoraCorteCuentas.Control = this.ImpresoraCorteCuentasComboBoxEdit;
            this.ItemForImpresoraCorteCuentas.CustomizationFormText = "Impresora Corte Cuentas";
            this.ItemForImpresoraCorteCuentas.Location = new System.Drawing.Point(210, 23);
            this.ItemForImpresoraCorteCuentas.Name = "ItemForImpresoraCorteCuentas";
            this.ItemForImpresoraCorteCuentas.Size = new System.Drawing.Size(212, 40);
            this.ItemForImpresoraCorteCuentas.Text = "Impresora Corte Cuentas";
            this.ItemForImpresoraCorteCuentas.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForImpresoraCorteCuentas.TextSize = new System.Drawing.Size(122, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.checkEdit1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 103);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(422, 35);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmRestaurant_Configurar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 265);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.BarraAcciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRestaurant_Configurar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Restaurant";
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImpresoraComandasComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PedirMesoneroCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConceptoServicioTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImpresoraCorteCuentasComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForImpresoraComandas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForConceptoServicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPedirMesonero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForImpresoraCorteCuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripButton Aceptar;
        private System.Windows.Forms.ToolStripButton Cancelar;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private System.Windows.Forms.BindingSource bindingSource2;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.ComboBoxEdit ImpresoraComandasComboBoxEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlItem ItemForImpresoraComandas;
        private DevExpress.XtraEditors.CheckEdit PedirMesoneroCheckEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPedirMesonero;
        private DevExpress.XtraEditors.TextEdit ConceptoServicioTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForConceptoServicio;
        private DevExpress.XtraEditors.ComboBoxEdit ImpresoraCorteCuentasComboBoxEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForImpresoraCorteCuentas;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}