using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK
{
    public class AgendaConfiguration : EntityTypeConfiguration<Agenda>
    {
        public AgendaConfiguration()
            : base()
        {

            HasKey(p => p.IdAgenda);
            Property(p => p.IdAgenda).
                HasColumnName("IdAgenda").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Agendas");
        }
    }
    public class BancoConfiguration : EntityTypeConfiguration<Banco>
    {
        public BancoConfiguration()
            : base()
        {

            HasKey(p => p.IdBanco);
            Property(p => p.IdBanco).
                HasColumnName("IdBanco").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Bancos");
        }
    }
    public class AuxiliarBancoConfiguration : EntityTypeConfiguration<AuxiliarBanco>
    {
        public AuxiliarBancoConfiguration()
            : base()
        {

            HasKey(p => p.IdAuxiliarBanco);
            Property(p => p.IdAuxiliarBanco).
                HasColumnName("IdAuxiliarBanco").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("AuxiliarBancos");
        }
    }
    public class BancosDepositosDetalleConfiguration : EntityTypeConfiguration<BancosDepositosDetalle>
    {
        public BancosDepositosDetalleConfiguration()
            : base()
        {

            HasKey(p => p.IdBancosDepositosDetalles);
            Property(p => p.IdBancosDepositosDetalles).
                HasColumnName("IdBancosDepositosDetalles").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("BancosDepositosDetalles");
        }
    }
    public class BancosMovimientoConfiguration : EntityTypeConfiguration<BancosMovimiento>
    {
        public BancosMovimientoConfiguration()
            : base()
        {

            HasKey(p => p.IdMovimientoBanco);
            Property(p => p.IdMovimientoBanco).
                HasColumnName("IdBancosDepositosDetalles").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("BancosMovimientos");
        }
    }
    public class CajaCierreConfiguration : EntityTypeConfiguration<CajaCierre>
    {
        public CajaCierreConfiguration()
            : base()
        {

            HasKey(p => p.IdCorteCaja);
            Property(p => p.IdCorteCaja).
                HasColumnName("IdCorteCaja").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("CajaCierres");
        }
    }
    public class CajasConfiguration : EntityTypeConfiguration<Caja>
    {
        public CajasConfiguration()
            : base()
        {

            HasKey(p => p.IdMovimientoCaja);
            Property(p => p.IdMovimientoCaja).
                HasColumnName("IdMovimientoCaja").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Cajas");
        }
    }
    public class CajasChicaConfiguration : EntityTypeConfiguration<CajasChica>
    {
        public CajasChicaConfiguration()
            : base()
        {

            HasKey(p => p.IdCajaChica);
            Property(p => p.IdCajaChica).
                HasColumnName("IdCajaChica").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("CajasChicas");
        }
    }
    public class ClientesConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClientesConfiguration()
            : base()
        {

            HasKey(p => p.IdCliente);
            Property(p => p.IdCliente).
                HasColumnName("IdCliente").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Clientes");
        }
    }
    public class ClientesMovimientosConfiguration : EntityTypeConfiguration<ClientesMovimiento>
    {
        public ClientesMovimientosConfiguration()
            : base()
        {

            HasKey(p => p.IdClienteMovimiento);
            Property(p => p.IdClienteMovimiento).
                HasColumnName("IdClienteMovimiento").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("ClientesMovimientos");
        }
    }
    public class ComprasConfiguration : EntityTypeConfiguration<Compra>
    {
        public ComprasConfiguration()
            : base()
        {

            HasKey(p => p.IdCompra);
            Property(p => p.IdCompra).
                HasColumnName("IdCompra").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Compras");
        }
    }
    public class ComprasProductosConfiguration : EntityTypeConfiguration<ComprasProducto>
    {
        public ComprasProductosConfiguration()
            : base()
        {

            HasKey(p => p.IdCompraProducto);
            Property(p => p.IdCompraProducto).
                HasColumnName("IdCompraProducto").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("ComprasProductos");
        }
    }
    public class ContadoresConfiguration : EntityTypeConfiguration<Contador>
    {
        public ContadoresConfiguration()
            : base()
        {

            HasKey(p => p.Variable);
            Property(p => p.Variable).
                HasColumnName("Variable").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Contadores");
        }
    }
    public class CotizacionesConfiguration : EntityTypeConfiguration<Cotizacion>
    {
        public CotizacionesConfiguration()
            : base()
        {

            HasKey(p => p.IdCotizacion);
            Property(p => p.IdCotizacion).
                HasColumnName("IdCotizacion").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Cotizaciones");
        }
    }
    public class CotizacionesProductosConfiguration : EntityTypeConfiguration<CotizacionesProducto>
    {
        public CotizacionesProductosConfiguration()
            : base()
        {

            HasKey(p => p.IdCotizacionProductos);
            Property(p => p.IdCotizacionProductos).
                HasColumnName("IdCotizacionProductos").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("CotizacionesProductos");
        }
    }
    public class DepartamentosConfiguration : EntityTypeConfiguration<Departamento>
    {
        public DepartamentosConfiguration()
            : base()
        {

            HasKey(p => p.IdDepartamento);
            Property(p => p.IdDepartamento).
                HasColumnName("IdDepartamento").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Departamentos");
        }
    }
    public class DepositosConfiguration : EntityTypeConfiguration<Deposito>
    {
        public DepositosConfiguration()
            : base()
        {

            HasKey(p => p.IdDeposito);
            Property(p => p.IdDeposito).
                HasColumnName("IdDeposito").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Depositos");
        }
    }
    public class DepositosExistenciasConfiguration : EntityTypeConfiguration<DepositosExistencia>
    {
        public DepositosExistenciasConfiguration()
            : base()
        {

            HasKey(p => p.IdDepositoExistencia);
            Property(p => p.IdDepositoExistencia).
                HasColumnName("IdDepositoExistencia").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("DepositosExistencias");
        }
    }
    public class EventosConfiguration : EntityTypeConfiguration<Evento>
    {
        public EventosConfiguration()
            : base()
        {

            HasKey(p => p.IdEvento);
            Property(p => p.IdEvento).
                HasColumnName("IdEvento").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Eventos");
        }
    }
    public class FacturasConfiguration : EntityTypeConfiguration<Factura>
    {
        public FacturasConfiguration()
            : base()
        {

            HasKey(p => p.IdFactura);
            Property(p => p.IdFactura).
                HasColumnName("IdFactura").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Factura");
        }
    }
    public class FacturasProductosConfiguration : EntityTypeConfiguration<FacturasProducto>
    {
        public FacturasProductosConfiguration()
            : base()
        {

            HasKey(p => p.IdFacturaProducto);
            Property(p => p.IdFacturaProducto).
                HasColumnName("IdFacturaProducto").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("FacturasProducto");
        }
    }
    public class LibroVentasConfiguration : EntityTypeConfiguration<LibroVenta>
    {
        public LibroVentasConfiguration()
            : base()
        {

            HasKey(p => p.IdLibroVentas);
            Property(p => p.IdLibroVentas).
                HasColumnName("IdLibroVentas").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("LibroVentas");
        }
    }
    public class LibroInventariosConfiguration : EntityTypeConfiguration<LibroInventario>
    {
        public LibroInventariosConfiguration()
            : base()
        {

            HasKey(p => p.IdLibroInventarios);
            Property(p => p.IdLibroInventarios).
                HasColumnName("IdLibroInventarios").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("LibroInventarios");
        }
    }
    public class MaestroDeCuentasConfiguration : EntityTypeConfiguration<MaestroDeCuenta>
    {
        public MaestroDeCuentasConfiguration()
            : base()
        {

            HasKey(p => p.IdMaestroDeCuenta);
            Property(p => p.IdMaestroDeCuenta).
                HasColumnName("IdMaestroDeCuenta").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("MaestroDeCuentas");
        }
    }
    public class MesasConfiguration : EntityTypeConfiguration<Mesa>
    {
        public MesasConfiguration()
            : base()
        {

            HasKey(p => p.IdMesa);
            Property(p => p.IdMesa).
                HasColumnName("IdMesa").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Mesas");
        }
    }
    public class MesasAbiertasConfiguration : EntityTypeConfiguration<MesasAbierta>
    {
        public MesasAbiertasConfiguration()
            : base()
        {

            HasKey(p => p.IdMesaAbierta);
            Property(p => p.IdMesaAbierta).
                HasColumnName("IdMesaAbierta").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("MesasAbiertas");
        }
    }
    public class MesasAbiertasProductosConfiguration : EntityTypeConfiguration<MesasAbiertasProducto>
    {
        public MesasAbiertasProductosConfiguration()
            : base()
        {

            HasKey(p => p.IdMesaAbiertaProducto);
            Property(p => p.IdMesaAbiertaProducto).
                HasColumnName("IdMesaAbiertaProducto").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("MesasAbiertasProductos");
        }
    }
    public class MesasAbiertasProductosAnuladosConfiguration : EntityTypeConfiguration<MesasAbiertasProductosAnulado>
    {
        public MesasAbiertasProductosAnuladosConfiguration()
            : base()
        {

            HasKey(p => p.IdProductoEliminado);
            Property(p => p.IdProductoEliminado).
                HasColumnName("IdProductoEliminado").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("MesasAbiertasProductosAnulados");
        }
    }
    public class MesasCerradasConfiguration : EntityTypeConfiguration<MesasCerrada>
    {
        public MesasCerradasConfiguration()
            : base()
        {

            HasKey(p => p.IdMesaCerrada);
            Property(p => p.IdMesaCerrada).
                HasColumnName("IdMesaCerrada").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("MesasCerradas");
        }
    }
    public class MesasCerradasProductosConfiguration : EntityTypeConfiguration<MesasCerradasProducto>
    {
        public MesasCerradasProductosConfiguration()
            : base()
        {

            HasKey(p => p.IdMesaCerradaProducto);
            Property(p => p.IdMesaCerradaProducto).
                HasColumnName("IdMesaCerradaProducto").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("MesasCerradasProductos");
        }
    }
    public class MesonerosConfiguration : EntityTypeConfiguration<Mesonero>
    {
        public MesonerosConfiguration()
            : base()
        {

            HasKey(p => p.IdMesonero);
            Property(p => p.IdMesonero).
                HasColumnName("IdMesonero").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Mesoneros");
        }
    }
    public class NotasEntregasConfiguration : EntityTypeConfiguration<NotasEntrega>
    {
        public NotasEntregasConfiguration()
            : base()
        {

            HasKey(p => p.IdNotaEntrega);
            Property(p => p.IdNotaEntrega).
                HasColumnName("IdNotaEntrega").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("NotasEntregas");
        }
    }
    public class NotasEntregasProductosConfiguration : EntityTypeConfiguration<NotasEntregasProducto>
    {
        public NotasEntregasProductosConfiguration()
            : base()
        {

            HasKey(p => p.IdNotasEntregasProducto);
            Property(p => p.IdNotasEntregasProducto).
                HasColumnName("IdNotasEntregasProducto").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("NotasEntregasProductos");
        }
    }
    public class PedidosConfiguration : EntityTypeConfiguration<Pedido>
    {
        public PedidosConfiguration()
            : base()
        {

            HasKey(p => p.IdPedido);
            Property(p => p.IdPedido).
                HasColumnName("IdPedido").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Pedidos");
        }
    }
    public class PedidosProductosConfiguration : EntityTypeConfiguration<PedidosProducto>
    {
        public PedidosProductosConfiguration()
            : base()
        {

            HasKey(p => p.IdPedidoProducto);
            Property(p => p.IdPedidoProducto).
                HasColumnName("IdPedidoProducto").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("PedidosProductos");
        }
    }
    public class ProductosConfiguration : EntityTypeConfiguration<Producto>
    {
        public ProductosConfiguration()
            : base()
        {

            HasKey(p => p.IdProducto);
            Property(p => p.IdProducto).
                HasColumnName("IdProducto").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            //Ignore(x => x.Utilidad);
            //Ignore(x => x.Utilidad2);
            //Ignore(x => x.Coeficiente);
            //Ignore(x => x.CostoTotal);
            //Ignore(x => x.Cantidad);
            ToTable("Productos");
        }
    }
    public class ProductosCompuestosConfiguration : EntityTypeConfiguration<ProductosCompuesto>
    {
        public ProductosCompuestosConfiguration()
            : base()
        {

            HasKey(p => p.IdProductoCompuesto);
            Property(p => p.IdProductoCompuesto).
                HasColumnName("IdProductoCompuesto").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("ProductosCompuestos");
        }
    }
    public class ProductosInventariosConfiguration : EntityTypeConfiguration<ProductosInventario>
    {
        public ProductosInventariosConfiguration()
            : base()
        {

            HasKey(p => p.IdProductoInventario);
            Property(p => p.IdProductoInventario).
                HasColumnName("IdProductoInventario").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("ProductosInventarios");
        }
    }
    public class ProductosMovimientosConfiguration : EntityTypeConfiguration<ProductosMovimiento>
    {
        public ProductosMovimientosConfiguration()
            : base()
        {

            HasKey(p => p.IdProductoMovimiento);
            Property(p => p.IdProductoMovimiento).
                HasColumnName("IdProductoMovimiento").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("ProductosMovimientos");
        }
    }
    public class ProveedoresConfiguration : EntityTypeConfiguration<Proveedor>
    {
        public ProveedoresConfiguration()
            : base()
        {

            HasKey(p => p.IdProveedor);
            Property(p => p.IdProveedor).
                HasColumnName("IdProveedor").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Proveedores");
        }
    }
    public class ProveedoresMovimientosConfiguration : EntityTypeConfiguration<ProveedoresMovimiento>
    {
        public ProveedoresMovimientosConfiguration()
            : base()
        {

            HasKey(p => p.IdProveedorMovimiento);
            Property(p => p.IdProveedorMovimiento).
                HasColumnName("IdProveedorMovimiento").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("ProveedoresMovimientos");
        }
    }
    public class RetencionesConfiguration : EntityTypeConfiguration<Retencion>
    {
        public RetencionesConfiguration()
            : base()
        {

            HasKey(p => p.Id);
            Property(p => p.Id).
                HasColumnName("Id").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Retenciones");
        }
    }
    public class RetencionesISLRsConfiguration : EntityTypeConfiguration<RetencionesISLR>
    {
        public RetencionesISLRsConfiguration()
            : base()
        {

            HasKey(p => p.IdRetencionISLR);
            Property(p => p.IdRetencionISLR).
                HasColumnName("IdRetencionISLR").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("RetencionesISLRs");
        }
    }
    public class SugerenciasConfiguration : EntityTypeConfiguration<Sugerencia>
    {
        public SugerenciasConfiguration()
            : base()
        {

            HasKey(p => p.IdPlatoDelDia);
            Property(p => p.IdPlatoDelDia).
                HasColumnName("IdPlatoDelDia").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Sugerencias");
        }
    }
    public class TrasladosConfiguration : EntityTypeConfiguration<Traslado>
    {
        public TrasladosConfiguration()
            : base()
        {

            HasKey(p => p.IdTraslado);
            Property(p => p.IdTraslado).
                HasColumnName("IdTraslado").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Traslados");
        }
    }
    public class TrasladosProductosConfiguration : EntityTypeConfiguration<TrasladosProducto>
    {
        public TrasladosProductosConfiguration()
            : base()
        {

            HasKey(p => p.IdTrasladoDetalle);
            Property(p => p.IdTrasladoDetalle).
                HasColumnName("IdTrasladoDetalle").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("TrasladosProductos");
        }
    }
    public class ValesConfiguration : EntityTypeConfiguration<Vale>
    {
        public ValesConfiguration()
            : base()
        {

            HasKey(p => p.IdVale);
            Property(p => p.IdVale).
                HasColumnName("IdVale").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Vales");
        }
    }
    public class VendedoresConfiguration : EntityTypeConfiguration<Vendedor>
    {
        public VendedoresConfiguration()
            : base()
        {

            HasKey(p => p.IdVendedor);
            Property(p => p.IdVendedor).
                HasColumnName("IdVendedor").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Vendedores");
        }
    }
    public class VendedoresMovimientosConfiguration : EntityTypeConfiguration<VendedoresMovimiento>
    {
        public VendedoresMovimientosConfiguration()
            : base()
        {

            HasKey(p => p.IdVendedorMovimiento);
            Property(p => p.IdVendedorMovimiento).
                HasColumnName("IdVendedorMovimiento").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("VendedoresMovimiento");
        }
    }
    public class ParametrosConfiguration : EntityTypeConfiguration<Parametro>
    {

        public ParametrosConfiguration()
            : base()
        {

            HasKey(p => p.EmpresaRif);
            Property(p => p.EmpresaRif).
                HasColumnName("EmpresaRif").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Parametros");
        }
    }
    public class UsuariosConfiguration : EntityTypeConfiguration<Usuario>
    {

        public UsuariosConfiguration()
            : base()
        {

            HasKey(p => p.IdUsuario);
            Property(p => p.IdUsuario).
                HasColumnName("IdUsuario").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).
                IsRequired();
            ToTable("Usuarios");
        }
    }

}
