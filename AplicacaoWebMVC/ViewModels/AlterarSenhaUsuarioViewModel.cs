using System.ComponentModel.DataAnnotations;

namespace AplicacaoWebMVC.ViewModels
{
    public class AlterarSenhaUsuarioViewModel
    {
        public int Id { get; set; }

        [MaxLength(8, ErrorMessage = "User com o máximo de 8 caracteres")]
        public string User { get; set; }

        [DataType(DataType.Password)]
        public string SenhaAtual { get; set; }

        
        [DataType(DataType.Password)]
        public string NovaSenha { get; set; }


        [DataType(DataType.Password)]
        [Compare("NovaSenha")]
       public string SenhaConfirma { get; set; }
    }    

}
