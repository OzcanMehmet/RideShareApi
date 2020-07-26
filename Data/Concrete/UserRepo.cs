using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RideShare.Model;
using RideShare.Helpers;

namespace RideShare.Data.Concrete
{
    public class UserRepo : IUserRepo
    {
        private ApiContext _context { get; set; }
        private readonly AppSettings _appSettings;
        public UserRepo(ApiContext context,IOptions<AppSettings> appSettings)
        {
            _context     = context;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.User.ToList();
        }

        public User Authentication(string mail, string password)
        {
            User currentuser = _context.User.FirstOrDefault(x=>x.Email==mail && x.Password==password);
            if(currentuser==null)
                return null;
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            
            byte[] key = System.Text.Encoding.ASCII.GetBytes(_appSettings.Secret);
            
            SecurityTokenDescriptor tokendescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Email,currentuser.Email),   
                    new Claim(ClaimTypes.Name,currentuser.Name)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha512Signature)
            };
            SecurityToken token  = handler.CreateToken(tokendescriptor);
            currentuser.Token    = handler.WriteToken(token);
            _context.SaveChanges();

            return currentuser;
        }

    

        public User GetUser(string Email)
        {
            return _context.User.FirstOrDefault(x=>x.Email==Email);
        }
    }
}