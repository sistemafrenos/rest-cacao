using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Data;

namespace HK.BussinessLogic
{
    public class EmailConfig
    {
        public string Host { set; get; }
        public string Port { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public string Acount { set; get; }
        public EmailConfig()
        {

            if (!File.Exists("OKconfig.xml"))
                Configuracion.Create();
            XElement doc = XElement.Load("OKconfig.xml");
            XElement item;
            try
            {
                item = (from b in doc.Elements("EmailConfig")
                        select b).First();
            }
            catch
            {
                item = new XElement("EmailConfig",
                new XElement("Host", "smtp.gmail.com"),
                new XElement("Port", "587"),
                new XElement("UserName", "nombre de usuario"),
                new XElement("Acount", "cuenta@gmail.com"),
                new XElement("Password", "Pa$$w0rd")
                );
                doc.Add(item);
                doc.Save("OKconfig.xml");
            }
            Host = item.Elements("Host").First().Value;
            Port = item.Elements("Port").First().Value;
            Username = item.Elements("UserName").First().Value;
            Acount = item.Elements("Acount").First().Value;
            Password = item.Elements("Password").First().Value;
        }
        public void Save()
        {
            XElement doc = XElement.Load("OKconfig.xml");
            var item = (from b in doc.Elements("EmailConfig")
                        select b).First();
            item.Elements("Host").First().Value = Host;
            item.Elements("Port").First().Value = Port;
            item.Elements("UserName").First().Value = Username;
            item.Elements("Acount").First().Value = Acount;
            item.Elements("Password").First().Value = Password;
            doc.Save("OKconfig.xml");
        }
    }
}
