using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HK.Formas;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Management;


namespace HK
{
    public partial class Basicas
    {
        public static Usuario Usuario = null;
        public static Boolean ImpresoraActiva = false;
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Name);
        public static object GetValue(object objeto, string propiedad)
        {
            return objeto.GetType().GetProperty(propiedad).GetValue(objeto, null);
        } 
        public static void AsegurarToolStrip(object[] toolStrips)
        {
            if (OK.usuario == null)
                return;
            foreach (ToolStrip toolStrip in toolStrips)
            {
                foreach (var item in toolStrip.Items)
                {
                    System.Reflection.PropertyInfo caption = item.GetType().GetProperty("Text");
                    if (caption.GetValue(item, null) != null)
                    {
                        OK.usuario.disabled = OK.usuario.disabled == null ? string.Empty : OK.usuario.disabled;
                        string Texto = string.Format("[{0}.{1}]", toolStrip.Text, caption.GetValue(item, null));
                        if (OK.usuario.disabled.Contains(Texto))
                        {
                            ((ToolStripItem)item).Visible =false;
                        }
                    }
                }
            }
        }
        public static DateTime MonthLastDay(int mes, int ano)
        {
            return Convert.ToDateTime(string.Format("{0}/{1}/{2}", ano, mes, DateTime.DaysInMonth(ano, mes)));
        }
        public static DateTime MonthFirstDay(int mes, int ano)
        {
            return Convert.ToDateTime(string.Format("{0}/{1}/01", ano, mes));
        }


