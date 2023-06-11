using BancoTeste.Models;
using BancoTeste.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BancoTeste.Controllers
{
    public class ContasController : Controller
    {
        private readonly IContaRepository _contaRepository;

        public ContasController(IContaRepository categoriaRepository)
        {
            _contaRepository = categoriaRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contaRepository.GetContasAll());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _contaRepository.GetContaById(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nome")] Conta conta)
        {
            if (ModelState.IsValid)
            {
                conta.Id = Guid.NewGuid();
                _contaRepository.Add(conta);
                await _contaRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conta);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await _contaRepository.GetContaById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Codigo,Nome")] Conta conta)
        {
            if (ModelState.IsValid)
            {
                _contaRepository.Update(conta);
                await _contaRepository.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(conta);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            return View(await _contaRepository.GetContaById(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var conta = await _contaRepository.GetContaById(id);
            if (conta != null)
            {
                _contaRepository.Delete(conta);
            }

            await _contaRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
