using BancoTeste.Context;
using BancoTeste.Models;
using BancoTeste.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BancoTeste.Repository
{
    public class TransacaoRepository : BaseRepository, ITransacaoRepository
    {
        public TransacaoRepository(BancoTesteContext context) : base(context)
        {
            
        }
        public async Task<List<Transacao>> GetTransacoesAll()
        {
            return await _context.Transacao
                .Include(x => x.Conta)
                .Include(x => x.Categoria)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Transacao> GetTransacaoById(Guid id)
        {
            return await _context.Transacao
                .Include(x => x.Conta)
                .Include(x => x.Categoria)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Transacao>> GetTransacaoByDate(DateTime initialDate, DateTime  finalDate)
        {
            return await _context.Transacao
                .Include(x => x.Conta)
                .Include(x => x.Categoria)
                .AsNoTracking()
                .Where(x => x.Data >= initialDate && x.Data <= finalDate)
                .ToListAsync();
        }

        public async Task<List<Transacao>> GetExtratoByAccount(string conta)
        {
            return await _context.Transacao
                .Include(x => x.Conta)
                .AsNoTracking()
                .Where(x => x.Conta.Codigo.Equals(conta))
                .OrderBy(x => x.Data)
                .ToListAsync();
        }
    }
}

//utilizei váriasa expressões LAMBDA com o objetivo de manter um código limpo.