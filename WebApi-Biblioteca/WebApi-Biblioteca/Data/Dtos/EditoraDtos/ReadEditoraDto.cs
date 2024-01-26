namespace WebApi_Biblioteca.Data.Dtos.EditoraDtos;

public class ReadEditoraDto
{
    public int EditoraId { get; set; }
    public string? Nome { get; set; }
    public string? Endereco { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? UF { get; set; }
}
