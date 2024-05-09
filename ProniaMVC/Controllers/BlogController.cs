using Microsoft.AspNetCore.Mvc;

namespace ProniaTemplate.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
