using Microsoft.AspNetCore.Mvc;
using SiteLanche.Repositories;
using System.Linq;

namespace SiteLanche.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public IViewComponentResult Invoke()
        {
            var categoria = _categoriaRepository.Categorias.OrderBy(c => c.CategoriaNome);
            return View(categoria);
        }
    }
}
