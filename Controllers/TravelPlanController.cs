using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using RideShare.Data;
using RideShare.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RideShare.Middleware;
using RideShare.Model.DTO.TravelPlan;

namespace RideShare.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]  
    public class TravelPlanController : ControllerBase
    {
        private IUserRepo       _userRepo    { get;set; }
        private ITravelPlanRepo _travelplan  { get;set; }
        private IMapper         _mapper      { get;set; }
        public TravelPlanController(IUserRepo userRepo,ITravelPlanRepo travelPlanRepo,IMapper mapper)
        {
           _userRepo   = userRepo;  
           _travelplan = travelPlanRepo; 
           _mapper     = mapper;
        }
        
       
        [HttpPost("Plans")]
        [ValidateModelState] 
        public IActionResult PostPlan(TravelPlanCreate plan)
        {
           User CurrentUser = null;
           string Email = User.FindFirst(ClaimTypes.Email)?.Value;
           if(Email!=string.Empty)
           {
                CurrentUser     = _userRepo.GetUser(Email);
                TravelPlan Plan = _mapper.Map<TravelPlanCreate,TravelPlan>(plan);
                Plan.Owner      = CurrentUser;
                _travelplan.Add(Plan);
                return new CreatedResult($"plans/{Plan.Id}",plan);

           }         
            return NotFound("Kullanıcı bulunamadı.");      

        }

        [HttpPut("Plans/{id}/Valid")]
        public IActionResult PutPlanAvailable(int id)
        {
            TravelPlan plan = _travelplan.GetById(id);
            if(plan!=null)
            {
                _travelplan.SetValid(plan);
                return Ok();
            }
            return NotFound("Plan bulunamadı.");
            
        }

        [HttpPut("Plans/{id}/InValid")]
        public IActionResult PutPlanDisable(int id)
        {
            TravelPlan plan = _travelplan.GetById(id);
            if(plan!=null)
            {
                _travelplan.SetInValid(plan);
                return Ok();
            }
            return NotFound("Plan bulunamadı.");
            
        }

        [HttpGet("Plans")]
        public IActionResult GetPlanList()
        {
            string Email = User.FindFirst(ClaimTypes.Email)?.Value;
            if(Email!=string.Empty)
            {
                IEnumerable<TravelPlan> plans = _travelplan.GetTravelPlansByEmail(Email);

                return Ok(_mapper.Map<IEnumerable<TravelPlan>,IEnumerable<TravelPlanInfo>>(plans));
            }
           
            return NotFound("Kullanıcı bulunamadı.");  

            
        }
        [HttpGet("Plans/{id}",Name="")]
        public IActionResult GetPlan(int id)
        {
            string Email = User.FindFirst(ClaimTypes.Email)?.Value;
            if(Email!=string.Empty)
            {
                IEnumerable<TravelPlan> plans = _travelplan.GetTravelPlansByEmail(Email);
                TravelPlan plan = plans.FirstOrDefault(x=>x.Id==id);
                return Ok(_mapper.Map<TravelPlan,TravelPlanInfo>(plan));
            }
           
            return NotFound("Kullanıcı bulunamadı.");  

            
        }

        [HttpGet("Plans/Search/")]
        [ValidateModelState] 
        public IActionResult GetPlanSearch(TravelPlanSearchRequest searchRequest)
        {
            IEnumerable<TravelPlan>  plans = _travelplan.List(x=>x.To.ToLower()==searchRequest.To.ToLower() 
                    && x.From.ToLower()==searchRequest.From.ToLower() && x.Valid);  
            return Ok(_mapper.Map<IEnumerable<TravelPlan>,IEnumerable<TravelPlanInfo>>(plans));          
        } 

        [HttpPost("Plans/Rent")]
        [ValidateModelState] 
        public IActionResult PostRentSeat(TravelGuestRequest planrequest)
        {

            string Email = User.FindFirst(ClaimTypes.Email)?.Value;
            if(Email!=string.Empty)
            {
               User CurrentUser =  _userRepo.GetUser(Email);
               /// aynı user için kiralama işlemini testte kolaylık olsun diye eklemedim.
               TravelPlan plan = _travelplan.ListWithGuests(x=>x.Id==planrequest.PlanId && x.Valid).FirstOrDefault();
               
               if(plan!=null)
               {
                  int validseat = plan.SeatCount-plan.TravelGuest.Sum(x=>x.RezervedSeatCount);
                  if(validseat<planrequest.Seat)
                     return  NotFound("Yeterli koltuk yok");
                  if(plan.Date<DateTime.Now)
                    return  NotFound("Plan tarihi geçmiş");
                     
                  TravelGuest guest =new TravelGuest{
                      Plan = plan,
                      Guest = CurrentUser,
                      RezervedSeatCount = planrequest.Seat
                  };
                  plan.TravelGuest.Add(guest);                
                  _travelplan.Update(plan);
                  return Ok();
               }
               return NotFound("Plan bulunamadı.");
            }
            
            return BadRequest();
        }    
  
    }
}
