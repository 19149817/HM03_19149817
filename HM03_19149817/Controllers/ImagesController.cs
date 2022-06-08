using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HM03_19149817.Models;


namespace HM03_19149817.Controllers
{
    public class ImagesController : Controller
    {
        static public List<FileModel> items = new List<FileModel>();
        // GET: Images
        public ActionResult Index()
        {

            items = ((List<FileModel>)Session["files"]);
            items = items.Where(t => t.Type == "img").ToList();

            return View(items);

        }
 

        public FileResult Download(int id)
        {
            items = ((List<FileModel>)Session["files"]);
            FileModel fileModel = new FileModel();
            fileModel = items.FirstOrDefault(x => x.Id == id);
            string path = Server.MapPath("~/UploadFiles/" + fileModel.FileName);
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileModel.FileName);
        }

        public ActionResult Delete(int id)
        {
            items = ((List<FileModel>)Session["files"]);
            items = items.Where(t => t.Type == "img").ToList();
            FileModel fileModel = new FileModel();
            fileModel = items.FirstOrDefault(x => x.Id == id);

            items.Remove(fileModel);
            Session["files"] = items;
            return View("Index", items);
        }
    }
}