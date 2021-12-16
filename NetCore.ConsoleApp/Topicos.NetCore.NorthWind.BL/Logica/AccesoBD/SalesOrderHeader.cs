using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.NetCore.NorthWind.BL.Logica.AccesoBD
{
    public class SalesOrderHeader
    {
        //Se crea la conexion a la BD. Estática para que siempre exista y privada para que nadie pueda tocarla.
        //Se declara sólo si se va a inicializar en un constructor.
        private static Proyecto1.MyModels.adventureWorksLT2019Context elContexto;

        public SalesOrderHeader()
        {
            //Se inicializa la conexión.
            elContexto = new Proyecto1.MyModels.adventureWorksLT2019Context();
        }

        //Lista de órdenes por nombre aproximado del cliente (considerando nombre y apellidos).
        public IList<Proyecto1.MyModels.SalesOrderHeader> BuscarOrdenesPorNombreAproximadoDeCliente(string nombreAproximado)
        {
            IList<Proyecto1.MyModels.SalesOrderHeader> temporal;
            using (var _elContexto = new Proyecto1.MyModels.adventureWorksLT2019Context())
            {
                temporal = _elContexto.SalesOrderHeaders.Include(o => o.Customer).
                    Where(o => o.Customer.FullName.Contains(nombreAproximado).ToList());
            }
            var resultado = temporal;
            return resultado;
        }

        //Dado un nombre aproximado de producto, genere una lista con el id, el nombre y la cantidad de productos
        //que fueron vendidos durante un intervalo determinado de fechas.
        public IList<Proyecto1.MyModels.SalesOrderDetail> BuscarProductosPorIntervaloDeFechas(string nombreAproximado, DateTime intervalo1, DateTime intervalo2)
        {
            IList<Proyecto1.MyModels.SalesOrderDetail> temporal;
            using (var _elContexto = new Proyecto1.MyModels.adventureWorksLT2019Context())
            {
                temporal = _elContexto.SalesOrderDetails.Include(od => od.Product).Include(od => od.SalesOrder).
                    Where( od => od.Product.Name.Contains(nombreAproximado) &&
                    (od.SalesOrder.OrderDate >= intervalo1) && (od.SalesOrder.OrderDate <= intervalo2)).ToList();
            }
            var resultado = temporal;
            return resultado;
        }
    }
}
