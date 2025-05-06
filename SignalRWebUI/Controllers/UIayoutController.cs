using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class UIayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
