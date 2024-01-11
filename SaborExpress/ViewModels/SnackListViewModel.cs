using SaborExpress.Models;

namespace SaborExpress.ViewModels
{
    public class SnackListViewModel
    {
        public IEnumerable<Snack> Snacks { get; set; }
        public string CurrentCategory{ get; set; }
    }
}
