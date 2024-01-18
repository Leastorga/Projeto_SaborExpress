using SaborExpress.Models;

namespace SaborExpress.Repositories.Interfaces
{
    public interface ISnackRepository
    {
        IEnumerable<Snack> Snacks { get; }
        IEnumerable<Snack> FavoriteSnack{ get; }
        Snack GetSnackById(int snackId);

    }
}
// Aqui vamos ter a propriedade só para leitura lanches que retorna uma lista de objetos
// Aqui vamos ter a propriedade Só para leitura Lanches favoritos que retorna um lista de objetos lanches onde iremos filtrar apenas os lanches preferidos.
// O método GetLancheById irá retornar um objeto no caso um lanche através do seu Id.