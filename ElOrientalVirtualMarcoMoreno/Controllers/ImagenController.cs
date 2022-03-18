using ElOrientalVirtualMarcoMoreno.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElOrientalVirtualMarcoMoreno.Controllers
{
    public class ImagenController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        public ImagenController(IWebHostEnvironment env)
        {
            _enviroment = env;
        }
        public IActionResult Index()
        {
            ViewBag.message = TempData["message"];
            return View();
        }
        public async Task<IActionResult> Upload(UploadModel upload)
        {
            var fileName = System.IO.Path.Combine(_enviroment.ContentRootPath,
                "Uploads", upload.MyFile.FileName);
            string ruta = fileName.ToString();
            await upload.MyFile.CopyToAsync(
                new System.IO.FileStream(fileName, System.IO.FileMode.Create));
            TempData["message"] = "Archivo Subido";
            return RedirectToAction("Index");
        }
    }
}
