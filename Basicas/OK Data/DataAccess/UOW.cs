using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Data.Entity.Core;
using System.Data;

namespace HK.BussinessLogic
{
     public partial class UOW : IDisposable, IUnitOfWork
     {
        public DatosEntities context;
        #region Miembros
        private Parametro systemParameters;
        private FiscalConfig fiscalConfig;
        private PuntoVentaConfig puntoVentaConfig;
        private SistemaConfig sistemaConfig;
        private GenericRepository<Pago> pagoRepository;
        private GenericRepository<Contador> contadorRepository;
        private GenericRepository<Usuario> usuarioRepository;
        private GenericRepository<Tercero> clienteRepository;
        private GenericRepository<Tercero> proveedorRepository;
        private GenericRepository<Producto> productoRepository;
        private GenericRepository<Cotizacion> cotizacionRepository;
        private GenericRepository<Factura> facturaRepository;
        private GenericRepository<NotaDeCredito> notaDeCreditoRepository;
        private GenericRepository<ProductoCarga> cargaRepository;
        private GenericRepository<ProductoDescarga> descargaRepository;
        private GenericRepository<LibroCompra> libroCompraRepository;
        private GenericRepository<LibroInventario> libroInventarioRepository;
        private GenericRepository<LibroVenta> libroVentaRepository;
        private GenericRepository<Compra> compraRepository;
        private GenericRepository<MaestroDeCuenta> maestroDeCuentaRepository;
        private GenericRepository<NotaEntrega> notaEntregaRepository;
        private GenericRepository<Banco> bancoRepository;
        private GenericRepository<Parametro> parametroRepository;
        private GenericRepository<Documento> documentosRepository;
        private GenericRepository<DocumentosProducto> documentoProductosRepository;
        private GenericRepository<TercerosMovimiento> terceroMovimientosRepository;
        private GenericRepository<Vale> valesRepository;
        private GenericRepository<Vendedor> vendedoresRepository;
        private GenericRepository<Tag> tagsRepository;
        private GenericRepository<ProductosCompuesto> productosCompuestosRepository;
        #endregion
        #region Constructor
        public UOW()
        {
            context = new DatosEntities();
            context.Configuration.AutoDetectChangesEnabled = false;
            OK.SystemParameters = SystemParameters;
        }
        #endregion
        #region Properties

        public Parametro SystemParameters
        {
            get
            {
                if (systemParameters == null)
                {
                    systemParameters = ParametroRepository.GetFirst();
                    //if (systemParameters == null)
                    //    systemParameters = SeedParametros();
                }
                return systemParameters;
            }
        }
        
