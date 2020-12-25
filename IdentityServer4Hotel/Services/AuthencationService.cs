using AutoMapper;
using IdentityServer4Hotel.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4Hotel.Services
{
    public class AuthencationService : IAuthencationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        public AuthencationService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterViewModel model)
        {
            var user = _mapper.Map<User>(model);
            return await _userManager.CreateAsync(user, model.Password);
        }

        public async Task<SignInResult> SignInAsync(LoginMetaModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email, model.Password,false,false);
        }
    }
}
