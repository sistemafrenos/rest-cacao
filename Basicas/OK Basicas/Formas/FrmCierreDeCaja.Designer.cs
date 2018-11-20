namespace HK.Formas
{
    partial class FrmCierreDeCaja
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
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.txtFecha = new DevExpress.XtraEditors.DateEdit();
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.btnImprimirTickera = new System.Windows.Forms.ToolStripButton();
            this.btnImprimirFisca = new System.Windows.Forms.ToolStripButton();
            this.Cancelar = new System.Windows.Forms.ToolStripButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCargar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties)).BeginInit();
            this.BarraAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(12, 40);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.AppearanceReadOnly.BackColor = System.Drawing.SystemColors.Info;
            this.memoEdit1.Properties.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.InfoText;
            this.memoEdit1.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.memoEdit1.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.memoEdit1.Properties.ReadOnly = true;
            this.memoEdit1.Size = new System.Drawing.Size(345, 433);
            this.memoEdit1.TabIndex = 0;
            // 
            // txtFecha
            // 
            this.txtFecha.EditValue = null;
            this.txtFecha.Location = new System.Drawing.Point(12, 12);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFecha.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtFecha.Size = new System.Drawing.Size(138, 20);
            this.txtFecha.TabIndex = 4;
            // 
            // BarraAcciones
            // 
            this.BarraAcciones.AutoSize = false;
            this.BarraAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BarraAcciones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImprimirTickera,
            this.btnImprimirFisca,
            this.Cancelar});
            this.BarraAcciones.Location = new System.Drawing.Point(0, 491);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(369, 54);
            this.BarraAcciones.TabIndex = 38;
            this.BarraAcciones.Text = "toolStrip1";
            // 
            // btnImprimirTickera
            // 
            this.btnImprimirTickera.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnImprimirTickera.Image = global::HK.Properties.Resources.printer;
            this.btnImprimirTickera.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimirTickera.Name = "btnImprimirTickera";
            this.btnImprimirTickera.Size = new System.Drawing.Size(86, 51);
            this.btnImprimirTickera.Text = "Imprimir Tickera";
            this.btnImprimirTickera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnImprimirFisca
            // 
            this.btnImprimirFisca.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnImprimirFisca.Image = global::HK.Properties.Resources.printer;
            this.btnImprimirFisca.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimirFisca.Name = "btnImprimirFisca";
            this.btnImprimirFisca.Size = new System.Drawing.Size(78, 51);
            this.btnImprimirFisca.Text = "Imprimir Fiscal";
            this.btnImprimirFisca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Cancelar
            // 
            this.Cancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Cancelar.Image = global::HK.Properties.Resources.disk_blue_error;
            this.Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(82, 51);
            this.Cancelar.Text = "Cancelar - ESC";
            this.Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.CustomizationFormText = "Contraseña";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem2";
            this.layoutControlItem1.Size = new System.Drawing.Size(320, 30);
            this.layoutControlItem1.Text = "Contraseña";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(56, 13);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.CustomizationFormText = "Contraseña";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem2";
            this.layoutControlItem3.Size = new System.Drawing.Size(320, 30);
            this.layoutControlItem3.Text = "Contraseña";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(56, 13);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(156, 12);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(201, 22);
            this.btnCargar.TabIndex = 5;
            this.btnCargar.Text = "Cargar Datos";
            // 
            // FrmCierreDeCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 545);
            this.Controls.Add(this.BarraAcciones);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.btnCargar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCierreDeCaja";
            this.Text = "Cierre de caja";
            this.Load += new System.EventHandler(this.FrmCierreDeCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFecha.Properties)).EndInit();
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.DateEdit txtFecha;
        private DevExpress.XtraEditors.SimpleButton btnCargar;
        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripButton Cancelar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.ToolStripButton btnImprimirTickera;
        private System.Windows.Forms.ToolStripButton btnImprimirFisca;
    }
}