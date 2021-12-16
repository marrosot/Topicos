using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.NetCore.NorthWind.BL.Logica.AccesoBD
{
    public class Product
    {
        //Se crea la conexion a la BD. Estática para que siempre exista y privada para que nadie pueda tocarla.
        //Se declara sólo si se va a inicializar en un constructor.
        private static Proyecto1.MyModels.adventureWorksLT2019Context elContexto;

        public Product()
        {
            //Se inicializa la conexión.
            elContexto = new Proyecto1.MyModels.adventureWorksLT2019Context();
        }

        //Lista de todos los productos descontinuados por rango de precio.
        public IList<Proyecto1.MyModels.Product> BuscarProductosDescontinuados(int rango1, int rango2)
        {
            IList<Proyecto1.MyModels.Product> temporal;
            using (var _elContexto = new Proyecto1.MyModels.adventureWorksLT2019Context())
            {
                temporal = _elContexto.Products.OrderByDescending(p => p.DiscontinuedDate).ToList().
                    Where(p => (p.ListPrice >= rango1) && (p.ListPrice <= rango2)).ToList();              
            }
            var resultado = temporal;
            return resultado;
        }

        //Lista de todos los productos por nombre aproximado de la categoría.
        public IList<Proyecto1.MyModels.Product> BuscarProductosPorNombreDeCategoriaAproximada(string nombreAproximado)
        {
            IList<Proyecto1.MyModels.Product> temporal;
            using (var _elContexto = new Proyecto1.MyModels.adventureWorksLT2019Context())
            {
                temporal = _elContexto.Products.Include(p => p.ProductCategory).
                    Where(p => p.ProductCategory.Name.Contains(nombreAproximado)).ToList();
            }
            var resultado = temporal;
            return resultado;
        }

   


    }
}
