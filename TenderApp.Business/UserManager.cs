using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Business.Abstract;
using TenderApp.Core.Utilities;
using TenderApp.DataAccess.Abstract;
using TenderApp.Entities;
using TenderApp.Entities.DTOs;

namespace TenderApp.Business
{
    public class UserManager : IUserService
    {
         private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        
        public async Task Add(User user)
        {
          await _userDal.AddAsync(user);
        }
        public async Task Delete(Guid id)
        {
            var user = await _userDal.Get(u => u.Id == id);
            await _userDal.DeleteAsync(user);
        }

        public async Task<List<User>> GetAll()
        {
            return await _userDal.GetAll();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _userDal.Get(u=>u.Id == id);
        }
        public async Task Update(User user)
        {
            await _userDal.UpdateAsync(user);
        }
        public async Task<string> Login(LoginDto loginDto)
        {
            var user= await GetByMail(loginDto.Email);

            if (user is null)
                throw new Exception("User not found");

            var password = Encrpt(loginDto.Password);
            if (user.Password != password)
                throw new Exception("Password is wrong");

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Surname,user.LastName),
            };
            var token =JWTHelper.GenerateToken(claims);
            return token;
        }
        private static string Encrpt(string password)
        {
            using var md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[]hashBytes=md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }

        public async  Task<User> GetByMail(string mail)
        {
           return  await _userDal.Get(u => u.Email == mail);
        }
    }
}
