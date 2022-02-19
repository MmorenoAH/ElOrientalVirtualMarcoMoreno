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
    public class ModuloController : Controller
    {
        private readonly MyDbContext _context;
        public ModuloController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Crear()
        {
            return View();
        }
        public IActionResult Crear(ModuloVirtual m)
        {
            _context.ModuloVirtual.Add(m);
            _context.SaveChanges();
            return View();
        }
        public async Task<IActionResult> Index()
        {
            var modulo = _context.ModuloVirtual;
            return View(await modulo.ToListAsync());
        }
    }
}
