using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenderApp.Business.Services.Abstract;
using TenderApp.Entities;

namespace TenderApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CorporateCustomerController : ControllerBase
    {
        private readonly ICorporateCustomerService _corporateCustomerService;

        public CorporateCustomerController(ICorporateCustomerService corporateCustomerService)
        {
            _corporateCustomerService = corporateCustomerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _corporateCustomerService.GetAll();
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var res = await _corporateCustomerService.GetById(id);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _corporateCustomerService.DeleteById(id));
        }
        [HttpPut]
        public async Task<IActionResult> Update(CorporateCustomer customer)
        {
            return Ok(await _corporateCustomerService.Update(customer));
        }
    }
}
