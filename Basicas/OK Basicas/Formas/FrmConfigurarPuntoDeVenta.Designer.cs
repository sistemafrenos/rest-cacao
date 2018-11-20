namespace HK.Formas
{
    partial class FrmConfigurarPuntoDeVenta
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
            this.bs = new System.Windows.Forms.BindingSource();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForModeloImpresoraFiscal = new DevExpress.XtraLayout.LayoutControlItem();
            this.Cancelar = new System.Windows.Forms.ToolStripButton();
            this.ItemForTipoImpresoraFiscal = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTipoImpresora = new DevExpress.XtraLayout.LayoutControlItem();
            this.Aceptar = new System.Windows.Forms.ToolStripButton();
            this.ItemForPuertoImpresoraFiscal = new DevExpress.XtraLayout.LayoutControlItem();
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.PedirNumeroOrdenCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.ItemForPedirNumeroOrden = new DevExpress.XtraLayout.LayoutControlItem();
            this.ImpresoraOrdenDespachoComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ItemForImpresoraOrdenDespacho = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModeloImpresoraFiscal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTipoImpresoraFiscal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTipoImpresora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPuertoImpresoraFiscal)).BeginInit();
            this.BarraAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PedirNumeroOrdenCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPedirNumeroOrden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImpresoraOrdenDespachoComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForImpresoraOrdenDespacho)).BeginInit();
            this.SuspendLayout();
            // 
            // bs
            // 
            this.bs.DataSource = typeof(HK.BussinessLogic.PuntoVentaConfig);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.PedirNumeroOrdenCheckEdit);
            this.dataLayoutControl1.Controls.Add(this.ImpresoraOrdenDespachoComboBoxEdit);
            this.dataLayoutControl1.DataSource = this.bs;
            this.dataLayoutControl1.Location = new System.Drawing.Point(12, 6);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(428, 65);
            this.dataLayoutControl1.TabIndex = 46;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(428, 65);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForPedirNumeroOrden,
            this.ItemForImpresoraOrdenDespacho});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(428, 65);
            this.layoutControlGroup2.Text = "autoGeneratedGroup0";
            // 
            // ItemForModeloImpresoraFiscal
            // 
            this.ItemForModeloImpresoraFiscal.CustomizationFormText = "Modelo Impresora Fiscal";
            this.ItemForModeloImpresoraFiscal.Location = new System.Drawing.Point(349, 50);
            this.ItemForModeloImpresoraFiscal.Name = "ItemForModeloImpresoraFiscal";
            this.ItemForModeloImpresoraFiscal.Size = new System.Drawing.Size(338, 24);
            this.ItemForModeloImpresoraFiscal.Text = "Modelo Impresora Fiscal";
            this.ItemForModeloImpresoraFiscal.TextSize = new System.Drawing.Size(115, 13);
            this.ItemForModeloImpresoraFiscal.TextToControlDistance = 5;
            // 
            // Cancelar
            // 
            this.Cancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Cancelar.Image = global::HK.Properties.Resources.disk_blue_error;
            this.Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(88, 55);
            this.Cancelar.Text = "Cancelar - ESC";
            this.Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ItemForTipoImpresoraFiscal
            // 
            this.ItemForTipoImpresoraFiscal.CustomizationFormText = "Tipo Impresora Fiscal";
            this.ItemForTipoImpresoraFiscal.Location = new System.Drawing.Point(0, 74);
            this.ItemForTipoImpresoraFiscal.Name = "ItemForTipoImpresoraFiscal";
            this.ItemForTipoImpresoraFiscal.Size = new System.Drawing.Size(349, 24);
            this.ItemForTipoImpresoraFiscal.Text = "Tipo Impresora Fiscal";
            this.ItemForTipoImpresoraFiscal.TextSize = new System.Drawing.Size(115, 13);
            this.ItemForTipoImpresoraFiscal.TextToControlDistance = 5;
            // 
            // ItemForTipoImpresora
            // 
            this.ItemForTipoImpresora.CustomizationFormText = "Tipo Impresora";
            this.ItemForTipoImpresora.Location = new System.Drawing.Point(0, 50);
            this.ItemForTipoImpresora.Name = "ItemForTipoImpresora";
            this.ItemForTipoImpresora.Size = new System.Drawing.Size(349, 24);
            this.ItemForTipoImpresora.Text = "Tipo Impresora";
            this.ItemForTipoImpresora.TextSize = new System.Drawing.Size(115, 13);
            this.ItemForTipoImpresora.TextToControlDistance = 5;
            // 
            // Aceptar
            // 
            this.Aceptar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Aceptar.Image = global::HK.Properties.Resources.disk_blue_ok;
            this.Aceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(81, 55);
            this.Aceptar.Text = "Aceptar - F12";
            this.Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ItemForPuertoImpresoraFiscal
            // 
            this.ItemForPuertoImpresoraFiscal.CustomizationFormText = "Puerto Impresora Fiscal";
            this.ItemForPuertoImpresoraFiscal.Location = new System.Drawing.Point(349, 74);
            this.ItemForPuertoImpresoraFiscal.Name = "ItemForPuertoImpresoraFiscal";
            this.ItemForPuertoImpresoraFiscal.Size = new System.Drawing.Size(338, 24);
            this.ItemForPuertoImpresoraFiscal.Text = "Puerto Impresora Fiscal";
            this.ItemForPuertoImpresoraFiscal.TextSize = new System.Drawing.Size(115, 13);
            this.ItemForPuertoImpresoraFiscal.TextToControlDistance = 5;
            // 
            // BarraAcciones
            // 
            this.BarraAcciones.AutoSize = false;
            this.BarraAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BarraAcciones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Aceptar,
            this.Cancelar});
            this.BarraAcciones.Location = new System.Drawing.Point(0, 87);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(460, 58);
            this.BarraAcciones.TabIndex = 45;
            this.BarraAcciones.Text = "toolStrip1";
            // 
            // PedirNumeroOrdenCheckEdit
            // 
            this.PedirNumeroOrdenCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bs, "PedirNumeroOrden", true));
            this.PedirNumeroOrdenCheckEdit.Location = new System.Drawing.Point(2, 2);
            this.PedirNumeroOrdenCheckEdit.Name = "PedirNumeroOrdenCheckEdit";
            this.PedirNumeroOrdenCheckEdit.Properties.Caption = "Pedir Numero Orden";
            this.PedirNumeroOrdenCheckEdit.Size = new System.Drawing.Size(424, 19);
            this.PedirNumeroOrdenCheckEdit.StyleController = this.dataLayoutControl1;
            this.PedirNumeroOrdenCheckEdit.TabIndex = 7;
            // 
            // ItemForPedirNumeroOrden
            // 
            this.ItemForPedirNumeroOrden.Control = this.PedirNumeroOrdenCheckEdit;
            this.ItemForPedirNumeroOrden.CustomizationFormText = "Pedir Numero Orden";
            this.ItemForPedirNumeroOrden.Location = new System.Drawing.Point(0, 0);
            this.ItemForPedirNumeroOrden.Name = "ItemForPedirNumeroOrden";
            this.ItemForPedirNumeroOrden.Size = new System.Drawing.Size(428, 23);
            this.ItemForPedirNumeroOrden.Text = "Pedir Numero Orden";
            this.ItemForPedirNumeroOrden.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForPedirNumeroOrden.TextToControlDistance = 0;
            this.ItemForPedirNumeroOrden.TextVisible = false;
            // 
            // ImpresoraOrdenDespachoComboBoxEdit
            // 
            this.ImpresoraOrdenDespachoComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bs, "ImpresoraOrdenDespacho", true));
            this.ImpresoraOrdenDespachoComboBoxEdit.Location = new System.Drawing.Point(137, 25);
            this.ImpresoraOrdenDespachoComboBoxEdit.Name = "ImpresoraOrdenDespachoComboBoxEdit";
            this.ImpresoraOrdenDespachoComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ImpresoraOrdenDespachoComboBoxEdit.Size = new System.Drawing.Size(289, 20);
            this.ImpresoraOrdenDespachoComboBoxEdit.StyleController = this.dataLayoutControl1;
            this.ImpresoraOrdenDespachoComboBoxEdit.TabIndex = 8;
            // 
            // ItemForImpresoraOrdenDespacho
            // 
            this.ItemForImpresoraOrdenDespacho.Control = this.ImpresoraOrdenDespachoComboBoxEdit;
            this.ItemForImpresoraOrdenDespacho.CustomizationFormText = "Impresora Orden Despacho";
            this.ItemForImpresoraOrdenDespacho.Location = new System.Drawing.Point(0, 23);
            this.ItemForImpresoraOrdenDespacho.Name = "ItemForImpresoraOrdenDespacho";
            this.ItemForImpresoraOrdenDespacho.Size = new System.Drawing.Size(428, 42);
            this.ItemForImpresoraOrdenDespacho.Text = "Impresora Orden Despacho";
            this.ItemForImpresoraOrdenDespacho.TextSize = new System.Drawing.Size(132, 13);
            // 
            // FrmConfigurarPuntoDeVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 145);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.BarraAcciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmConfigurarPuntoDeVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Punto de Venta";
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModeloImpresoraFiscal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTipoImpresoraFiscal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTipoImpresora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPuertoImpresoraFiscal)).EndInit();
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PedirNumeroOrdenCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPedirNumeroOrden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImpresoraOrdenDespachoComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForImpresoraOrdenDespacho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bs;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.CheckEdit PedirNumeroOrdenCheckEdit;
        private DevExpress.XtraEditors.ComboBoxEdit ImpresoraOrdenDespachoComboBoxEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPedirNumeroOrden;
        private DevExpress.XtraLayout.LayoutControlItem ItemForImpresoraOrdenDespacho;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModeloImpresoraFiscal;
        private System.Windows.Forms.ToolStripButton Cancelar;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTipoImpresoraFiscal;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTipoImpresora;
        private System.Windows.Forms.ToolStripButton Aceptar;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPuertoImpresoraFiscal;
        public System.Windows.Forms.ToolStrip BarraAcciones;
    }
}