namespace WebApi_Biblioteca.Data.Dtos.LivrosDtos
{
    public class ReadLivroDto
    {
        public int LivroId { get; set; }
        public int EditoraId { get; set; }
        public string? Nome { get; set; }
        public string? Assunto { get; set; }
        public int? Tombo { get; set; }
        public bool? Status { get; set; }
        public string? Autor { get; set; }
    }
}
