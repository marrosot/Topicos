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

       public IList<Model.MyModels.Customer> BuscarPorNombreAproximadoDelStateProvince(string nombreAproximadoDelState)
        {
          /*  IList<Model.MyModels.Customer> resultado;

            //Con el Using, no es necesario crear la variable privada stática arriba ni el constructor
            //ya que aquí mismo se declara y se inicializa.
            using (var _elContexto = new Model.MyModels.sakilaContext())
            {
                var laConsulta = _elContexto.Customers.Include(c => c.CustomerAddresses).ThenInclude(ca => ca.Address).
                    Where(c => c.CustomerAddresses.Any(ca => ca.Address.StateProvince.Contains(nombreAproximadoDelState))).
                    OrderByDescending(c => c.Phone);
                resultado = laConsulta.ToList();
            }*/
            return resultado;
        }
    }
}
