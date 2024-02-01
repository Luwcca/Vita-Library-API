namespace WebApi_Biblioteca.Data.Dtos.EmprestimoDtos
{
    public class PostItemEmprestimoDto
    {
        public int? LivroId { get; set; }
        public int? PeriodicoId { get; set; }
        public DateTime Devolucao { get; set; }
    }
}
