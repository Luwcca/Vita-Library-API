namespace WebApi_Biblioteca.Data.Dtos.EmprestimoDtos;

public class GetEmprestimosDto
{
    public int EmprestimoId { get; set; }

    public int AlunoId { get; set; }

    public int FuncionarioId { get; set; }


    public DateTime Hora { get; set; }
    public DateTime? Devolucao { get; set; }


}
