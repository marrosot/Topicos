using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Topicos.NetCore.Sakila.BL.Logica.AccesoBD
{
    public class Customer
    {

        private static Model.MyModels.sakilaContext elContexto;


        //Este metodo me trae sólo un resultado.
        public Model.MyModels.Customer BuscarPorId(int customerId)
        {
            Model.MyModels.Customer resultado;
            //El Find sirve para lo mismo del de abajo pero es más rápido.
            //resultado = elContexto.Customers.Find(customerId);
            resultado = elContexto.Customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
            return resultado;
        }


        //Listado de clientes por nombre aproximado del City o El Country
        public IList<Model.MyModels.Customer> BuscarPorNombreAproximadoDeLaUbicacion(string nombreAproximado)
        {
            IList<Model.MyModels.Customer> resultado = new List<Model.MyModels.Customer>();

            using (var _elContexto = new Model.MyModels.sakilaContext())
            {
                var laConsulta = _elContexto.Customers.Include(c => c.Address).ThenInclude(a => a.City).ThenInclude(ct => ct.Country).
                    Where(c => c.Address.City.City1.Contains(nombreAproximado) || c.Address.City.Country.Country1.Contains(nombreAproximado));
                                             
                resultado = laConsulta.ToList();
            }
            return resultado;
        }

    
    }
}
