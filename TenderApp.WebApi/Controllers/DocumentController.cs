using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TenderApp.Business.Services.Abstract;
using TenderApp.Entities;
using TenderApp.Entities.DTOs;

namespace TenderApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;

        public DocumentController(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllByCarID(Guid carId)
        {
            return Ok( await _documentService.GetListByCarId(carId));
        }
        [HttpPost]
        public async Task<IActionResult> Add(IFormFile file, [FromForm]DocumentDto documentDto)
        {
            var document = _mapper.Map<Document>(documentDto);
            return Ok( await _documentService.Add(file, document));
        }
        [HttpDelete]
        public async Task <IActionResult> DeleteById(Guid id)
        {
            var document = await _documentService.GetById(id);
            await _documentService.Delete( document.Data);
            return Ok("Document Deleted");
        }
        [HttpPut]
        public async Task<IActionResult>Update(Guid id,bool isActive)
        {
            await _documentService.Update(id, isActive);
            return Ok("Document Updated! \n Active = "+isActive);
        }
        
    }
}
