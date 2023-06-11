using BancoTeste.Context;
using BancoTeste.Repository.Interfaces;

namespace BancoTeste.Repository
{
    public class BaseRepository : IBaseRepository
    {        
        public BancoTesteContext _context { get; set; }

        public BaseRepository(BancoTesteContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Set<T>().AddAsync(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}


/*Esta classe foi definida para dar uma estrutura básica para a implementação de operações de acesso a dados
 com as demais classes, bem como ajudando a reduzir duplicidade de código e a troca de BD posteriores*/
