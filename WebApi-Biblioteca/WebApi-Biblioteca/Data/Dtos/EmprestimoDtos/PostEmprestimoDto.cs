namespace WebApi_Biblioteca.Data.Dtos.EmprestimoDtos
{
    public class PostEmprestimoDto
    {
        public int AlunoId { get; set; }
        public int FuncionarioId { get; set; }
        public PostItemEmprestimoDto ItemEmprestimo { get; set; }
        public DateTime Hora { get; set; }
    }
}
