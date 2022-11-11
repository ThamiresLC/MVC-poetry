namespace AplicacaoWebMVC.ViewModels
{
    public class PoesiaViewModel
    {
        public int Id { get; set; }

        public string Titulo { get; set;}

        public DateTime Data { get; set; }

        public string TextoPoesia { get; set; }

        public string UrlImagem { get; set; }

        public IFormFile Imagem { get; set; }
    }
}
