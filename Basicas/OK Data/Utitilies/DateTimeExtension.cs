using System;
using System.Collections.Generic;
using System.Linq;

namespace HK
{
    namespace Utilitatios
    {
        /// <summary>
        /// Demo DateTime.DateDiff
        /// </summary>
        public class DateTimeExtension
        {

            /// <summary>
            /// Devuelve un valor Long que especifica el n�mero de
            /// intervalos de tiempo entre dos valores Date.
            /// </summary>
            /// <param name="interval">Obligatorio. Valor de enumeraci�n
            /// DateInterval o expresi�n String que representa el intervalo
            /// de tiempo que se desea utilizar como unidad de diferencia
            /// entre Date1 y Date2. </param>
            /// <param name="date1">Obligatorio. Date. Primer valor de
            /// fecha u hora que se desea utilizar en el c�lculo. </param>
            /// <param name="date2">Obligatorio. Date. Segundo valor de
            /// fecha u hora que se desea utilizar en el c�lculo. </param>
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
    }
}
