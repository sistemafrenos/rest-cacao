using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HK.Formas;

namespace HK
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DatosEntities data = new DatosEntities();
            data.CheckDatabase();
            data = null;
            //if (DateTime.Today > DateTime.Parse("01/09/2015"))
            //{
            //    MessageBox.Show("Esta version es un demo y ha expirado");
            //    Application.Exit();
            //}
            FrmLogin login = new FrmLogin() { Sistema = "OK RESTAURANT" };
            login.ShowDialog();
            if (login.DialogResult == DialogResult.OK)
            {
                if (OK.usuario != null)
                {
                    Application.Run(new Formas.FrmRestaurant_MesasAbiertas());
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
