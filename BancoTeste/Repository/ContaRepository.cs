using BancoTeste.Context;
using BancoTeste.Models;
using BancoTeste.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BancoTeste.Repository
{
    public class ContaRepository : BaseRepository, IContaRepository
    {
        public ContaRepository(BancoTesteContext context) : base(context)
        {
            
        }
        public async Task<List<Conta>> GetContasAll()
        {
            return await _context.Conta
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Conta> GetContaById(Guid id)
        {
            return await _context.Conta
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

/* O método AsNoTracking() não criará objetos no cache do contexto para as entidades
 retornadas por essa consulta, o que pode reduzir o consumo de memória e o tempo de execução.*/

/* FirstOrDefault : Ele retorna primeiro elemento específico de uma coleção de elementos se 
 um ou mais objetos forem encontrados para esse elemento.*/