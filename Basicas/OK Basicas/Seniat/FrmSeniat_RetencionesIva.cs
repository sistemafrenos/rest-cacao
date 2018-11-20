using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK.Clases;


namespace HK.Formas
{
    public partial class FrmSeniat_RetencionesIva : DevExpress.XtraEditors.XtraForm
    {
        BussinessLogic.Retenciones retenciones;
        List<Retencion> lista = new List<Retencion>();
        public FrmSeniat_RetencionesIva()
        {
            InitializeComponent();
            BarraAcciones.Text = "RetencionesIva";
            Basicas.AsegurarToolStrip(new object[] { BarraAcciones });
        }
        private void FrmRetenciones_Load(object sender, EventArgs e)
        {
            retenciones = new BussinessLogic.Retenciones();
            this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            this.btnNuevo.Click += new EventHandler(btnNuevo_Click);
            this.btnEditar.Click += new EventHandler(btnEditar_Click);
            this.btnEliminar.Click += new EventHandler(btnEliminar_Click);
            this.btnBuscar.Click += new EventHandler(btnBuscar_Click);
            this.btnImprimir.Click += new EventHandler(btnImprimir_Click);
            this.txtAño.Text = DateTime.Today.Year.ToString();
            this.txtMes.Text = DateTime.Today.Month.ToString("00");
            this.btnTxt.Click += new EventHandler(btnTxt_Click);
            if (DateTime.Today.Day > 15)
                this.txtPeriodo.Text = "SEGUNDO PERIODO";
            else
                this.txtPeriodo.Text = "PRIMER PERIODO";
            Busqueda();
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
        }

        void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            EditarRegistro();
        }

        void btnEditar_Click(object sender, EventArgs e)
        {
            EditarRegistro();
        }

        private void EditarRegistro()
        {
            Retencion Registro = (Retencion)this.bs.Current;
            if (Registro == null)
                return;
            FrmSeniat_RetencionesIvaItem f = new FrmSeniat_RetencionesIvaItem();
            f.Modificar(Registro);
            Busqueda();
        }


        void btnImprimirDoble_Click(object sender, EventArgs e)
        {
            Retencion registro = (Retencion)this.bs.Current;
            if (registro == null)
                return;
            FrmReportes f = new FrmReportes();
          //  f.Seniat_ImprimirRetencionDoble(FactoryRetenciones.Item(registro));
            f = null;
        }
        void btnTxt_Click(object sender, EventArgs e)
        {
            SaveFileDialog stxt = new SaveFileDialog();
            stxt.CheckPathExists = true;
            stxt.FileName = txtAño.Text + txtMes.Text + txtPeriodo.Text + ".txt";
            stxt.FileOk += new CancelEventHandler(stxt_FileOk);
            stxt.ShowDialog();
        }

        void stxt_FileOk(object sender, CancelEventArgs e)
        {
            string filename = ((SaveFileDialog)sender).FileName;
            System.IO.StreamWriter f = new System.IO.StreamWriter(filename);
            var Acumulado = from p in lista
                            group p by new
                            { p.ComprobanteRetencionIVA }
                            into itemResumido
                            select new Retencion
                            {
                            PeriodoImpositivo = itemResumido.ElementAt(0).PeriodoImpositivo,
                            FechaComprobante = itemResumido.ElementAt(0).FechaComprobante,
                            Fecha = itemResumido.ElementAt(0).Fecha,
                            Tipo = itemResumido.ElementAt(0).Tipo,
                            TipoOperacion = itemResumido.ElementAt(0).TipoOperacion,
                            CedulaRif = itemResumido.ElementAt(0).CedulaRif,
                            Numero = itemResumido.ElementAt(0).Numero,
                            NumeroControl = itemResumido.ElementAt(0).NumeroControl,
                            MontoTotal = itemResumido.Sum(x => x.MontoTotal),
                            BaseImponible = itemResumido.Sum(x => x.BaseImponible),
                            MontoRetenido = itemResumido.Sum(x => x.MontoRetenido),
                            ComprobanteRetencionIVA = itemResumido.Key.ComprobanteRetencionIVA,
                            MontoExento = itemResumido.Sum(x => x.MontoExento),
                            TasaIva = itemResumido.ElementAt(0).TasaIva
                            };
            foreach (Retencion t in Acumulado)
            {

                f.Write(OK.SystemParameters.EmpresaRif + "\t");
                f.Write(t.PeriodoImpositivo + "\t");
                f.Write(String.Format("{0}-{1:00}-{2:00}\t", t.Fecha.Year, t.Fecha.Month, t.Fecha.Day));
                f.Write(t.TipoOperacion + "\t");
                f.Write(t.Tipo + "\t");
                f.Write(t.CedulaRif + "\t");
                f.Write(t.Numero + "\t");
                f.Write(t.NumeroControl + "\t");
                f.Write(t.MontoTotal.Value.ToString("N2").PadLeft(15).Replace(".", "").Replace(",", ".") + "\t");
                f.Write(t.BaseImponible.Value.ToString("N2").PadLeft(15).Replace(".", "").Replace(",", ".") + "\t");
                f.Write(t.MontoRetenido.Value.ToString("N2").PadLeft(15).Replace(".", "").Replace(",", ".") + "\t");
                f.Write("0\t");
                f.Write(t.ComprobanteRetencionIVA.PadLeft(14) + "\t");
                f.Write(t.MontoExento.Value.ToString("N2").PadLeft(15).Replace(".", "").Replace(",", ".") + "\t");
                f.Write(t.TasaIva.Value.ToString("N2").PadLeft(5).Replace(".", "").Replace(",", ".") + "\t");
                f.WriteLine("0\t");
            }
            f.Close();
        }
        void btnImprimir_Click(object sender, EventArgs e)
        {
            Retencion registro = (Retencion)this.bs.Current;
            if (registro == null)
                return;
            FrmReportes f = new FrmReportes();
          //  f.Seniat_ImprimirRetencion(FactoryRetenciones.Item(registro));
            f = null;
        }
        void txtBuscar_Validating(object sender, CancelEventArgs e)
        {
            Busqueda();
        }
        void btnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }
        void btnNuevo_Click(object sender, EventArgs e)
        {
            AgregarRegistro();
        }
        private void Buscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }
        private void Busqueda()
        {
            this.bs.DataSource = retenciones.GetMes(int.Parse(txtAño.Text), int.Parse(txtMes.Text), txtPeriodo.Text);
            this.gridView1.BestFitColumns();
        }
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView1.ActiveEditor == null)
            {
                if (e.KeyCode == Keys.Return)
                {
                    EditarRegistro();
                }
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Subtract)
                {
                    EliminarRegistro();
                }
                if (e.KeyCode == Keys.Insert)
                {
                    AgregarRegistro();
                }
            }
        }
        private void AgregarRegistro()
        {
            FrmSeniat_RetencionesIvaItem F = new FrmSeniat_RetencionesIvaItem();
            F.Incluir();
            if (F.DialogResult == DialogResult.OK)
            {
                Busqueda();
            }
        }
        private void EliminarRegistro()
        {
            if (this.gridView1.IsFocusedView)
            {
                Retencion Registro = (Retencion)this.bs.Current;
                if (Registro == null)
                    return;
                if (MessageBox.Show("Esta seguro de eliminar este registro", "Atencion", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                try
                {
                    //d.Retenciones.Remove(Registro);
                    //d.SaveChanges();
                    Busqueda();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
        }
        private void Nuevo_Click(object sender, EventArgs e)
        {
            AgregarRegistro();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
        }
    }
}
