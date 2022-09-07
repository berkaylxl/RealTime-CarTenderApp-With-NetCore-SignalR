using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenderApp.Business.Services.Abstract;
using TenderApp.Entities;

namespace TenderApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly ITenderService _tenderService;
        public TenderController(ITenderService tenderService)
        {
            _tenderService = tenderService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _tenderService.GetAll();
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var res = await _tenderService.GetById(id);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Tender tender)
        {
            var res = await _tenderService.Add(tender);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _tenderService.Delete(id));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Tender tender)
        {
            return Ok(await _tenderService.Update(tender));
        }


    }
}
