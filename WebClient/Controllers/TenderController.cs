using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{

    public class TenderController : Controller
    {
        public IActionResult Index()
        {
            string status = "0";
            if (TempData["Status"] is not null)
                status = TempData["Status"].ToString();
            TempData["Status"] = 0;

            if (status == "1")
            {
                return View();
            }
            return RedirectToAction("Login", "Auth");
           
        }
        public IActionResult TenderDetail()
        {
            return View();
        }
    }
}