        public FiscalConfig FiscalConfig
        {
            get
            {
                if (fiscalConfig == null)
                {
                    fiscalConfig = new BussinessLogic.FiscalConfig();
                }
                return fiscalConfig;
            }
        }
        public SistemaConfig SistemaConfig
        {
            get
            {
                if (sistemaConfig == null)
                {
                    sistemaConfig = new BussinessLogic.SistemaConfig();
                }
                return sistemaConfig;
            }
        }
        public PuntoVentaConfig PuntoVentaConfig
        {
            get
            {
                if (puntoVentaConfig == null)
                {
                    puntoVentaConfig = new BussinessLogic.PuntoVentaConfig();
                }
                return puntoVentaConfig;
            }
        }
        public GenericRepository<Usuario> UsuarioRepository
        {
            get
            {
                if (this.usuarioRepository == null)
                {
                    this.usuarioRepository = new GenericRepository<Usuario>(context);
                }
                return usuarioRepository;
            }
        }
        public GenericRepository<Banco> BancoRepository
        {
            get
            {
                if (bancoRepository == null)
                {
                    bancoRepository = new GenericRepository<Banco>(context);
                }
                return bancoRepository;
            }
        }
        public GenericRepository<Tercero> ClienteRepository
        {
            get
            {
                if (clienteRepository == null)
                {
                    clienteRepository = new GenericRepository<Tercero>(context);
                }
                return clienteRepository;
            }
        }
        public GenericRepository<Tercero> ProveedorRepository
        {
            get
            {
                if (proveedorRepository == null)
                {
                    proveedorRepository = new GenericRepository<Tercero>(context);
                }
                return proveedorRepository;
            }
        }
        public GenericRepository<Contador> ContadorRepository
        {
            get
            {
                if (contadorRepository == null)
                {
                    contadorRepository = new GenericRepository<Contador>(context);
                }
                return contadorRepository;
            }
        }
        public GenericRepository<Producto> ProductoRepository
        {
            get
            {
                if (productoRepository == null)
                {
                    productoRepository = new GenericRepository<Producto>(context);
                }
                return productoRepository;
            }
        }
        public GenericRepository<Documento> DocumentosRepository
        {
            get
            {
                if (documentosRepository == null)
                {
                    documentosRepository = new GenericRepository<Documento>(context);
                }
                return documentosRepository;
            }
        }
        public GenericRepository<DocumentosProducto> DocumentoProductosRepository
        {
            get
            {
                if (documentoProductosRepository == null)
                {
                    documentoProductosRepository = new GenericRepository<DocumentosProducto>(context);
                }
                return documentoProductosRepository;
            }
        }
        public GenericRepository<Pago> PagoRepository
        {
            get
            {
                if (pagoRepository == null)
                {
                    pagoRepository = new GenericRepository<Pago>(context);
                }
                return pagoRepository;
            }
        }
        public GenericRepository<Cotizacion> CotizacionRepository
        {
            get
            {
                if (cotizacionRepository == null)
                {
                    cotizacionRepository = new GenericRepository<Cotizacion>(context);
                }
                return cotizacionRepository;
            }
        }
        public GenericRepository<Factura> FacturaRepository
        {
            get
            {
                if (facturaRepository == null)
                {
                    facturaRepository = new GenericRepository<Factura>(context);
                }
                return facturaRepository;
            }
        }
        public GenericRepository<NotaDeCredito> NotaCreditoRepository
        {
            get
            {
                if (notaDeCreditoRepository == null)
                {
                    notaDeCreditoRepository = new GenericRepository<NotaDeCredito>(context);
                }
                return notaDeCreditoRepository;
            }
        }
        public GenericRepository<Compra> CompraRepository
        {
            get
            {
                if (compraRepository == null)
                {
                    compraRepository = new GenericRepository<Compra>(context);
                }
                return compraRepository;
            }
        }
        public GenericRepository<ProductoCarga> CargaRepository
        {
            get
            {
                if (cargaRepository == null)
                {
                    cargaRepository = new GenericRepository<ProductoCarga>(context);
                }
                return cargaRepository;
            }
        }
        public GenericRepository<ProductoDescarga> DescargaRepository
        {
            get
            {
                if (descargaRepository == null)
                {
                    descargaRepository = new GenericRepository<ProductoDescarga>(context);
                }
                return descargaRepository;
            }
        }
        public GenericRepository<NotaEntrega> NotaEntregaRepository
        {
            get
            {
                if (notaEntregaRepository == null)
                {
                    notaEntregaRepository = new GenericRepository<NotaEntrega>(context);
                }
                return notaEntregaRepository;
            }
        }
        public GenericRepository<MaestroDeCuenta> MaestroDeCuentaRepository
        {
            get
            {
                if (maestroDeCuentaRepository == null)
                {
                    maestroDeCuentaRepository = new GenericRepository<MaestroDeCuenta>(context);
                }
                return maestroDeCuentaRepository;
            }
        }
        public GenericRepository<LibroCompra> LibroCompraRepository
        {
            get
            {
                if (libroCompraRepository == null)
                {
                    libroCompraRepository = new GenericRepository<LibroCompra>(context);
                }
                return libroCompraRepository;
            }
        }
        public GenericRepository<LibroInventario> LibroInventarioRepository
        {
            get
            {
                if (libroInventarioRepository == null)
                {
                    libroInventarioRepository = new GenericRepository<LibroInventario>(context);
                }
                return libroInventarioRepository;
            }
        }
        public GenericRepository<LibroVenta> LibroVentaRepository
        {
            get
            {
                if (libroVentaRepository == null)
                {
                    libroVentaRepository = new GenericRepository<LibroVenta>(context);
                }
                return libroVentaRepository;
            }
        }
        public GenericRepository<Parametro> ParametroRepository
        {
            get
            {
                if (parametroRepository == null)
                {
                    parametroRepository = new GenericRepository<Parametro>(context);
                }
                return parametroRepository;
            }
        }
        public GenericRepository<TercerosMovimiento> TerceroMovimientosRepository
        {
            get
            {
                if (terceroMovimientosRepository == null)
                {
                    terceroMovimientosRepository = new GenericRepository<TercerosMovimiento>(context);
                }
                return terceroMovimientosRepository;
            }
        }
        public GenericRepository<Vale> ValesRepository
        {
            get
            {
                if (valesRepository == null)
                {
                    valesRepository = new GenericRepository<Vale>(context);
                }
                return valesRepository;
            }
        }
        public GenericRepository<Vendedor> VendedoresRepository
        {
            get
            {
                if (vendedoresRepository == null)
                {
                    vendedoresRepository = new GenericRepository<Vendedor>(context);
                }
                return vendedoresRepository;
            }
        }
        public GenericRepository<Tag> TagsRepository
        {
            get
            {
                if (tagsRepository == null)
                {
                    tagsRepository = new GenericRepository<Tag>(context);
                }
                return tagsRepository;
            }
        }
        public GenericRepository<ProductosCompuesto> ProductoCompuestoRepository
        {
            get
            {
                if (productosCompuestosRepository == null)
                {
                    productosCompuestosRepository = new GenericRepository<ProductosCompuesto>(context);
                }
                return productosCompuestosRepository;
            }
        }
        #endregion
        #region Metodos
        public DatosEntities GetContext()
        {
            return this.context;
        }
        public string Save()
        {
            int registros = 0;
            try
            {
                registros = context.SaveChanges();
            }
            catch (EntityException xx)
            {
                return OK.ManejarException(xx);
            }

            catch (DataException xx)
            {
                return OK.ManejarException(xx);
            }
            catch (Exception x)
            {
                return OK.ManejarException(x);
            }
            return null;
        }
        public void Dispose()
        {
          //  throw new NotImplementedException();
        }
        // Validar Entidades
        public bool IsValid<T>(T item) where T:Entity
        {
            item.ValidationResult = context.Entry(item).GetValidationResult();
            return item.ValidationResult.IsValid;
        }
        public void DeAttach(object item)
        {
            context.Entry(item).State = EntityState.Detached;
        }
        public string ValidationErrors<T>(T item) where T: Entity
        {
            if (item.ValidationResult.IsValid)
                return null;
            return OK.ErroresToString(item.ValidationResult.ValidationErrors.ToArray());
        }
        #endregion
     }
}
