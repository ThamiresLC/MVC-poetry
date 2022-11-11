namespace AplicacaoWebMVC.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        public string? Nome { get; set; } = null!;

        public string? CPF { get; set; } = null!;

        public DateTime? DataNascimento { get; set; } = null!;

        public string User { get; set; }

        public string Email { get; set; }

        public string? Telefone { get; set; } = null!;

        public string Celular { get; set; }

        public string Senha { get; set; }

        public string? CEP { get; set; } = null!;

        public string? Logradouro { get; set; } = null!;

        public string? Bairro { get; set; } = null!;

        public string? Cidade { get; set; } = null!;

        public string? UF { get; set; } = null!;

        public string? FotoPerfil { get; set; } = null!;
    }
}
