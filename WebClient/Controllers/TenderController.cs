using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.Json;
using WebClient.Models.DeserializeModels;
using WebClient.Models.FilterModels;

namespace WebClient.Controllers
{

    public class TenderController : Controller
    {
        private readonly HttpClient client = new HttpClient();
       
        public async Task<IActionResult> Index(string brand, string year, string location, string fuel, string gear)
        {
            var response = await client.GetAsync(new Uri("https://localhost:44354/api/Tender/GetAll"));
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<TenderData>(content);

            if (brand is not null
             || year is not null
             || location is not null
             || fuel is not null
             || gear is not null)
            {
                if (brand is not null)
                    data.data = data.data.Where(d => d.car.brand.ToUpper() == brand.ToUpper()).ToList();
                if (year is not null)
                    data.data = data.data.Where(d => d.car.year == Convert.ToInt32(year)).ToList();
                if (location is not null)
                    data.data = data.data.Where(d => d.car.location.ToUpper() == location.ToUpper()).ToList();
                if (fuel is not null)
                    data.data = data.data.Where(d => d.car.fuelType.ToUpper() == fuel.ToUpper()).ToList();
                if (gear is not null)
                    data.data = data.data.Where(d => d.car.gear.ToUpper() == gear.ToUpper()).ToList();
            }
            return View(data);
        }

        [Route("Tender/TenderDetail/{id}")]
        public async Task <IActionResult> TenderDetail(Guid id)
        {
            var response = await client.GetAsync(new Uri($"https://localhost:44354/api/Tender/GetById?id={id}"));
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<TenderDetailData>(content);
            return View(data);
        }

        


    }
}
