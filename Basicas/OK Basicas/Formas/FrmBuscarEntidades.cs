using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK.Clases;
using HK.BussinessLogic;

namespace HK
{
    public partial class FrmBuscarEntidades : Form
    {
        public string Status;
        public object registro = null;
        public object items;
        private string Texto = "";
        private string myLayout = "";
        Administrativo data;
        public FrmBuscarEntidades()
        {
            InitializeComponent();
        }
        private void FrmBuscar_Load(object sender, EventArgs e)
        {
            data = new Administrativo();
            this.txtFiltro.Text = "TODOS";
            this.txtBuscar.Text = Texto;
            this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            this.Buscar.Click += new EventHandler(txtBuscar_Click);
            this.Imprimir.Click += new EventHandler(Imprimir_Click);
            txtBuscar.KeyDown += new KeyEventHandler(txtBuscar_KeyDown);
            Busqueda();
        }
        void txtBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }
        public void BuscarClientes(string s)
        {
            Texto = s;
            myLayout = "CLIENTES";
            this.ShowDialog();
        }
        public void BuscarCajaChica()
        {
            myLayout = "BUSCARCAJACHICA";
            this.ShowDialog();
        }

        public void BuscarBancosCheque()
        {
            myLayout = "BUSCARBANCOSCHEQUE";
            this.ShowDialog();
        }
        public void BuscarVendedores(string s)
        {
            Texto = s;
            myLayout = "VENDEDORES";
            this.ShowDialog();
        }
        public void BuscarDrivers(string s)
        {
            Texto = s;
            myLayout = "DRIVERS";
            this.ShowDialog();
        }
        public void BuscarCuentas(string s)
        {
            Texto = s;
            myLayout = "MAESTRO CUENTAS";
            this.ShowDialog();
        }
        public void BuscarProveedores(string s)
        {
            Texto = s;
            myLayout = "PROVEEDORES";
            this.ShowDialog();
        }
        public void BuscarMesoneros(string s)
        {
            Texto = s;
            myLayout = "MESONEROS";
            this.ShowDialog();
        }
        public void BuscarMesas(string s)
        {
            Texto = s;
            myLayout = "MESAS";
            this.ShowDialog();
        }
        public void BuscarMesasDisponibles(string s)
        {
            Texto = s;
            myLayout = "MESAS DISPONIBLES";
            this.ShowDialog();
        }
        public void BuscarPlatos(string s)
        {
            myLayout = "PLATOS";
            Texto = s;
            this.ShowDialog();
        }
        public void BuscarFacturas(string s)
        {
            myLayout = "FACTURAS";
            Texto = s;
            this.ShowDialog();
        }
        public void BuscarCompras(string s)
        {
            myLayout = "COMPRAS";
            Texto = s;
            this.ShowDialog();
        }
        public void BuscarComprasAbiertas(string s)
        {
            myLayout = "COMPRASABIERTA";
            Texto = s;
            this.ShowDialog();
        }
        public void BuscarComprasProveedor(string s)
        {
            myLayout = "COMPRASPROVEEDOR";
            Texto = s;
            this.ShowDialog();
        }
        public void BuscarProductos(string s)
        {
            myLayout = "BUSCARPRODUCTOS";
            Texto = s;
            this.ShowDialog();
        }
        public void BuscarDepartamentos(string s)
        {
            myLayout = "DEPARTAMENTOS";
            Texto = s;
            this.ShowDialog();
        }
        public void BuscarProductosVentas(string s)
        {
            myLayout = "BUSCARPRODUCTOSVENTAS";
            Texto = s;
            this.ShowDialog();
        }
        public void BuscarProductosCompras(string s)
        {
            myLayout = "BUSCARPRODUCTOSCOMPRAS";
            Texto = s;
            this.ShowDialog();
        }
        public void BuscarCotizaciones(string s)
        {
            myLayout = "COTIZACIONES";
            Texto = s;
            this.ShowDialog();
        }
        public void BuscarAbiertas()
        {
            myLayout = "ABIERTAS";
            Texto = null;
            this.ShowDialog();
        }
        public void BuscarNotasEntrega(string s)
        {
            myLayout = "NOTASENTREGAS";
            Texto = s;
            this.ShowDialog();
        }
        public void BuscarBancos(string s)
        {
            myLayout = "BANCOS";
            Texto = s;
            this.ShowDialog();
        }

