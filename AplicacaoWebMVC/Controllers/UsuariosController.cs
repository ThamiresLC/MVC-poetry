using AplicacaoWebMVC.Data;
using AplicacaoWebMVC.Entities;
using AplicacaoWebMVC.Models;
using AplicacaoWebMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AplicacaoWebMVC.Controllers
{
    public class UsuariosController : Controller
    {
        Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        AplicacaoContext _context = new AplicacaoContext(new DbContextOptions<AplicacaoContext>());
        public UsuariosController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(UsuarioViewModel viewModel)
        {
            var usuario = new Usuario();
            usuario.User = viewModel.User;
            usuario.Celular = viewModel.Celular;
            usuario.Email = viewModel.Email;
            usuario.Senha = viewModel.NovaSenha;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Edicao), new { Id = usuario.Id });
        }

        public IActionResult Usuarios()
        {
            var usuarios = _context.Usuarios.ToList().Select(x => new UsuarioViewModel
            {
                Id = x.Id,
                User = x.User,
                Nome = x.Nome,
                DataNascimento = x.DataNascimento,
                CPF = x.CPF,
                Telefone = x.Telefone,
                Celular = x.Celular,
                Email = x.Email,
                NovaSenha = x.Senha,
                CEP = x.CEP,
                Logradouro = x.Logradouro,
                Bairro = x.Bairro,
                Cidade = x.Cidade,
                UF = x.UF,
            }).ToList();
            return View(usuarios);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Edicao(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            var viewModel = new UsuarioViewModel();
            viewModel.Id = id;
            viewModel.Nome = usuario.Nome;
            viewModel.DataNascimento = usuario.DataNascimento;
            viewModel.CPF = usuario.CPF;
            viewModel.Telefone = usuario.Telefone;
            viewModel.Celular = usuario.Celular;
            viewModel.Email = usuario.Email;
            viewModel.CEP = usuario.CEP;
            viewModel.Logradouro = usuario.Logradouro;
            viewModel.Bairro = usuario.Bairro;
            viewModel.Cidade = usuario.Cidade;
            viewModel.UF = usuario.UF;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edicao(UsuarioViewModel viewModel)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == viewModel.Id);
            usuario.Nome = viewModel.Nome;
            usuario.Email = viewModel.Email;
            usuario.DataNascimento = viewModel.DataNascimento;
            usuario.CPF = viewModel.CPF;
            usuario.Telefone = viewModel.Telefone;
            usuario.Celular = viewModel.Celular;
            usuario.CEP = viewModel.CEP;
            usuario.Logradouro = viewModel.Logradouro;
            usuario.Bairro = viewModel.Bairro;
            usuario.Cidade = viewModel.Cidade;
            usuario.UF = viewModel.UF;

            if (viewModel.File != null && viewModel.File.Length > 0)
            {
                string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                string filePath = Path.Combine(uploads, viewModel.File.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await viewModel.File.CopyToAsync(fileStream);
                }
                usuario.FotoPerfil = Path.Combine("uploads", viewModel.File.FileName);
            }
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Usuarios));
        }
        public IActionResult Perfil(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            var viewModel = new UsuarioViewModel
            {
                Id = usuario.Id,
                User = usuario.User,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                CPF = usuario.CPF,
                Telefone = usuario.Telefone,
                Celular = usuario.Celular,
                Email = usuario.Email,
                NovaSenha = usuario.Senha,
                CEP = usuario.CEP,
                Logradouro = usuario.Logradouro,
                Bairro = usuario.Bairro,
                Cidade = usuario.Cidade,
                UF = usuario.UF,
                FotoPerfil = usuario.FotoPerfil,
            };

            viewModel.Poesias = _context.Poesias.ToList().Select(x => new PoesiaViewModel
            {
                Data = x.Data,
                Id = x.Id,
                TextoPoesia = x.TextoPoesia,
                Titulo = x.Titulo,
                UrlImagem = x.UrlImagem,

            }).ToList();

            return View(viewModel);
        }

        public IActionResult AlterarSenha(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            var viewModel = new AlterarSenhaUsuarioViewModel();

            viewModel.Id = id;
            viewModel.User = usuario.User;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AlterarSenha(AlterarSenhaUsuarioViewModel viewModel)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == viewModel.Id);
            usuario.User = viewModel.User;
            usuario.Senha = viewModel.NovaSenha;
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Usuarios));
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Usuarios));
        }

    }
}