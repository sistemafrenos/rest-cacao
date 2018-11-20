using HK.BussinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HK
{
    public partial class FrmTags : Form
    {
        Administrativo data;
        Tag[] etiquetas;
        public FrmTags()
        {
            InitializeComponent();
            Load += FrmTags_Load;
        }

        void FrmTags_Load(object sender, EventArgs e)
        {
            data = new Administrativo();
            etiquetas = data.GetAllEtiquetas(null);
            dataSource.DataSource = etiquetas;
            dataSource.ResetBindings(false);
            btnAgregarEtiqueta.Click += btnAgregarEtiqueta_Click;
            Aceptar.Click += Aceptar_Click;
            Cancelar.Click += Cancelar_Click;
        }

        void Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Abort;
        }

        void Aceptar_Click(object sender, EventArgs e)
        {
            string result = data.GuardarCambios();
            if (result != null)
            {
                MessageBox.Show(result, "ERROR");
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        void btnAgregarEtiqueta_Click(object sender, EventArgs e)
        {   
            data.GuardarTag(new Tag() { Descripcion = txtNuevaEtiqueta.Text },false);
            txtNuevaEtiqueta.Text = "";
        }

    }
}
