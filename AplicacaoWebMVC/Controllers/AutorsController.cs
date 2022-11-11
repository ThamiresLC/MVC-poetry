#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AplicacaoWebMVC.Data;
using AplicacaoWebMVC.Entities;
using AplicacaoWebMVC.ViewModels;

namespace AplicacaoWebMVC.Controllers
{
    public class AutorsController : Controller
    {
        private readonly AplicacaoContext _context;

        public AutorsController(AplicacaoContext context)
        {
            _context = context;
        }

        // GET: Autors
        public async Task<IActionResult> Autores()
        {
            var autoresViewModel = _context.Autores.ToList().Select(x => new AutorViewModel
            {
                Id = x.Id,
                Nome = x.Nome,
                CPF = x.CPF,
                DataNascimento = x.DataNascimento,
                Celular = x.Celular,
                Email = x.Email,
                CEP = x.CEP,
                Logradouro = x.Logradouro,
                Bairro = x.Bairro,
                Cidade = x.Cidade,
                UF = x.UF,
                FotoPerfil = x.FotoPerfil,
            });

                return View(autoresViewModel);
        }

        // GET: Autors/Details/5
        public async Task<IActionResult> Detalhar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = _context.Autores.FirstOrDefault(u => u.Id == id);
            var viewModel = new AutorViewModel();
            viewModel.Id = autor.Id;
            viewModel.Nome = autor.Nome;
            viewModel.DataNascimento = autor.DataNascimento;
            viewModel.CPF = autor.CPF;
            viewModel.Celular = autor.Celular;
            viewModel.Email = autor.Email;
            viewModel.CEP = autor.CEP;
            viewModel.Logradouro = autor.Logradouro;
            viewModel.Bairro = autor.Bairro;
            viewModel.Cidade = autor.Cidade;
            viewModel.UF = autor.UF;

            return View(viewModel);
        }

        // GET: Autors/Create
        public IActionResult Cadastrar()
        {
            return View();
        }

        // POST: Autors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Cadastrar(AutorViewModel viewModel)
        {   
            if (ModelState.IsValid)
            {
                var autor = new Autor 
                { 
                    Id = viewModel.Id, 
                    Nome = viewModel.Nome, 
                    CPF = viewModel.CPF,
                    Celular = viewModel.Celular,
                    DataNascimento = viewModel.DataNascimento,
                    Email = viewModel.Email,
                    CEP = viewModel.CEP,
                    Logradouro = viewModel.Logradouro,
                    Bairro = viewModel.Bairro,
                    Cidade = viewModel.Cidade,
                    UF = viewModel.UF,
                    FotoPerfil= viewModel.FotoPerfil,

                };
                
                _context.Add(autor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Autores));
            }
            return View(viewModel);
        }

        // GET: Autors/Edit/5
        public async Task<IActionResult> Editar(int id)
        {
            var autor = _context.Autores.FirstOrDefault(u => u.Id == id);
            var viewModel = new AutorViewModel();
            viewModel.Id = id;
            viewModel.Nome = autor.Nome;
            viewModel.DataNascimento = autor.DataNascimento;
            viewModel.CPF = autor.CPF;
            viewModel.Celular = autor.Celular;
            viewModel.Email = autor.Email;
            viewModel.CEP = autor.CEP;
            viewModel.Logradouro = autor.Logradouro;
            viewModel.Bairro = autor.Bairro;
            viewModel.Cidade = autor.Cidade;
            viewModel.UF = autor.UF;

            return View(viewModel);
        }

        // POST: Autors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, AutorViewModel viewModel)
        {
            var autor = _context.Autores.FirstOrDefault(u => u.Id == viewModel.Id);
            autor.Nome = viewModel.Nome;
            autor.DataNascimento = viewModel.DataNascimento;
            autor.CPF = viewModel.CPF;
            autor.Celular = viewModel.Celular;
            autor.CEP = viewModel.CEP;
            autor.Logradouro = viewModel.Logradouro;
            autor.Bairro = viewModel.Bairro;
            autor.Cidade = viewModel.Cidade;
            autor.UF = viewModel.UF;
            _context.Autores.Update(autor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Autores));
        }
           

        // GET: Autors/Delete/5
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = _context.Autores.FirstOrDefault(u => u.Id == id);
            var viewModel = new AutorViewModel();
            viewModel.Id = autor.Id;
            viewModel.Nome = autor.Nome;
            viewModel.DataNascimento = autor.DataNascimento;
            viewModel.CPF = autor.CPF;
            viewModel.Celular = autor.Celular;
            viewModel.Email = autor.Email;
            viewModel.CEP = autor.CEP;
            viewModel.Logradouro = autor.Logradouro;
            viewModel.Bairro = autor.Bairro;
            viewModel.Cidade = autor.Cidade;
            viewModel.UF = autor.UF;
            return View(viewModel);
        }

        // POST: Autors/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Autores));
        }

        private bool AutorExists(int id)
        {
            return _context.Autores.Any(e => e.Id == id);
        }
    }
}
