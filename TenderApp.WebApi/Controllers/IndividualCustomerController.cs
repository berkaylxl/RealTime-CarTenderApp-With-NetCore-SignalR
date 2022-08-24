using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenderApp.Business.Services.Abstract;
using TenderApp.Entities;

namespace TenderApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IndividualCustomerController : ControllerBase
    {
        private readonly IIndividualCustomerService _individualCustomerService;

        public IndividualCustomerController(IIndividualCustomerService individualCustomerService)
        {
            _individualCustomerService = individualCustomerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _individualCustomerService.GetAll();
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var res = await _individualCustomerService.GetById(id);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _individualCustomerService.DeleteById(id));
        }
        [HttpPut]
        public async Task<IActionResult> Update(IndividualCustomer customer)
        {
            return Ok(await _individualCustomerService.Update(customer));
        }
    }
}
