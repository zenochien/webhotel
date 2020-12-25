using IdentityServer4Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4Hotel.Services
{
    public interface ITokenService
    {
        Task<UserToken> BuildTokenAsync(LoginMetaModel model);
    }
}
