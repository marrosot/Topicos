using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.NetCore.NorthWind.BL.Logica.AccesoBD
{
    public class Customer
    //internal class Customer
    {

        //Se crea la conexion a la BD. Estática para que siempre exista y privada para que nadie pueda tocarla.
        //Se declara sólo si se va a inicializar en un constructor.
        private static Model.MyModels.AdventureWorksLT2019Context elContexto;

        public Customer(){
            //Para inicializar la conexión.
            elContexto = new Model.MyModels.AdventureWorksLT2019Context();
        }

        //Este metodo me trae sólo un resultado.
        public Model.MyModels.Customer BuscarPorId (int customerId)
        {
            Model.MyModels.Customer resultado;
            //El Find sirve para lo mismo del de abajo pero es más rápido.
            resultado = elContexto.Customers.Find(customerId);
            //resultado = elContexto.Customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
            return resultado;
        }

        public IList<Model.MyModels.Customer> BuscarPorNombreAproximadoDelStateProvince(string nombreAproximadoDelState)
        {
            IList<Model.MyModels.Customer> resultado;
            
            //Con el Using, no es necesario crear la variable privada stática arriba ni el constructor
            //ya que aquí mismo se declara y se inicializa.
            using (var _elContexto = new Model.MyModels.AdventureWorksLT2019Context())
            {
                var laConsulta = _elContexto.Customers.Include(c => c.CustomerAddresses).ThenInclude(ca => ca.Address).
                    Where(c => c.CustomerAddresses.Any(ca => ca.Address.StateProvince.Contains(nombreAproximadoDelState))).
                    OrderByDescending(c => c.Phone);
                resultado = laConsulta.ToList();
            }
            return resultado;
        }

        //Este metodo me puede traer de uno a muchos resultados.
        public IList<Model.MyModels.Customer> BuscarPorNombreAproximado(string nombreAproximado)
        {
            IList<Model.MyModels.Customer> temporal;
            using (var _elContexto = new Model.MyModels.AdventureWorksLT2019Context())
            {
                temporal = _elContexto.Customers.OrderByDescending(c => c.Phone).ToList().
                    Where(c => c.FullName.Contains(nombreAproximado)).ToList();
            }
            var resultado = temporal;
            return resultado;
        }
    }    
}
