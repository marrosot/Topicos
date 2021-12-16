using NetCore.Mensajeria.BL;
using System;
using System.Collections.Generic;


namespace NetCore.ConsoleApp
{
    public class LogicaPrincipal
    {
        public void HagaLaMagiaOld()
        {
            Console.WriteLine("Hello World!");
        }

        public void HagaLaMagiaOldV2()
        {
            var elMensaje = new Mensaje("Yo", "Usted", "Hello Word!");
            var elServicio = new MensajeriaPlana();
            elServicio.Enviar(elMensaje);
        }

        public void HagaLaMagia()
        {
            ConsultaPorNombreAproximado();
            ConsultaPorPaisAproximado();
        }

        public void HagaLaMagiaProyecto1()
        {
            ConsultaPorNombreAproximado();
            ConsultaPorPaisAproximado();
        }

        private void ConsultaPorNombreAproximado()
        {
            var elNombreAproximado = "as";
            var elServicio = new Topicos.NetCore.NorthWind.BL.Logica.AccesoBD.Customer();
            var elResultado = elServicio.BuscarPorNombreAproximado(elNombreAproximado);
            ImprimirCustomers(elResultado);
        }

        private void ConsultaPorPaisAproximado()
        {
            var elStateProvinceAproximado = "que";
            var elServicio = new Topicos.NetCore.NorthWind.BL.Logica.AccesoBD.Customer();
            var elResultado = elServicio.BuscarPorNombreAproximadoDelStateProvince(elStateProvinceAproximado);
            ImprimirCustomers(elResultado);
        }


        private void ConsultaProductosDescontiniadosPorPrecio()
        {
            var elRango1 = 200;
            var elRango2 = 300;
            var elServicio = new Topicos.NetCore.NorthWind.BL.Logica.AccesoBD.Product();
            var elResultado = elServicio.BuscarProductosDescontinuados(elRango1, elRango2);
            ImprimirProductos(elResultado);
        }

        private void ConsultaOrdenesPorNombreAproximadoDeCliente()
        {
            var elNombreAproximado = "Jhon";
            var elServicio = new Topicos.NetCore.NorthWind.BL.Logica.AccesoBD.SalesOrderHeader();
            var elResultado = elServicio.BuscarOrdenesPorNombreAproximadoDeCliente(elNombreAproximado);
            ImprimirOrdenes(elResultado);
        }

        private void ConsultaBuscarProductosPorIntervaloDeFechas()
        {
            var elNombreAproximado = "Oil";
            var elIntervalo1 = 3 - 3 - 2002;
            var elIntervalo2 = 6 - 6 - 2002;

            var elServicio = new Topicos.NetCore.NorthWind.BL.Logica.AccesoBD.SalesOrderHeader();
            var elResultado = elServicio.BuscarProductosPorIntervaloDeFechas(elNombreAproximado,elIntervalo1,elIntervalo2);
            ImprimirProductos(elResultado);
        }


        private void ImprimirCustomers(IList<Topicos.NetCore.NorthWind.Model.MyModels.Customer> elResultado)
        {
            if (elResultado == null)
            {
                System.Console.WriteLine("Lista sin elementos");
                return;
            }
            foreach (var customer in elResultado)
            {
                System.Console.WriteLine($"ID: {customer.CustomerId} - Nombre Completo: {customer.FullName} - Telefono: {customer.Phone}");
                System.Console.WriteLine("Direcciones:");
                foreach (var direccion in customer.CustomerAddresses)
                {
                    System.Console.WriteLine($"   - Address Line 1: {direccion.Address.AddressLine1} - City: {direccion.Address.City} - State: {direccion.Address.StateProvince} - Country: {direccion.Address.CountryRegion}");
                }
            }
        }


        private void ImprimirProductos(IList<Topicos.NetCore.Proyecto1.MyModels.Product> elResultado)
        {
            if (elResultado == null)
            {
                System.Console.WriteLine("Lista sin elementos");
                return;
            }
            foreach (var product in elResultado)
            {
                System.Console.WriteLine($"ID: {product.ProductId} - Nombre: {product.Name} - Precio: {product.ListPrice}");
               
            }
        }
    }
    
}
