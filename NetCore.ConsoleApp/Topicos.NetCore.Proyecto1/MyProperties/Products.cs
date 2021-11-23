using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.NetCore.Proyecto1.MyProperties
{
    public partial class Products
    {
        [NotMapped]
        public string xxxx 
        {
            get
            {
                var elResultado = $" ";

                return elResultado;
            }

            set { }            
        }
    }
}
