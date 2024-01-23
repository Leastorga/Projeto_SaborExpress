using Microsoft.AspNetCore.Mvc;
using SaborExpress.Repositories.Interfaces;

namespace SaborExpress.Components
{
    public class MenuCategory : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public MenuCategory(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.Categories.OrderBy(x => x.CategoryName);
            return View(categories);
        }
    }
}
