using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.NetCore.Proyecto1.MyModels
{
    public partial class SalesOrderDetail
    {
        [NotMapped]
        public double CalcularMontoBruto
        {
            get
            {
                var montoBruto = 0.0;                
                var resultado = 0.0;

                if (this.OrderQty != 0) 
                {
                    montoBruto = (double)(this.UnitPrice * this.OrderQty);
                    resultado = resultado + montoBruto;
                }

                return resultado;
            }

            set 
            {
            
            }
        }

        [NotMapped]
        public double CalcularMontoDelDescuento
        {
            get
            {
                var resultado = 0.0;
                var descuento = 0.0;

                if (this.UnitPriceDiscount != 0)
                {
                    descuento = (double)(this.UnitPriceDiscount) * this.OrderQty;
                    resultado = resultado + descuento;
                }

                return resultado;
            }

            set
            {

            }
        }

        [NotMapped]
        public double CalcularMontoNeto
        {
            get
            {
                var resultado = 0.0;
                var  montoNeto= 0.0;

                if (this.OrderQty != 0)
                {
                    montoNeto = (double)(this.UnitPrice - this.UnitPriceDiscount) * this.OrderQty;
                    resultado = resultado + montoNeto;
                }

                return resultado;
            }

            set
            {

            }
        }

        [NotMapped]
        public string PasarASignoPorcentual
        {
            get
            {
                var resultado = string.Empty;
                var porcentaje = string.Empty;

                if (this.OrderQty != 0)
                {
                    porcentaje = CalcularMontoDelDescuento.ToString("2");
                    resultado = resultado + porcentaje;
                }

                return resultado;
            }

            set
            {

            }
        }
    }
}
