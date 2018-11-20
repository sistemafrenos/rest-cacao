using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using HK.Utitilies;

namespace HK.Formas
{
    public partial class FrmUtilitarios_Restore : Form
    {
        HK.BussinessLogic.DbConfig config;
        HK.BussinessLogic.SistemaConfig sistema;
        public FrmUtilitarios_Restore()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmBackupRestore_Load);
        }

        void  FrmBackupRestore_Load(object sender, EventArgs e)
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
            this.Aceptar.Enabled = false;
            this.Aceptar.Text = "Restaurando...";
            this.UseWaitCursor = true;
            Application.DoEvents();
            string sBackup = string.Format("RESTORE DATABASE [{0}] FROM  DISK = N'{1}' WITH  FILE = 1,  MOVE N'{2}' TO N'c:\\HK\\DataSQL\\{2}.mdf',  MOVE N'{2}_log' TO N'c:\\HK\\DataSQL\\{2}_1.ldf',  NOUNLOAD,  REPLACE,  STATS = 10", txtBase.Text, txtBackup.Text, txtBase.Text);
            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
            csb.DataSource = this.txtServidor.Text;
            // Es mejor abrir la conexión con la base Master
            csb.InitialCatalog = "master";
            csb.IntegratedSecurity = true;
            //csb.ConnectTimeout = 480; // el predeterminado es 15

            using (SqlConnection con = new SqlConnection(csb.ConnectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmdBackUp = new SqlCommand(sBackup, con);
                    cmdBackUp.ExecuteNonQuery();
                    MessageBox.Show("Se ha restaurado la copia de la base de datos.",
                    "Restaurar base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                    "Error al restaurar la base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            this.UseWaitCursor = false;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
