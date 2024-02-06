using SaborExpress.Context;
using SaborExpress.Models;

namespace SaborExpress.Areas.Admin.Services
{
    public class SalesServiceChart
    {
        private readonly AppDbContext context;

        public SalesServiceChart(AppDbContext context)
        {
            this.context = context;
        }

        public List<GraficSnack> GetSnacksSales(int days = 360)
        {
            var date = DateTime.Now.AddDays(-days);
            var snacks = (from pd in context.OrderDetails
                          join l in context.Snacks on pd.SnackId equals l.SnackId
                          where pd.Order.OrderDispatched >= date
                          group pd by new
                          {
                              pd.SnackId, l.Name, pd.Quantity
                          } into g
                          select new
                          {
                              SnackName = g.Key.Name,
                              SnacksQuantity = g.Sum(q => q.Quantity),
                              SnacksTotalValue = g.Sum(a => a.Price * a.Quantity)
                          });

            var list = new List<GraficSnack>();
            foreach(var item in snacks)
            {
                var snack = new GraficSnack();
                snack.SnackName = item.SnackName;
                snack.SnacksQuantity = item.SnacksQuantity;
                snack.SnacksTotalValue = item.SnacksTotalValue;
                list.Add(snack);
            }
            return list;
        }
    }
}
