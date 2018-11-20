using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK.Clases;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmVentasCotizaciones : Form
    {
        Administrativo data;
        public FrmVentasCotizaciones()
        {
            InitializeComponent();
            data = new Administrativo();
            this.Load += new EventHandler(FrmCotizaciones_Load);
        }
        void FrmCotizaciones_Load(object sender, EventArgs e)
        {
            try
            {
            this.KeyPreview = true;
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(gridView1_InvalidRowException);
            this.KeyDown += new KeyEventHandler(FrmCotizaciones_KeyDown);
            gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnBuscar.Click += new EventHandler(btnBuscar_Click);
            btnEditar.Click += new EventHandler(btnEditar_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
            btnImprimir.Click += new EventHandler(btnImprimir_Click);
            btnEmail.Click += new EventHandler(btnEmail_Click);
            btnFactura.Click += new EventHandler(btnFactura_Click);
            btnNotaEntrega.Click += new EventHandler(btnNotaEntrega_Click);
            txtBuscar.KeyDown += new KeyEventHandler(txtBuscar_KeyDown);
            this.txtFiltro.Items.AddRange(new string[] { "HOY", "AYER", "ESTE MES", "MES ANTERIOR", "TODAS" });
            //#region grid
            //gridView1.OptionsLayout.Columns.Reset();
            //gridControl1.ForceInitialize();
            //this.gridControl1.DefaultView.RestoreLayoutFromXml(String.Format("{0}\\{1}.XML", data.SistemaConfig.DirectorioListas ,"Cotizaciones"), DevExpress.Utils.OptionsLayoutGrid.FullLayout);
            //#endregion

                Busqueda();
            }
            catch (Exception x)
            {
                var s = x.Message;
            }
        }

        void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        void btnNotaEntrega_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            FrmVentasNotasEntregasItem f = new FrmVentasNotasEntregasItem();
            f.CargarCotizacion((Cotizacion)bs.Current);
        }

        void btnFactura_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            FrmVentasFacturasItem f = new FrmVentasFacturasItem();
            f.CargarCotizacion((Cotizacion)bs.Current);
        }
        void btnEmail_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            FrmReportes f = new FrmReportes();
            f.Ventas_Cotizacion((Cotizacion)this.bs.Current, true);
        }
        void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            FrmReportes f = new FrmReportes();
            f.Ventas_Cotizacion((Cotizacion)this.bs.Current, false);
        }
        void FrmCotizaciones_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    btnNuevo.PerformClick();
                    break;
            }
        }
        void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
        }
        void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            FrmVentasCotizacionesItem f = new FrmVentasCotizacionesItem()
            {
                data = data,
                IdCotizacion = ((Cotizacion)this.bs.Current).ID
            };
            f.Modificar();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                Busqueda();
        }
        void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmVentasCotizacionesItem f = new FrmVentasCotizacionesItem();
            f.data = data;
            f.Incluir();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                Busqueda();
        }
        private void Busqueda()
        {
            this.bs.DataSource = data.GetDocumentos(txtBuscar.Text, "COTIZACION", txtFiltro.Text);
            this.bs.ResetBindings(true);
            gridView1.BestFitColumns();
        }
        private void EliminarRegistro()
        {
            Cotizacion item = (Cotizacion)this.bs.Current;
            if (item == null)
                return;
            if (MessageBox.Show("Esta seguro de eliminar esta Cotizacion", "Atencion", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                return;
            data.EliminarCotizacion(item,true);
            Busqueda();
        }
        #region Eventos
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView1.ActiveEditor == null)
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        btnNuevo.PerformClick();
                        break;
                    case Keys.Return:
                        btnEditar.PerformClick();
                        break;
                    case Keys.Delete:
                        btnEliminar.PerformClick();
                        break;
                    case Keys.Subtract:
                        btnEliminar.PerformClick();
                        break;
                }
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }
        private void Eliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
        }
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Busqueda();
            }
        }
        #endregion
    }
}
