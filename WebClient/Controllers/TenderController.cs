using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Drawing.Drawing2D;
using System.Text.Json;
using WebClient.Models.DeserializeModels;
using WebClient.Models.FilterModels;

namespace WebClient.Controllers
{

    public class TenderController : Controller
    {
        private readonly HttpClient client = new HttpClient();
        public async Task<IActionResult> Index( TenderFilter filter )
        {
            var response = await client.GetAsync(new Uri("https://localhost:44354/api/Tender/GetAll"));
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<TenderData>(content);
            // Filtrele buttonu click olduğunda gelen filter parametresi, dolu olduğunda çalışacak
            if (filter.brand is not null
             || filter.year is not null
             || filter.location is not null
             || filter.fuel is not null
             || filter.gear is not null)
            {
                if (filter.brand is not null)
                    data.data = data.data.Where(d => d.car.brand.ToUpper() == filter.brand.ToUpper()).ToList();
                if (filter.year is not null)
                    data.data = data.data.Where(d => d.car.year == Convert.ToInt32(filter.year)).ToList();
                if (filter.location is not null)
                    data.data = data.data.Where(d => d.car.location.ToUpper() == filter.location.ToUpper()).ToList();
                if (filter.fuel is not null)
                    data.data = data.data.Where(d => d.car.fuelType.ToUpper() == filter.fuel.ToUpper()).ToList();
                if (filter.gear is not null)
                    data.data = data.data.Where(d => d.car.gear.ToUpper() == filter.gear.ToUpper()).ToList();
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
        [Route("Tender/MyTenders/{userId}")]
        public async Task<IActionResult> MyTenders(string userId)
        {
            var response = await client.GetAsync(new Uri("https://localhost:44354/api/Tender/GetAll"));
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<TenderData>(content);
            var filteredData = data.data.Where(t => t.userId == userId).ToList();
            return View(filteredData);
        }
        public async Task<IActionResult> CreateTender()
        {
            return View();
        }

    }
}
