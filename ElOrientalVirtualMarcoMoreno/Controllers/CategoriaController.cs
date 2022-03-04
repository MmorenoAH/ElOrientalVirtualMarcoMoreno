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
    public class CategoriaController : Controller
    {
        private readonly MyDbContext _context;
        public CategoriaController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Categoria c)
        {
            if (string.IsNullOrEmpty(c.NombreCategoria))
            {
                return Json(new
                {
                    Success = false,
                    Message = "El nombre de la categoria esta vacio."                   
                }); ;
            }
            else
            {
                _context.Categoria.Add(c);
                _context.SaveChanges();
                List<Categoria> cat = _context.Categoria.ToList();
                return Json(new
                {
                    Success = true,
                    Message = "Categoria guardada correctamente."
                }); ;
            }
        }

        public async Task<IActionResult> Index()
        {
            var categoria = _context.Categoria;
            return View(await categoria.ToListAsync());
        }

        public IActionResult EditarCategoria(int id)
        {
            Categoria modelo=_context.Categoria.Where(c => c.IdCategoria == id).FirstOrDefault();
            return View("Editar", modelo);
        }
        [HttpPost]
        public IActionResult EditarCategoria(Categoria c)
        {
            //llamamos al valor actual de la base de datos
            Categoria cactual = _context.Categoria.Where(p => p.IdCategoria == c.IdCategoria).FirstOrDefault();
            //Actualizo el valor con el nuevo
            cactual.IdCategoria = c.IdCategoria;
            cactual.NombreCategoria = c.NombreCategoria;
            cactual.DescripcionCategoria = c.DescripcionCategoria;
            //Guardamos los cambios
            _context.SaveChanges();
            List<Categoria> cat = _context.Categoria.ToList();
            return View("Index", cat);
        }
        public IActionResult EliminarCategoria(int id)
        {
           /*
            List<Producto> productos = _context.Producto.Where(a => a.IdCategoria == id).ToList();
            if (productos != null)
            {
                _context.RemoveRange(productos);
            }
           */
            Categoria categoria = _context.Categoria.Where(a => a.IdCategoria == id).FirstOrDefault();
            if (categoria != null)
            _context.Remove(categoria);
            _context.SaveChanges();
            List<Categoria> cat = _context.Categoria.ToList();
            return View("Index", cat);
        }
    }
}
