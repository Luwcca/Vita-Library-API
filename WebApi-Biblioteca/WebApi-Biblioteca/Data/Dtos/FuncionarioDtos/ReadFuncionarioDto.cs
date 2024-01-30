namespace WebApi_Biblioteca.Data.Dtos.FuncionarioDtos
{
    public class ReadFuncionarioDto
    {
        public int FuncionarioId { get; set; }
        public string? Nome { get; set; }
        public int? Telefone { get; set; }
        public int? CPF { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; }
        public string? Login { get; set; }
    }
}
