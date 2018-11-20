using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.Clases
{
    public class FactoryContadores
    {
        public static string GetContador(string Variable)
        {
            try
            {
                using (var oEntidades = new DatosEntities(OK.CadenaConexion))
                {
                    Contador Contador = oEntidades.Contadores.FirstOrDefault(x => x.Variable == Variable);
                    if (Contador == null)
                    {
                        Contador = new Contador();
                        Contador.Variable = Variable;
                        Contador.Valor = 1;
                        oEntidades.Contadores.Add(Contador);
                    }
                    else
                    {
                        Contador.Valor++;

                    }
                    oEntidades.SaveChanges();
                    return ((Int32)Contador.Valor).ToString("000000");
                }
            }
            catch (Exception ex)
            {
                string x = ex.Message;
            }
            return "";
        }
        public static string GetContador(string Variable, string formato)
        {
            try
            {
                using (var oEntidades = new DatosEntities(OK.CadenaConexion))
                {
                    Contador Contador = oEntidades.Contadores.FirstOrDefault(x => x.Variable == Variable);
                    if (Contador == null)
                    {
                        Contador = new Contador();
                        Contador.Variable = Variable;
                        Contador.Valor = 1;
                        oEntidades.Contadores.Add(Contador);
                    }
                    else
                    {
                        Contador.Valor++;

                    }
                    oEntidades.SaveChanges();
                    return ((Int32)Contador.Valor).ToString(formato);
                }
            }
            catch (Exception ex)
            {
                string x = ex.Message;
            }
            return "";
        }
        public static string GetContadorDiario()
        {
            string Fecha = "C" + DateTime.Today.ToShortDateString().Replace("/", "");
            return GetContador(Fecha);
        }
        public static string GetContadorComprobante(string mes, string ano)
        {
            return String.Format("{0}{1}00{2}", ano, mes, GetContadorII("COMPROBANTE_" + ano + mes));
        }
        public static string GetContadorII(string Variable)
        {
            try
            {
                using (var oEntidades = new DatosEntities(OK.CadenaConexion))
                {
                    Contador Contador = oEntidades.Contadores.FirstOrDefault(x => x.Variable == Variable);
                    if (Contador == null)
                    {
                        Contador = new Contador();
                        Contador.Variable = Variable;
                        Contador.Valor = 1;
                        oEntidades.Contadores.Add(Contador);
                        oEntidades.SaveChanges();
                    }
                    else
                    {
                        Contador.Valor++;
                    }
                    return ((Int32)Contador.Valor).ToString("000000");
                }
            }
            catch (Exception ex)
            {
                string x = ex.Message;
            }
            return "";
        }
        public static void SetMax(string Variable, Int32 Valor)
        {
            try
            {
                using (var oEntidades = new DatosEntities(OK.CadenaConexion))
                {
                    Contador Contador = oEntidades.Contadores.FirstOrDefault(x => x.Variable == Variable);
                    if (Contador == null)
                    {
                        Contador = new Contador();
                        Contador.Variable = Variable;
                    }
                    else
                    {
                        Contador.Valor++;

                    }
                    Contador.Valor = Valor;
                    oEntidades.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string x = ex.Message;
            }
        }
        public static void SetMax(string Variable)
        {
            try
            {
                using (var Db = new DatosEntities(OK.CadenaConexion))
                {
                    Contador Contador = Db.Contadores.FirstOrDefault(x => x.Variable == Variable);
                    if (Contador == null)
                    {
                        Contador = new Contador();
                        Contador.Variable = Variable;
                        Contador.Valor = 1;
                    }
                    else
                    {
                        Contador.Valor++;

                    }
                    if (Db.Entry(Contador).State == System.Data.EntityState.Detached)
                    {
                        Db.Contadores.Add(Contador);
                    }
                    Db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string x = ex.Message;
            }
        }
    }
}
