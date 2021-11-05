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
    }
    
}
