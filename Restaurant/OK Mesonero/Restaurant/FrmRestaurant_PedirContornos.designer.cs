namespace HK.Formas
{
    partial class FrmRestaurant_PedirContornos
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
            this.Aceptar = new System.Windows.Forms.ToolStripButton();
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.Cancelar = new System.Windows.Forms.ToolStripButton();
            this.platosComentarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtContornos = new DevExpress.XtraEditors.ListBoxControl();
            this.platosContornoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BarraAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.platosComentarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContornos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platosContornoBindingSource)).BeginInit();
            this.SuspendLayout();
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
            // BarraAcciones
            // 
            this.BarraAcciones.AutoSize = false;
            this.BarraAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BarraAcciones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Aceptar,
            this.Cancelar});
            this.BarraAcciones.Location = new System.Drawing.Point(0, 458);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(398, 54);
            this.BarraAcciones.TabIndex = 46;
            this.BarraAcciones.Text = "toolStrip1";
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
            // txtContornos
            // 
            this.txtContornos.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContornos.Appearance.Options.UseFont = true;
            this.txtContornos.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.txtContornos.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.txtContornos.HotTrackItems = true;
            this.txtContornos.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick;
            this.txtContornos.Location = new System.Drawing.Point(12, 12);
            this.txtContornos.LookAndFeel.SkinName = "Office 2010 Blue";
            this.txtContornos.Name = "txtContornos";
            this.txtContornos.Padding = new System.Windows.Forms.Padding(2);
            this.txtContornos.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.txtContornos.Size = new System.Drawing.Size(379, 443);
            this.txtContornos.TabIndex = 53;
            // 
            // platosContornoBindingSource
            // 
            this.platosContornoBindingSource.DataSource = typeof(HK.Producto);
            // 
            // FrmRestaurant_PedirContornos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 512);
            this.Controls.Add(this.txtContornos);
            this.Controls.Add(this.BarraAcciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRestaurant_PedirContornos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalles del Plato";
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.platosComentarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContornos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platosContornoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource platosContornoBindingSource;
        private System.Windows.Forms.ToolStripButton Aceptar;
        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripButton Cancelar;
        private System.Windows.Forms.BindingSource platosComentarioBindingSource;
        private DevExpress.XtraEditors.ListBoxControl txtContornos;
    }
}