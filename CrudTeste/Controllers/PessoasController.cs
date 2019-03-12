using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudTeste.Models.Entidades;
using CrudTeste.Models.Services;

namespace CrudTeste.Controllers
{
    public class PessoasController : Controller
    {
        private readonly BancoContexto _context;

        public PessoasController(BancoContexto context)
        {
            _context = context;
        }

        // GET: Pessoas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pessoas
                .Include(c => c.Endereco)
                .AsNoTracking()
                .ToListAsync());
        }

       
    }
}
