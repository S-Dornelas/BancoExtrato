using BancoTeste.Context;
using BancoTeste.Models;
using BancoTeste.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BancoTeste.Controllers
{
    public class TransacaoController : Controller
    {
        private readonly BancoTesteContext _context;
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IContaRepository _contaRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public TransacaoController(BancoTesteContext context, ITransacaoRepository transacaoRepository, IContaRepository contaRepository, ICategoriaRepository categoriaRepository)
        {
            _context = context;
            _transacaoRepository = transacaoRepository;
            _contaRepository = contaRepository;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _transacaoRepository.GetTransacoesAll());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _transacaoRepository.GetTransacaoById(id));
        }

        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_categoriaRepository.GetCategoriasAll().Result, "Id", "Nome");
            ViewData["ContaId"] = new SelectList(_contaRepository.GetContasAll().Result, "Id", "Codigo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContaId,CategoriaId,Historico,Data,Debito,Credito,Conciliado,Notas")] Transacao transacao)
        {
            transacao.Id = Guid.NewGuid();
            _transacaoRepository.Add(transacao);
            await _transacaoRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var transacao = await _transacaoRepository.GetTransacaoById(id);
            
            ViewData["CategoriaId"] = new SelectList(_categoriaRepository.GetCategoriasAll().Result, "Id", "Nome", transacao.CategoriaId);
            ViewData["ContaId"] = new SelectList(_contaRepository.GetContasAll().Result, "Id", "Codigo", transacao.ContaId);
            return View(transacao);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ContaId,CategoriaId,Historico,Data,Debito,Credito,Conciliado,Notas")] Transacao transacao)
        {
            _transacaoRepository.Update(transacao);
            await _transacaoRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            return View(await _transacaoRepository.GetTransacaoById(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var transacao = await _transacaoRepository.GetTransacaoById(id);
            if (transacao != null)
            {
                _context.Transacao.Remove(transacao);
            }
            
            await _transacaoRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransacaoExists(Guid id)
        {
          return (_context.Transacao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Extrato(string conta)
        {
            return View(await _transacaoRepository.GetExtratoByAccount("0008"));
        }
    }
}

//Fiz a inclusão dos dados de Extrato aqui, uma vez que as informações pertinentes ao processo está nesse Controler