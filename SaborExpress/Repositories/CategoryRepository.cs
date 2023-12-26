using SaborExpress.Context;
using SaborExpress.Models;
using SaborExpress.Repositories.Interfaces;

namespace SaborExpress.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        // Quero retornar uma coleção de categorias, para isso preciso acessar o banco.Logo, Tenho que acessar o banco, para isso vamos instanciar o context.
        private readonly AppDbContext _Context;

        public CategoryRepository(AppDbContext context)
        {
            _Context = context;
        }

        public IEnumerable<Category> Categories => _Context.Categories; 
    }
}
