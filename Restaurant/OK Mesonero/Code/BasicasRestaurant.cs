using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using HK.Clases;
using HK.BussinessLogic.Restaurant;
using HK.BussinessLogic;

namespace HK
{
    public partial class BasicasRestaurant
    {
        public static void ImprimirAnulacion(MesasAbiertasProducto item)
        {
            int Lineas = 0;
            try
            {
                LPrintWriter l = new LPrintWriter() { Font = new Font("FontA12", (float)18.0) };
                l.WriteLine("ANULACION");
                l.Font = new Font("FontA11", (float)9.0);
                l.WriteLine("========================================");
                l.WriteLine(string.Format("TICKET:{0}", item.MesasAbierta.Numero));
                l.Font = new Font("FontA11", (float)9.0);
                l.WriteLine(string.Format("FECHA :{0}    HORA:{1}", DateTime.Today.ToShortDateString(), DateTime.Now.ToShortTimeString()));
                l.WriteLine(string.Format("MESA:{0}", item.MesasAbierta.CodigoMesa));
                l.WriteLine(string.Format("MESONERO:{0}", item.Mesonero));
                l.WriteLine("========================================");
                l.WriteLine(" {0}) {1} ", item.Cantidad.Value.ToString("N0"), item.Descripcion);
                l.WriteLine("========================================");
                for (Lineas = 0; Lineas < 6; Lineas++)
                {
                    l.WriteLine(" ");
                }
                l.WriteLine(" ");
                l.WriteLine(".");
                l.WriteLine(" ");
                l.WriteLine(".");
                l.WriteLine(" ");
                l.WriteLine(".");
                l.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al imprimir anulacion", ex);
            }
        }
        //public static void ImprimirPlatosDelDia(List<Sugerencia> productos, string Comentario, string Comentario2, int copias)
        //{
        //    if (productos.Count() < 1)
        //        return;
        //    try
        //    {
        //        int Lineas = 1;
        //        //LPrintWriter l = new LPrintWriter();
        //        //l.Impresora = "BARRA";
        //        StreamWriter l = new StreamWriter("Sugerencias.txt");
        //        l.WriteLine(Basicas.TipoLetra(25) + "SUGERENCIAS DEL DIA ");
        //        l.WriteLine(" ");
        //        l.WriteLine("COD  DESCRIPCION               PRECIO   ");
        //        l.WriteLine("========================================");
        //        foreach (var Item in productos)
        //        {
        //            l.WriteLine("{0} {1} {2}", Item.Codigo.PadRight(6, ' '), Item.Descripcion.PadRight(28, ' ').Substring(0, 28), (Item.PrecioConIva.Value).ToString("N0").PadLeft(3));
        //        }
        //        l.WriteLine("========================================");
        //        l.WriteLine(Comentario);
        //        l.WriteLine(Comentario2);
        //        l.WriteLine(Basicas.TipoLetra(7));
        //        for (Lineas = 0; Lineas < 8; Lineas++)
        //            l.WriteLine(" ");
        //        l.WriteLine(".");
        //        l.Flush();
        //        l.Dispose();
        //        for (int i = 1; i <= copias; i++)
        //        {
        //            RawPrinterHelper.SendFileToPrinter("BARRA", "Sugerencias.txt");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error imprimiendo Sugerencia", ex);
        //    }
        //}
        public static void ImprimirConsumos()
        {
            return;
        }
        public static void ImprimirComandaMesonero(MesasAbierta documento)
        {
            string NumeroComanda;
            var porimprimir = from p in documento.MesasAbiertasProductos
                                where !String.IsNullOrEmpty(p.EnviarComanda) && string.IsNullOrEmpty(p.NumeroComanda)  && p.EnviarComanda != "NINGUNA"
                                select p;
            if (porimprimir.Count() == 0)
                return;
            var Cocina = (from x in porimprimir
                            where x.EnviarComanda == "COCINA"
                            select x).ToList();
            var Barra = (from x in porimprimir
                            where x.EnviarComanda == "BARRA"
                            select x).ToList();
            var Pizza = (from x in porimprimir
                         where x.EnviarComanda == "PIZZA"
                         select x).ToList();

            if (Cocina.Count() > 0)
            {
                NumeroComanda = Administrativo.GetContador("ComandaCocina");
              //  DoImprimir(documento, Cocina, "COCINA 1", NumeroComanda);
                DoImprimir(documento, Cocina, "COCINA", NumeroComanda);
            }
            if (Barra.Count() > 0)
            {
                NumeroComanda = Administrativo.GetContador("ComandaBarra");
                DoImprimir(documento, Barra, "BARRA", NumeroComanda);
            }
            if (Pizza.Count() > 0)
            {
                NumeroComanda = Administrativo.GetContador("ComandaBarra");
                DoImprimir(documento, Barra, "PIZZA", NumeroComanda);
            }
        }
        public static void ImprimirComanda(Restaurant restaurant, MesasAbierta mesaAbierta)
        {
            string NumeroComanda;
            {
                var porimprimir = (from p in mesaAbierta.MesasAbiertasProductos
                                  where !String.IsNullOrEmpty(p.EnviarComanda) && string.IsNullOrEmpty(p.NumeroComanda) && p.Anulado!=true
                                  select p).ToList();
                if (porimprimir.Count() == 0)
                    return;
                var Cocina = (from x in porimprimir
                              where x.EnviarComanda == "COCINA"
                              select x).ToList();
                var Cocina2 = (from x in porimprimir
                              where x.EnviarComanda == "COCINA2"
                              select x).ToList();
                var Barra = (from x in porimprimir
                             where x.EnviarComanda == "BARRA"
                             select x).ToList();
                var Pizza = (from x in porimprimir
                             where x.EnviarComanda == "PIZZA"
                             select x).ToList();
                if (Cocina.Count() > 0)
                {

                    NumeroComanda = Administrativo.GetContador("NumeroComanda");
                //    DoImprimir(mesaAbierta, Cocina, "COCINA 1", NumeroComanda);
                    
                    DoImprimir(mesaAbierta, Cocina, "COCINA", NumeroComanda);
                }

                if (Cocina2.Count() > 0)
                {

                    NumeroComanda = Administrativo.GetContador("NumeroComanda");
                    //    DoImprimir(mesaAbierta, Cocina, "COCINA 1", NumeroComanda);
                    DoImprimir(mesaAbierta, Cocina2, "COCINA2", NumeroComanda);
                }
                if (Barra.Count() > 0)
                {
                    NumeroComanda = Administrativo.GetContador("NumeroComanda");
                    DoImprimir(mesaAbierta, Barra, "BARRA", NumeroComanda);
                }
                if (Pizza.Count() > 0)
                {
                    NumeroComanda = Administrativo.GetContador("NumeroComanda");
                    DoImprimir(mesaAbierta, Pizza, "PIZZA", NumeroComanda);
                }

            }
        }
        private static void DoImprimir(MesasAbierta documento, List<MesasAbiertasProducto> porimprimir, string Impresora, string NumeroComanda)
        {
            if (porimprimir.Count() < 1)
                return;
            try
            {
               // LPrintWriter l = new LPrintWriter() { Font = new Font("FontA12", (float)18.0) };
               // l.Impresora = Impresora;
                string Archivo =String.Format("Comanda_{0}.txt", Impresora);
                StreamWriter l = new StreamWriter(Archivo);
                l.WriteLine(" ");
                l.WriteLine(Basicas.TipoLetra(40) + string.Format("MESA:{0}", documento.CodigoMesa + Basicas.TipoLetra(7)));
                l.WriteLine(string.Format("COMANDA:{0}", NumeroComanda.Substring(3, 3)));
                l.WriteLine(string.Format("TICKET:{0}", documento.Numero));
                l.WriteLine(string.Format("FECHA :{0}    HORA:{1}", DateTime.Today.ToShortDateString(), DateTime.Now.ToShortTimeString()));
                l.WriteLine(string.Format("ATENDIDO POR:{0}", Basicas.TipoLetra(23) + documento.Mesonero + Basicas.TipoLetra(7)));
                l.WriteLine("========================================");
                foreach (var item in porimprimir)
                {
                    item.NumeroComanda = NumeroComanda;
                    if (item.Cantidad != null)
                    {
                        if(item.Cantidad>=1)
                           l.WriteLine(Basicas.TipoLetra(40) + "{0}>{1}", item.Cantidad.Value.ToString("N0"), item.Descripcion.PadRight(25));
                        else
                          l.WriteLine(Basicas.TipoLetra(40) + "{0}>{1}", item.Cantidad.Value.ToString("N2"), item.Descripcion.PadRight(25));
                    }
                    else
                        l.WriteLine(Basicas.TipoLetra(40) + "{0}",item.Descripcion.PadRight(25));
                    if (item.Comentario != null)
                    {
                        l.WriteLine(Basicas.TipoLetra(08) + item.Comentario + Basicas.TipoLetra(40));
                        l.WriteLine(" ");
                    }
                }
                l.WriteLine(Basicas.TipoLetra(08));
                l.WriteLine(Basicas.TipoLetra(32) + (documento.CodigoMesa[0] == 'L' ? "PARA LLEVAR" : "") + Basicas.TipoLetra(07));
                l.WriteLine("\n\n\n\n\n\n.");
                l.Flush();
                l.Close();
                switch (Impresora)
                {
                    case "COCINA 1":
                        RawPrinterHelper.SendFileToPrinter("COCINA 1", String.Format("Comanda_{0}.txt", Impresora));
                        break;
                    case "COCINA":
                        RawPrinterHelper.SendFileToPrinter("COCINA", String.Format("Comanda_{0}.txt", Impresora));
                        break;
                    case "COCINA2":
                        RawPrinterHelper.SendFileToPrinter("COCINA2", String.Format("Comanda_{0}.txt", Impresora));
                        break;
                    case "BARRA":
                        RawPrinterHelper.SendFileToPrinter("BARRA", String.Format("Comanda_{0}.txt", Impresora));
                        break;
                    case "PIZZA":
                        RawPrinterHelper.SendFileToPrinter("PIZZA", String.Format("Comanda_{0}.txt", Impresora));
                        break;
                    default:
                        RawPrinterHelper.SendFileToPrinter("COCINA 1", String.Format("Comanda_{0}.txt", Impresora));
                        break;
                }
              //  RawPrinterHelper.SendFileToPrinter(Basicas.GetDefaultPrinterName(), Archivo);
            }
            catch (Exception x)
            {
               throw new Exception(string.Format("La impresora {0} no esta disponible", Impresora),x);
            }
        }
        private static void DoImprimirPequeño(MesasAbierta documento, List<MesasAbiertasProducto> porimprimir, string Impresora, string NumeroComanda)
        {
            if (porimprimir.Count() < 1)
                return;
            try
            {
                // LPrintWriter l = new LPrintWriter() { Font = new Font("FontA12", (float)18.0) };
                // l.Impresora = Impresora;
                StreamWriter l = new StreamWriter(String.Format("Comanda_{0}.txt", Impresora));
                l.WriteLine(" ");
                l.WriteLine(Basicas.TipoLetra(32) + string.Format("MESA:{0}", documento.CodigoMesa + Basicas.TipoLetra(7)));
                l.WriteLine(string.Format("COMANDA:{0}", NumeroComanda.Substring(3, 3)));
                l.WriteLine(string.Format("TICKET:{0}", documento.Numero));
                l.WriteLine(string.Format("FECHA :{0}    HORA:{1}", DateTime.Today.ToShortDateString(), DateTime.Now.ToShortTimeString()));
                l.WriteLine(string.Format("ATENDIDO POR:{0}", documento.Mesonero));
                l.WriteLine("========================================");
                foreach (var item in porimprimir)
                {
                    item.NumeroComanda = NumeroComanda;
                    if (item.Cantidad != null)
                    {
                        if (item.Cantidad >= 1)
                            l.WriteLine(Basicas.TipoLetra(40) + "{0}>{1}", item.Cantidad.Value.ToString("N0"), item.Descripcion.PadRight(25));
                        else
                            l.WriteLine(Basicas.TipoLetra(40) + "{0}>{1}", item.Cantidad.Value.ToString("N2"), item.Descripcion.PadRight(25));
                    }
                    else
                        l.WriteLine("{0}", item.Descripcion.PadRight(25));
                    if (item.Comentario != null)
                    {
                        l.WriteLine(item.Comentario);
                    }
                }
            //    l.WriteLine(Basicas.TipoLetra(07));
                l.WriteLine( (documento.CodigoMesa[0] == 'L' ? "PARA LLEVAR" : ""));
                l.WriteLine("\n\n\n\n\n\n.");
                l.Flush();
                l.Close();
                switch (Impresora)
                {
                    case "COCINA 1":
                        RawPrinterHelper.SendFileToPrinter("COCINA 1", String.Format("Comanda_{0}.txt", Impresora));
                        break;
                    case "COCINA":
                        RawPrinterHelper.SendFileToPrinter("COCINA", String.Format("Comanda_{0}.txt", Impresora));
                        break;
                    case "COCINA2":
                        RawPrinterHelper.SendFileToPrinter("COCINA2", String.Format("Comanda_{0}.txt", Impresora));
                        break;
                    case "BARRA":
                        RawPrinterHelper.SendFileToPrinter("BARRA", String.Format("Comanda_{0}.txt", Impresora));
                        break;
                    case "PIZZA":
                        RawPrinterHelper.SendFileToPrinter("PIZZA", String.Format("Comanda_{0}.txt", Impresora));
                        break;
                    default:
                        RawPrinterHelper.SendFileToPrinter("COCINA 1", String.Format("Comanda_{0}.txt", Impresora));
                        break;
                }
            }
            catch (Exception x)
            {
                throw new Exception(string.Format("La impresora {0} no esta disponible", Impresora), x);
            }
        }
    }
}
