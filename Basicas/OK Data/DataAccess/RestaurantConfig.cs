using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace HK.BussinessLogic
{
    public class RestaurantConfig
    {
        public bool PedirMesonero { get; set; }
        public bool IncluirMontoEnCorteCuenta { set; get; }
        public string ConceptoServicio { set; get; }
        public string ImpresoraComandas { set; get; }
        public string ImpresoraCorteCuentas { set; get; }
        public RestaurantConfig()
        {

            if (!File.Exists("OKConfig.xml"))
                Configuracion.Create();
            XElement doc = XElement.Load("OKConfig.xml");
            XElement item;
            try
            {
                item = (from b in doc.Elements("RestaurantConfig")
                        select b).First();
            }
            catch
            {
                item = new XElement("RestaurantConfig");
                OK.XMLEscribirElemento(item,"PedirMesonero",false);
                OK.XMLEscribirElemento(item,"ConceptoServicio","SERVICIO MESONEROS");
                OK.XMLEscribirElemento(item,"ImpresoraComandas","NINGUNA");
                OK.XMLEscribirElemento(item,"ImpresoraCorteCuentas", "WINDOWS");
                OK.XMLEscribirElemento(item,"IncluirMontoEnCorteCuenta", "FALSE");
                doc.Add(item);
                doc.Save("OKConfig.xml");
            }
            ConceptoServicio = OK.XMLLeerElemento(item, "ConceptoServicio");
            ImpresoraComandas = OK.XMLLeerElemento(item, "ImpresoraComandas");
            ImpresoraCorteCuentas = OK.XMLLeerElemento(item, "ImpresoraCorteCuentas");
            PedirMesonero = OK.XMLLeerElemento(item, "PedirMesonero").ToUpper() == "TRUE" ? true : false;
            IncluirMontoEnCorteCuenta = OK.XMLLeerElemento(item, "IncluirMontoEnCorteCuenta","TRUE").ToUpper() == "TRUE" ? true : false;
        }
        public void Save()
        {
            XElement doc = XElement.Load("OKconfig.xml");
            var item = (from b in doc.Elements("RestaurantConfig")
                        select b).First();
            OK.XMLEscribirElemento(item, "PedirMesonero", PedirMesonero.ToString().ToUpper());
            OK.XMLEscribirElemento(item, "ConceptoServicio", ConceptoServicio);
            OK.XMLEscribirElemento(item, "ImpresoraComandas", ImpresoraComandas);
            OK.XMLEscribirElemento(item, "ImpresoraCorteCuentas", ImpresoraCorteCuentas);
            OK.XMLEscribirElemento(item, "IncluirMontoEnCorteCuenta", IncluirMontoEnCorteCuenta);
            doc.Save("OKconfig.xml");
        }
    }
}
