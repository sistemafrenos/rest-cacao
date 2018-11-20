namespace HK.Formas
{
    partial class FrmTablas_PlatosInsumosItem
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.CodigoButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.DescripcionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CantidadCalcEdit = new DevExpress.XtraEditors.CalcEdit();
            this.CostoCalcEdit = new DevExpress.XtraEditors.CalcEdit();
            this.TotalCostoCalcEdit = new DevExpress.XtraEditors.CalcEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForCodigo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCantidad = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCosto = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTotalCosto = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescripcion = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.Aceptar = new System.Windows.Forms.ToolStripButton();
            this.Cancelar = new System.Windows.Forms.ToolStripButton();
            this.itemBindingSource = new System.Windows.Forms.BindingSource();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CodigoButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescripcionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadCalcEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostoCalcEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalCostoCalcEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.BarraAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataLayoutControl1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.BarraAcciones);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(657, 192);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(657, 192);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.CodigoButtonEdit);
            this.dataLayoutControl1.Controls.Add(this.DescripcionTextEdit);
            this.dataLayoutControl1.Controls.Add(this.CantidadCalcEdit);
            this.dataLayoutControl1.Controls.Add(this.CostoCalcEdit);
            this.dataLayoutControl1.Controls.Add(this.TotalCostoCalcEdit);
            this.dataLayoutControl1.DataSource = this.itemBindingSource;
            this.dataLayoutControl1.Location = new System.Drawing.Point(13, 13);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(627, 106);
            this.dataLayoutControl1.TabIndex = 45;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // CodigoButtonEdit
            // 
            this.CodigoButtonEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.itemBindingSource, "Codigo", true));
            this.CodigoButtonEdit.Location = new System.Drawing.Point(2, 18);
            this.CodigoButtonEdit.Name = "CodigoButtonEdit";
            this.CodigoButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.CodigoButtonEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CodigoButtonEdit.Size = new System.Drawing.Size(193, 20);
            this.CodigoButtonEdit.StyleController = this.dataLayoutControl1;
            this.CodigoButtonEdit.TabIndex = 4;
            // 
            // DescripcionTextEdit
            // 
            this.DescripcionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.itemBindingSource, "Descripcion", true));
            this.DescripcionTextEdit.Location = new System.Drawing.Point(199, 18);
            this.DescripcionTextEdit.Name = "DescripcionTextEdit";
            this.DescripcionTextEdit.Properties.AppearanceReadOnly.BackColor = System.Drawing.SystemColors.Info;
            this.DescripcionTextEdit.Properties.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DescripcionTextEdit.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.DescripcionTextEdit.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.DescripcionTextEdit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DescripcionTextEdit.Properties.ReadOnly = true;
            this.DescripcionTextEdit.Size = new System.Drawing.Size(426, 20);
            this.DescripcionTextEdit.StyleController = this.dataLayoutControl1;
            this.DescripcionTextEdit.TabIndex = 5;
            this.DescripcionTextEdit.TabStop = false;
            // 
            // CantidadCalcEdit
            // 
            this.CantidadCalcEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.itemBindingSource, "Cantidad", true));
            this.CantidadCalcEdit.Location = new System.Drawing.Point(303, 58);
            this.CantidadCalcEdit.Name = "CantidadCalcEdit";
            this.CantidadCalcEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.CantidadCalcEdit.Size = new System.Drawing.Size(78, 20);
            this.CantidadCalcEdit.StyleController = this.dataLayoutControl1;
            this.CantidadCalcEdit.TabIndex = 6;
            // 
            // CostoCalcEdit
            // 
            this.CostoCalcEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.itemBindingSource, "Costo", true));
            this.CostoCalcEdit.Location = new System.Drawing.Point(385, 58);
            this.CostoCalcEdit.Name = "CostoCalcEdit";
            this.CostoCalcEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.CostoCalcEdit.Size = new System.Drawing.Size(98, 20);
            this.CostoCalcEdit.StyleController = this.dataLayoutControl1;
            this.CostoCalcEdit.TabIndex = 7;
            // 
            // TotalCostoCalcEdit
            // 
            this.TotalCostoCalcEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.itemBindingSource, "TotalCosto", true));
            this.TotalCostoCalcEdit.Location = new System.Drawing.Point(487, 58);
            this.TotalCostoCalcEdit.Name = "TotalCostoCalcEdit";
            this.TotalCostoCalcEdit.Properties.AllowFocused = false;
            this.TotalCostoCalcEdit.Properties.AppearanceReadOnly.BackColor = System.Drawing.SystemColors.Info;
            this.TotalCostoCalcEdit.Properties.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.InfoText;
            this.TotalCostoCalcEdit.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TotalCostoCalcEdit.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.TotalCostoCalcEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.TotalCostoCalcEdit.Properties.ReadOnly = true;
            this.TotalCostoCalcEdit.Size = new System.Drawing.Size(138, 20);
            this.TotalCostoCalcEdit.StyleController = this.dataLayoutControl1;
            this.TotalCostoCalcEdit.TabIndex = 8;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(627, 106);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForCodigo,
            this.ItemForCantidad,
            this.ItemForCosto,
            this.ItemForTotalCosto,
            this.ItemForDescripcion,
            this.emptySpaceItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(627, 106);
            this.layoutControlGroup2.Text = "autoGeneratedGroup0";
            // 
            // ItemForCodigo
            // 
            this.ItemForCodigo.Control = this.CodigoButtonEdit;
            this.ItemForCodigo.CustomizationFormText = "Codigo";
            this.ItemForCodigo.Location = new System.Drawing.Point(0, 0);
            this.ItemForCodigo.Name = "ItemForCodigo";
            this.ItemForCodigo.Size = new System.Drawing.Size(197, 40);
            this.ItemForCodigo.Text = "Codigo";
            this.ItemForCodigo.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForCodigo.TextSize = new System.Drawing.Size(55, 13);
            // 
            // ItemForCantidad
            // 
            this.ItemForCantidad.Control = this.CantidadCalcEdit;
            this.ItemForCantidad.CustomizationFormText = "Cantidad";
            this.ItemForCantidad.Location = new System.Drawing.Point(301, 40);
            this.ItemForCantidad.Name = "ItemForCantidad";
            this.ItemForCantidad.Size = new System.Drawing.Size(82, 66);
            this.ItemForCantidad.Text = "Cantidad";
            this.ItemForCantidad.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForCantidad.TextSize = new System.Drawing.Size(55, 13);
            // 
            // ItemForCosto
            // 
            this.ItemForCosto.Control = this.CostoCalcEdit;
            this.ItemForCosto.CustomizationFormText = "Costo";
            this.ItemForCosto.Location = new System.Drawing.Point(383, 40);
            this.ItemForCosto.Name = "ItemForCosto";
            this.ItemForCosto.Size = new System.Drawing.Size(102, 66);
            this.ItemForCosto.Text = "Costo";
            this.ItemForCosto.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForCosto.TextSize = new System.Drawing.Size(55, 13);
            // 
            // ItemForTotalCosto
            // 
            this.ItemForTotalCosto.Control = this.TotalCostoCalcEdit;
            this.ItemForTotalCosto.CustomizationFormText = "Total Costo";
            this.ItemForTotalCosto.Location = new System.Drawing.Point(485, 40);
            this.ItemForTotalCosto.Name = "ItemForTotalCosto";
            this.ItemForTotalCosto.Size = new System.Drawing.Size(142, 66);
            this.ItemForTotalCosto.Text = "Total Costo";
            this.ItemForTotalCosto.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForTotalCosto.TextSize = new System.Drawing.Size(55, 13);
            // 
            // ItemForDescripcion
            // 
            this.ItemForDescripcion.Control = this.DescripcionTextEdit;
            this.ItemForDescripcion.CustomizationFormText = "Descripcion";
            this.ItemForDescripcion.Location = new System.Drawing.Point(197, 0);
            this.ItemForDescripcion.Name = "ItemForDescripcion";
            this.ItemForDescripcion.Size = new System.Drawing.Size(430, 40);
            this.ItemForDescripcion.Text = "Descripcion";
            this.ItemForDescripcion.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForDescripcion.TextSize = new System.Drawing.Size(55, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 40);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(301, 66);
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
            this.BarraAcciones.Location = new System.Drawing.Point(0, 135);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(657, 57);
            this.BarraAcciones.TabIndex = 44;
            this.BarraAcciones.Text = "toolStrip1";
            // 
            // Aceptar
            // 
            this.Aceptar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Aceptar.Image = global::HK.Properties.Resources.disk_blue_ok;
            this.Aceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(81, 54);
            this.Aceptar.Text = "Aceptar - F12";
            this.Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Cancelar
            // 
            this.Cancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Cancelar.Image = global::HK.Properties.Resources.disk_blue_error;
            this.Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(88, 54);
            this.Cancelar.Text = "Cancelar - ESC";
            this.Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataSource = typeof(HK.ProductosCompuesto);
            // 
            // FrmTablas_PlatosInsumosItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 192);
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmTablas_PlatosInsumosItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insumo del plato";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CodigoButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescripcionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadCalcEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostoCalcEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalCostoCalcEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.BindingSource itemBindingSource;
        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripButton Aceptar;
        private System.Windows.Forms.ToolStripButton Cancelar;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.ButtonEdit CodigoButtonEdit;
        private DevExpress.XtraEditors.TextEdit DescripcionTextEdit;
        private DevExpress.XtraEditors.CalcEdit CantidadCalcEdit;
        private DevExpress.XtraEditors.CalcEdit CostoCalcEdit;
        private DevExpress.XtraEditors.CalcEdit TotalCostoCalcEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCodigo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescripcion;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCantidad;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCosto;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTotalCosto;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}