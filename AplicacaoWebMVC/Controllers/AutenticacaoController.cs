using AplicacaoWebMVC.Data;
using AplicacaoWebMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AplicacaoWebMVC.Controllers
{
    public class AutenticacaoController : Controller
    {
        AplicacaoContext _context = new AplicacaoContext(new DbContextOptions<AplicacaoContext>());

        public IActionResult SolicitarRecuperacaoSenha()
        {
            return View();
        }


        public IActionResult RecuperarSenha()
        {
            return View();
        }


        [HttpPost]
        public IActionResult RecuperarSenha(AutenticacaoViewModel viewModel)
        {
            //var recuperar = _context.Autenticacao.FirstOrDefault(u => u.Id == viewModel.Id);
            //recuperar.RecuperarSenha = viewModel.RecuperarSenha;
            //_context.Autenticacao.Update(recuperar);
            //_context.SaveChanges();
            return RedirectToAction("Login", "Usuarios");
        }

    }
}
