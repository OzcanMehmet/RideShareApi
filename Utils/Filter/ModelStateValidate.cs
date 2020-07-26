using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace RideShare.Middleware
{
    public class ValidateModelState : ActionFilterAttribute
    {
     
        public override void  OnActionExecuting(ActionExecutingContext  context)
        {
            if(!context.ModelState.IsValid)
                context.Result = new BadRequestResult();
            else
                base.OnActionExecuting(context);         
        }


    }
}