namespace HK.Formas
{
    partial class FrmUtilitarios_Restore
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
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtBackup = new System.Windows.Forms.TextBox();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.txtServidor = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.BarraAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServidor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
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
            this.BarraAcciones.Location = new System.Drawing.Point(0, 104);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(457, 54);
            this.BarraAcciones.TabIndex = 37;
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
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtBackup;
            this.layoutControlItem3.CustomizationFormText = "Destino";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(422, 30);
            this.layoutControlItem3.Text = "Origen";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(70, 13);
            // 
            // txtBackup
            // 
            this.txtBackup.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Backup", true));
            this.txtBackup.Location = new System.Drawing.Point(85, 60);
            this.txtBackup.Name = "txtBackup";
            this.txtBackup.Size = new System.Drawing.Size(345, 20);
            this.txtBackup.TabIndex = 6;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtBackup);
            this.layoutControl1.Controls.Add(this.txtBase);
            this.layoutControl1.Controls.Add(this.txtServidor);
            this.layoutControl1.Location = new System.Drawing.Point(12, 6);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(442, 98);
            this.layoutControl1.TabIndex = 36;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtBase
            // 
            this.txtBase.BackColor = System.Drawing.SystemColors.Info;
            this.txtBase.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "DataBase", true));
            this.txtBase.Location = new System.Drawing.Point(85, 36);
            this.txtBase.Name = "txtBase";
            this.txtBase.ReadOnly = true;
            this.txtBase.Size = new System.Drawing.Size(345, 20);
            this.txtBase.TabIndex = 5;
            this.txtBase.TabStop = false;
            // 
            // txtServidor
            // 
            this.txtServidor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Server", true));
            this.txtServidor.Location = new System.Drawing.Point(85, 12);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Properties.AppearanceReadOnly.BackColor = System.Drawing.SystemColors.Info;
            this.txtServidor.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtServidor.Properties.ReadOnly = true;
            this.txtServidor.Size = new System.Drawing.Size(345, 20);
            this.txtServidor.StyleController = this.layoutControl1;
            this.txtServidor.TabIndex = 4;
            this.txtServidor.TabStop = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(442, 98);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtServidor;
            this.layoutControlItem1.CustomizationFormText = "Servidor";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(422, 24);
            this.layoutControlItem1.Text = "Servidor";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(70, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtBase;
            this.layoutControlItem2.CustomizationFormText = "Base De Datos";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(422, 24);
            this.layoutControlItem2.Text = "Base De Datos";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(70, 13);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(HK.BussinessLogic.DbConfig);
            // 
            // FrmUtilitarios_Restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 158);
            this.Controls.Add(this.BarraAcciones);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmUtilitarios_Restore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurar Base De Datos";
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtServidor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripButton Aceptar;
        private System.Windows.Forms.ToolStripButton Cancelar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.TextBox txtBackup;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.TextBox txtBase;
        private DevExpress.XtraEditors.TextEdit txtServidor;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}