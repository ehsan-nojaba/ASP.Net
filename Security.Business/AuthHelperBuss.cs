using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Security.BusinessServiceContract;
using Security.DomainModel.DTO.User;
using Security.DomainModel.Model;

namespace Security.Business
{
    public class AuthHelperBuss:IAuthHelperBuss
    {
        private IHttpContextAccessor contextAccessor;

        public AuthHelperBuss(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public void SignIn(UserInfo account)
        {
            var claims = new List<Claim>
            {
                new Claim("UserId", account.UserId.ToString()),
                new Claim(ClaimTypes.Name, account.UserName),
                new Claim("RoleId", account.RoleId.ToString()),
                new Claim("RoleName", account.RoleName),
                new Claim("FullName", account.FullName),
                new Claim("Email", account.Email),
                new Claim("Mobile", account.Mobile),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20)
                ,
                IsPersistent = true

                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };
        }

        public void SignOut()
        {
            contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public UserInfo GetCurrentUserInfo()
        {
            if (contextAccessor.HttpContext.User.Claims.FirstOrDefault() == null)
            {
                return new UserInfo();
            }
            var claims = contextAccessor.HttpContext.User.Claims.ToList();
            var userId = int.Parse(claims.First(x => x.Type == "UserId").Value);
            var userName = claims.First(x => x.Type == ClaimTypes.Name).Value;
            var roleId = int.Parse(claims.First(x => x.Type == "RoleId").Value);
            var roleName = claims.First(x => x.Type == "RoleName").Value;
            var fullName = claims.First(x => x.Type == "FullName").Value;
            var mobile = claims.First(x => x.Type == "Mobile").Value;
            var email = claims.First(x => x.Type == "Email").Value;
            return new UserInfo { FullName = fullName, RoleId = roleId, RoleName = roleName, UserId = userId, UserName = userName, Email = email, Mobile = mobile };
        }
    }
}