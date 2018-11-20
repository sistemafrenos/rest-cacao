using System;
using System.Configuration.Assemblies;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace HK.BussinessLogic
{
    public class SistemaConfig
    {
        public string DirectorioListas { set; get; }
        public string DirectorioReportes { set; get; }
        public string EmailDestinatario1 { set; get; }
        public string EmailDestinatario2 { set; get; }
        public string ArchivoRespaldo { set; get; }

        public SistemaConfig()
        {
            
            if (!File.Exists("OKconfig.xml"))
                Configuracion.Create();
            XElement doc = XElement.Load("OKconfig.xml");
            XElement item;
            try
            {
                item = (from b in doc.Elements("SistemasConfig")
                        select b).First();
            }
            catch
            {
                item = new XElement("SistemasConfig");
                
                OK.XMLEscribirElemento(item,"EmailDestinatario1", "administrador@gmail.com");
                OK.XMLEscribirElemento(item,"EmailDestinatario2", "sistema@gmail.com");
                OK.XMLEscribirElemento(item,"DirectorioReportes", @".\Reportes");
                OK.XMLEscribirElemento(item, "DirectorioListas", @".\Layouts");
                OK.XMLEscribirElemento(item, "ArchivoRespaldo", @".\Backup");
                doc.Add(item);
                doc.Save("OKConfig.xml");
            }
            EmailDestinatario1 = OK.XMLLeerElemento(item,"EmailDestinatario1");
            EmailDestinatario2 = OK.XMLLeerElemento(item, "EmailDestinatario2");
            DirectorioListas = OK.XMLLeerElemento(item, "DirectorioListas");
            DirectorioReportes = OK.XMLLeerElemento(item, "DirectorioReportes");
            ArchivoRespaldo = OK.XMLLeerElemento(item, "ArchivoRespaldo");
            
        }
        public void Save()
        {
            XElement doc = XElement.Load("OKconfig.xml");
            var item = (from b in doc.Elements("SistemasConfig")
                        select b).First();
            OK.XMLEscribirElemento(item, "EmailDestinatario1", EmailDestinatario1);
            OK.XMLEscribirElemento(item, "EmailDestinatario2", EmailDestinatario2);
            OK.XMLEscribirElemento(item, "DirectorioReportes", DirectorioReportes);
            OK.XMLEscribirElemento(item, "DirectorioListas", DirectorioListas);
            OK.XMLEscribirElemento(item, "ArchivoRespaldo",ArchivoRespaldo);
            doc.Save("OKconfig.xml");
        }
    }
}
