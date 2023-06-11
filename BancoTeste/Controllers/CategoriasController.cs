using BancoTeste.Models;
using BancoTeste.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BancoTeste.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriasController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View( await _categoriaRepository.GetCategoriasAll());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            return View( await _categoriaRepository.GetCategoriaById(id));
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Tipo")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.Id = Guid.NewGuid();
                _categoriaRepository.Add(categoria);
                await _categoriaRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await _categoriaRepository.GetCategoriaById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Tipo")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepository.Update(categoria);
                await _categoriaRepository.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            return View(await _categoriaRepository.GetCategoriaById(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var categoria = await _categoriaRepository.GetCategoriaById(id);
            if (categoria != null)
            {
                _categoriaRepository.Delete<Categoria>(categoria);
            }
            
            await _categoriaRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }        
    }
}
