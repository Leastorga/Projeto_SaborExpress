using SaborExpress.Models;

namespace SaborExpress.Repositories.Interfaces
{
    public interface ISnackRepository
    {
        IEnumerable<Snack> Snacks { get; }
        IEnumerable<Snack> FavoriteSnack { get; }
        Snack GetSnackById(int snackId);

    }
}
