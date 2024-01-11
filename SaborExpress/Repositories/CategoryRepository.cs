using SaborExpress.Context;
using SaborExpress.Models;
using SaborExpress.Repositories.Interfaces;

namespace SaborExpress.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories => _context.Categories; 
    }
}

// Aqui utilizamos uma injeção de depêndencia nativa do Asp.Net para injetar uma instância do serviço do contexto e através do construtor eu realizo a injenção de dependência.
// Quero retornar uma coleção de categorias, para isso preciso acessar o banco.Logo, Tenho que acessar o banco, para isso vamos instanciar o context.