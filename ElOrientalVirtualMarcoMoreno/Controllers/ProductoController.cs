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

            return View();
        }
    }
}
