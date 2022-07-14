using Microsoft.AspNetCore.Mvc.Rendering;

namespace AAL.Models.DTO
{
    public static class Utility
    {
        public static string IsActive(this IHtmlHelper htmlHelper, string area, string controller)
        {
            var routeData = htmlHelper.ViewContext.RouteData;

            var routeAction = routeData.Values["action"].ToString();
            var routeController = routeData.Values["controller"].ToString();
            var routeArea = routeData.Values["area"].ToString();


            var returnActive = (controller == routeController && area == routeArea);

            return returnActive ? "active" : "";
        }
    }
}
