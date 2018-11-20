namespace HK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Adm.Bancos",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Cuenta = c.String(nullable: false, maxLength: 20),
                        Descripcion = c.String(nullable: false, maxLength: 150),
                        Agencia = c.String(maxLength: 100),
                        Telefonos = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Contacto = c.String(maxLength: 150),
                        FechaApertura = c.DateTime(),
                        MontoInicial = c.Double(),
                        Saldo = c.Double(),
                        ComisionTarjetasCredito = c.Double(),
                        ComisionTarjetaDebito = c.Double(),
                        RetencionISLR = c.Double(),
                        PoseePuntoDeVenta = c.Boolean(),
                        ComsionTodoTicket = c.Double(),
                        UltimaEdicion = c.DateTime(),
                        UsuarioID = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Adm.BancosMovimientos",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Fecha = c.DateTime(),
                        Tipo = c.String(maxLength: 20),
                        Numero = c.String(nullable: false, maxLength: 20),
                        Concepto = c.String(maxLength: 100),
                        Debito = c.Double(),
                        Credito = c.Double(),
                        Conciliado = c.Boolean(),
                        Ejecutado = c.Boolean(),
                        PlanCuenta = c.String(maxLength: 20),
                        Beneficiario = c.String(maxLength: 150),
                        CedulaRif = c.String(maxLength: 10),
                        MontoEnLetras = c.String(maxLength: 150),
                        DescripcionCuenta = c.String(maxLength: 100),
                        ComprobanteRetencion = c.String(maxLength: 20),
                        UltimaEdicion = c.DateTime(),
                        UsuarioID = c.String(maxLength: 40),
                        Saldo = c.Double(),
                        Banco_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Adm.Bancos", t => t.Banco_ID, cascadeDelete: true)
                .Index(t => t.Banco_ID);
            
            CreateTable(
                "Adm.AsientosCajaChicas",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        DocumentoID = c.String(maxLength: 40),
                        MovimientoBancoID = c.String(maxLength: 40),
                        Fecha = c.DateTime(),
                        Numero = c.String(maxLength: 20),
                        RazonSocial = c.String(nullable: false, maxLength: 150),
                        Concepto = c.String(nullable: false, maxLength: 100),
                        Monto = c.Double(),
                        Saldo = c.Double(),
                        NumeroCheque = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Adm.CierreCajas",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        NumeroLote = c.Int(),
                        Fecha = c.DateTime(),
                        Hora = c.DateTime(),
                        Efectivo = c.Double(),
                        Cheque = c.Double(),
                        Banesco = c.Double(),
                        Banesco2 = c.Double(),
                        Mercantil = c.Double(),
                        Corpbanca = c.Double(),
                        Tarjetas = c.Double(),
                        DepositosTransferencias = c.Double(),
                        Creditos = c.Double(),
                        Otros = c.Double(),
                        Gastos = c.Double(),
                        Vales = c.Double(),
                        Retenciones = c.Double(),
                        CreditosCobrados = c.Double(),
                        TotalCaja = c.Double(),
                        CantidadFacturas = c.Double(),
                        CantidadFacturasCredito = c.Double(),
                        ComisionMesoneros = c.Double(),
                        Propinas = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Sist.Contadores",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Variable = c.String(maxLength: 40),
                        Valor = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Adm.Documentos",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Anulado = c.Boolean(),
                        CajaChica = c.Boolean(),
                        Fecha = c.DateTime(nullable: false),
                        Vence = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        Mes = c.Int(),
                        Ano = c.Int(),
                        Tipo = c.String(maxLength: 20),
                        Estatus = c.String(maxLength: 20),
                        Numero = c.String(maxLength: 20),
                        NumeroOrden = c.String(maxLength: 20),
                        NumeroControl = c.String(maxLength: 20),
                        NumeroZ = c.String(maxLength: 10),
                        TipoPrecio = c.String(maxLength: 20),
                        MaquinaFiscal = c.String(maxLength: 20),
                        CedulaRif = c.String(nullable: false, maxLength: 10),
                        RazonSocial = c.String(nullable: false, maxLength: 150),
                        Direccion = c.String(),
                        Email = c.String(maxLength: 40),
                        Telefonos = c.String(maxLength: 40),
                        MontoSinDerechoCredito = c.Double(),
                        MontoExento = c.Double(),
                        MontoImpuestosLicores = c.Double(),
                        MontoGravable = c.Double(),
                        MontoGravableB = c.Double(),
                        TasaIva = c.Double(),
                        TasaIvaB = c.Double(),
                        MontoIva = c.Double(),
                        MontoIvaB = c.Double(),
                        Descuentos = c.Double(),
                        MontoTotal = c.Double(),
                        Saldo = c.Double(),
                        CodigoVendedor = c.String(maxLength: 20),
                        Vendedor = c.String(maxLength: 150),
                        Comentarios = c.String(maxLength: 250),
                        LibroVentas = c.Boolean(),
                        LibroCompras = c.Boolean(),
                        LibroInventarios = c.Boolean(),
                        CodigoCuenta = c.String(maxLength: 20),
                        DescripcionCuenta = c.String(maxLength: 150),
                        ComprobanteRetencionIVA = c.String(maxLength: 40),
                        ComprobanteRetencionISLR = c.String(maxLength: 40),
                        DescuentoProntoPago = c.Double(),
                        Inventarios = c.Boolean(),
                        DocumentoAfectado = c.String(maxLength: 20),
                        Referencia = c.String(maxLength: 20),
                        DocumentoAfectadoID = c.String(maxLength: 20),
                        BaseImponible = c.Double(),
                        MontoSujetoRetencion = c.Double(),
                        PorcentajeRetencion = c.Double(),
                        Sustraendo = c.Double(),
                        MontoRetenido = c.Double(),
                        FechaComprobante = c.DateTime(),
                        NotaCredito = c.String(maxLength: 20),
                        NotaDebito = c.String(maxLength: 20),
                        categoria = c.String(),
                        Deposito = c.Double(),
                        Tarjetas = c.Double(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Tercero_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Adm.Terceros", t => t.Tercero_ID)
                .Index(t => t.Tercero_ID);
            
            CreateTable(
                "Adm.DocumentoProductos",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        ProductoID = c.String(nullable: false, maxLength: 40),
                        Codigo = c.String(nullable: false, maxLength: 40),
                        CodigoProveedor = c.String(maxLength: 40),
                        Descripcion = c.String(maxLength: 160),
                        UnidadMedida = c.String(maxLength: 40),
                        Cantidad = c.Double(nullable: false),
                        Presentacion = c.String(maxLength: 20),
                        UnidadesxEmpaque = c.Double(),
                        Inicio = c.Double(),
                        Entrada = c.Double(),
                        Salida = c.Double(),
                        Final = c.Double(),
                        Precio = c.Double(),
                        Utilidad = c.Double(),
                        TasaIva = c.Double(),
                        PrecioConIva = c.Double(),
                        Total = c.Double(),
                        Costo = c.Double(),
                        CostoIva = c.Double(),
                        Precio2 = c.Double(),
                        PrecioConIva2 = c.Double(),
                        Utilidad2 = c.Double(),
                        Precio3 = c.Double(),
                        PrecioConIva3 = c.Double(),
                        Utilidad3 = c.Double(),
                        Precio4 = c.Double(),
                        PrecioConIva4 = c.Double(),
                        Utilidad4 = c.Double(),
                        CostoNeto = c.Double(),
                        ImpuestoLicores = c.Double(),
                        Departamento = c.String(maxLength: 80),
                        Iva = c.Double(),
                        Comentario = c.String(maxLength: 80),
                        Fecha = c.DateTime(nullable: false),
                        momento = c.DateTime(nullable: false),
                        LlevaInventario = c.Boolean(nullable: false),
                        Documento_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Adm.Documentos", t => t.Documento_ID, cascadeDelete: true)
                .Index(t => t.Documento_ID);
            
            CreateTable(
                "Adm.Pagos",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        NumeroLote = c.Int(),
                        Fecha = c.DateTime(),
                        Hora = c.DateTime(),
                        Tipo = c.String(maxLength: 40),
                        Numero = c.String(maxLength: 20),
                        Concepto = c.String(maxLength: 100),
                        Efectivo = c.Double(),
                        Cheque = c.Double(),
                        TarjetaCredito = c.Double(),
                        TarjetaDebito = c.Double(),
                        CestaTicket = c.Double(),
                        Transferencia = c.Double(),
                        RetencionISLR = c.Double(),
                        RetencionIVA = c.Double(),
                        NumeroCheque = c.String(maxLength: 20),
                        BancoCheque = c.String(maxLength: 40),
                        NumeroTransferencia = c.String(maxLength: 20),
                        ComprobanteRetencionIVA = c.String(maxLength: 20),
                        MovimientoBancoID = c.String(maxLength: 40),
                        RetencionImpuestoMun = c.Double(),
                        Deposito = c.Double(),
                        NumeroDeposito = c.Double(),
                        BancoDestino = c.String(maxLength: 40),
                        Cambio = c.Double(),
                        TipoDocumento = c.String(),
                        Credito = c.Double(),
                        ComisionPunto = c.Double(),
                        NetoDepositar = c.Double(),
                        UltimaEdicion = c.DateTime(),
                        UsuarioID = c.String(maxLength: 40),
                        Documento_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Adm.Documentos", t => t.Documento_ID)
                .Index(t => t.Documento_ID);
            
            CreateTable(
                "Adm.Terceros",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Codigo = c.String(maxLength: 40),
                        Tipo = c.String(maxLength: 20),
                        Estatus = c.String(maxLength: 20),
                        Categoria = c.String(maxLength: 40),
                        CedulaRif = c.String(nullable: false, maxLength: 10),
                        RazonSocial = c.String(nullable: false, maxLength: 150),
                        Direccion = c.String(maxLength: 150),
                        DiasCredito = c.Int(),
                        LimiteCredito = c.Double(),
                        Telefonos = c.String(maxLength: 40),
                        Contacto = c.String(maxLength: 150),
                        Email = c.String(maxLength: 40),
                        PorcentajeRetencionIVA = c.Double(),
                        PorcentajeDescuento = c.Double(),
                        Comentarios = c.String(maxLength: 150),
                        TipoPrecio = c.String(maxLength: 20),
                        Activo = c.Boolean(),
                        SaldoPendiente = c.Double(),
                        FacturasPendientes = c.Int(),
                        Anticipos = c.Double(),
                        CodigoVendedor = c.String(maxLength: 140),
                        Vendedor = c.String(maxLength: 150),
                        VendedorEmail = c.String(maxLength: 40),
                        VendedorTelefonos = c.String(maxLength: 40),
                        Banco = c.String(maxLength: 100),
                        NumeroCuenta = c.String(maxLength: 20),
                        PrestaServicios = c.Boolean(),
                        ContactoCedulaRif = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Adm.TercerosMovimientos",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        CajaID = c.String(maxLength: 40),
                        DocumentoID = c.String(maxLength: 40),
                        NumeroLote = c.Int(),
                        Fecha = c.DateTime(),
                        Vence = c.DateTime(),
                        Numero = c.String(nullable: false, maxLength: 40),
                        Tipo = c.String(maxLength: 40),
                        Concepto = c.String(nullable: false, maxLength: 150),
                        Comentarios = c.String(maxLength: 150),
                        Debito = c.Double(),
                        Credito = c.Double(),
                        Saldo = c.Double(),
                        DescuentoProntoPago = c.Double(),
                        Cuenta = c.String(maxLength: 40),
                        DescripcionCuenta = c.String(maxLength: 150),
                        ProntoPagoAplicado = c.Boolean(),
                        PagarHoy = c.Double(),
                        CodigoVendedor = c.String(maxLength: 40),
                        Vendedor = c.String(maxLength: 150),
                        DocumentoAfectado = c.String(maxLength: 40),
                        NumeroCuenta = c.String(maxLength: 20),
                        FormaDePago = c.String(maxLength: 20),
                        CedulaRifBeneficiario = c.String(maxLength: 10),
                        Beneficiario = c.String(maxLength: 150),
                        MontoGravable = c.Double(),
                        MontoIva = c.Double(),
                        MontoExcento = c.Double(),
                        MontoSinDerechoCreditoFiscal = c.Double(),
                        TasaIva = c.Double(),
                        NumeroPago = c.String(maxLength: 40),
                        NumeroControl = c.String(maxLength: 40),
                        Dias = c.Long(),
                        RazonSocial = c.String(),
                        CuentaCorriente = c.String(),
                        Banco = c.String(),
                        Rif = c.String(),
                        Email = c.String(),
                        Dias1 = c.Long(),
                        RazonSocial1 = c.String(),
                        CuentaCorriente1 = c.String(),
                        Banco1 = c.String(),
                        Rif1 = c.String(),
                        Email1 = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Tercero_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Adm.Terceros", t => t.Tercero_ID, cascadeDelete: true)
                .Index(t => t.Tercero_ID);
            
            CreateTable(
                "Rest.Eventos",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Fecha = c.DateTime(),
                        Tipo = c.String(maxLength: 100),
                        Modulo = c.String(maxLength: 100),
                        Estacion = c.String(maxLength: 100),
                        Usuario = c.String(maxLength: 100),
                        Descripcion = c.String(maxLength: 200),
                        Dia = c.DateTime(),
                        Mesa = c.String(maxLength: 100),
                        Mesonero = c.String(maxLength: 100),
                        Comentario = c.String(maxLength: 150),
                        NumeroImpresiones = c.Int(),
                        Hora = c.DateTime(),
                        TieneEventos = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Adm.LibroCompras",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        DocumentoID = c.String(maxLength: 40),
                        Fecha = c.DateTime(),
                        Mes = c.Int(),
                        Ano = c.Int(),
                        Numero = c.String(nullable: false, maxLength: 40),
                        NumeroControl = c.String(nullable: false, maxLength: 40),
                        MontoExento = c.Double(),
                        MontoGravable = c.Double(),
                        MontoIva = c.Double(),
                        MontoTotal = c.Double(),
                        CedulaRif = c.String(nullable: false, maxLength: 10),
                        RazonSocial = c.String(nullable: false, maxLength: 150),
                        TasaIva = c.Double(),
                        Direccion = c.String(maxLength: 150),
                        IvaRetenido = c.Double(),
                        ComprobanteRetencion = c.String(maxLength: 20),
                        TasaIvaB = c.Double(),
                        MontoIvaB = c.Double(),
                        MontoGravableB = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Adm.LibroInventarios",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Codigo = c.String(nullable: false, maxLength: 40),
                        Descripcion = c.String(nullable: false, maxLength: 150),
                        UltimaEdicion = c.DateTime(),
                        Inicio = c.Double(),
                        Entradas = c.Double(),
                        Salidas = c.Double(),
                        Autoconsumo = c.Double(),
                        Final = c.Double(),
                        Costo = c.Double(),
                        Mes = c.Int(),
                        Ano = c.Int(),
                        Fecha = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Adm.LibroVentas",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        FacturaID = c.String(maxLength: 40),
                        Fecha = c.DateTime(),
                        Factura = c.String(maxLength: 20),
                        NotaCredito = c.String(maxLength: 20),
                        NotaDebito = c.String(maxLength: 20),
                        NumeroZ = c.String(maxLength: 6),
                        MaquinaFiscal = c.String(maxLength: 20),
                        RazonSocial = c.String(maxLength: 150),
                        CedulaRif = c.String(maxLength: 10),
                        Comprobante = c.String(maxLength: 20),
                        FacturaAfectada = c.String(maxLength: 20),
                        TipoOperacion = c.String(maxLength: 20),
                        MontoTotal = c.Double(),
                        MontoExento = c.Double(),
                        IvaRetenido = c.Double(),
                        Mes = c.Int(),
                        Ano = c.Int(),
                        MontoGravableContribuyentes = c.Double(),
                        MontoGravableNoContribuyentes = c.Double(),
                        MontoIvaContribuyentes = c.Double(),
                        MontoIvaNoContribuyentes = c.Double(),
                        TasaIvaContribuyentes = c.Double(),
                        TasaIvaNoContribuyentes = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Adm.MaestroDeCuentas",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Codigo = c.String(nullable: false, maxLength: 20),
                        Descripcion = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Rest.Mesas",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Codigo = c.String(nullable: false, maxLength: 20),
                        Ubicacion = c.String(nullable: false, maxLength: 40),
                        CobraServicio = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Rest.MesasAbiertas",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        MesoneroID = c.String(maxLength: 40),
                        CodigoMesa = c.String(nullable: false, maxLength: 20),
                        Mesonero = c.String(maxLength: 40),
                        Personas = c.Int(),
                        Apertura = c.DateTime(),
                        UltimaImpresion = c.DateTime(),
                        MontoGravable = c.Double(),
                        MontoExento = c.Double(),
                        MontoIva = c.Double(),
                        MontoTotal = c.Double(),
                        MontoServicio = c.Double(),
                        Numero = c.String(maxLength: 20),
                        NumeroImpresiones = c.Int(),
                        ImpresaPor = c.String(),
                        Estacion = c.String(maxLength: 40),
                        CobraServicio = c.Boolean(),
                        CedulaRif = c.String(maxLength: 10),
                        RazonSocial = c.String(maxLength: 150),
                        Email = c.String(maxLength: 40),
                        Direccion = c.String(maxLength: 150),
                        Bloqueada = c.Boolean(),
                        TieneBebidas = c.Boolean(),
                        TieneComidas = c.Boolean(),
                        TieneEventos = c.Boolean(),
                        Descuentos = c.Double(),
                        TipoPrecio = c.String(maxLength: 10),
                        Telefonos = c.String(maxLength: 40),
                        Ubicacion = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Rest.MesasAbiertasProductos",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        ProductoID = c.String(nullable: false, maxLength: 40),
                        Codigo = c.String(nullable: false, maxLength: 40),
                        Descripcion = c.String(nullable: false, maxLength: 150),
                        Cantidad = c.Double(),
                        Precio = c.Double(),
                        TasaIva = c.Double(),
                        PrecioConIva = c.Double(),
                        Total = c.Double(),
                        Costo = c.Double(),
                        EnviarComanda = c.String(maxLength: 40),
                        Departamento = c.String(maxLength: 150),
                        Comentario = c.String(maxLength: 150),
                        Mesonero = c.String(maxLength: 100),
                        Hora = c.DateTime(),
                        NumeroComanda = c.String(maxLength: 10),
                        Alerta = c.Boolean(),
                        Anulado = c.Boolean(),
                        TotalBase = c.Double(),
                        LlevaInventario = c.Boolean(nullable: false),
                        MesasAbierta_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Rest.MesasAbiertas", t => t.MesasAbierta_ID, cascadeDelete: true)
                .Index(t => t.MesasAbierta_ID);
            
            CreateTable(
                "Rest.MesasCerradas",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        DocumentoID = c.String(maxLength: 40),
                        Numero = c.String(maxLength: 10),
                        NumeroLote = c.Int(),
                        Fecha = c.DateTime(),
                        NumeroImpresiones = c.Int(),
                        Factura = c.String(maxLength: 10),
                        TipoPrecio = c.String(maxLength: 10),
                        CodigoMesa = c.String(maxLength: 20),
                        Ubicacion = c.String(maxLength: 40),
                        CobraServicio = c.Boolean(),
                        Mesonero = c.String(maxLength: 100),
                        Personas = c.Int(),
                        Apertura = c.DateTime(),
                        Cierre = c.DateTime(),
                        MontoGravable = c.Double(),
                        MontoExento = c.Double(),
                        MontoIva = c.Double(),
                        MontoTotal = c.Double(),
                        Descuentos = c.Double(),
                        MontoServicio = c.Double(),
                        Comentarios = c.String(maxLength: 150),
                        CedulaRif = c.String(maxLength: 10),
                        RazonSocial = c.String(maxLength: 150),
                        Direccion = c.String(maxLength: 150),
                        Telefonos = c.String(maxLength: 40),
                        Email = c.String(maxLength: 40),
                        Tipo = c.String(maxLength: 20),
                        Efectivo = c.Double(),
                        Cheque = c.Double(),
                        TarjetaCR = c.Double(),
                        TarjetaDB = c.Double(),
                        CestaTickets = c.Double(),
                        Saldo = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Rest.MesasCerradasProductos",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        ProductoID = c.String(maxLength: 40),
                        Codigo = c.String(maxLength: 20),
                        Descripcion = c.String(maxLength: 150),
                        Cantidad = c.Double(),
                        Precio = c.Double(),
                        TasaIva = c.Double(),
                        PrecioConIva = c.Double(),
                        Total = c.Double(),
                        Costo = c.Double(),
                        Departamento = c.String(maxLength: 100),
                        Mesonero = c.String(maxLength: 100),
                        Hora = c.DateTime(),
                        NumeroComanda = c.String(),
                        Anulado = c.Boolean(),
                        LlevaInventario = c.Boolean(nullable: false),
                        NumeroLote = c.Int(),
                        MesasCerrada_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Rest.MesasCerradas", t => t.MesasCerrada_ID, cascadeDelete: true)
                .Index(t => t.MesasCerrada_ID);
            
            CreateTable(
                "Rest.Mesoneros",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Cedula = c.String(nullable: false, maxLength: 10),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Codigo = c.String(maxLength: 20),
                        Puntos = c.Double(),
                        Activo = c.Boolean(),
                        Direccion = c.String(maxLength: 150),
                        Telefonos = c.String(maxLength: 40),
                        Cargo = c.String(maxLength: 40),
                        PuedeDarCreditos = c.Boolean(),
                        PuedeCambiarMesa = c.Boolean(),
                        AnularPlatos = c.Boolean(),
                        PuedeRegistrarPago = c.Boolean(),
                        PuedeDarConsumoInterno = c.Boolean(),
                        PuedePedirCorteDeCuenta = c.Boolean(),
                        PuedeSepararCuentas = c.Boolean(),
                        PuedeDividirCuentas = c.Boolean(),
                        PuedeCambiarPrecios = c.Boolean(),
                        PuedeLiberarMesa = c.Boolean(),
                        PuedeAnularMesa = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Sist.Parametros",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        EmpresaRif = c.String(maxLength: 10),
                        Empresa = c.String(maxLength: 150),
                        EmpresaDireccion = c.String(maxLength: 150),
                        EmpresaTelefonos = c.String(maxLength: 40),
                        TasaIva = c.Double(),
                        TipoIva = c.String(maxLength: 40),
                        Ciudad = c.String(maxLength: 40),
                        Licencia = c.String(maxLength: 100),
                        TasaIvaB = c.Double(),
                        TasaIvaC = c.Double(),
                        PorcentajeRetencion = c.Double(),
                        PeriodoFiscal = c.String(maxLength: 40),
                        NotaCorteCuenta1 = c.String(maxLength: 100),
                        NotaCorteCuenta2 = c.String(maxLength: 100),
                        NotaCorteCuenta3 = c.String(maxLength: 100),
                        NotaCorteCuenta4 = c.String(maxLength: 100),
                        NotaPieFactura = c.String(maxLength: 100),
                        NotaPieFactura2 = c.String(maxLength: 100),
                        NotaPieFactura3 = c.String(maxLength: 100),
                        NotaPieCotizacion = c.String(maxLength: 100),
                        NotaPieCotizacion2 = c.String(maxLength: 100),
                        NotaPieCotizacion3 = c.String(maxLength: 100),
                        NotaPieNotaEntrega = c.String(maxLength: 100),
                        NotaPieNotaEntrega2 = c.String(maxLength: 100),
                        NotaPieNotaEntrega3 = c.String(maxLength: 100),
                        Utilidad = c.Double(),
                        Utilidad2 = c.Double(),
                        Utilidad3 = c.Double(),
                        Utilidad4 = c.Double(),
                        CalculoPrecios = c.String(maxLength: 20),
                        CantidadPrecios = c.Int(),
                        TipoCliente = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Adm.Productos",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Codigo = c.String(nullable: false, maxLength: 40),
                        CodigoProveedor = c.String(maxLength: 40),
                        CodigoBarras = c.String(maxLength: 40),
                        Departamento = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(nullable: false, maxLength: 150),
                        UnidadMedida = c.String(maxLength: 40),
                        Costo = c.Double(),
                        Precio = c.Double(),
                        TasaIva = c.Double(),
                        Raciones = c.Double(),
                        Existencia = c.Double(),
                        ImpresionComanda = c.String(maxLength: 40),
                        LlevaInventario = c.Boolean(),
                        HabilitadoParaCompras = c.Boolean(),
                        HabilitadoParaVentas = c.Boolean(),
                        Activo = c.Boolean(),
                        ActivoRP = c.Boolean(),
                        Litros = c.Double(),
                        GradoAlcoholico = c.Double(),
                        Importado = c.Boolean(),
                        UsaContornos = c.Boolean(),
                        EsContorno = c.Boolean(),
                        PrecioConIva = c.Double(),
                        Precio2 = c.Double(),
                        PrecioConIva2 = c.Double(),
                        Minimo = c.Double(),
                        EsCompuesto = c.Boolean(),
                        UnidadesxEmpaque = c.Double(),
                        FechaPrecio = c.DateTime(),
                        LlevaTermino = c.Boolean(),
                        UltimoAjuste = c.Double(),
                        ExistenciaAnterior = c.Double(),
                        Precio3 = c.Double(),
                        PrecioConIva3 = c.Double(),
                        Precio4 = c.Double(),
                        PrecioConIva4 = c.Double(),
                        UltimoProveedor = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Adm.ProductosCompuestos",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        InsumoID = c.String(maxLength: 40),
                        Codigo = c.String(maxLength: 40),
                        Descripcion = c.String(maxLength: 150),
                        Cantidad = c.Double(),
                        Costo = c.Double(),
                        TotalCosto = c.Double(),
                        Departamento = c.String(),
                        Plato = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Producto_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Adm.Productos", t => t.Producto_ID, cascadeDelete: true)
                .Index(t => t.Producto_ID);
            
            CreateTable(
                "Sist.Usuarios",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Cedula = c.String(maxLength: 10),
                        Nombre = c.String(maxLength: 150),
                        TipoUsuario = c.String(maxLength: 40),
                        Clave = c.String(maxLength: 20),
                        PuedeDarConsumoInterno = c.Boolean(),
                        PuedeSepararCuentas = c.Boolean(),
                        PuedePedirCorteDeCuenta = c.Boolean(),
                        PuedeRegistrarPago = c.Boolean(),
                        PuedeCambiarMesa = c.Boolean(),
                        PuedeDarCreditos = c.Boolean(),
                        ReporteX = c.Boolean(),
                        ReporteZ = c.Boolean(),
                        Vale = c.Boolean(),
                        CierreDeCaja = c.Boolean(),
                        ContarDinero = c.Boolean(),
                        Activo = c.Boolean(),
                        PuedeDividirCuentas = c.Boolean(),
                        GenerarNotaCredito = c.Boolean(),
                        PuedeCambiarVendedor = c.Boolean(),
                        PuedeCambiarPrecios = c.Boolean(),
                        PuedeModificarDescripcion = c.Boolean(),
                        PuedeModificarProveedores = c.Boolean(),
                        PuedeLiberarMesa = c.Boolean(),
                        PuedeAnularMesa = c.Boolean(),
                        AccesoMenu = c.Boolean(),
                        disabled = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Adm.Vales",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Fecha = c.DateTime(),
                        IdCajero = c.String(maxLength: 40),
                        Concepto = c.String(maxLength: 150),
                        Monto = c.Double(),
                        Cajero = c.String(maxLength: 150),
                        Numero = c.String(maxLength: 20),
                        Cedula = c.String(maxLength: 10),
                        Nombre = c.String(maxLength: 150),
                        NumeroLote = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Adm.Vendedores",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Codigo = c.String(maxLength: 40),
                        CedulaRif = c.String(nullable: false, maxLength: 10),
                        Nombre = c.String(nullable: false, maxLength: 150),
                        Direccion = c.String(maxLength: 150),
                        Telefonos = c.String(maxLength: 40),
                        Email = c.String(maxLength: 40),
                        Activo = c.Boolean(),
                        ComisionesPendientes = c.Double(),
                        PorcentajeComision = c.Double(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Adm.Tags",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        ReferenceID = c.String(maxLength: 40),
                        Descripcion = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Adm.ProductosCompuestos", "Producto_ID", "Adm.Productos");
            DropForeignKey("Rest.MesasCerradasProductos", "MesasCerrada_ID", "Rest.MesasCerradas");
            DropForeignKey("Rest.MesasAbiertasProductos", "MesasAbierta_ID", "Rest.MesasAbiertas");
            DropForeignKey("Adm.Documentos", "Tercero_ID", "Adm.Terceros");
            DropForeignKey("Adm.TercerosMovimientos", "Tercero_ID", "Adm.Terceros");
            DropForeignKey("Adm.Pagos", "Documento_ID", "Adm.Documentos");
            DropForeignKey("Adm.DocumentoProductos", "Documento_ID", "Adm.Documentos");
            DropForeignKey("Adm.BancosMovimientos", "Banco_ID", "Adm.Bancos");
            DropIndex("Adm.ProductosCompuestos", new[] { "Producto_ID" });
            DropIndex("Rest.MesasCerradasProductos", new[] { "MesasCerrada_ID" });
            DropIndex("Rest.MesasAbiertasProductos", new[] { "MesasAbierta_ID" });
            DropIndex("Adm.TercerosMovimientos", new[] { "Tercero_ID" });
            DropIndex("Adm.Pagos", new[] { "Documento_ID" });
            DropIndex("Adm.DocumentoProductos", new[] { "Documento_ID" });
            DropIndex("Adm.Documentos", new[] { "Tercero_ID" });
            DropIndex("Adm.BancosMovimientos", new[] { "Banco_ID" });
            DropTable("Adm.Tags");
            DropTable("Adm.Vendedores");
            DropTable("Adm.Vales");
            DropTable("Sist.Usuarios");
            DropTable("Adm.ProductosCompuestos");
            DropTable("Adm.Productos");
            DropTable("Sist.Parametros");
            DropTable("Rest.Mesoneros");
            DropTable("Rest.MesasCerradasProductos");
            DropTable("Rest.MesasCerradas");
            DropTable("Rest.MesasAbiertasProductos");
            DropTable("Rest.MesasAbiertas");
            DropTable("Rest.Mesas");
            DropTable("Adm.MaestroDeCuentas");
            DropTable("Adm.LibroVentas");
            DropTable("Adm.LibroInventarios");
            DropTable("Adm.LibroCompras");
            DropTable("Rest.Eventos");
            DropTable("Adm.TercerosMovimientos");
            DropTable("Adm.Terceros");
            DropTable("Adm.Pagos");
            DropTable("Adm.DocumentoProductos");
            DropTable("Adm.Documentos");
            DropTable("Sist.Contadores");
            DropTable("Adm.CierreCajas");
            DropTable("Adm.AsientosCajaChicas");
            DropTable("Adm.BancosMovimientos");
            DropTable("Adm.Bancos");
        }
    }
}
