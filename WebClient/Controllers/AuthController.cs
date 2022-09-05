using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Text.Json;
using WebClient.Models;
using WebClient.Models.DeserializeModels;

namespace WebClient.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient client = new HttpClient();

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login logindto)
        {
            var response = await client.PostAsJsonAsync(new Uri("https://localhost:44354/api/Auth/Login"), logindto);

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<LoginData>(content);
            if (data.status==1)
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(data.data.token);
                var payload = token.Payload.ToArray();
                TempData["Email"] = payload[1].Value.ToString();
                TempData["Status"] = data.status.ToString();
                return RedirectToAction("Index","Tender");
            }
            else
            {
                TempData["Status"] = 0;
                return View();
            }
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
