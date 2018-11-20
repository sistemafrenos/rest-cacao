using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    partial class Administrativo
    {
        public Pago FindPago(string id)
        {
            return data.PagoRepository.Find(id);
        }
        public Pago FindPagoIdDocumento(string id)
        {
            return data.PagoRepository.GetFirst(x=> x.Documento.ID == id);
        }
        public Pago AnularPagoIdDocumento(string id)
        {
            var item = FindPagoIdDocumento(id);
            if (item != null)
            {
                item.Cambio = 0;
                item.CestaTicket = 0;
                item.Cheque = 0;
                item.ComisionPunto = 0;
                item.Credito = 0;
                item.Deposito = 0;
                item.Efectivo = 0;
                item.MontoPagado = 0;
                item.MontoPagar = 0;
                item.Saldo = 0;
                item.TarjetaCredito = 0;
                item.TarjetaDebito = 0;
                item.Transferencia = 0;
                data.PagoRepository.Update(item);
            }
            return item;
        }
    }
}
