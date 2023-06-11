using BancoTeste.Models;

namespace BancoTeste.Repository.Interfaces
{
    public interface IContaRepository : IBaseRepository
    {
        Task<List<Conta>> GetContasAll();
        Task<Conta> GetContaById(Guid id);
    }
}
