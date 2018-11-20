using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using HK.Clases;
using System.Data.SqlClient;
using System.Data.EntityClient;

namespace HK.Formas
{
    public partial class FrmUtilitarios_ConfigurarEstacion : Form
    {
        SqlConnection cn = new SqlConnection();
        const string cadena = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(local)\\SqlExpress;attachdbfilename=|DataDirectory|\\Administrativo.mdf;integrated security=True;multipleactiveresultsets=True;App=EntityFramework&quot;\" providerName=\"System.Data.EntityClient\" />";
        Configuration oConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public FrmUtilitarios_ConfigurarEstacion()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmConfigurarEstacion_Load);
           
        }

        void FrmConfigurarEstacion_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            try
            {
                //cn.ConnectionString = oConfig.ConnectionStrings.ConnectionStrings["DatosEntities"].ConnectionString;
                //txtBase.Text = cn.Database;
                //txtServidor.Text = cn.DataSource;
                txtTipoImpresora.Text = Application.CommonAppDataRegistry.GetValue("ModeloImpresoraFiscal").ToString();
                PuertoImpresoraFiscalComboBoxEdit.Text = Application.CommonAppDataRegistry.GetValue("PuertoImpresoraFiscal").ToString();
                NumeroRegistro.Text = Application.CommonAppDataRegistry.GetValue("NumeroRegistro").ToString();
                Reportes.Text = Application.CommonAppDataRegistry.GetValue("Reportes").ToString();
                Layouts.Text = Application.CommonAppDataRegistry.GetValue("Layouts").ToString();
                txtBase.Text = Application.CommonAppDataRegistry.GetValue("BaseDeDatos").ToString();
                txtServidor.Text = Application.CommonAppDataRegistry.GetValue("Servidor").ToString();

                object ImprimirComandas = Application.CommonAppDataRegistry.GetValue("ImprimirComandas");
                chkImprimirComandas.EditValue = ImprimirComandas == null ? false : (string)ImprimirComandas == "True" ? true : false;
                cmbImprimirComandas.Properties.Items.AddRange(new Object[] { "TICKERA", "FISCAL" });
                object ImpresoraComandas = Application.CommonAppDataRegistry.GetValue("ImpresoraComandas");
                cmbImprimirComandas.EditValue = ImpresoraComandas == null ? "FISCAL" : (string)ImpresoraComandas;

                object ImprimirOrdenDespacho = Application.CommonAppDataRegistry.GetValue("ImprimirOrdenDespacho");
                chkOrdenDespacho.EditValue = ImprimirOrdenDespacho == null ? false : (string)ImprimirOrdenDespacho == "True" ? true : false;
                cmbOrdenDespacho.Properties.Items.AddRange(new Object[] { "TICKERA", "FISCAL" });
                object ImpresoraOrdenDespacho = Application.CommonAppDataRegistry.GetValue("ImpresoraOrdenDespacho");
                cmbOrdenDespacho.EditValue = ImpresoraOrdenDespacho == null ? "FISCAL" : (string)ImpresoraOrdenDespacho;



                object ImprimirCorteSinPrecios = Application.CommonAppDataRegistry.GetValue("ImprimirCorteSinPrecios");
                chkCorteSinPrecio.EditValue = ImprimirCorteSinPrecios == null ? false : (string)ImprimirCorteSinPrecios == "True" ? true : false;

            }
            catch
            {
                txtTipoImpresora.Text = "BIXOLON";
                PuertoImpresoraFiscalComboBoxEdit.Text = "COM1";
                NumeroRegistro.Text = null;
                Reportes.Text = Application.StartupPath + "\\Reportes\\";
                Layouts.Text = Application.StartupPath + "\\Layouts\\";
                txtServidor.Text =".\\SQLEXPRESS";
                txtBase.Text= "Administrativo";
                chkOrdenDespacho.EditValue=false;
                chkImprimirComandas.EditValue = false;
                chkCorteSinPrecio.EditValue = true;
                OK.CadenaConexion = @"Server=.\SqlExpress;Database=Administrativo;integrated security=SSPI;";
            }
            this.PuertoImpresoraFiscalComboBoxEdit.Properties.Items.AddRange(new string[] { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8" });
            this.txtTipoImpresora.Properties.Items.AddRange(new object[] { "BIXOLON", "EPSON", "WINDOWS","TICKERA","NINGUNA","REMOTA" });
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyDown += new KeyEventHandler(FrmConfigurarEstacion_KeyDown);
           
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
            try
            {
                if (comboBoxEditTipoServidor.Text == "SQLSERVER")
                    OK.CadenaConexion = Basicas.CrearConexionString(txtServidor.Text, txtBase.Text);
                else
                    OK.CadenaConexion = "Data";
            }
            catch
            {
                MessageBox.Show("Imposible conectar con la Base de datos", "Error");
                return;
            }
            Application.CommonAppDataRegistry.SetValue("TipoServidor", comboBoxEditTipoServidor.Text);
            Application.CommonAppDataRegistry.SetValue("ModeloImpresoraFiscal", txtTipoImpresora.Text);
            Application.CommonAppDataRegistry.SetValue("PuertoImpresoraFiscal", PuertoImpresoraFiscalComboBoxEdit.Text);
            Application.CommonAppDataRegistry.SetValue("NumeroRegistro", NumeroRegistro.Text);
            Application.CommonAppDataRegistry.SetValue("Reportes", Reportes.Text);
            Application.CommonAppDataRegistry.SetValue("Layouts", Layouts.Text);
            Application.CommonAppDataRegistry.SetValue("CadenaConexion",OK.CadenaConexion);
            Application.CommonAppDataRegistry.SetValue("Servidor", txtServidor.Text);
            Application.CommonAppDataRegistry.SetValue("BaseDeDatos", txtBase.Text);
            Application.CommonAppDataRegistry.SetValue("ImprimirOrdenDespacho", chkOrdenDespacho.EditValue);
            Application.CommonAppDataRegistry.SetValue("ImpresoraOrdenDespacho", cmbOrdenDespacho.EditValue);
            Application.CommonAppDataRegistry.SetValue("ImprimirComandas", chkImprimirComandas.EditValue);
            Application.CommonAppDataRegistry.SetValue("ImpresoraComandas", cmbImprimirComandas.EditValue);
            Application.CommonAppDataRegistry.SetValue("ImprimirCorteSinPrecios", chkCorteSinPrecio.EditValue);
       //    OK.CadenaConexion = cn.ConnectionString;
            try
            {
                oConfig.AppSettings.Settings["DatosEntities"].Value = OK.CadenaConexion;
                oConfig.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch
            { }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
