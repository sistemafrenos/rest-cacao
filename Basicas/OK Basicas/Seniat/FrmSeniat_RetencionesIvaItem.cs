using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmSeniat_RetencionesIvaItem : Form
    {
        Administrativo data = new Administrativo();
        List<Retencion> registros = new List<Retencion>();
        Tercero proveedor = new Tercero();
       
        BussinessLogic.Retenciones retenciones;
        public string NumeroComprobante = null;
        private string PeriodoImpositivo =  DateTime.Today.Year.ToString("0000") + DateTime.Today.Month.ToString("00");
        private DateTime FechaComprobante = DateTime.Today;
        private string Periodo = DateTime.Today.Day <= 15 ? "PRIMER PERIODO" : "SEGUNDO PERIODO";
        public FrmSeniat_RetencionesIvaItem()
        {
            InitializeComponent();
            retenciones = new BussinessLogic.Retenciones();
            this.Load += new EventHandler(FrmSeniat_RetencionesIvaItem_Load);
        }
        void FrmSeniat_RetencionesIvaItem_Load(object sender, EventArgs e)
        {
            this.NumeroFacturaButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(NumeroFacturaButtonEdit_ButtonClick);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyDown += new KeyEventHandler(FrmPagar_KeyDown);
            txtPorcentajeRetencion.Validating += new CancelEventHandler(txtPorcentajeRetencion_Validating);
            txtBaseImponible.Validating += new CancelEventHandler(txtBaseImponible_Validating);
            txtMontoExentoIva.Validating += new CancelEventHandler(txtMontoExentoIva_Validating);
        }

        void txtPorcentajeRetencion_Validating(object sender, CancelEventArgs e)
        {
            retencioneBindingSource.EndEdit();
            DevExpress.XtraEditors.ComboBoxEdit editor = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            Retencion registro = (Retencion)this.retencioneBindingSource.Current;
            registro.PorcentajeRetencion = Basicas.Round(Convert.ToDouble( editor.Text));
            registro.MontoRetenido = Basicas.Round(registro.MontoIva * (registro.PorcentajeRetencion / 100));
        }

        void txtMontoExentoIva_Validating(object sender, CancelEventArgs e)
        {
            retencioneBindingSource.EndEdit();
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            Retencion registro = (Retencion)this.retencioneBindingSource.Current;
            registro.BaseImponible = Basicas.Round( (double)editor.Value);
            registro.MontoTotal = Basicas.Round(registro.MontoExento + registro.BaseImponible + registro.MontoIva);
        }

        void txtBaseImponible_Validating(object sender, CancelEventArgs e)
        {
            retencioneBindingSource.EndEdit();
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            Retencion registro =   (Retencion)this.retencioneBindingSource.Current;
            registro.BaseImponible = (double)editor.Value;
            registro.MontoIva = Basicas.Round( registro.BaseImponible * (registro.TasaIva / 100));
            registro.MontoRetenido = Basicas.Round( registro.MontoIva * (registro.PorcentajeRetencion / 100));
            registro.MontoTotal = Basicas.Round(registro.MontoExento + registro.BaseImponible + registro.MontoIva);
        }

        void txtPorcentaje_Validating(object sender, CancelEventArgs e)
        {
            retencioneBindingSource.EndEdit();
            DevExpress.XtraEditors.ComboBoxEdit editor = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            Retencion registro =   (Retencion)this.retencioneBindingSource.Current;
            try
            {
                Double? Valor = Convert.ToDouble(editor.Text);
                registro.MontoRetenido = registro.MontoIva * Valor.GetValueOrDefault(0) / 100;
            }
            catch
            {
            }
        }

        void NumeroFacturaButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (proveedor == null)
                return;
            FrmBuscarEntidades f = new FrmBuscarEntidades();
            f.BuscarComprasProveedor(proveedor.CedulaRif);
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            //Retencion item = (from x in db.Retenciones
            //                  where x.IdDocumento == ((Documento)f.registro).IdDocumento
            //                  select x).FirstOrDefault();
            //if (item != null)
            //{
            //    MessageBox.Show("Esta compra ya tiene retencion aplicada", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            CrearRetencion((Compra)f.registro);
        }
        void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        void Aceptar_Click(object sender, EventArgs e)
        {
            this.retencioneBindingSource.EndEdit();
            foreach (var item in registros)
            {
                item.ComprobanteRetencionIVA = NumeroComprobanteTextEdit.Text;
                //if (db.Entry(item).State == EntityState.Detached)
                //{
                //    Documento c = (from x in db.Documentos
                //                   where x.IdDocumento == item.IdDocumento
                //                   select x).FirstOrDefault();
                //    TercerosMovimiento p = (from x in db.TercerosMovimientos
                //                            where x.IdDocumento == item.IdDocumento
                //                            select x).FirstOrDefault();
                //    if (c != null)
                //    {
                //        c.ComprobanteRetencion = item.NumeroComprobante;

                //    }
                //    if (p != null)
                //    {
                //        p.Saldo = p.Saldo - item.MontoIvaRetenido.GetValueOrDefault(0);
                //    }
                //    TercerosMovimiento mov_ret = new TercerosMovimiento();
                //    mov_ret.Concepto = string.Format("RET.IVA SOBRE FACTURA {0}", c.Numero);
                //    mov_ret.Credito = item.MontoIvaRetenido;
                //    mov_ret.DocumentoAfectado = item.NumeroDocumento;
                //    mov_ret.Fecha = DateTime.Today;
                //    mov_ret.IdDocumento = c != null ? c.IdDocumento : null;
                //    mov_ret.IdTercero = p != null ? p.IdTercero : null;
                //    mov_ret.Numero = NumeroComprobanteTextEdit.Text;
                //    mov_ret.Saldo = 0;
                //    mov_ret.Tipo = "RETENCION IVA";
                //    mov_ret.Vence = DateTime.Today;
                //    mov_ret.AsignarID();
                //    if (!db.Entry(mov_ret).GetValidationResult().IsValid)
                //    {
                //        Basicas.ErroresDeValidacion(db.Entry(mov_ret).GetValidationResult());
                //    }
                //    db.TercerosMovimientos.Add(mov_ret);
                //    if (!db.Entry(item).GetValidationResult().IsValid)
                //    {
                //        Basicas.ErroresDeValidacion(db.Entry(item).GetValidationResult());
                //    }
                //    db.Retenciones.Add(item);
                //}
            }
            //if (db.Entry(registros[0]).State == EntityState.Detached || db.Entry(registros[0]).State == EntityState.Added)
            //{
            //    Comprobante = Convert.ToInt32(NumeroComprobanteTextEdit.Text.Substring(8, 6));
            //    FactoryContadores.SetMax("NumeroComprobanteRetencion", Comprobante);
            //}
            //NumeroComprobante = NumeroComprobanteTextEdit.Text;
            //db.SaveChanges();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        public void Incluir()
        {
            this.CedulaRifTextEdit.Enabled = true;
            this.ShowDialog();
        }
        public void Modificar(Retencion registro)
        {
            this.CedulaRifTextEdit.Enabled = true;
            this.NumeroFacturaButtonEdit.Enabled = false;
            registros.Add(registro);
            this.PeriodoComboBoxEdit.Text = registro.Periodo;
            this.PeriodoImpositivoTextEdit.Text = registro.PeriodoImpositivo;
            this.NumeroComprobanteTextEdit.Text = registro.ComprobanteRetencionIVA;
            this.FechaComprobanteDateEdit.DateTime = registro.FechaComprobante.Value;
            this.CedulaRifTextEdit.Text = registro.CedulaRif;
            //   this.NumeroControlDocumentoTextEdit.Text = NotaCredito.NumeroControl;
            this.RazonSocialTextEdit.Text = proveedor.RazonSocial;
            this.retencioneBindingSource.DataSource = registros;
            this.ShowDialog();
        }

        public void CrearRetencion(Compra compra)
        {
            this.CedulaRifTextEdit.Enabled = false;
            this.NumeroComprobante = String.Format("{0:0000}{1:00}00{2}", DateTime.Today.Year, DateTime.Today.Month, Administrativo.GetContador("NumeroComprobanteRetencion"));
            retenciones.CrearRetencion(compra, DateTime.Today.Month, DateTime.Today.Year, Periodo);
            this.PeriodoComboBoxEdit.Text = Periodo;
            this.PeriodoImpositivoTextEdit.Text = PeriodoImpositivo;
            this.NumeroComprobanteTextEdit.Text = NumeroComprobante;
            this.FechaComprobanteDateEdit.DateTime = FechaComprobante;
            this.CedulaRifTextEdit.Text = proveedor.CedulaRif;
            this.RazonSocialTextEdit.Text = proveedor.RazonSocial;
            this.retencioneBindingSource.DataSource = registros;
            this.retencioneBindingSource.ResetBindings(true);
            if ( !this.Visible )
                this.ShowDialog();
        }

        void FrmPagar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Cancelar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F12:
                    this.Aceptar.PerformClick();
                    e.Handled = true;
                    break;
            }
        }
    }
}
