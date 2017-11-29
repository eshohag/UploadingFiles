using System.IO;
using System.Web;
using System.Web.Mvc;

namespace UploadingFiles.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);

                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
                    file.SaveAs(path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }

        }
    }
}