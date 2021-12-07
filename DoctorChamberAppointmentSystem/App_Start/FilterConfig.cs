using System.Web;
using System.Web.Mvc;

namespace DoctorChamberAppointmentMangementSystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}