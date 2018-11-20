
using HK.BussinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmRestaurant_PedirContornos : Form
    {
        public bool LlevaTermino = false;
        public string Contornos=null;
        public Administrativo data;
        public Producto producto;
        public FrmRestaurant_PedirContornos()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmPedirContornos_Load);
            if (data == null)
                data = new Administrativo();
        }
        void FrmPedirContornos_Load(object sender, EventArgs e)
        {
            switch( producto.Departamento)
            {
                case "PASTAS":
                    this.txtContornos.Items.AddRange(new object[] { "RAVIOLI", "TORTELLONI", "PLUMITAS", "RIGATONNE", "LINGUINNI", "VERMICCELLI", "PAGLIA E FIERNO" });
                    break;
                case "WHISKEYS":
                    this.txtContornos.Items.AddRange(new object[] { "SECO", "EN LAS ROCAS", "CON AGUA", "CON SODA", "CON AGUAQUINA", "AGUA DE COCO", "(02) VASOS", "(03) VASOS", "(04) VASOS", "(05) VASOS" });
                    break;
                default:
                    this.txtContornos.Items.AddRange(new object[] { "ARROZ", "PAPAS AL VAPOR", "PAPAS FRITAS","PURE", "ENS. MIXTA", "ENS. RAYADA", "VEGETALES", "TOSTONES","AGUACATE","TAJADAS","AREPITAS" });
                    break;
            }
            if (producto.Departamento.Contains("CARNE") || producto.Departamento.Contains("PARRILLA") || producto.Departamento.Contains("POLLO") ||  producto.Departamento.Contains("AVES"))
            {
                this.txtContornos.Items.AddRange(new object[] { "Ter: 1/2", "Ter: 3/4", "Ter: B.C" });
            }   
            if(producto.Departamento.Contains("PESCA"))
            {
                this.txtContornos.Items.AddRange(new object[] { "FRITO","A LA PLANCHA","CON MOJO"} );
            }
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmPedirContorno_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
        }
        void FrmPedirContorno_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Cancelar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F12:
                    this.Aceptar.PerformClick();
                    e.Handled = true;
                    break;
            }
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            try
            {
                StringBuilder retorno = new StringBuilder();
                foreach (var x in this.txtContornos.SelectedIndices)
                {   
                    retorno.Append(string.Format("{0}/",txtContornos.Items[x]));
                }
                if(retorno.Length>0)
                    Contornos = retorno.Remove(retorno.Length - 1, 1).ToString();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos \n" + ex.Source + "\n" + ex.Message, "Atencion", MessageBoxButtons.OK);
            }
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.platosContornoBindingSource.ResetBindings(true);
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
