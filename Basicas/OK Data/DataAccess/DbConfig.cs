using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Data.Common;
using System.Data.SqlClient;

namespace HK.BussinessLogic
{
    public class DbConfig
    {
        public string Provider { set; get; }
        public string Server { set; get; }
        public bool IntegratedSecurity { set; get; }
        public string DataBase { set; get; }
        public string User { set; get; }
        public string Password { set; get; }
        public string Backup { set; get; }
    }
}
