namespace HK.Formas
{
    partial class FrmUtilidades_ConfigurarServidor
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.bs = new System.Windows.Forms.BindingSource();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.comboBoxEditTipoServidor = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtServidor = new DevExpress.XtraEditors.TextEdit();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTipoImpresora = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForModeloImpresoraFiscal = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTipoImpresoraFiscal = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPuertoImpresoraFiscal = new DevExpress.XtraLayout.LayoutControlItem();
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.Aceptar = new System.Windows.Forms.ToolStripButton();
            this.Cancelar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditTipoServidor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServidor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTipoImpresora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModeloImpresoraFiscal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTipoImpresoraFiscal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPuertoImpresoraFiscal)).BeginInit();
            this.BarraAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtPassword);
            this.layoutControl1.Controls.Add(this.txtUser);
            this.layoutControl1.Controls.Add(this.checkEdit1);
            this.layoutControl1.Controls.Add(this.comboBoxEditTipoServidor);
            this.layoutControl1.Controls.Add(this.txtServidor);
            this.layoutControl1.Controls.Add(this.txtBase);
            this.layoutControl1.Location = new System.Drawing.Point(12, 12);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(599, 174);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtPassword
            // 
            this.txtPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs, "Password", true));
            this.txtPassword.Location = new System.Drawing.Point(228, 146);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(369, 20);
            this.txtPassword.StyleController = this.layoutControl1;
            this.txtPassword.TabIndex = 34;
            // 
            // bs
            // 
            this.bs.DataSource = typeof(HK.BussinessLogic.DbConfig);
            // 
            // txtUser
            // 
            this.txtUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs, "User", true));
            this.txtUser.Location = new System.Drawing.Point(228, 122);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(369, 20);
            this.txtUser.StyleController = this.layoutControl1;
            this.txtUser.TabIndex = 33;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(2, 122);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Windows Integrated Security";
            this.checkEdit1.Size = new System.Drawing.Size(163, 19);
            this.checkEdit1.StyleController = this.layoutControl1;
            this.checkEdit1.TabIndex = 32;
            // 
            // comboBoxEditTipoServidor
            // 
            this.comboBoxEditTipoServidor.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bs, "Provider", true));
            this.comboBoxEditTipoServidor.Enabled = false;
            this.comboBoxEditTipoServidor.Location = new System.Drawing.Point(2, 18);
            this.comboBoxEditTipoServidor.Name = "comboBoxEditTipoServidor";
            this.comboBoxEditTipoServidor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditTipoServidor.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditTipoServidor.Size = new System.Drawing.Size(595, 20);
            this.comboBoxEditTipoServidor.StyleController = this.layoutControl1;
            this.comboBoxEditTipoServidor.TabIndex = 31;
            // 
            // txtServidor
            // 
            this.txtServidor.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bs, "Server", true));
            this.txtServidor.Location = new System.Drawing.Point(2, 58);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(595, 20);
            this.txtServidor.StyleController = this.layoutControl1;
            this.txtServidor.TabIndex = 4;
            // 
            // txtBase
            // 
            this.txtBase.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs, "DataBase", true));
            this.txtBase.Location = new System.Drawing.Point(2, 98);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(595, 20);
            this.txtBase.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem9,
            this.layoutControlItem7,
            this.layoutControlItem6,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(599, 174);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.comboBoxEditTipoServidor;
            this.layoutControlItem9.CustomizationFormText = "Tipo de servidor";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(599, 40);
            this.layoutControlItem9.Text = "Provider";
            this.layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtServidor;
            this.layoutControlItem7.CustomizationFormText = "Servidor";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(599, 40);
            this.layoutControlItem7.Text = "Server";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtBase;
            this.layoutControlItem6.CustomizationFormText = "Base de datos";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 80);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(599, 40);
            this.layoutControlItem6.Text = "DataBase";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.checkEdit1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(167, 54);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtUser;
            this.layoutControlItem2.CustomizationFormText = "Usuario";
            this.layoutControlItem2.Location = new System.Drawing.Point(167, 120);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(432, 24);
            this.layoutControlItem2.Text = "Usuario";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtPassword;
            this.layoutControlItem3.CustomizationFormText = "Contraseña";
            this.layoutControlItem3.Location = new System.Drawing.Point(167, 144);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(432, 30);
            this.layoutControlItem3.Text = "Contraseña";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(56, 13);
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
            this.BarraAcciones.Location = new System.Drawing.Point(0, 198);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(618, 58);
            this.BarraAcciones.TabIndex = 43;
            this.BarraAcciones.Text = "toolStrip1";
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
            // FrmUtilidades_ConfigurarServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 256);
            this.Controls.Add(this.BarraAcciones);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmUtilidades_ConfigurarServidor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion Servidor";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditTipoServidor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServidor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTipoImpresora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForModeloImpresoraFiscal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTipoImpresoraFiscal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPuertoImpresoraFiscal)).EndInit();
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTipoImpresora;
        private DevExpress.XtraLayout.LayoutControlItem ItemForModeloImpresoraFiscal;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTipoImpresoraFiscal;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPuertoImpresoraFiscal;
        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripButton Aceptar;
        private System.Windows.Forms.ToolStripButton Cancelar;
        private DevExpress.XtraEditors.TextEdit txtServidor;
        private System.Windows.Forms.TextBox txtBase;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditTipoServidor;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private System.Windows.Forms.BindingSource bs;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;

    }
}