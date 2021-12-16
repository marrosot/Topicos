using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.NetCore.Proyecto1.MyModels
{
    public partial class Product
    {
        [NotMapped]
        public string NombreDeLaCategoria
        {
            get
            {
                var elResultado = string.Empty;

                if (this.ProductCategory != null)
                    elResultado = this.ProductCategory.Name;

                return elResultado;
            }

            set { }
        }

    }
}
