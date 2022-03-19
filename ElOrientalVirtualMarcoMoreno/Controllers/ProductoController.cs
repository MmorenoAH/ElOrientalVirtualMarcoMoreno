﻿using ElOrientalVirtualMarcoMoreno.Data;
using ElOrientalVirtualMarcoMoreno.Models;
using ElOrientalVirtualMarcoMoreno.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElOrientalVirtualMarcoMoreno.Controllers
{
    public class ProductoController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _enviroment;
        public ProductoController(MyDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _enviroment = env;
        }
        public async Task<IActionResult> Index()
        {
            var Producto = _context.Producto.Include(c=>c.Categoria);
            return View(await Producto.ToListAsync());
        }

        public IActionResult Agregar()
        {
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "NombreCategoria");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(Producto p, UploadModel upload)
        {
            if (ModelState.IsValid)
            {

                _context.Producto.Add(p);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "NombreCategoria", p.IdCategoria);
            return View("Index");
        }
        public async Task<IActionResult> Upload(UploadModel upload)
        {
            var fileName = System.IO.Path.Combine(_enviroment.WebRootPath,
                "imagen", upload.MyFile.FileName);
            string ruta = fileName.ToString();
            await upload.MyFile.CopyToAsync(
                new System.IO.FileStream(fileName, System.IO.FileMode.Create));
            TempData["message"] = "Archivo Subido";
            return RedirectToAction("Index");
        }

        public IActionResult EditarProducto(int id, Producto c)
        {
            Producto modelo = _context.Producto.Where(c => c.IdProducto == id).FirstOrDefault();
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "NombreCategoria", c.IdCategoria);
            return View("Editar", modelo);
        }
        [HttpPost]
        public IActionResult EditarProducto(Producto p)
        {
            Producto pactual = _context.Producto.Where(c => c.IdProducto == p.IdProducto).FirstOrDefault();
            pactual.IdProducto = p.IdProducto;
            pactual.NombreProducto = p.NombreProducto;
            pactual.PrecioProducto = p.PrecioProducto;
            pactual.DescripcionProducto = p.DescripcionProducto;
            pactual.IdCategoria = p.IdCategoria;
            pactual.RutaProductoImagen = p.RutaProductoImagen;
            _context.SaveChanges();
            var Producto = _context.Producto.Include(c => c.Categoria);
            return RedirectToAction("Index");
        }
        public IActionResult EliminarProducto(int id)
        {
            Producto prod=_context.Producto.Where(a=> a.IdProducto == id).FirstOrDefault();
            if(prod != null)
                _context.Remove(prod);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ObtenerDescripcion(int id)
        {
            //string descripcion= _context.Categoria.Where(a => a.IdCategoria == id).FirstOrDefault().DescripcionCategoria;
            string descripcion = "Sin descripcion.";
            Producto producto = _context.Producto.Where(a => a.IdProducto == id).FirstOrDefault();
            if (producto != null && !string.IsNullOrEmpty(producto.DescripcionProducto))
            {
                descripcion = producto.DescripcionProducto;
            }
            return Json(new { descripcion });
        }

       
    }
}
