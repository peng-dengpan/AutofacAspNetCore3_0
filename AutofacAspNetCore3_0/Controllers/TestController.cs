
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutofacAspNetCore3_0.MiddleLayer;
using AutofacAspNetCore3_0.Models;
using AutofacAspNetCore3_0.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutofacAspNetCore3_0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public readonly IConsumerService _consumerService;
        public TestController(IConsumerService consumerService)
        {
            this._consumerService = consumerService;
        }
        public events events { get; set; }

        // GET api/Home
        [HttpGet]
        public string Get()
        {
            return this._consumerService.ToString();
        }

        // GET api/Home/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return this.events.ToString();
        }
    }
}
