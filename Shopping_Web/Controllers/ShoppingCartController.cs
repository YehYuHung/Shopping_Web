using Microsoft.AspNetCore.Mvc;

namespace Shopping_Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
