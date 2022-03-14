using ElOrientalVirtualMarcoMoreno.Data;
using ElOrientalVirtualMarcoMoreno.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElOrientalVirtualMarcoMoreno.Controllers
{
    public class PropietarioController : Controller
    {
        private readonly MyDbContext _context;
        public PropietarioController(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var prop = _context.Propietario;
            return View(await prop.ToListAsync());
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Propietario c)
        {
            if (string.IsNullOrEmpty(c.NombrePropietario))
            {
                return Json(new
                {
                    Success = false,
                    Message = "El nombre del propietario esta vacio."
                }); ;
            }
            else
            {
                _context.Propietario.Add(c);
                _context.SaveChanges();
                return Json(new
                {
                    Success = true,
                    Message = "Propietario guardado correctamente."
                }); ;
            }
        }
        public IActionResult EditarPropietario(int id)
        {
            Propietario modelo = _context.Propietario.Where(c => c.IdPropietario == id).FirstOrDefault();
            return View("Editar", modelo);
        }
        [HttpPost]
        public IActionResult EditarPropietario(Propietario c)
        {
            //llamamos al valor actual de la base de datos
            Propietario practual = _context.Propietario.Where(p => p.IdPropietario == c.IdPropietario).FirstOrDefault();
            //Actualizo el valor con el nuevo
            practual.IdPropietario = c.IdPropietario;
            practual.NombrePropietario = c.NombrePropietario;
            //Guardamos los cambios
            _context.SaveChanges();
            return View("Index");
        }
        public IActionResult EliminarPropietario(int id)
        {
            Propietario propietario = _context.Propietario.Where(a => a.IdPropietario == id).FirstOrDefault();
            if (propietario != null)
                _context.Remove(propietario);
            _context.SaveChanges();
            List<Propietario> prop = _context.Propietario.ToList();
            return View("Index", prop);
        }

    }
}
