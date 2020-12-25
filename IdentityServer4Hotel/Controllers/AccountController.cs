using IdentityServer4Hotel.Models;
using IdentityServer4Hotel.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4Hotel.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthencationService _authencationService;
        private readonly ITokenService _tokenService;

        public AccountController(IAuthencationService authencationService, ITokenService tokenService)
        {
            _authencationService = authencationService;
            _tokenService = tokenService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginMetaModel model)
        {
            // return token
            var result =await _authencationService.SignInAsync(model);
            if (!result.Succeeded) return BadRequest();


            return  Ok(await _tokenService.BuildTokenAsync(model));
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            var result = await _authencationService.RegisterAsync(model);
            if (!result.Succeeded) return BadRequest();


            return Ok(await _tokenService.BuildTokenAsync(new LoginMetaModel { Email=model.Email,Password=model.Password}));

        }
    }

  
 
    
}
