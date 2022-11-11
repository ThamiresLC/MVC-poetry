using AplicacaoWebMVC.Data;
using AplicacaoWebMVC.Entities;
using AplicacaoWebMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplicacaoWebMVC.Controllers
{
    public class PoesiasController : Controller
    {

        AplicacaoContext _context = new AplicacaoContext(new DbContextOptions<AplicacaoContext>());
        Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public PoesiasController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: PoesiasController
        public ActionResult Poesia()
        {
            var poesias = _context.Poesias.ToList().Select(x => new PoesiaViewModel
            {

                Data = x.Data,
                Id = x.Id,
                TextoPoesia = x.TextoPoesia,
                Titulo = x.Titulo,
                UrlImagem = x.UrlImagem,

            }); 

            return View(poesias);
        }

        // GET: PoesiasController/Details/5
        public ActionResult Detalhar(int id)
        {
            return View();
        }

        // GET: PoesiasController/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: PoesiasController/Create
        [HttpPost]
        //[ValidateInput(false)]
        public async Task<ActionResult> Cadastrar(PoesiaViewModel viewModel)
        {
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            string filePath = "";

            if (viewModel.Imagem.Length > 0)
            {
                filePath = Path.Combine(uploads, viewModel.Imagem.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await viewModel.Imagem.CopyToAsync(fileStream);
                }
            }
            var poesia = new Poesia {
                Data = viewModel.Data,
                Id = viewModel.Id,
                TextoPoesia = viewModel.TextoPoesia,
                Titulo = viewModel.Titulo,
                UrlImagem = Path.Combine("uploads", viewModel.Imagem.FileName)
        };

            poesia.TextoPoesia = viewModel.TextoPoesia;

            _context.Poesias.Add(poesia);
            _context.SaveChanges();
            return RedirectToAction(nameof(Poesia));
        }

        // GET: PoesiasController/Edit/5
        public async Task<IActionResult> Editar(int id)
        {
            var poesia = _context.Poesias.FirstOrDefault(u => u.Id == id);
            if (poesia == null)
                return NotFound();
            var viewModel = new PoesiaViewModel();
            viewModel.Id = id;
            viewModel.Titulo = poesia.Titulo;
            viewModel.Data = poesia.Data;
            viewModel.UrlImagem = poesia.UrlImagem;
            viewModel.TextoPoesia = poesia.TextoPoesia;

            return View(viewModel);
        }

        // POST: PoesiasController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Editar(int id, PoesiaViewModel viewModel)
        {
            var poesia = _context.Poesias.FirstOrDefault(u => u.Id == viewModel.Id);
            poesia.Id = viewModel.Id;
            poesia.Data = viewModel.Data;
            poesia.UrlImagem = viewModel.UrlImagem;
            poesia.Titulo = viewModel.Titulo;
            poesia.TextoPoesia = viewModel.TextoPoesia;
            _context.Poesias.Update(poesia);
            _context.SaveChanges();
            return RedirectToAction(nameof(Poesia));
        }

        // POST: PoesiasController/Delete/5
        [HttpPost]
        public IActionResult Excluir(int id, int usuarioId)
        {
            //Select * from Poesias where Id = 1 
            var poesia = _context.Poesias.FirstOrDefault(u => u.Id == id);
            _context.Poesias.Remove(poesia);
            _context.SaveChanges();
            return RedirectToAction("Perfil", "Usuarios", new {Id = usuarioId});
        }
    }
}
