using Microsoft.Build.Framework;

namespace BancoTeste.Models
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public Guid ContaId { get; set; }
        public Conta Conta { get; set; }
        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public string Historico { get; set; }
        public DateTime Data { get; set; }
        public decimal Debito { get; set; }
        public decimal Credito { get; set; }
        public bool Conciliado { get; set; }
        public string Notas { get; set; }        
    }
}