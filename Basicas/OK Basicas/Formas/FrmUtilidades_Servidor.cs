using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using HK.Utitilies;

namespace HK.Formas
{
    public partial class FrmUtilidades_ConfigurarServidor : Form
    {
        HK.BussinessLogic.DbConfig dbConfig;
        public FrmUtilidades_ConfigurarServidor()
        {
            InitializeComponent();
            dbConfig = new BussinessLogic.DbConfig();
            this.Load += new EventHandler(FrmConfigurarEstacion_Load);
            this.checkEdit1.CheckedChanged += new EventHandler(checkEdit1_CheckedChanged);
        }
        void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (this.checkEdit1.CheckState ==  CheckState.Checked)
            {
                txtUser.Text = "";
                txtPassword.Text = "";
                txtUser.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUser.Enabled = true;
                txtPassword.Enabled = true;
            }
        }
        void FrmConfigurarEstacion_Load(object sender, EventArgs e)
        {
            KeyPreview = true;

            this.bs.ResetBindings(true);
            this.comboBoxEditTipoServidor.Properties.Items.AddRange(new object[] { "System.Data.SqlClient", "System.Data.SqlServerCe.4.0" });
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyDown += new KeyEventHandler(FrmConfigurarEstacion_KeyDown);
            this.comboBoxEditTipoServidor.Validated += new EventHandler(comboBoxEditTipoServidor_Validated);
            LeerConfig();
        }
        void LeerConfig()
        {
            string cs = ConnectionStringManager.GetConnectionString("DatosEntities");
            dbConfig.DataBase = ConnectionStringManager.GetSqlServerDatabaseName(cs);
            dbConfig.IntegratedSecurity = ConnectionStringManager.GetSqlServerIntegratedSecurity(cs).GetValueOrDefault();
            dbConfig.Password = ConnectionStringManager.GetSqlServerPassword(cs);
            dbConfig.Server = ConnectionStringManager.GetSqlServerServerName(cs);
            dbConfig.User = ConnectionStringManager.GetSqlServerUserName(cs);
            if (dbConfig.IntegratedSecurity)
            {
                this.checkEdit1.CheckState = CheckState.Checked;
                txtUser.Enabled = false;
                txtPassword.Enabled = false;
                txtUser.Text = "";
                txtPassword.Text = "";
            }
            else
            {
                this.checkEdit1.CheckState = CheckState.Unchecked;
                txtUser.Enabled = true;
                txtPassword.Enabled = true;
            }
            this.bs.DataSource = dbConfig; 
        }
        void comboBoxEditTipoServidor_Validated(object sender, EventArgs e)
        {
            switch(comboBoxEditTipoServidor.Text)
            {
                case "System.Data.SqlClient":
                    txtBase.Text = "newAdministrativo";
                    txtServidor.Text = @".\SQLEXPRESS";
                    break;
                case "LOCALDB":
                    txtBase.Text = "newAdministrativo";
                    txtServidor.Text = @"(localdb)\V11.0";
                    break;
                case "System.Data.SqlServerCe.4.0":
                    txtServidor.Text = "";
                    txtBase.Text = "newData.SDF";
                    break;
            }
        }

        void FrmConfigurarEstacion_KeyDown(object sender, KeyEventArgs e)
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
            bs.EndEdit();
            string cs = ConnectionStringManager.GetConnectionString("DatosEntities");
            cs = ConnectionStringManager.SetConnectionStringServerName(cs, dbConfig.Server);
            if(dbConfig.IntegratedSecurity)
              cs = ConnectionStringManager.SetConnectionStringAutenticationIntegrated(cs);
            else
              cs = ConnectionStringManager.SetConnectionStringAutenticationSQLServer(cs, dbConfig.User, dbConfig.Password);
            cs = ConnectionStringManager.SetConnectionStringDatabaseName(cs, dbConfig.DataBase);
            ConnectionStringManager.SaveConnectionString("DatosEntities", cs);
            Application.Exit();
            //this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
