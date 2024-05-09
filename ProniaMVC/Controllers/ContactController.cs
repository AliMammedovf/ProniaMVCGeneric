using Microsoft.AspNetCore.Mvc;

namespace ProniaTemplate.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