        private void Busqueda()
        {
            Texto = this.txtBuscar.Text;
            switch (myLayout.ToUpper())
            {
                case "CLIENTES":
                    this.bindingSource.DataSource = data.GetAllClientes(txtBuscar.Text);
                    break;
                case "VENDEDORES":
                    this.bindingSource.DataSource = data.GetAllVendedores(txtBuscar.Text);
                    break;
                case "COMPRAS":
                    this.bindingSource.DataSource = data.GetAllCompras(Texto,null);
                    break;
                case "COMPRASABIERTA":
                    this.bindingSource.DataSource = data.GetQueryableCompras().Where(x => x.Estatus == "COMPRA ABIERTA").OrderBy(x => x.Fecha).ToList();
                    break;
                case "COMPRASPROVEEDOR":
                    this.bindingSource.DataSource = data.GetAllCompras(Texto,null);
                    break;
                case "FACTURAS":
                    this.bindingSource.DataSource = data.GetAllFacturas(Texto);
                    break;
                case "NOTASENTREGAS":
                    this.bindingSource.DataSource = data.GetAllNotasDeEntrega(Texto);
                    break;
                case "BUSCARPRODUCTOS":
                    this.bindingSource.DataSource = data.GetAllProductos(Texto);
                    break;
                case "BUSCARPRODUCTOSVENTAS":
                    this.bindingSource.DataSource = data.GetAllProductosVentas(Texto,null);
                    break;
                case "BUSCARPRODUCTOSCOMPRAS":
                    this.bindingSource.DataSource = data.GetAllProductosCompras(Texto);
                    break;
                case "PROVEEDORES":
                    this.bindingSource.DataSource = data.GetAllProveedores(Texto);
                    break;
                case "COTIZACIONES":
                    this.bindingSource.DataSource = data.GetAllCotizaciones(Texto);
                    break;
                case "MAESTRO CUENTAS":
                    this.bindingSource.DataSource = data.GetAllMaestroCuenta(Texto);
                    break;
                case "BANCOS":
                    this.bindingSource.DataSource = data.GetAllBancos(Texto);
                    break;
                case "BUSCARCAJACHICA":
                  //  this.bindingSource.DataSource = FactoryCajasChica.PagosCajasChica(dc);
                    break;
                case "BUSCARBANCOSCHEQUE":
                  //  this.bindingSource.DataSource = FactoryBancos.ItemxCheques(dc, Texto);
                    break;
                case "ABIERTAS":
                    this.bindingSource.DataSource = data.GetAllFacturasAbiertas(txtBuscar.Text,"FACTURA ABIERTA");
                    break;
                case "FACTURA":
                    this.bindingSource.DataSource = data.GetAllFacturas(txtBuscar.Text, "FACTURA");
                    break;
            }
            if (this.bindingSource.Count > 0)
            {
                this.txtBuscar.Focus();
            }
            else
            {
                this.gridView1.Focus();
            }
            this.gridControl1.DataSource = this.bindingSource;
            gridControl1.ForceInitialize();
            gridView1.OptionsLayout.Columns.Reset();
            this.gridControl1.DefaultView.RestoreLayoutFromXml(String.Format("{0}\\{1}.XML", data.SistemaConfig.DirectorioListas , myLayout), DevExpress.Utils.OptionsLayoutGrid.FullLayout);
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor =  Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Seleccionar();
        }
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    Eliminar();
                    e.Handled = true;
                    break;
                case Keys.Return:
                    Seleccionar();
                    e.Handled = true;
                    break;
                case Keys.Escape:
                    Cancelar();
                    e.Handled = true;
                    break;
                case Keys.F2:
                    txtBuscar.Focus();
                    e.Handled = true;
                    break;
                case Keys.F3:
                    gridView1.Focus();
                    e.Handled = true;
                    break;
            }
        }
        private void Seleccionar()
        {
            if (this.bindingSource.Current != null)
            {
                this.DialogResult = DialogResult.OK;
                registro = this.bindingSource.Current;
                this.Close();
            }
        }
        private void Eliminar()
        {
            if (this.bindingSource.Current != null)
            {
                this.DialogResult = DialogResult.Abort;
                registro = this.bindingSource.Current;
                this.Close();
            }
        }
        private void Cancelar()
        {
            this.DialogResult = DialogResult.Cancel;
            registro = null;
            this.Close();
        }
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Busqueda();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Cancelar();
            }
        }
        private void Imprimir_Click(object sender, EventArgs e)
        {
            this.gridControl1.ShowPrintPreview();
        }
    }
}
