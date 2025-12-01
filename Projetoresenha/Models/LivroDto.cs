namespace Projetoresenha.Models
{
    public class LivroDto
    {
        public int Pkid_livro { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string? Descricao { get; set; }
    }
}
