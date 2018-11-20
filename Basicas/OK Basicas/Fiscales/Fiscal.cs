using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.Fiscales
{
    public class Fiscal
    {
        IFiscal mFiscal;
        HK.BussinessLogic.FiscalConfig config;
        public IFiscal GetFiscal(string TipoImpresora, string Puerto="COM1")
        {
            switch (TipoImpresora)
            {
                case "BIXOLON":
                    mFiscal = new FiscalBixolon(Puerto);
                    break;
                case "BIXOLON 2010":
                    mFiscal = new FiscalBixolon2010(Puerto);
                    break;
                case "EPSON":
                    mFiscal = new FiscalEpson(Puerto);
                    break;
                case "WINDOWS":
                    mFiscal = new FiscalWindows(Puerto);
                    break;
                case "TICKERA":
                    mFiscal = new FiscalTickera(Puerto);
                    break;
                //case "REMOTA":
                //    mFiscal = new FiscalRemota(config.TipoImpresora);
                //    break;
                //case "NINGUNA":
                //    mFiscal = new FiscalNinguna(config.TipoImpresora);
                //    break;
                default:
                    mFiscal = new FiscalWindows(Puerto);
                    break;
            }
            return mFiscal;
        }
        public IFiscal GetFiscal()
        {
            config = new BussinessLogic.FiscalConfig();
            return GetFiscal(config.TipoImpresora, config.Puerto);
        }
    }
}
