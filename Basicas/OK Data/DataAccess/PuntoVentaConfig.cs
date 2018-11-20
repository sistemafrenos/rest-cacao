using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace HK.BussinessLogic
{
    public class PuntoVentaConfig
    {
        public bool PedirNumeroOrden { set; get; }
        public string ImpresoraOrdenDespacho { set; get; }

        public PuntoVentaConfig()
        {

            if (!File.Exists("OKconfig.xml"))
                Configuracion.Create();
            XElement doc = XElement.Load("OKconfig.xml");
            XElement item;
            try
            {
                item = (from b in doc.Elements("PuntoVentaConfig")
                        select b).First();
            }
            catch
            {
                item = new XElement("PuntoVentaConfig");
                OK.XMLEscribirElemento(item,"EmailDestinatario1", "administrador@gmail.com");
                OK.XMLEscribirElemento(item, "ImpresoraOrdenDespacho", "NINGUNA");
                doc.Add(item);
                doc.Save("OKConfig.xml");
            }
            PedirNumeroOrden = OK.XMLLeerElemento(item, "PedirNumeroOrden")=="TRUE"?true:false;
            ImpresoraOrdenDespacho = OK.XMLLeerElemento(item, "ImpresoraOrdenDespacho");
        }
        public void Save()
        {
            XElement doc = XElement.Load("OKconfig.xml");
            var item = (from b in doc.Elements("PuntoVentaConfig")
                        select b).First();
            OK.XMLEscribirElemento(item, "PedirNumeroOrden", PedirNumeroOrden?"TRUE":"FALSE");
            OK.XMLEscribirElemento(item, "ImpresoraOrdenDespacho", ImpresoraOrdenDespacho);
            doc.Save("OKconfig.xml");
        }
    }
}
