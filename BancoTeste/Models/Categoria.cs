namespace BancoTeste.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Transacao = new HashSet<Transacao>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Tipo { get; set; }

        public ICollection<Transacao> Transacao { get; set; }
    }
}

// com a pripriedade  public ICollection<Transacao> Transacao { get; set; } foi representada a cardinalidade 1:N
//a propriedade GUID é a KEY