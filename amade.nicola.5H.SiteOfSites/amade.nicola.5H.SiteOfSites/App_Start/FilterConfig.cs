using System.Web;
using System.Web.Mvc;

namespace amade.nicola._5H.SiteOfSites
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
