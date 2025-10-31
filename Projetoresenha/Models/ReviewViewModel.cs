using System.ComponentModel.DataAnnotations;

namespace Projetoresenha.Models
{
    public class ReviewViewModel
    {
        [Required]
        public int LivroId { get; set; }

        [Required(ErrorMessage = "Informe uma nota")]
        [Range(1, 5, ErrorMessage = "A nota deve estar entre 1 e 5")]
        public int Nota { get; set; } = 1;

        [Required(ErrorMessage = "Escreva sua opinião")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Sua resenha deve ter pelo menos 10 caracteres")]
        [Display(Name = "Resenha")]
        public string Texto { get; set; } = "";
    }
}
