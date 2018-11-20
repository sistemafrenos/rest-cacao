using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer;
using System.Data.SqlClient;
using HK.Utitilies;

namespace HK.Formas
{
    public partial class FrmUtilitarios_Backup : Form
    {
        HK.BussinessLogic.DbConfig config;
        HK.BussinessLogic.SistemaConfig sistema;
        public FrmUtilitarios_Backup()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmBackup_Load);
        }
        void FrmBackup_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmLapso_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            config = new BussinessLogic.DbConfig();
            sistema = new BussinessLogic.SistemaConfig();
            string cs = ConnectionStringManager.GetConnectionString("DatosEntities");
            config.DataBase = ConnectionStringManager.GetSqlServerDatabaseName(cs);
            config.Server = ConnectionStringManager.GetSqlServerServerName(cs);
            txtBackup.Text = sistema.ArchivoRespaldo;
            this.bindingSource1.DataSource = config;
            this.bindingSource1.ResetBindings(true);
        }
        void FrmLapso_KeyDown(object sender, KeyEventArgs e)
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
        void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        void Aceptar_Click(object sender, EventArgs e)
        {
            this.bindingSource1.EndEdit();
            sistema.ArchivoRespaldo = txtBackup.Text;
            sistema.Save();
            string sBackup = "BACKUP DATABASE " + this.txtBase.Text +
            " TO DISK = N'" + this.txtBackup.Text +
            "' WITH NOFORMAT, NOINIT, NAME =N'" + this.txtBase.Text +
            "'";

            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();

            csb.DataSource = this.txtServidor.Text;
            csb.InitialCatalog = this.txtBase.Text;
            csb.IntegratedSecurity = true;

            using (SqlConnection con = new SqlConnection(csb.ConnectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmdBackUp = new SqlCommand(sBackup, con);

                    cmdBackUp.ExecuteNonQuery();

                    MessageBox.Show("Se ha creado un BackUp de La base de datos satisfactoriamente",
                    "Copia de seguridad de base de datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                    "Error al copiar la base de datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
