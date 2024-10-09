﻿namespace ClientesApp.Application.Events
{
    public class ClienteCadastradoEvent
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string? MensagemCadastro { get; set; }
    }
}