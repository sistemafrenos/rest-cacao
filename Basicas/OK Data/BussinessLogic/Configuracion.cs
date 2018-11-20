using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Data;

namespace HK.BussinessLogic
{
    static class Configuracion
    {
        public static void Create()
        {
            XElement Configuracion = new XElement("Config");
            Configuracion.Save("OKconfig.xml");
        }
    }
    public class FiscalConfig
    {
        public string TipoImpresora { set; get; }
        public string Puerto { set; get; }
        public string NumeroRegistro { set; get; }
        public FiscalConfig()
        {

            if (!File.Exists("OKconfig.xml"))
                Configuracion.Create();
            XElement doc = XElement.Load("OKconfig.xml");
            XElement item;
            try
            {
                item = (from b in doc.Elements("FiscalConfig")
                        select b).First();
            }
            catch
            {
                item = new XElement("FiscalConfig",
                new XElement("TipoImpresora", "BIXOLON"),
                new XElement("Puerto", "COM1"),
                new XElement("NumeroRegistro", "Z01010101")
                );
                doc.Add(item);
                doc.Save("OKConfig.xml");
            }
            TipoImpresora = item.Elements("TipoImpresora").First().Value;
            Puerto = item.Elements("Puerto").First().Value;
            NumeroRegistro = item.Elements("NumeroRegistro").First().Value;
        }
        public void Save()
        {
            XElement doc = XElement.Load("OKconfig.xml");
            var item = (from b in doc.Elements("FiscalConfig")
                        select b).First();
            item.Elements("TipoImpresora").First().Value = TipoImpresora;
            item.Elements("Puerto").First().Value = Puerto;
            item.Elements("NumeroRegistro").First().Value = NumeroRegistro;
            doc.Save("OKconfig.xml");
        }
    }
}
