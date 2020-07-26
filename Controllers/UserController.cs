using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using RideShare.Data;
using RideShare.Model;
using RideShare.Model.DTO;
using RideShare.Model.DTO.User;

namespace  RideShare.Controller 
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]  
    public class UserController : ControllerBase
    {
        private IUserRepo _userRepo          { get; set; }
        private IMapper         _mapper      { get; set; }
        public UserController(IUserRepo userRepo,IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper   = mapper;        
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserLogin userParam)
        {
           User currentuser =  _userRepo.Authentication(userParam.Email,userParam.Password);
           if(currentuser==null)
                return NotFound("Kullanıcı bulanamadı");
           return Ok(_mapper.Map<User,UserDTO>(currentuser));

        }

       
        [HttpPost("test")]
        public IActionResult AllUser()
        {
            //_userRepo.GetUsers()
           return Ok();

        }


    }
}