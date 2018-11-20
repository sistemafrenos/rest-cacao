namespace HK.Formas
{
    partial class FrmTablas_MaestroDeCuentasItem
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
            this.ItemForUltimaEdicion = new DevExpress.XtraLayout.LayoutControlItem();
            this.UltimaEdicionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dataLayoutControl2 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.IdDepositoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CodigoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.maestroDeCuentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DescripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.IdUsuarioTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForIdDeposito = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIdUsuario = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForCodigo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescripcion = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.Aceptar = new System.Windows.Forms.ToolStripButton();
            this.Cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUltimaEdicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltimaEdicionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).BeginInit();
            this.dataLayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IdDepositoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodigoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maestroDeCuentaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdUsuarioTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIdDeposito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIdUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.BarraAcciones.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemForUltimaEdicion
            // 
            this.ItemForUltimaEdicion.Control = this.UltimaEdicionTextEdit;
            this.ItemForUltimaEdicion.CustomizationFormText = "Ultima Edicion";
            this.ItemForUltimaEdicion.Location = new System.Drawing.Point(0, 0);
            this.ItemForUltimaEdicion.Name = "ItemForUltimaEdicion";
            this.ItemForUltimaEdicion.Size = new System.Drawing.Size(0, 0);
            this.ItemForUltimaEdicion.Text = "Ultima Edicion";
            this.ItemForUltimaEdicion.TextSize = new System.Drawing.Size(50, 20);
            this.ItemForUltimaEdicion.TextToControlDistance = 5;
            // 
            // UltimaEdicionTextEdit
            // 
            this.UltimaEdicionTextEdit.Location = new System.Drawing.Point(0, 0);
            this.UltimaEdicionTextEdit.Name = "UltimaEdicionTextEdit";
            this.UltimaEdicionTextEdit.Size = new System.Drawing.Size(0, 20);
            this.UltimaEdicionTextEdit.StyleController = this.dataLayoutControl2;
            this.UltimaEdicionTextEdit.TabIndex = 7;
            // 
            // dataLayoutControl2
            // 
            this.dataLayoutControl2.Controls.Add(this.IdDepositoTextEdit);
            this.dataLayoutControl2.Controls.Add(this.CodigoTextEdit);
            this.dataLayoutControl2.Controls.Add(this.DescripcionTextEdit);
            this.dataLayoutControl2.Controls.Add(this.IdUsuarioTextEdit);
            this.dataLayoutControl2.Controls.Add(this.UltimaEdicionTextEdit);
            this.dataLayoutControl2.DataSource = this.maestroDeCuentaBindingSource;
            this.dataLayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl2.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForIdDeposito,
            this.ItemForUltimaEdicion,
            this.ItemForIdUsuario});
            this.dataLayoutControl2.Location = new System.Drawing.Point(2, 22);
            this.dataLayoutControl2.Name = "dataLayoutControl2";
            this.dataLayoutControl2.Root = this.layoutControlGroup2;
            this.dataLayoutControl2.Size = new System.Drawing.Size(550, 99);
            this.dataLayoutControl2.TabIndex = 1;
            this.dataLayoutControl2.Text = "dataLayoutControl2";
            // 
            // IdDepositoTextEdit
            // 
            this.IdDepositoTextEdit.Location = new System.Drawing.Point(0, 0);
            this.IdDepositoTextEdit.Name = "IdDepositoTextEdit";
            this.IdDepositoTextEdit.Size = new System.Drawing.Size(0, 20);
            this.IdDepositoTextEdit.StyleController = this.dataLayoutControl2;
            this.IdDepositoTextEdit.TabIndex = 4;
            // 
            // CodigoTextEdit
            // 
            this.CodigoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.maestroDeCuentaBindingSource, "Codigo", true));
            this.CodigoTextEdit.Location = new System.Drawing.Point(60, 2);
            this.CodigoTextEdit.Name = "CodigoTextEdit";
            this.CodigoTextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CodigoTextEdit.Size = new System.Drawing.Size(213, 20);
            this.CodigoTextEdit.StyleController = this.dataLayoutControl2;
            this.CodigoTextEdit.TabIndex = 5;
            // 
            // maestroDeCuentaBindingSource
            // 
            this.maestroDeCuentaBindingSource.DataSource = typeof(HK.MaestroDeCuenta);
            // 
            // DescripcionTextEdit
            // 
            this.DescripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.maestroDeCuentaBindingSource, "Descripcion", true));
            this.DescripcionTextEdit.Location = new System.Drawing.Point(60, 26);
            this.DescripcionTextEdit.Name = "DescripcionTextEdit";
            this.DescripcionTextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DescripcionTextEdit.Size = new System.Drawing.Size(488, 20);
            this.DescripcionTextEdit.StyleController = this.dataLayoutControl2;
            this.DescripcionTextEdit.TabIndex = 6;
            // 
            // IdUsuarioTextEdit
            // 
            this.IdUsuarioTextEdit.Location = new System.Drawing.Point(0, 0);
            this.IdUsuarioTextEdit.Name = "IdUsuarioTextEdit";
            this.IdUsuarioTextEdit.Size = new System.Drawing.Size(0, 20);
            this.IdUsuarioTextEdit.StyleController = this.dataLayoutControl2;
            this.IdUsuarioTextEdit.TabIndex = 8;
            // 
            // ItemForIdDeposito
            // 
            this.ItemForIdDeposito.Control = this.IdDepositoTextEdit;
            this.ItemForIdDeposito.CustomizationFormText = "Id Deposito";
            this.ItemForIdDeposito.Location = new System.Drawing.Point(0, 0);
            this.ItemForIdDeposito.Name = "ItemForIdDeposito";
            this.ItemForIdDeposito.Size = new System.Drawing.Size(0, 0);
            this.ItemForIdDeposito.Text = "Id Deposito";
            this.ItemForIdDeposito.TextSize = new System.Drawing.Size(50, 20);
            this.ItemForIdDeposito.TextToControlDistance = 5;
            // 
            // ItemForIdUsuario
            // 
            this.ItemForIdUsuario.Control = this.IdUsuarioTextEdit;
            this.ItemForIdUsuario.CustomizationFormText = "Id Usuario";
            this.ItemForIdUsuario.Location = new System.Drawing.Point(0, 0);
            this.ItemForIdUsuario.Name = "ItemForIdUsuario";
            this.ItemForIdUsuario.Size = new System.Drawing.Size(0, 0);
            this.ItemForIdUsuario.Text = "Id Usuario";
            this.ItemForIdUsuario.TextSize = new System.Drawing.Size(50, 20);
            this.ItemForIdUsuario.TextToControlDistance = 5;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(550, 99);
            this.layoutControlGroup2.Text = "layoutControlGroup2";
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AllowDrawBackground = false;
            this.layoutControlGroup3.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForCodigo,
            this.ItemForDescripcion,
            this.emptySpaceItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "autoGeneratedGroup0";
            this.layoutControlGroup3.Size = new System.Drawing.Size(550, 99);
            this.layoutControlGroup3.Text = "autoGeneratedGroup0";
            // 
            // ItemForCodigo
            // 
            this.ItemForCodigo.Control = this.CodigoTextEdit;
            this.ItemForCodigo.CustomizationFormText = "Codigo";
            this.ItemForCodigo.Location = new System.Drawing.Point(0, 0);
            this.ItemForCodigo.Name = "ItemForCodigo";
            this.ItemForCodigo.Size = new System.Drawing.Size(275, 24);
            this.ItemForCodigo.Text = "Codigo";
            this.ItemForCodigo.TextSize = new System.Drawing.Size(54, 13);
            // 
            // ItemForDescripcion
            // 
            this.ItemForDescripcion.Control = this.DescripcionTextEdit;
            this.ItemForDescripcion.CustomizationFormText = "Descripcion";
            this.ItemForDescripcion.Location = new System.Drawing.Point(0, 24);
            this.ItemForDescripcion.Name = "ItemForDescripcion";
            this.ItemForDescripcion.Size = new System.Drawing.Size(550, 75);
            this.ItemForDescripcion.Text = "Descripcion";
            this.ItemForDescripcion.TextSize = new System.Drawing.Size(54, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(275, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(275, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // BarraAcciones
            // 
            this.BarraAcciones.AutoSize = false;
            this.BarraAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BarraAcciones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Aceptar,
            this.Cancelar});
            this.BarraAcciones.Location = new System.Drawing.Point(0, 148);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(589, 54);
            this.BarraAcciones.TabIndex = 39;
            this.BarraAcciones.Text = "toolStrip1";
            // 
            // Aceptar
            // 
            this.Aceptar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Aceptar.Image = global::HK.Properties.Resources.disk_blue_ok;
            this.Aceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(77, 51);
            this.Aceptar.Text = "Aceptar - F12";
            this.Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            // toolStripFecha
            // 
            this.toolStripFecha.Name = "toolStripFecha";
            this.toolStripFecha.Size = new System.Drawing.Size(36, 17);
            this.toolStripFecha.Text = "Fecha";
            // 
            // toolStripUsuario
            // 
            this.toolStripUsuario.Name = "toolStripUsuario";
            this.toolStripUsuario.Size = new System.Drawing.Size(47, 17);
            this.toolStripUsuario.Text = "Usuario:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripUsuario,
            this.toolStripFecha});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(589, 22);
            this.statusStrip1.TabIndex = 41;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dataLayoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(554, 123);
            this.groupControl1.TabIndex = 40;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.groupControl1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.BarraAcciones);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(589, 202);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(589, 224);
            this.toolStripContainer1.TabIndex = 44;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // FrmTablas_MaestroDeCuentasItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 224);
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmTablas_MaestroDeCuentasItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Maestro Cuenta";
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUltimaEdicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltimaEdicionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).EndInit();
            this.dataLayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IdDepositoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodigoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maestroDeCuentaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdUsuarioTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIdDeposito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIdUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlItem ItemForUltimaEdicion;
        private DevExpress.XtraEditors.TextEdit UltimaEdicionTextEdit;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl2;
        private DevExpress.XtraEditors.TextEdit IdDepositoTextEdit;
        private DevExpress.XtraEditors.TextEdit CodigoTextEdit;
        private DevExpress.XtraEditors.TextEdit DescripcionTextEdit;
        private DevExpress.XtraEditors.TextEdit IdUsuarioTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIdDeposito;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIdUsuario;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCodigo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescripcion;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripButton Aceptar;
        private System.Windows.Forms.ToolStripButton Cancelar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripFecha;
        private System.Windows.Forms.ToolStripStatusLabel toolStripUsuario;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.BindingSource maestroDeCuentaBindingSource;
    }
}