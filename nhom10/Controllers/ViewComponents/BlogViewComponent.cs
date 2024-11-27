using nhom10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace nhom10.Controllers.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        public readonly Nhom10Context _context;

        public BlogViewComponent(Nhom10Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbBlogs.Where(m => (bool)m.IsActive).ToList();

            return await Task.FromResult<IViewComponentResult>(View(items));
        }


    }
}

