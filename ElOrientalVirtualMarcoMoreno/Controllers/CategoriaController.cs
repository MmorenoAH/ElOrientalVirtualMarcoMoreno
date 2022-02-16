using ElOrientalVirtualMarcoMoreno.Data;
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

        public async Task<IActionResult> Index()
        {
            var categoria = _context.Categoria;
            return View(await categoria.ToListAsync());
        }
    }
}
