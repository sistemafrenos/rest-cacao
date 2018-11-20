using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HK.Clases;
using System.Windows.Forms;
using HK.Formas;

namespace HK.Clases
{
    public class FactoryBancos
    {
        public static List<Banco> getItems(string texto)
        {
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                var mproductos = from x in db.Bancos
                                 orderby x.Descripcion
                                 where (x.Cuenta.Contains(texto) || x.Descripcion.Contains(texto) || texto.Length == 0)
                                 select x;
                return mproductos.ToList();
            }
        }
        public static List<Banco> getItems(DatosEntities db, string texto)
        {
            var mproductos = from x in db.Bancos
                             orderby x.Descripcion
                             where (x.Cuenta.Contains(texto) || x.Descripcion.Contains(texto) || texto.Length == 0)
                             select x;
            return mproductos.ToList();
        }
        public static Banco Item(string id)
        {
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                var item = (from x in db.Bancos
                            where (x.IdBanco == id)
                            select x).FirstOrDefault();
                return item;
            }
        }
        public static Banco Item(DatosEntities db, string id)
        {
            var item = (from x in db.Bancos
                        where (x.IdBanco == id)
                        select x).FirstOrDefault();
            return item;
        }
        public static List<string> getBancos()
        {
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                var mgrupos = (from x in db.Bancos
                               orderby x.Descripcion
                               select x.Descripcion).Distinct();
                return mgrupos.ToList();
            }
        }
        public static string[] getCuentasBancarias()
        {
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                var mgrupos = (from x in db.Bancos
                               orderby x.Cuenta
                               select x.Cuenta + " " + x.Descripcion);
                return mgrupos.ToArray();
            }
        }
        public static void RegistrarMovimientos()
        {
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                try
                {
                    BancosMovimiento movimiento = new BancosMovimiento();
                    movimiento.IdMovimientoBanco = BancosMovimiento.GetID();
                    db.SaveChanges();
                }
                catch (Exception x)
                {
                    Basicas.ManejarError(x);
                }
            }
        }
        public static List<BancosMovimiento> movimientos(DatosEntities db, Banco banco, int mes, int año)
        {
            var items = from x in db.BancosMovimientos
                        where x.IdBanco == banco.IdBanco && x.Fecha.Value.Month == mes && x.Fecha.Value.Year == año
                        select x;
            return items.ToList();
        }

        public static BancosMovimiento ItemxNumeroCheque(string numeroCH)
        {
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                var items = from x in db.BancosMovimientos
                            where x.Numero == numeroCH
                            select x;
                return items.FirstOrDefault();
            }
        }

        public static List<BancosMovimiento> ItemxCheques(DatosEntities db, string texto)
        {
            var items = from x in db.BancosMovimientos
                        where x.Numero.Contains(texto)
                        && ( x.Tipo == "CHEQUE" || x.Tipo == "TRANSFERENCIA" || x.Tipo == "LOTE TRANSFERENCIA" )
                        select x;
            return items.ToList();
        }

        public static Banco ItemxNumeroCuenta(string cuenta)
        {
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                var item = (from x in db.Bancos
                            where (x.Cuenta == cuenta )
                            select x).FirstOrDefault();
                return item;
            }
        }
        public static Banco ItemxNumeroCuenta(DatosEntities db, string cuenta)
        {
            var item = (from x in db.Bancos
                        where (x.Cuenta == cuenta)
                        select x).FirstOrDefault();
            return item;
        }

        internal static void RegistrarPago(TercerosMovimiento movimiento)
        {
            DatosEntities db = new DatosEntities(OK.CadenaConexion);
            Utilitatios.Numalet num = new Utilitatios.Numalet();
            Banco banco = FactoryBancos.ItemxNumeroCuenta(db, movimiento.NumeroCuenta);
            BancosMovimiento Existe = db.BancosMovimientos.Where(x => x.Tipo == movimiento.FormaDePago && x.Numero == movimiento.Numero && x.IdBanco == banco.IdBanco).FirstOrDefault();
            if (Existe == null)
            {
                BancosMovimiento bancoMovimiento = new BancosMovimiento();
                bancoMovimiento.Beneficiario = movimiento.Beneficiario;
                bancoMovimiento.CedulaRif = movimiento.CedulaRifBeneficiario;
                bancoMovimiento.Concepto = movimiento.Concepto;
                bancoMovimiento.Conciliado = false;
                bancoMovimiento.DescripcionCuenta = movimiento.DescripcionCuenta;
                bancoMovimiento.Fecha = movimiento.Fecha;
                bancoMovimiento.IdUsuario = OK.usuario.IdUsuario;
                bancoMovimiento.MontoEnLetras = Utilitatios.Numalet.ToCardinal(movimiento.Credito.GetValueOrDefault(0));
                bancoMovimiento.Numero = movimiento.NumeroPago;
                bancoMovimiento.Tipo = movimiento.FormaDePago;
                bancoMovimiento.UltimaEdicion = DateTime.Now;
                bancoMovimiento.Debito = movimiento.Credito.GetValueOrDefault(0);
                bancoMovimiento.IdMovimientoBanco = BancosMovimiento.GetID();
                banco.BancosMovimientos.Add(bancoMovimiento);
                db.SaveChanges();
                if (bancoMovimiento.Tipo == "CHEQUE")
                {
                    if (MessageBox.Show("Desea imprimir este cheque", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        FrmReportes repo = new FrmReportes();
                        try
                        {
                            repo.Banco_ImprimirCH(bancoMovimiento);
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
    }
}
