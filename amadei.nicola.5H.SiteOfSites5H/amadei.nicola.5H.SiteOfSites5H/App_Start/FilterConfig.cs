using System.Web;
using System.Web.Mvc;

namespace amadei.nicola._5H.SiteOfSites5H
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
