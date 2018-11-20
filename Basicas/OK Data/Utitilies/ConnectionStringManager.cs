using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace HK.Utitilies
{
        public class ConnectionStringManager
        {
            public static string GetConnectionString(string connectionStringName)
            {
                Configuration appconfig =
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConnectionStringSettings connStringSettings = appconfig.ConnectionStrings.ConnectionStrings[connectionStringName];
                return connStringSettings.ConnectionString;
            }

            public static void SaveConnectionString(string connectionStringName, string connectionString)
            {
                Configuration appconfig =
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                appconfig.ConnectionStrings.ConnectionStrings[connectionStringName].ConnectionString = connectionString;
                appconfig.Save();
            }
            // Lectura
            public static List<string> GetConnectionStringNames()
            {
                List<string> cns = new List<string>();
                Configuration appconfig =
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                foreach (ConnectionStringSettings cn in appconfig.ConnectionStrings.ConnectionStrings)
                {
                    cns.Add(cn.Name);
                }
                return cns;
            }
            public static string GetFirstConnectionStringName()
            {
                return GetConnectionStringNames().FirstOrDefault();
            }
            public static string GetFirstConnectionString()
            {
                return GetConnectionString(GetFirstConnectionStringName());
            }
            public static string GetSqlServerServerName( string cs = null )
            {
                if (cs == null)
                    cs = GetConnectionString(GetFirstConnectionStringName());
                if (cs != null)
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(cs);
                    return builder.DataSource;
                }
                else
                    return null;
            }
            public static string GetSqlServerDatabaseName( string cs = null )
            {
                if(cs==null)
                cs = GetConnectionString(GetFirstConnectionStringName());
                if (cs != null)
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(cs);
                    return builder.InitialCatalog;
                }
                else
                    return null;
            }
            public static string GetSqlServerUserName( string cs = null)
            {
                if (cs == null)
                    cs = GetConnectionString(GetFirstConnectionStringName());
                if (cs != null)
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(cs);
                    return builder.UserID;
                }
                else
                    return null;
            }
            public static string GetSqlServerPassword( string cs = null)
            {
                if (cs == null)
                    cs = GetConnectionString(GetFirstConnectionStringName());
                if (cs != null)
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(cs);
                    return builder.Password;
                }
                else
                    return null;
            }
            public static bool? GetSqlServerIntegratedSecurity( string cs = null)
            {
                if (cs == null)
                    cs = GetConnectionString(GetFirstConnectionStringName());
                if (cs != null)
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(cs);
                    return builder.IntegratedSecurity;
                }
                else
                    return null;
            }
            // Escritura
            public static string SetConnectionStringServerName( string connectionString,
                string serverName)
            {
                SqlConnectionStringBuilder builder =
                    new SqlConnectionStringBuilder(connectionString);
                builder.DataSource = serverName;
                return builder.ConnectionString;
            }
            public static string SetConnectionStringAutenticationIntegrated(
                string connectionString)
            {
                SqlConnectionStringBuilder builder =
                    new SqlConnectionStringBuilder(connectionString);
                builder.IntegratedSecurity = true;
                return builder.ConnectionString;
            }
            public static string SetConnectionStringAutenticationSQLServer(
                string connectionString, string username, string password)
            {
                SqlConnectionStringBuilder builder =
                    new SqlConnectionStringBuilder(connectionString);
                builder.IntegratedSecurity = false;
                builder.UserID = username;
                builder.Password = password;
                return builder.ConnectionString;
            }
            public static string SetConnectionStringDatabaseName(
                string connectionString, string databaseName)
            {
                SqlConnectionStringBuilder builder =
                    new SqlConnectionStringBuilder(connectionString);
                builder.InitialCatalog = databaseName;
                return builder.ConnectionString;
            }
        }
}
