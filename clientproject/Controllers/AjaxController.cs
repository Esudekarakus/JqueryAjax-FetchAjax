using Microsoft.AspNetCore.Mvc;

namespace clientproject.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
