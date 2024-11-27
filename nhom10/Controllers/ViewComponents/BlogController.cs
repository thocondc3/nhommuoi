using nhom10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace harmic.Controllers.ViewComponents
{
    public class BlogController : Controller
    {
        private readonly Nhom10Context  _context;
        private readonly ILogger _logger;

        public BlogController(Nhom10Context  context, ILogger<BlogController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/blog/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null || _context.TbBlogs == null)
            {
                return NotFound();
            }


            var blog = await _context.TbBlogs.FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }

            ViewBag.blogComment = _context.TbBlogComments.Where(i => i.BlogId == id).ToList();


            return View(blog);
        }
    }
}

