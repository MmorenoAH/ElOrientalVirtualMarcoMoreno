using ElOrientalVirtualMarcoMoreno.Data;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }
    }
}
