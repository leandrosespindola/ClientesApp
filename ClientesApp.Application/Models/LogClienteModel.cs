namespace ClientesApp.Application.Models
{
    public class LogClienteModel
    {
        public Guid? Id { get; set; }
        public TipoOperacao? TipoOperacao { get; set; }
        public DateTime? DataOperacao { get; set; }
        public Guid? ClienteId { get; set; }
        public string? DadosClientes { get; set; }
    }

    public enum TipoOperacao
    { 
        Add = 1,
        Update = 2,
        Delete = 3
    }
}
