using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data.SqlClient;
using HK.BussinessLogic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;

namespace HK
{

    public class OK
    {
        public static Usuario usuario;
        public static Parametro SystemParameters;
        private static DbConfig db;
        public static DbConfig DBconfig 
        {
            get
            {
                if (db == null)
                {
                    db = new DbConfig();
                }
                return db;
            } 
            set
            {
                db = value;
            } 
        }
        public static T DeepCopy<T>(T source) where T: HK.BussinessLogic.Entity, new ()
        {
            T result;
            result = new T();
            foreach (var item in result.GetType().GetProperties())
            {
                object valor = source.GetType().GetProperty(item.Name).GetValue(source, null);
                item.SetValue(result, valor, null);
            }
            result.ID = Guid.NewGuid().ToString();
            return result;
        }
        public static void XMLEscribirElemento(XElement item, string variable, object valor)
        {
            try
            {
                item.Elements(variable).First().Value = valor.ToString();
            }
            catch (Exception)
            {
                item.Add(new XElement(variable, valor));
            }
        }
        public static string XMLLeerElemento(XElement item, string variable, string defecto=null)
        {
            try
            {
                return item.Elements(variable).First().Value;
            }
            catch (Exception)
            {
                return defecto;
            }
        }
        public static bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
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
        public static string ListToString(List<string> lista)
        {
            StringBuilder retorno = new StringBuilder();
            foreach (string x in lista)
            {
                retorno.AppendLine(x);
            }
            return retorno.ToString();
        }
        public static string ErroresToString(ICollection<System.Data.Entity.Validation.DbValidationError> lista)
        {
            StringBuilder retorno = new StringBuilder();
            foreach (var x in lista)
            {
                retorno.AppendLine(x.ErrorMessage);
            }
            return retorno.ToString();
        }
        public static string ManejarException(Exception x)
        {
            while (x.InnerException != null)
            {
                x = x.InnerException;
            }
            return x.Message;
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
        public static DateTime MonthLastDay(int mes, int ano)
        {
            return Convert.ToDateTime(string.Format("{0}/{1}/{2}", ano, mes, DateTime.DaysInMonth(ano, mes)));
        }
        public static DateTime MonthFirstDay(int mes, int ano)
        {
            return Convert.ToDateTime(string.Format("{0}/{1}/01", ano, mes));
        }
        public class DateTimeExtension
        {

            /// <summary>
            /// Devuelve un valor Long que especifica el número de
            /// intervalos de tiempo entre dos valores Date.
            /// </summary>
            /// <param name="interval">Obligatorio. Valor de enumeración
            /// DateInterval o expresión String que representa el intervalo
            /// de tiempo que se desea utilizar como unidad de diferencia
            /// entre Date1 y Date2. </param>
            /// <param name="date1">Obligatorio. Date. Primer valor de
            /// fecha u hora que se desea utilizar en el cálculo. </param>
            /// <param name="date2">Obligatorio. Date. Segundo valor de
            /// fecha u hora que se desea utilizar en el cálculo. </param>
            /// <returns></returns>
            public static long DateDiff(DateInterval interval, DateTime date1, DateTime date2)
            {
                long rs = 0;
                TimeSpan diff = date2.Subtract(date1);
                switch (interval)
                {
                    case DateInterval.Day:
                    case DateInterval.DayOfYear:
                        rs = (long)diff.TotalDays;
                        break;
                    case DateInterval.Hour:
                        rs = (long)diff.TotalHours;
                        break;
                    case DateInterval.Minute:
                        rs = (long)diff.TotalMinutes;
                        break;
                    case DateInterval.Month:
                        rs = (date2.Month - date1.Month) + (12 * DateTimeExtension.DateDiff(DateInterval.Year, date1, date2));
                        break;
                    case DateInterval.Quarter:
                        rs = (long)Math.Ceiling((double)(DateTimeExtension.DateDiff(DateInterval.Month, date1, date2) / 3.0));
                        break;
                    case DateInterval.Second:
                        rs = (long)diff.TotalSeconds;
                        break;
                    case DateInterval.Weekday:
                    case DateInterval.WeekOfYear:
                        rs = (long)(diff.TotalDays / 7);
                        break;
                    case DateInterval.Year:
                        rs = date2.Year - date1.Year;
                        break;
                }//switch
                return rs;
            }//DateDiff
        }
        /// <summary>
        /// Enumerados que definen los tipos de
        /// intervalos de tiempo posibles.
        /// </summary>
        public enum DateInterval
        {
            Day,
            DayOfYear,
            Hour,
            Minute,
            Month,
            Quarter,
            Second,
            Weekday,
            WeekOfYear,
            Year
        }
    }
}
