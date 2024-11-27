using nhom10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace harmic.Controllers.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        public readonly Nhom10Context _context;

        public ProductViewComponent(Nhom10Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbProducts.Include(m => m.CategoryProduct).Where(m => (bool)m.IsActive)
                .Where(m => m.IsNew);
            return await Task.FromResult<IViewComponentResult>
    (View(items.OrderByDescending(m => m.ProductId).ToList()));
        }
    }
}
