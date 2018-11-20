namespace HK
{
    partial class FrmTags
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.gridGrupos = new DevExpress.XtraGrid.GridControl();
            this.layoutGrupos = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.colDepartamento = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.layoutViewField_colUbicacion = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnAgregarEtiqueta = new DevExpress.XtraEditors.SimpleButton();
            this.txtNuevaEtiqueta = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.BarraAcciones = new System.Windows.Forms.ToolStrip();
            this.Aceptar = new System.Windows.Forms.ToolStripButton();
            this.Cancelar = new System.Windows.Forms.ToolStripButton();
            this.dataSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutGrupos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colUbicacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevaEtiqueta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.BarraAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridGrupos
            // 
            this.gridGrupos.Location = new System.Drawing.Point(12, 50);
            this.gridGrupos.MainView = this.layoutGrupos;
            this.gridGrupos.Name = "gridGrupos";
            this.gridGrupos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemMemoEdit1});
            this.gridGrupos.Size = new System.Drawing.Size(596, 318);
            this.gridGrupos.TabIndex = 8;
            this.gridGrupos.TabStop = false;
            this.gridGrupos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutGrupos});
            // 
            // layoutGrupos
            // 
            this.layoutGrupos.Appearance.CardCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(204)))), ((int)(((byte)(187)))));
            this.layoutGrupos.Appearance.CardCaption.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(204)))), ((int)(((byte)(187)))));
            this.layoutGrupos.Appearance.CardCaption.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.layoutGrupos.Appearance.CardCaption.ForeColor = System.Drawing.Color.Black;
            this.layoutGrupos.Appearance.CardCaption.Options.UseBackColor = true;
            this.layoutGrupos.Appearance.CardCaption.Options.UseBorderColor = true;
            this.layoutGrupos.Appearance.CardCaption.Options.UseFont = true;
            this.layoutGrupos.Appearance.CardCaption.Options.UseForeColor = true;
            this.layoutGrupos.Appearance.FieldCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(204)))), ((int)(((byte)(187)))));
            this.layoutGrupos.Appearance.FieldCaption.BackColor2 = System.Drawing.Color.GhostWhite;
            this.layoutGrupos.Appearance.FieldCaption.ForeColor = System.Drawing.Color.Black;
            this.layoutGrupos.Appearance.FieldCaption.Options.UseBackColor = true;
            this.layoutGrupos.Appearance.FieldCaption.Options.UseForeColor = true;
            this.layoutGrupos.Appearance.FieldValue.BackColor = System.Drawing.Color.White;
            this.layoutGrupos.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.layoutGrupos.Appearance.FieldValue.ForeColor = System.Drawing.Color.Black;
            this.layoutGrupos.Appearance.FieldValue.Options.UseBackColor = true;
            this.layoutGrupos.Appearance.FieldValue.Options.UseFont = true;
            this.layoutGrupos.Appearance.FieldValue.Options.UseForeColor = true;
            this.layoutGrupos.Appearance.FieldValue.Options.UseTextOptions = true;
            this.layoutGrupos.Appearance.FieldValue.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutGrupos.Appearance.FieldValue.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.None;
            this.layoutGrupos.Appearance.FieldValue.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutGrupos.Appearance.FieldValue.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.layoutGrupos.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.layoutGrupos.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(201)))), ((int)(((byte)(164)))));
            this.layoutGrupos.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.layoutGrupos.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.layoutGrupos.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.layoutGrupos.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.layoutGrupos.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.layoutGrupos.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.layoutGrupos.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(111)))), ((int)(((byte)(74)))));
            this.layoutGrupos.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.layoutGrupos.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
            this.layoutGrupos.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.layoutGrupos.Appearance.FilterPanel.Options.UseBackColor = true;
            this.layoutGrupos.Appearance.FilterPanel.Options.UseForeColor = true;
            this.layoutGrupos.Appearance.FocusedCardCaption.BackColor = System.Drawing.Color.Teal;
            this.layoutGrupos.Appearance.FocusedCardCaption.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.layoutGrupos.Appearance.FocusedCardCaption.BorderColor = System.Drawing.Color.Teal;
            this.layoutGrupos.Appearance.FocusedCardCaption.ForeColor = System.Drawing.Color.White;
            this.layoutGrupos.Appearance.FocusedCardCaption.Options.UseBackColor = true;
            this.layoutGrupos.Appearance.FocusedCardCaption.Options.UseBorderColor = true;
            this.layoutGrupos.Appearance.FocusedCardCaption.Options.UseForeColor = true;
            this.layoutGrupos.Appearance.HideSelectionCardCaption.BackColor = System.Drawing.Color.Gray;
            this.layoutGrupos.Appearance.HideSelectionCardCaption.BorderColor = System.Drawing.Color.Gray;
            this.layoutGrupos.Appearance.HideSelectionCardCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.layoutGrupos.Appearance.HideSelectionCardCaption.Options.UseBackColor = true;
            this.layoutGrupos.Appearance.HideSelectionCardCaption.Options.UseBorderColor = true;
            this.layoutGrupos.Appearance.HideSelectionCardCaption.Options.UseForeColor = true;
            this.layoutGrupos.Appearance.SelectedCardCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.layoutGrupos.Appearance.SelectedCardCaption.ForeColor = System.Drawing.Color.White;
            this.layoutGrupos.Appearance.SelectedCardCaption.Options.UseBackColor = true;
            this.layoutGrupos.Appearance.SelectedCardCaption.Options.UseForeColor = true;
            this.layoutGrupos.Appearance.SeparatorLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(204)))), ((int)(((byte)(187)))));
            this.layoutGrupos.Appearance.SeparatorLine.Options.UseBackColor = true;
            this.layoutGrupos.Appearance.ViewBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(224)))), ((int)(((byte)(207)))));
            this.layoutGrupos.Appearance.ViewBackground.Options.UseBackColor = true;
            this.layoutGrupos.CardHorzInterval = 0;
            this.layoutGrupos.CardMinSize = new System.Drawing.Size(133, 28);
            this.layoutGrupos.CardVertInterval = 0;
            this.layoutGrupos.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.colDepartamento});
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.DarkSeaGreen;
            styleFormatCondition3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.Appearance.Options.UseFont = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition3.Expression = "[TieneComidas] == True";
            styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.Gold;
            styleFormatCondition4.Appearance.Options.UseBackColor = true;
            styleFormatCondition4.ApplyToRow = true;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition4.Expression = "[Bloqueada] == True";
            this.layoutGrupos.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition3,
            styleFormatCondition4});
            this.layoutGrupos.GridControl = this.gridGrupos;
            this.layoutGrupos.Name = "layoutGrupos";
            this.layoutGrupos.OptionsBehavior.AllowExpandCollapse = false;
            this.layoutGrupos.OptionsBehavior.AllowRuntimeCustomization = false;
            this.layoutGrupos.OptionsBehavior.Editable = false;
            this.layoutGrupos.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.layoutGrupos.OptionsBehavior.UseTabKey = false;
            this.layoutGrupos.OptionsCustomization.AllowFilter = false;
            this.layoutGrupos.OptionsCustomization.AllowSort = false;
            this.layoutGrupos.OptionsCustomization.ShowGroupCardCaptions = false;
            this.layoutGrupos.OptionsCustomization.ShowGroupCardIndents = false;
            this.layoutGrupos.OptionsCustomization.ShowGroupCards = false;
            this.layoutGrupos.OptionsCustomization.ShowGroupFields = false;
            this.layoutGrupos.OptionsCustomization.ShowGroupHiddenItems = false;
            this.layoutGrupos.OptionsCustomization.ShowGroupLayout = false;
            this.layoutGrupos.OptionsCustomization.ShowGroupLayoutTreeView = false;
            this.layoutGrupos.OptionsCustomization.ShowGroupView = false;
            this.layoutGrupos.OptionsCustomization.ShowResetShrinkButtons = false;
            this.layoutGrupos.OptionsCustomization.ShowSaveLoadLayoutButtons = false;
            this.layoutGrupos.OptionsFilter.AllowMRUFilterList = false;
            this.layoutGrupos.OptionsItemText.AlignMode = DevExpress.XtraGrid.Views.Layout.FieldTextAlignMode.AutoSize;
            this.layoutGrupos.OptionsItemText.TextToControlDistance = 0;
            this.layoutGrupos.OptionsSingleRecordMode.CardAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Near;
            this.layoutGrupos.OptionsSingleRecordMode.StretchCardToViewHeight = true;
            this.layoutGrupos.OptionsSingleRecordMode.StretchCardToViewWidth = true;
            this.layoutGrupos.OptionsView.CardsAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Far;
            this.layoutGrupos.OptionsView.ShowCardCaption = false;
            this.layoutGrupos.OptionsView.ShowCardExpandButton = false;
            this.layoutGrupos.OptionsView.ShowCardFieldBorders = true;
            this.layoutGrupos.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.layoutGrupos.OptionsView.ShowHeaderPanel = false;
            this.layoutGrupos.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiRow;
            this.layoutGrupos.TemplateCard = this.layoutViewCard1;
            // 
            // colDepartamento
            // 
            this.colDepartamento.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colDepartamento.FieldName = "Departamento";
            this.colDepartamento.LayoutViewField = this.layoutViewField_colUbicacion;
            this.colDepartamento.Name = "colDepartamento";
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // layoutViewField_colUbicacion
            // 
            this.layoutViewField_colUbicacion.EditorPreferredWidth = 129;
            this.layoutViewField_colUbicacion.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_colUbicacion.Name = "layoutViewField_colUbicacion";
            this.layoutViewField_colUbicacion.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutViewField_colUbicacion.Size = new System.Drawing.Size(131, 23);
            this.layoutViewField_colUbicacion.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_colUbicacion.TextToControlDistance = 0;
            this.layoutViewField_colUbicacion.TextVisible = false;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.GroupBordersVisible = false;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_colUbicacion});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 0;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnAgregarEtiqueta);
            this.layoutControl1.Controls.Add(this.txtNuevaEtiqueta);
            this.layoutControl1.Location = new System.Drawing.Point(12, 12);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(593, 32);
            this.layoutControl1.TabIndex = 9;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnAgregarEtiqueta
            // 
            this.btnAgregarEtiqueta.Location = new System.Drawing.Point(298, 2);
            this.btnAgregarEtiqueta.Name = "btnAgregarEtiqueta";
            this.btnAgregarEtiqueta.Size = new System.Drawing.Size(293, 22);
            this.btnAgregarEtiqueta.StyleController = this.layoutControl1;
            this.btnAgregarEtiqueta.TabIndex = 5;
            this.btnAgregarEtiqueta.Text = "Agregar Etiqueta";
            // 
            // txtNuevaEtiqueta
            // 
            this.txtNuevaEtiqueta.Location = new System.Drawing.Point(2, 2);
            this.txtNuevaEtiqueta.Name = "txtNuevaEtiqueta";
            this.txtNuevaEtiqueta.Size = new System.Drawing.Size(292, 20);
            this.txtNuevaEtiqueta.StyleController = this.layoutControl1;
            this.txtNuevaEtiqueta.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(593, 32);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtNuevaEtiqueta;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(296, 32);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnAgregarEtiqueta;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(296, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(297, 32);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // BarraAcciones
            // 
            this.BarraAcciones.AutoSize = false;
            this.BarraAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BarraAcciones.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.BarraAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Aceptar,
            this.Cancelar});
            this.BarraAcciones.Location = new System.Drawing.Point(0, 380);
            this.BarraAcciones.Name = "BarraAcciones";
            this.BarraAcciones.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BarraAcciones.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.BarraAcciones.Size = new System.Drawing.Size(624, 62);
            this.BarraAcciones.TabIndex = 45;
            this.BarraAcciones.Text = "toolStrip1";
            // 
            // Aceptar
            // 
            this.Aceptar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Aceptar.Image = global::HK.Properties.Resources.disk_blue_ok;
            this.Aceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(81, 59);
            this.Aceptar.Text = "Aceptar - F12";
            this.Aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Cancelar
            // 
            this.Cancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Cancelar.Image = global::HK.Properties.Resources.disk_blue_error;
            this.Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(88, 59);
            this.Cancelar.Text = "Cancelar - ESC";
            this.Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // FrmTags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.BarraAcciones);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.gridGrupos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmTags";
            this.Text = "Etiquetas";
            ((System.ComponentModel.ISupportInitialize)(this.gridGrupos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutGrupos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colUbicacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevaEtiqueta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.BarraAcciones.ResumeLayout(false);
            this.BarraAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridGrupos;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutGrupos;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colDepartamento;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colUbicacion;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnAgregarEtiqueta;
        private DevExpress.XtraEditors.TextEdit txtNuevaEtiqueta;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        public System.Windows.Forms.ToolStrip BarraAcciones;
        private System.Windows.Forms.ToolStripButton Aceptar;
        private System.Windows.Forms.ToolStripButton Cancelar;
        private System.Windows.Forms.BindingSource dataSource;
    }
}