using BancoTeste.Models;

namespace BancoTeste.Repository.Interfaces
{
    public interface ITransacaoRepository : IBaseRepository
    {
        Task<List<Transacao>> GetTransacoesAll();
        Task<Transacao> GetTransacaoById(Guid id);
        Task<List<Transacao>> GetTransacaoByDate(DateTime initialDate, DateTime finalDate);
        Task<List<Transacao>> GetExtratoByAccount(string conta);
    }
}
