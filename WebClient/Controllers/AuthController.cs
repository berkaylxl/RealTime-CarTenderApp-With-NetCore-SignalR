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


                HttpContext.Session.SetString("Token", data.data.token);
                //HttpContext.Response.Cookies.Append("token", data.data.token);
                //System.Threading.Thread.Sleep(1000);
                return RedirectToAction("Index","Tender");
            }
            else
            {

                return View();
            }



        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
