using BancoTeste.Context;
using BancoTeste.Models;
using BancoTeste.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BancoTeste.Repository
{
    public class CategoriaRepository : BaseRepository, ICategoriaRepository
    {
        public CategoriaRepository(BancoTesteContext context) : base(context)
        {
            
        }

        public async Task<List<Categoria>> GetCategoriasAll()
        {
            return await _context.Categoria.AsNoTracking().ToListAsync();
        }

        public async Task<Categoria> GetCategoriaById(Guid id)
        {
            return await _context.Categoria.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}


/* ToListAsync() executa a consulta de forma assíncrona e retorna uma lista de entidades como uma tarefa (Task) assíncrona*/