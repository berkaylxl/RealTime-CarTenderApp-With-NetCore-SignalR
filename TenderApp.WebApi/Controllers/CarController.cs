using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenderApp.Business.Services.Abstract;

namespace TenderApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _carService.GetAll();
            return Ok(res);
        }
    }
}
