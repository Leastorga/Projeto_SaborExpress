using Microsoft.EntityFrameworkCore;
using SaborExpress.Context;
using SaborExpress.Models;

namespace SaborExpress.Areas.Admin.Services
{
    public class SalesServiceReport
    {
        private readonly AppDbContext context;
        public SalesServiceReport(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Order>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in context.Orders select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.OrderDispatched >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.OrderDispatched <= maxDate.Value);
            }

            return await result
                .Include(l => l.OrderItems)
                .ThenInclude(l => l.Snack)
                .OrderByDescending(l => l.OrderDispatched)
                .ToListAsync();
        }
    }
}
