using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class TenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
