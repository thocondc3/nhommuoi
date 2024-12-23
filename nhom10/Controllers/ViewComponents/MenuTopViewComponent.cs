﻿using Microsoft.AspNetCore.Mvc;
using nhom10.Models;

namespace nhom10.Controllers.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly Nhom10Context _context;
        public MenuTopViewComponent(Nhom10Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbMenus.Where(m => (bool)m.IsActive).
                OrderBy(m => m.Position).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
