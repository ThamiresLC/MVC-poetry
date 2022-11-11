using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AplicacaoWebMVC.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "Por favor digite seu nome.")]
        [MaxLength(30)]
        public string? Nome { get; set; } = null!;

        public string? CPF { get; set; } = null!;

        public DateTime? DataNascimento { get; set; } = null!;

        [MaxLength(15, ErrorMessage = "User com o máximo de 8 caracteres")]
        public string User { get; set; }

        [MaxLength(30)]
        [Display(Name = "E-mail")]
        [Remote("EmailUnico", "Usuarios", ErrorMessage = "e-mail já cadastrado")]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$", ErrorMessage = "Formato do E-mail Inválido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [DataType(DataType.Password)]
        [Compare("NovaSenha")]
        public string SenhaConfirma { get; set; }

        [DataType(DataType.Password)]
        public string NovaSenha { get; set; }

        [DataType(DataType.Password)]
        public string SenhaAtual { get; set; }

        [DataType(DataType.PostalCode)]
        public string? CEP { get; set; } = null!;

        [MaxLength(50)]
        public string? Logradouro { get; set; } = null!;

        [MaxLength(50)]
        public string? Bairro { get; set; } = null!;

        [MaxLength(50)]
        public string?Cidade { get; set; } = null!;

        [MaxLength(2)]
        public string? UF { get; set; } = null!;

        public IFormFile File { get; set; }

        public string? FotoPerfil { get; set; } = null!;

        public List<PoesiaViewModel> Poesias { get; set; }
    }
}
