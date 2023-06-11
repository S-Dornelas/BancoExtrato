using BancoTeste.Models;

namespace BancoTeste.Repository.Interfaces
{
    public interface ICategoriaRepository : IBaseRepository
    {
        Task<List<Categoria>> GetCategoriasAll();
        Task<Categoria> GetCategoriaById(Guid id);
    }
}
