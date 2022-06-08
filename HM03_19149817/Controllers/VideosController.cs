using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HM03_19149817.Models;


namespace HM03_19149817.Controllers
{
    public class VideosController : Controller
    {
        static public List<FileModel> item = new List<FileModel>();
        // GET: Videos

        public ActionResult Index()
        {

            item = ((List<FileModel>)Session["files"]);
            item = item.Where(a => a.Type == "vid").ToList();
            return View(item);

        }
        public ActionResult Delete(int id)
        {

            item = ((List<FileModel>)Session["files"]);
            item = item.Where(a => a.Type == "vid").ToList();
            FileModel fileModel = new FileModel();
            fileModel = item.FirstOrDefault(a => a.Id == id);


            item.Remove(fileModel);
            Session["files"] = item;
            return View("Index", item);
        }
        public FileResult Download(int id)
        {
            item = ((List<FileModel>)Session["files"]);
            FileModel fileModel = new FileModel();
            fileModel = item.FirstOrDefault(a => a.Id == id);
            string path = Server.MapPath("~/UploadedFiles/" + fileModel.FileName);
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileModel.FileName);
        }
    }
}