using System.Web;
using System.Web.Mvc;

namespace Lad_33_Helpdesk_Entity
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
