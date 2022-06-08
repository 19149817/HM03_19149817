using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HM03_19149817.Models;


namespace HM03_19149817.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        static public List<FileModel> item = new List<FileModel>();

        public ActionResult Index()
        {

            item = ((List<FileModel>)Session["files"]);
            item = item.Where(y => y.Type == "doc").ToList();

            return View(item);

        }

        public ActionResult Delete(int id)
        {
            item = ((List<FileModel>)Session["files"]);
            item = item.Where(y => y.Type == "doc").ToList();
            FileModel fileModels = new FileModel();
            fileModels = item.FirstOrDefault(x => x.Id == id);

            item.Remove(fileModels);
            Session["files"] = item;
            return View("Index", item);
        }
        public FileResult Download(int id)
        {
            item = ((List<FileModel>)Session["files"]);
            FileModel fileModel = new FileModel();
            fileModel = item.FirstOrDefault(y => y.Id == id);
            string path = Server.MapPath("~/UploadFiles/" + fileModel.FileName);
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileModel.FileName);
        }
    }
}