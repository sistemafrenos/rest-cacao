using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public partial class UOW 
    {
        private RestaurantConfig restaurantConfig;
        private GenericRepository<Mesa> mesaRepository;
        private GenericRepository<Mesonero> mesoneroRepository; 
        private GenericRepository<MesasAbierta> mesaAbiertaRepository;
        private GenericRepository<MesasAbiertasProducto> mesaAbiertaProductoRepository; 
        private GenericRepository<MesasCerrada> mesaCerradaRepository;
        private GenericRepository<MesasCerradasProducto> mesaCerradaProductoRepository;
        private GenericRepository<Producto> platosRepository;
        private GenericRepository<ProductosCompuesto> platosInsumosRepository;
        public RestaurantConfig RestaurantConfig
        {
            get
            {
                if (restaurantConfig == null)
                {
                   restaurantConfig= new BussinessLogic.RestaurantConfig();
                }
                return restaurantConfig;
            }
        }
        public GenericRepository<Producto> PlatosRepository
        {
            get
            {
                if (platosRepository == null)
                {
                    platosRepository = new GenericRepository<Producto>(context);
                }
                return platosRepository;
            }
        }
        public GenericRepository<ProductosCompuesto> PlatosInsumosRepository
        {
            get
            {
                if (platosInsumosRepository == null)
                {
                    platosInsumosRepository = new GenericRepository<ProductosCompuesto>(context);
                }
                return platosInsumosRepository;
            }
        }
        public GenericRepository<Mesa> MesaRepository
        {
            get
            {
                if (mesaRepository == null)
                {
                    mesaRepository = new GenericRepository<Mesa>(context);
                }
                return mesaRepository;
            }
        }
        public GenericRepository<Mesonero> MesoneroRepository
        {
            get
            {
                if (mesoneroRepository == null)
                {
                    mesoneroRepository = new GenericRepository<Mesonero>(context);
                }
                return mesoneroRepository;
            }
        }
        public GenericRepository<MesasAbierta> MesaAbiertaRepository
        {
            get
            {
                if (mesaAbiertaRepository == null)
                {
                    mesaAbiertaRepository = new GenericRepository<MesasAbierta>(context);
                }
                return mesaAbiertaRepository;
            }
        }
        public GenericRepository<MesasAbiertasProducto> MesaAbiertaProductoRepository
        {
            get
            {
                if (mesaAbiertaProductoRepository == null)
                {
                    mesaAbiertaProductoRepository = new GenericRepository<MesasAbiertasProducto>(context);
                }
                return mesaAbiertaProductoRepository;
            }
        }
        public GenericRepository<MesasCerrada> MesaCerradaRepository
        {
            get
            {
                if (mesaCerradaRepository == null)
                {
                    mesaCerradaRepository = new GenericRepository<MesasCerrada>(context);
                }
                return mesaCerradaRepository;
            }
        }
        public GenericRepository<MesasCerradasProducto> MesaCerradaProductoRepository
        {
            get
            {
                if (mesaCerradaProductoRepository == null)
                {
                    mesaCerradaProductoRepository = new GenericRepository<MesasCerradasProducto>(context);
                }
                return mesaCerradaProductoRepository;
            }
        }
    }
}
