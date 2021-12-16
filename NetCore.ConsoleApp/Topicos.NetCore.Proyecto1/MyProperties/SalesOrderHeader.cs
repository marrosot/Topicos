using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Topicos.NetCore.Proyecto1.MyModels
{
    public partial class SalesOrderHeader
    {
        [NotMapped]
        //Calcula la cantidad de días que duró la orden en ser fabricada
        public TimeSpan CalcularDiasDeFabricacion
        {
            get
            {
                var cantidadDias = TimeSpan.Zero;
                var resultado = TimeSpan.Zero;
                var v = TimeSpan.Zero;
                

                if (this.OrderDate != null)
                {
                   // v = (ShipDate - OrderDate).Days;
                    //v = this.ShipDate.Subtract(this.OrderDate);
                    cantidadDias = v;
                    resultado = resultado + cantidadDias;
                }
                return resultado;
            }
            set
            {

            }
        }
    }
}
