using System.Web;
using System.Web.Mvc;

namespace Topicos.MiPrimeraSolucion
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
