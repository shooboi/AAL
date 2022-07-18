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
        public static async Task<string> UploadFile(IFormFile file, string sDirectory)
        {
            FileInfo rootpath = new FileInfo(@"wwwroot/" + sDirectory);

            if (!Directory.Exists(rootpath.FullName))
            {
                Directory.CreateDirectory(rootpath.FullName);
            }
            try
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    var fileExtension = Path.GetExtension(file.FileName);

                    string ImageName = fileName + DateTime.Now.ToString("ddMMyyyy");

                    var ImageSavePath = Path.Combine(rootpath.FullName, $"{ImageName}{fileExtension}");

                    using (FileStream stream = new FileStream(ImageSavePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return $"/{sDirectory}/{ImageName}{fileExtension}";
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static void Delete(string fileName, string sDirectory)
        {
            try
            {
                string pathFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", sDirectory, fileName);
                FileInfo file = new FileInfo(@"wwwroot/" + sDirectory + fileName);

                if (file.Exists) /// Khác các file định nghĩa
                {
                    file.Delete();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
