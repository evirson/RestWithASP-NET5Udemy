﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstudoRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerbosMockController : ControllerBase
    {
        private readonly ILogger<VerbosMockController> _logger;

        public VerbosMockController(ILogger<VerbosMockController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult findAll()
        {


            return Ok("deu boa");

        }

        [HttpGet("{id}")]
        public IActionResult findById(int id)
        {


            return Ok(id.ToString());

        }


    }
}
