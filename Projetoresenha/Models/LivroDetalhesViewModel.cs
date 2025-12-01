using System.ComponentModel.DataAnnotations;

namespace Projetoresenha.Models
{
    public class ResenhaViewModel
    {
        public string UsuarioNome { get; set; } = "";
        public string Comentario { get; set; } = "";
        public int Nota { get; set; }
        public DateTime Data { get; set; }
    }

    public class LivroDetalhesViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = "";
        public string AutorNome { get; set; } = "";
        public string Descricao { get; set; } = "";
        public decimal NotaMedia { get; set; }

        public List<ResenhaViewModel> Resenhas { get; set; } = new();

        // campos para novo comentário
        [Required]
        public string NovoComentario { get; set; } = "";

        [Range(1, 5, ErrorMessage = "A nota deve ser entre 1 e 5")]
        public int NovaNota { get; set; }
    }
}
