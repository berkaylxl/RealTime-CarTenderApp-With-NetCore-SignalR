using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenderApp.Business.Services.Abstract;
using TenderApp.Entities;

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
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var res = await _carService.GetById(id);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Car car)
        {
            var res = await _carService.Add(car);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _carService.Delete(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Car car)
        {
            return Ok(await _carService.Update(car));
        }
    }
}
