using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HM03_19149817.Models;
using System.IO;

namespace HM03_19149817.Controllers
{
    public class HomeController : Controller
    {
        
        public static List<FileModel> filesList = new List<FileModel>(); 

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string ch)
        {
            Random random = new Random();

            if (ch == "doc")
            {
                try
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/UploadFiles"), _FileName);

                        FileModel item = new FileModel();

                        item.Link = "~/UploadFiles/" + _FileName;
                        item.FileName = _FileName;
                        item.Id = random.Next(10000);
                        item.Type = "doc";
                        filesList.Add(item);
                        Session["files"] = filesList;
                        file.SaveAs(_path);
                    }
                    ViewBag.Message = "File Uploaded Successfully!!";
                    return View();
                }
                catch
                {
                    ViewBag.Message = "File upload unssucessful.";
                    return View();
                }
            }
            if (ch == "img")
            {
                try
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/UploadFiles"), _FileName);

                        FileModel item = new FileModel();

                        item.Link = "~/UploadFiles/" + _FileName;
                        item.FileName = _FileName;
                        item.Id = random.Next(10000);
                        item.Type = "img";
                        filesList.Add(item);
                        Session["files"] = filesList;
                        file.SaveAs(_path);
                    }
                    ViewBag.Message = "Your file has been uploaded successfully.";
                    return View();
                }
                catch
                {
                    ViewBag.Message = "File upload unsuccessful.";
                    return View();
                }
            }
            if (ch == "vid")
            {
                try
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/UploadFiles"), _FileName);

                        FileModel item = new FileModel();
                        item.Link = "~/UploadFiles/" + _FileName;
                        item.FileName = _FileName;
                        item.Id = random.Next(10000);
                        item.Type = "vid";
                        filesList.Add(item);
                        Session["files"] = filesList;
                        file.SaveAs(_path);
                    }
                    ViewBag.Message = "Your video has been uploaded successfully.";
                    return View();
                }
                catch
                {
                    ViewBag.Message = "Video upload unsuccessful.";
                    return View();
                }
            }
            return View();

        }


       
    }
}