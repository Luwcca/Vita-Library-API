﻿namespace WebApi_Biblioteca.Data.Dtos.PeriodicoDtos
{
    public class UpdatePeriodicoDto
    {
        public string? Nome { get; set; }
        public string? Assunto { get; set; }
        public int? Tombo { get; set; }
        public bool? Status { get; set; }
        public string? Autor { get; set; }
    }
}
