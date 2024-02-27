using Microsoft.AspNetCore.Mvc;

namespace clientproject.Controllers
{
    public class FetchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