        public static string VerificarRif(string txtBuscar)
        {
            txtBuscar = txtBuscar.Replace("V0", "V");
            string texto = txtBuscar;
            string responseFromServer=null;   
            for(int i=0;i<10;i++)
            {
                try
                {
                    if (!texto.Contains("V"))
                    {
                        i = 10;
                    }
                    else 
                    {
                        texto = txtBuscar + i;
                    }
                WebRequest request = WebRequest.Create( string.Format("http://contribuyente.seniat.gob.ve/getContribuyente/getrif?rif={0}", texto));
                request.Credentials = CredentialCache.DefaultCredentials;
                WebResponse response =  request.GetResponse();
                if(((HttpWebResponse)response).StatusCode !=HttpStatusCode.OK) {
                    return null;
                } 
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream, Encoding.UTF8);
                responseFromServer = reader.ReadToEnd();
                reader.Close();
                response.Close();
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(responseFromServer);
                var d = xml.GetElementsByTagName("rif:Rif").Item(0);
                return d.ChildNodes[0].InnerText;
                }
                catch (Exception x)
                {
                    if (x.Message.Contains("452"))
                    {
                        continue;
                    }
                    else {
                        MessageBox.Show(x.Message);
                        return null;
                    }  
                }
            }
            return responseFromServer;
            //while (true);
            //if (objStream == null)
            //    return null;
            //StreamReader objReader = new StreamReader(objStream);
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(objReader.ReadToEnd());
            //foreach (var itemNode in doc.DocumentElement)
            //{
            //    XmlElement itemElement = (XmlElement)itemNode;
            //    if (itemElement.Name == "rif:Nombre")
            //    {
            //        return itemElement.InnerText;
            //    }
            //}
            //return null;
        }
        public static string GetDefaultPrinterName()
        {
            var query = new ObjectQuery("SELECT * FROM Win32_Printer");
            var searcher = new ManagementObjectSearcher(query);

            foreach (ManagementObject mo in searcher.Get())
            {
                if (((bool?)mo["Default"]) ?? false)
                {
                    return mo["Name"] as string;
                }
            }

            return null;
        }
        public static string TipoLetra(int I)
        {
            return String.Format("{0}!{1}", Convert.ToChar(27), Convert.ToChar(I));
        }
        public static void ManejarError(Exception x)
        {
            string s = null;
            if (x.InnerException != null)
                s = string.Format("Error:{0}\n{1}:{2}", x.StackTrace, DateTime.Now, x.InnerException.Message);
            else
                s = string.Format("Error:{0}\n{1}:{2}", x.StackTrace, DateTime.Now, x.Message);
            try
            {
                MessageBox.Show(s);
                StreamWriter log = File.AppendText(Application.ExecutablePath + "Errores.txt");
                log.WriteLine(s);
                log.Flush();
                log.Close();
            }
            catch (Exception x2)
            {
                MessageBox.Show(x2.Message);
            }
        }
        public static void ErroresDeValidacion(List<string> errores)
        {
            string mensaje = "";
            foreach (var item in errores)
            {
                mensaje += item + "\n";
            }
            MessageBox.Show(mensaje, "Errores", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static double Round(double? valor)
        {
            try
            {
                if (valor == null)
                    valor = 0;
                decimal myValor = (decimal)valor;
                myValor = decimal.Round(myValor, 2);
                return (double)myValor;
            }
            catch
            {
                return 0;
            }
        }
        public static string ListToString(List<string> lista)
        {
            string retorno = "";
            foreach (string item in lista)
            {
                retorno += item + "\n";
            }
            return retorno;
        }
        public static void DisposeImage(Image image)
        {
            image.Dispose();
            image = null;
            GC.Collect();
        }
        public static string CedulaRif(string Texto)
        {
            if (string.IsNullOrEmpty(Texto))
            {
                return "";
            }
            Texto = Texto.ToUpper();
            Texto = Texto.Replace(":", "");
            Texto = Texto.Replace("-", "").Replace(".", "").Replace(" ", "").Replace(",", "").Replace("CI", "").Replace("RIF", "").Replace("C", "");
            if (Texto[0] == 'J' || Texto[0] == 'G')
            {
                if (Texto.Length > 10)
                {
                    Texto.Substring(0, 10);
                }
            }
            //else
            //{
            if (IsNumeric(Texto))
            {
                Texto = "V" + Texto.PadLeft(9, '0');
            }
            if (Texto[0] == 'V')
            {
                Texto = Texto.Replace("V", "");
                Texto = "V" + Texto.PadLeft(9, '0');
            }
            if (Texto[0] == 'E')
            {
                Texto = Texto.Replace("E", "");
                Texto = "E" + Texto.PadLeft(9, '0');
            }
            //}
            return Texto;
        }
        public static string NumeroCuenta(string Texto)
        {
            if (string.IsNullOrEmpty(Texto))
            {
                return Texto;
            }
            Texto = Texto.Replace("-", "").Replace(".", "").Replace(" ", "").Replace(",", "");
            return Texto;
        }
        public static string PrintFix(string Texto, int Largo, int Alineacion)
        {
            const string x = "";
            if (Texto == null) Texto = "";
            Texto = Texto.Trim();
            if (Texto.Length > Largo)
            {
                return Texto.Substring(0, Largo);
            }
            switch (Alineacion)
            {
                case 1:
                    Texto = Texto.PadRight(Largo);
                    break;
                case 2:
                    Texto = Texto.PadLeft(Largo);
                    break;
                case 3:
                    int Suplemento = (Largo - Texto.Length) / 2;
                    Texto = x.Substring(0, Suplemento) + Texto + x.Substring(0, Suplemento);
                    break;
            }
            return Texto.Substring(0,Largo);
        }
        public static string PrintNumero(double? d, int len)
        {
            if (!d.HasValue)
            {
                d = 0;
            }
            return d.Value.ToString("n2").PadLeft(len);
        }
        public static bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        public static string ExportReportToPDF(object reporte)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            LocalReport r = (LocalReport)reporte;
            string reportName = r.ReportPath;
            byte[] bytes = r.Render(
            "PDF", null, out mimeType, out encoding, out filenameExtension,
            out streamids, out warnings);
            string filename = Path.Combine(Path.GetTempPath(), String.Format("{0}-{1}.PDF", Path.GetFileNameWithoutExtension(reportName), DateTime.Now.ToLongTimeString().Replace(":", "")));
            FileStream fs = new FileStream(filename, FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Flush();
            fs.Close();
            fs.Dispose();
            r.ReleaseSandboxAppDomain();
            return filename;
        }
        public class Mail : IDisposable
        {
            public void Dispose()
            {
            }
            public BussinessLogic.EmailConfig mailConfig { get; set; }
            public string Title { get; set; }
            public string Text { get; set; }
            public string From { get; set; }
            public bool RequireAutentication { get; set; }
            public bool DeleteFilesAfterSend { get; set; }

            public List<string> To { get; set; }
            public List<string> Cc { get; set; }
            public List<string> Bcc { get; set; }
            public List<string> AttachmentFiles { get; set; }

            #region appi declarations
            internal enum MoveFileFlags
            {
                MOVEFILE_REPLACE_EXISTING = 1,
                MOVEFILE_COPY_ALLOWED = 2,
                MOVEFILE_DELAY_UNTIL_REBOOT = 4,
                MOVEFILE_WRITE_THROUGH = 8
            }

            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            static extern bool MoveFileEx(string lpExistingFileName, string lpNewFileName, MoveFileFlags dwFlags);
            #endregion

            public Mail()
            {
                To = new List<string>();
                Cc = new List<string>();
                Bcc = new List<string>();
                AttachmentFiles = new List<string>();
                mailConfig = new BussinessLogic.EmailConfig();
            }

            public void Send()
            {
                SmtpClient client = new SmtpClient();
                client = new SmtpClient(mailConfig.Host, int.Parse( mailConfig.Port));
                client.EnableSsl = mailConfig.Port == "25" ? false : true;          

                if (RequireAutentication)
                {
                    var credentials = new NetworkCredential(mailConfig.Acount, mailConfig.Password);
                    client.Credentials = credentials;
                }
                var message = new MailMessage
                {
                Sender = new MailAddress(From, From),
                From = new MailAddress(From, From)
                };

                AddDestinataryToList(To, message.To);
                AddDestinataryToList(Cc, message.CC);
                AddDestinataryToList(Bcc, message.Bcc);

                message.Subject = Title;
                message.Body = Text;
                message.IsBodyHtml = false;
                message.Priority = MailPriority.High;


                foreach (var attachment in AttachmentFiles.Select(file => new Attachment(file)))
                {
                    message.Attachments.Add(attachment);
                }

                client.Send(message);

                if (DeleteFilesAfterSend)
                {
                    AttachmentFiles.ForEach(DeleteFile);
                }
            }
            private void AddDestinataryToList(IEnumerable<string> from, ICollection<MailAddress> mailAddressCollection)
            {
                foreach (var destinatary in from)
                {
                    mailAddressCollection.Add(new MailAddress(destinatary, destinatary));
                }
            }

            private void DeleteFile(string filepath)
            {
                //this should delete the file in the next reboot, not now.
                MoveFileEx(filepath, null, MoveFileFlags.MOVEFILE_DELAY_UNTIL_REBOOT);
            }
        }
        public static void EnviarEmail(string[] texto, string destinatario)
        {
            try
            {
                Mail correo = new Mail();
                StringBuilder salida = new StringBuilder();
                foreach (var x in texto)
                {
                    salida.AppendLine(x);
                }
                correo.Title = texto[0];
                correo.Text = salida.ToString();
                correo.To.Add(destinatario);
                //     correo.AttachmentFiles.Add(archivo);
                correo.From = correo.mailConfig.Acount;
                correo.RequireAutentication = true;
                //    correo.DeleteFilesAfterSend = true;
                correo.Send();

                //                MessageBox.Show("Correo enviado exitosamente", "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error al enviar el mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void EnviarEmail(string archivo, string Titulo, string destinatario)
        {
            try
            {
                Mail correo = new Mail();
                FrmDatosEmail f = new FrmDatosEmail() { asunto = string.Format("{0}-{1}", Titulo, OK.SystemParameters.Empresa), Texto = "Estimado cliente enviamos este documento cualquier duda, estamos a sus ordenes", destinatario = destinatario };
                f.ShowDialog();
                if (f.DialogResult == DialogResult.Cancel)
                    return;
                correo.Title = f.asunto;
                correo.Text = f.Texto;
                correo.To.Add(f.destinatario);
                correo.AttachmentFiles.Add(archivo);
                correo.From = correo.mailConfig.Acount;
                correo.RequireAutentication = true;
                correo.DeleteFilesAfterSend = true;
                correo.Send();
                MessageBox.Show("Correo enviado exitosamente", "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error al enviar el mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
