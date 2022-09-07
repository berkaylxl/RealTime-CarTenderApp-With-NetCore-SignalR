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
    public class AuthController : ControllerBase
    {
        //Only Admin and Support
        private readonly IAuthService _authService;
        private readonly IValidator<User> _loginValidator;
        private readonly IValidator<IndividualCustomer> _inRegisterValidator;
        private readonly IValidator<CorporateCustomer> _coRegisterValidator;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IValidator<User> validator, IMapper mapper, IValidator<IndividualCustomer> inRegisterValidator, IValidator<CorporateCustomer> coRegisterValidator)
        {
            _authService = authService;
            _loginValidator = validator;
            _mapper = mapper;
            _inRegisterValidator = inRegisterValidator;
            _coRegisterValidator = coRegisterValidator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var validResult = await _loginValidator.ValidateAsync(_mapper.Map<User>(loginDto));

            if (validResult.IsValid)
            {

                return Ok(await _authService.Login(loginDto));
            }
            return BadRequest(ValidateHelper.SendValidateMessage(validResult));
        }
        [HttpPost]
        public async Task<IActionResult> IndividualRegister([FromBody] IndividualRegisterDto registerDto)
        {
            var validResult = await _inRegisterValidator.ValidateAsync(_mapper.Map<IndividualCustomer>(registerDto));

            if (validResult.IsValid)
            {
                return Ok(await _authService.IndividualRegister(registerDto));
            }

            return BadRequest(ValidateHelper.SendValidateMessage(validResult));
        }
        [HttpPost]
        public async Task<IActionResult> CorporateRegister([FromBody] CorporateRegisterDto registerDto)
        {
            var validResult = await _coRegisterValidator.ValidateAsync(_mapper.Map<CorporateCustomer>(registerDto));

            if (validResult.IsValid)
            {
                return Ok(await _authService.CorporateRegister(registerDto));
            }

            return BadRequest(ValidateHelper.SendValidateMessage(validResult));
        }

        [HttpGet]
        public async Task<IActionResult> GetByUserEmail(string email)
        {
            var data =await _authService.GetIdByMail(email);
            return Ok(data);
        }


    }
}
