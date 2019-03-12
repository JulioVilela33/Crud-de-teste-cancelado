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
    public class PessoasFisicasController : Controller
    {
        private readonly BancoContexto _context;

        public PessoasFisicasController(BancoContexto context)
        {
            _context = context;
        }
        
        // GET: PessoaFisicas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoasFisicas
                .FirstOrDefaultAsync(m => m.PessoaId == id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return View(pessoaFisica);
        }

        // GET: PessoaFisicas/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,PessoaId,Data,Documento,Telefone,Email")] PessoaFisica pessoaFisica)
        {
            if (ModelState.IsValid)
            {
                pessoaFisica.PessoaId = Guid.NewGuid();
                _context.Add(pessoaFisica);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Pessoas");
            }
            CreateEndereco()
            return View(pessoaFisica);
        }

        // GET: PessoaFisicas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoasFisicas.FindAsync(id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }
            return View(pessoaFisica);
        }

        // POST: PessoaFisicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,PessoaId,Data,Documento,Telefone,Email")] PessoaFisica pessoaFisica)
        {
            if (id != pessoaFisica.PessoaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaFisica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaFisicaExists(pessoaFisica.PessoaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Pessoas");
            }
            return View(pessoaFisica);
        }

        // GET: PessoaFisicas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoasFisicas
                .FirstOrDefaultAsync(m => m.PessoaId == id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return View(pessoaFisica);
        }

        // POST: PessoaFisicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pessoaFisica = await _context.PessoasFisicas.FindAsync(id);
            _context.PessoasFisicas.Remove(pessoaFisica);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Pessoas");
        }

        public IActionResult CreateEndereco()
        {
            return PartialView("_Endereco", new Endereco()
            {
                EnderecoId = Guid.NewGuid(),
            });
        }

        private bool PessoaFisicaExists(Guid id)
        {
            return _context.PessoasFisicas.Any(e => e.PessoaId == id);
        }
    }
}
