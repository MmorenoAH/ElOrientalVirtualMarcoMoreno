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

            var modulo = _context.ModuloVirtual;
            return View(await modulo.ToListAsync());
        }
        public IActionResult Crear()
        {
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
            return View("Index");
        }

        public IActionResult EditarModulo(int id)
        {
            ModuloVirtual modelo = _context.ModuloVirtual.Where(c => c.IdModulo == id).FirstOrDefault();
            return View("Editar", modelo);
        }
        [HttpPost]
        public IActionResult EditarModulo(ModuloVirtual c)
        {
            //llamamos al valor actual de la base de datos
            ModuloVirtual mactual = _context.ModuloVirtual.Where(p => p.IdModulo == c.IdModulo).FirstOrDefault();
            //Actualizo el valor con el nuevo
            mactual.IdModulo = c.IdModulo;
            mactual.NombrePropietario = c.NombrePropietario;
            mactual.DescripcionModulo = c.DescripcionModulo;
            //Guardamos los cambios
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EliminarModulo(int id)
        {
            ModuloVirtual modulo = _context.ModuloVirtual.Where(a => a.IdModulo == id).FirstOrDefault();
            if (modulo != null)
            _context.Remove(modulo);
            _context.SaveChanges();
            List<ModuloVirtual> mod = _context.ModuloVirtual.ToList();
            return View("Index", mod);
        }

        public IActionResult MostrarProducto(int id)
        {
            List<Producto> productos = _context.Producto.Where(a => a.IdModulo == id).ToList();
            return View("Productos", productos);
        }
    }
}
