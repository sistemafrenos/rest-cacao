using HK.BussinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmTablas_Clientes : Form
    {
        Tercero cliente;
        Administrativo data;
        public FrmTablas_Clientes()
        {
            InitializeComponent();
            cliente = new Tercero();
            data = new Administrativo();
            this.Load += new EventHandler(FrmTerceros_Load);
            BarraAcciones.Text = "Clientes";
            Basicas.AsegurarToolStrip(new object[] { BarraAcciones });
        }
        void FrmTerceros_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmTerceros_KeyDown);
            this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            this.btnNuevo.Click += new EventHandler(btnNuevo_Click);
            this.btnEditar.Click += new EventHandler(btnEditar_Click);
            this.btnEliminar.Click += new EventHandler(btnEliminar_Click);
            this.btnEstadoCuentaCliente.Click += new EventHandler(btnEstadoCuentaCliente_Click);
            this.btnBuscar.Click += new EventHandler(btnBuscar_Click);
            this.txtBuscar.Validating += new CancelEventHandler(txtBuscar_Validating);
            this.btnImprimir.Click += new EventHandler(btnImprimir_Click);
            this.txtBuscar.KeyDown += new KeyEventHandler(txtBuscar_KeyDown);
            this.Height = Screen.PrimaryScreen.Bounds.Height - 100;
            this.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            this.CenterToScreen();
            Busqueda();
        }

        void btnEstadoCuentaCliente_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            FrmReportes f = new FrmReportes();
            f.CxC_EstadoDeCuentaTercero((Tercero)this.bs.Current,false);
        }
        void FrmTerceros_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    btnNuevo.PerformClick();
                    break;
            }
        }
        public string filtro;
        void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.Tablas_Clientes((Tercero[])bs.DataSource);
            f = null;
        }
        void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                btnBuscar.PerformClick();
        }
        void txtBuscar_Validating(object sender, CancelEventArgs e)
        {
            Busqueda();
        }
        void btnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }
        void btnEditar_Click(object sender, EventArgs e)
        {
            EditarRegistro();
        }
        void btnNuevo_Click(object sender, EventArgs e)
        {
            AgregarRegistro();
        }
        private void Busqueda()
        {
            //var clientes = data.GetAllClientes(this.txtBuscar.Text);
            //foreach (var item in clientes)
            //{
            //    item.CedulaRif = Basicas.CedulaRif(item.CedulaRif);
            //}
            //data.GuardarCambios();
            this.bs.DataSource = data.GetAllClientes(this.txtBuscar.Text);
            this.bs.ResetBindings(true);
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
            do
            {
                FrmTablas_ClientesItem F = new FrmTablas_ClientesItem() 
                { data = this.data };
                F.Incluir();
                if (F.DialogResult != DialogResult.OK)
                    return;
                Busqueda();
            }
            while (true);
        }
        private void EditarRegistro()
        {
            if (this.bs.Current == null)
                return;
            FrmTablas_ClientesItem F = new FrmTablas_ClientesItem();
            F.data = this.data;
            F.Modificar((Tercero)this.bs.Current);
            Busqueda();
        }
        private void EliminarRegistro()
        {
            if (this.bs.Current == null)
                return;
            if (this.gridView1.IsFocusedView)
            {
                if (MessageBox.Show("Esta seguro de eliminar este registro", "Atencion", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                data.EliminarCliente((Tercero)this.bs.Current,true);
                Busqueda();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            EditarRegistro();
        }
    }
}
