using System.Web;
using System.Web.Mvc;

namespace k22cnt3_tdt_2210900134
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
