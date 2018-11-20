using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.Fiscales;
using HK.BussinessLogic;
using HK.BussinessLogic.Restaurant;

namespace HK.Formas
{
    public partial class FrmRestaurant_ConsultarFacturas : Form
    {
        public Restaurant data;
        DateTime inicio = DateTime.Today;
        DateTime final = DateTime.Today;
        MesasCerrada[] lista;
        public FrmRestaurant_ConsultarFacturas()
        {
            InitializeComponent();
            if (data == null)
                data = new Restaurant();
            this.Load += new EventHandler(FrmFacturas_Load);
        }
        void FrmFacturas_Load(object sender, EventArgs e)
        {
            Busqueda();
            Buscar.Click += new EventHandler(Buscar_Click);
            gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            VerFactura.Click += new EventHandler(VerFactura_Click);
            Eliminar.Click += new EventHandler(Eliminar_Click);
            txtBuscar.KeyDown += new KeyEventHandler(txtBuscar_KeyDown);
            Duplicar.Click += new EventHandler(Duplicar_Click);
            btnMail.Click += new EventHandler(btnMail_Click);
            btnReporteFacturas.Click += new EventHandler(btnReporteFacturas_Click);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);

            gridView1.OptionsLayout.Columns.Reset();
            txtDesde.Text = inicio.ToShortDateString();
            txtHasta.Text = final.ToShortDateString();

            this.Height = Screen.PrimaryScreen.Bounds.Height - 100;
            this.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            this.CenterToScreen();
        }

        void btnMail_Click(object sender, EventArgs e)
        {
            var f = new FrmRestaurant_Reportes();
            f.Restaurant_MesasCerradas(lista, string.Format("desde {0} hasta {1}",txtDesde.Text,txtHasta.Text), true);
        }

        void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        void btnReporteFacturas_Click(object sender, EventArgs e)
        {
            var f = new FrmRestaurant_Reportes();
            f.Restaurant_MesasCerradas(lista, string.Format("desde {0} hasta {1}", txtDesde.Text, txtHasta.Text), false);
        }
        void VerFactura_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            Factura documento = data.FindFactura(((MesasCerrada)this.bs.Current).DocumentoID);
            if (documento != null)
            {
                FrmConsultarFacturasItem f = new FrmConsultarFacturasItem() { IdDocumento = documento.ID };
                f.Ver();
            }
        }
        private void Busqueda()
        {
            if(!DateTime.TryParse(txtDesde.Text, out inicio))
                inicio = DateTime.Today;
            if(!DateTime.TryParse(txtHasta.Text, out final))
                final = DateTime.Today;
            lista = data.GetByFechasTipoMesasCerradas(inicio, final, txtBuscar.Text);
            this.bs.DataSource = lista;
            this.bs.ResetBindings(true);
        }
        private void DuplicarRegistro()
        {
            if (this.bs.Current == null)
                return;
            Factura documento = data.FindFactura( ((MesasCerrada)this.bs.Current).DocumentoID);
            try
            {
                if(documento!=null)
                {
                    IFiscal Fiscal = ((Fiscal)new Fiscal()).GetFiscal();
                    Fiscal.ImprimeFacturaCopia(documento);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        private void EliminarRegistro()
        {
            if (this.bs.Current == null)
                return;
            Factura documento = data.FindFacturaByNumero(((MesasCerrada)this.bs.Current).Factura);
            if (documento == null) 
            {
                MessageBox.Show("Numero de factura no encontrada", "Atencion");
                return;
            }
            if (documento.Anulado.GetValueOrDefault(false) == true)
            {
                if (MessageBox.Show("Esta operacion ya fue devuelta,Desea realizar la devolucion de nuevo", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
            }
            try
            {
                NotaDeCredito devolucion = data.CrearNotaDeCredito(documento);
                IFiscal Fiscal = ((Fiscal)new Fiscal()).GetFiscal();
                Pago pago = data.FindPagoIdDocumento(documento.ID);
                Fiscal.ImprimeNotaCredito(devolucion, pago);
                data.ProcesarNotaCredito(documento, devolucion);
            }
            catch (Exception x)
            {
                Basicas.ManejarError(x);
            }
        }
        #region Eventos
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView1.ActiveEditor == null)
            {
                switch (e.KeyCode)
                {
                    case Keys.Return:
                        VerFactura.PerformClick();
                        break;
                    case Keys.Delete:
                        Eliminar.PerformClick();
                        break;
                    case Keys.Subtract:
                        Eliminar.PerformClick();
                        break;
                    case Keys.P:
                        Duplicar.PerformClick();
                        break;
                }
            }
        }
        private void Buscar_Click(object sender, EventArgs e)
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
        private void Duplicar_Click(object sender, EventArgs e)
        {
            DuplicarRegistro();
        }
        #endregion
    }
}
