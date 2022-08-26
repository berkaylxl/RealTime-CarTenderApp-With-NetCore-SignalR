using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
	public class AuthController : Controller
	{
		public IActionResult Login()
		{

			return View();
		}

		[HttpPost]
        public IActionResult Login(string a)
        {
            return Ok();
        }

        public IActionResult Register()
		{
            return View();
        }
	}
}
