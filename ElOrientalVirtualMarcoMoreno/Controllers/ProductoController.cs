using ElOrientalVirtualMarcoMoreno.Data;
using ElOrientalVirtualMarcoMoreno.Models;
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
        public ProductoController(MyDbContext context)
        {
            _context = context;
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
        public IActionResult Agregar(Producto p)
        {
            if (ModelState.IsValid)
            {
                _context.Producto.Add(p);
                _context.SaveChanges();
                return View();
            }
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "NombreCategoria", p.IdCategoria);

            return View("index");
        }

        public IActionResult EditarProducto(int id)
        {
            Producto modelo = _context.Producto.Where(c => c.IdProducto == id).FirstOrDefault();
            return View("Editar", modelo);
        }
        [HttpPost]
        public IActionResult EditarProducto(Producto p)
        {
            Producto pactual = _context.Producto.Where(c => c.IdProducto == p.IdProducto).FirstOrDefault();
            pactual.NombreProducto = p.NombreProducto;
            pactual.PrecioProducto = p.PrecioProducto;
            pactual.DescripcionProducto = p.DescripcionProducto;
            pactual.IdCategoria = p.IdCategoria;
            pactual.RutaProductoImagen = p.RutaProductoImagen;
            _context.SaveChanges();
            List<Producto> prod = _context.Producto.ToList();
            return View("Index");
        }
        public IActionResult EliminarProducto(int id)
        {
            Producto prod=_context.Producto.Where(a=> a.IdProducto == id).FirstOrDefault();
            if(prod != null)
                _context.Remove(prod);
            _context.SaveChanges();
            return View("Index");
        }
    }
}
