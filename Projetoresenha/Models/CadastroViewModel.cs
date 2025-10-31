using System.ComponentModel.DataAnnotations;

namespace Projetoresenha.Models
{
    public class CadastroViewModel
    {
        [Required, StringLength(60)]
        [Display(Name = "Nome")]
        public string Nome { get; set; } = "";

        [Required, StringLength(80)]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; } = "";

        [Required, EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = "";

        [Required, StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter ao menos 6 caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare(nameof(Senha), ErrorMessage = "As senhas não conferem")]
        public string ConfirmacaoSenha { get; set; } = "";
    }
}
