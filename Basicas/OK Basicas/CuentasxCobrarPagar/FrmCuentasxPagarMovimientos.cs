using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK.Clases;

namespace HK.Formas
{
    public partial class FrmCuentasxPagarMovimientos : Form
    {
      //  DatosEntities db = new DatosEntities(OK.CadenaConexion);
        public Tercero proveedor = new Tercero();
        private List<TercerosMovimiento> lista = new List<TercerosMovimiento>();
        public FrmCuentasxPagarMovimientos()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmCuentasxPagarMovimientos_Load);
        }
        void FrmCuentasxPagarMovimientos_Load(object sender, EventArgs e)
        {
            this.desde.DateTime = DateTime.Today.AddDays(-30);
            this.hasta.DateTime = DateTime.Today;
            this.btnBuscar.Click += new EventHandler(btnBuscar_Click);
            this.btnVer.Click += new EventHandler(btnVer_Click);
            this.btnImprimir.Click += new EventHandler(btnImprimir_Click);
            this.comboBoxProveedores.Properties.Items.Add(proveedor.RazonSocial);
            this.comboBoxProveedores.Properties.Items.Add("TODOS");
            this.comboBoxProveedores.Text = proveedor.RazonSocial;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 100;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - 50;
            this.CenterToScreen();
        }

        void btnImprimir_Click(object sender, EventArgs e)
        {

        }


        void btnVer_Click(object sender, EventArgs e)
        {
            TercerosMovimiento movimiento = (TercerosMovimiento)this.bs.Current;
            if (movimiento == null)
                return;
            if (movimiento.Tipo == "COMPRA")
            {
                //using (var db = new DatosEntities(OK.CadenaConexion))
                //{
                //    BussinesLogic.Compras compras = new BussinesLogic.Compras();
                //    compras.Load(movimiento.IdDocumento);
                //    if (compras.current == null)
                //        return;
                //    if (compras.current.DocumentosProductos.Count > 0)
                //    {
                //        FrmComprasItem f = new FrmComprasItem();
                //        f.IdDocumento = compras.current.IdDocumento;
                //        f.Ver();
                //    }
                //    else
                //    {
                //        FrmComprasItemGasto f = new FrmComprasItemGasto();
                //        f.IdDocumento = compras.current.IdDocumento;
                //        f.Ver();
                //    }
                //}
            }
            // Pendiente Pasar a CH
            if (movimiento.Tipo == "PAGO")
            {
                //FrmBancosCheque f2 = new FrmBancosCheque();
                //BancosMovimiento ch = FactoryBancos.ItemxNumeroCheque(movimiento.Numero);
                //if (ch == null)
                //    return;
                //f2.registro = ch;
                //f2.Ver();
            }
        }
        void btnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }
        private void Busqueda()
        {
            // pendiente
            //proveedor.TercerosMovimientos;
            this.bs.DataSource = lista;
            this.bs.ResetBindings(true);
        }
    }
}
