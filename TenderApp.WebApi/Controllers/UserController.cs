using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenderApp.Business.Abstract;
using TenderApp.Entities;
using TenderApp.Entities.DTOs;

namespace TenderApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Only Admin and Support
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [Authorize]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var res =_userService.GetAll();
            return Ok(res);
        }
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var res = await _userService.GetById(id);
            return Ok(res);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(User user)
        {
            await _userService.Add(user);
            return Ok(" User Added");
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.DeleteById(id);
            return Ok(" User Deleted");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginDto loginDto)
        {
            var res = await _userService.Login(loginDto);
            return Ok(res);
        }





    }
}
