using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenderApp.Business.Services.Abstract;
using TenderApp.Core.Utilities;
using TenderApp.Core.Utilities.Security;
using TenderApp.Entities;
using TenderApp.Entities.DTOs;

namespace TenderApp.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Only Admin and Support
        private readonly IUserService _userService;
        private readonly IValidator<User> _validator;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IValidator<User> validator, IMapper mapper )
        {
            _userService = userService;
            _validator = validator;
            _mapper = mapper;
        }
       // [Authorize(Roles ="admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res =await _userService.GetAll();
            return Ok(res);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var res = await _userService.GetById(id);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            var validResult = await _validator.ValidateAsync(user);

            if (validResult.IsValid)
            {
                
                return Ok(await _userService.Add(user));
            }
            return BadRequest(ValidateHelper.SendValidateMessage(validResult));

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _userService.DeleteById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
                var res = await _userService.Login(loginDto);
            if (res != null)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var validResult = await _validator.ValidateAsync(_mapper.Map<User>(registerDto));

            if (validResult.IsValid)
            {
                return Ok(await _userService.Register(registerDto));
            }

            return BadRequest(ValidateHelper.SendValidateMessage(validResult));
        }
    }
}
