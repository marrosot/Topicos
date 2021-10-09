using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCore.Convertidor.Logica.Interfaz;

namespace NetCore.Convertidor.Logica.Servicio
{
    class ConvertidorDeMonedas : InterfazMoneda
    {
        private string NombreMonedaX;
        private string NombreMonedaY;
        private double FactorConversion;

        public ConvertidorDeMonedas(string monedaX, string monedaY, double factConversion)
        {
            NombreMonedaX = monedaX;
            NombreMonedaY = monedaY;
            FactorConversion = factConversion;
        }

        public void DeMonedaXAMonedaY(double monedaX)
        {
            double valorMonedaY = monedaX * FactorConversion;
            System.Console.WriteLine($"{monedaX} {NombreMonedaX} equivalen a {valorMonedaY} {NombreMonedaY}.");
        }

        public void DeMonedaYAMonedaX(double monedaY)
        {
            double valorMonedaX = monedaY / FactorConversion;
            System.Console.WriteLine($"{monedaY} {NombreMonedaY} equivalen a {valorMonedaX} {NombreMonedaX}.");
        }
    }
}
