using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Convertidor.Logica.Interfaz
{
    public interface InterfazMoneda
    {
        public void DeMonedaXAMonedaY(double monedaX);

        public void DeMonedaYAMonedaX(double monedaY);
    }
}
