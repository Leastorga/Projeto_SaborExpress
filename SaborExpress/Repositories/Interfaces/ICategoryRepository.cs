using SaborExpress.Models;


namespace SaborExpress.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
//Retorna uma coleção de categorias e percorre ela sequencialmente, funciona apenas para leitura.