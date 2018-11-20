namespace HK.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<HK.DatosEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        public void MySeed(DatosEntities c)
        {
            this.Seed(c);
        }
        protected override void Seed(HK.DatosEntities context)
        {
            if (context.Parametros.Count() == 0)
            {
                Parametro current = new Parametro()
                {
                    ID = new Guid().ToString(),
                    CalculoPrecios = "SOBRE COSTOS",
                    CantidadPrecios = 2,
                    Ciudad = "CARACAS",
                    Empresa = "EMPRESA DEMO, C.A.",
                    EmpresaDireccion = "CARACAS",
                    EmpresaRif = "J310037221",
                    EmpresaTelefonos = "0412-2173029",
                    Licencia = "Demo",
                    PorcentajeRetencion = 75,
                    TasaIva = 12,
                    TasaIvaB = 8,
                    TipoCliente = "ADMINISTRATIVO",
                    TipoIva = "INCLUIDO",
                    Utilidad = 30,
                    Utilidad2 = 40,
                    Utilidad3 = 20,
                    Utilidad4 = 10,
                    PeriodoFiscal = DateTime.Now.Year.ToString(),
                    NotaPieFactura = "FAVOR EMITIR CHEQUES A NOMBRE DE: EMPRESA DEMO, C.A.",
                    NotaPieFactura2 = "6 MESES DE GARANTIA SOBRE DEFECTOS DE FABRICA",
                    NotaPieFactura3 = DateTime.Today.Year.ToString(),
                    NotaPieCotizacion = "COTIZACION VALIDA POR 7 DIAS"
                };
                context.Parametros.AddOrUpdate(current);
                context.SaveChanges();
            }
        }
    }
}
