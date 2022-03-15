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
    public class ModuloController : Controller
    {
        private readonly MyDbContext _context;
        public ModuloController(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var modulo = _context.ModuloVirtual.Include(c => c.Propietario);
            return View(await modulo.ToListAsync());
        }
        public IActionResult Crear()
        {
            ViewData["Propietario"] = new SelectList(_context.Propietario, "IdPropietario", "NombrePropietario");
            return View();
        }
        [HttpPost]
        public IActionResult Crear(ModuloVirtual m)
        {
            if (ModelState.IsValid)
            {
                _context.ModuloVirtual.Add(m);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Propietario"] = new SelectList(_context.Propietario, "IdPropietario", "NombrePropietario");           
            return View("Index");
        }

    }
}
