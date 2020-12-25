using IdentityServer4Hotel.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4Hotel.Services
{
    public interface IAuthencationService
    {
        public Task<IdentityResult> RegisterAsync(RegisterViewModel model);
        public Task<SignInResult> SignInAsync(LoginMetaModel model);
    }
}
