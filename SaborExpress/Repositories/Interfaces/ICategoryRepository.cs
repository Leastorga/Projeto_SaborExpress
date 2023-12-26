using SaborExpress.Models;

namespace SaborExpress.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

    }
}
