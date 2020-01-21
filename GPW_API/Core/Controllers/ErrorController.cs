using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GPW_API.Core.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {

        private readonly ILogger<ErrorController> _logger;


        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }



        [Route("/error")]
        public IActionResult Error()
        {
            var exceptionDetail = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _logger.LogError($"The Path{exceptionDetail.Path} threw an exception: {exceptionDetail.Error}");


            return Problem();
        }
    }
}