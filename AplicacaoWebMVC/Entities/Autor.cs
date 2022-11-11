namespace AplicacaoWebMVC.Entities
{
    public class Autor
    {
        public int Id { get; set; }

        public string? Nome { get; set; } = null!;

        public string? CPF { get; set; } = null!;

        public DateTime? DataNascimento { get; set; } = null!;

        public string Email { get; set; }

        public string Celular { get; set; }

        public string? CEP { get; set; } = null!;

        public string? Logradouro { get; set; } = null!;

        public string? Bairro { get; set; } = null!;

        public string? Cidade { get; set; } = null!;

        public string? UF { get; set; } = null!;

        public string? FotoPerfil { get; set; } = null!;

    }
}
