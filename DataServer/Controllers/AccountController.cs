using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using DataServer.Models;
using DataServer.Providers;
using DataServer.Results;
using DataServer.Role;
using Frontend.Model;

namespace DataServer.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
		#region Private members

		private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;
		private ApplicationRoleManager _roleManager;

		#endregion Private members

		#region Ctors

		public AccountController()
        {

        }

        public AccountController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

		#endregion Ctors

		#region Properties

		public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

		public ApplicationRoleManager RoleManager
		{
			get
			{
				return _roleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
			}
			private set
			{
				_roleManager = value;
			}
		}

		public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

		#endregion Properties

		#region Public methods

		[Authorize(Roles = "admin")]
		[Route("GetAll")]
		public List<FrontendUserModel> GetAll()
		{
			List<FrontendUserModel> userList = new List<FrontendUserModel>();
			foreach(ApplicationUser appuser in UserManager.Users)
			{
				if(appuser.UserName != "admin")
				{
					List<string> roleNames = new List<string>();
					foreach(IdentityUserRole role in appuser.Roles)
					{
						roleNames.Add(RoleManager.FindById(role.RoleId).Name);
					}
					userList.Add(new FrontendUserModel { Login = appuser.UserName, Roles = roleNames });
				}
			}
			return userList;
		}

		[Route("GetRoles")]
		public List<string> GetRoles()
		{
			return ApplicationRoleManager.DefinedRoles;
		}

		[Route("GetCurrentRoles")]
		public List<string> GetCurrentRoles()
		{
			ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());
			List<string> roleNames = new List<string>();
			foreach (IdentityUserRole role in currentUser.Roles)
			{
				roleNames.Add(RoleManager.FindById(role.RoleId).Name);
			}
			return roleNames;
		}

		[Authorize(Roles = "admin")]
		[Route("Update")]
		public IHttpActionResult Update(FrontendUserModel model)
		{
			if (ModelState.IsValid)
			{
				ApplicationUser user = UserManager.FindByName(model.Login);
				if(user != null)
				{
					UserManager.RemoveFromRoles(user.Id, ApplicationRoleManager.DefinedRoles.ToArray());
					if(model.Roles != null)
					{
						foreach (string roleName in model.Roles)
						{
							UserManager.AddToRoles(user.Id, model.Roles.ToArray());
						}
						return Ok();
					}

				}
			}
			return BadRequest(ModelState);
		}

		// POST api/Account/Add
		[Authorize(Roles ="admin")]
		[Route("Add")]
		public async Task<IHttpActionResult> Add(AddUserBindingModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var user = new ApplicationUser() { UserName = model.Username };

			IdentityResult result = await UserManager.CreateAsync(user, model.Password);

			if (!result.Succeeded)
			{
				return GetErrorResult(result);
			}

			return Ok();
		}


       /* // POST api/Account/ChangePassword
        [Route("ChangePassword")]
        public IHttpActionResult ChangePassword(ChangePasswordBindingModel model)
        {
			if (ModelState.IsValid && model.Username != null)
			{
				ApplicationUser foundUser = UserManager.FindByName(model.Username);
				if (foundUser != null)
				{
					if (UserManager.ChangePassword(foundUser.Id,  model.NewPassword).Succeeded)
					{
						return Ok();
					}
				}
			}
            return BadRequest();
        }*/

		// POST api/Account/ChangeMyPassword
		[Route("ChangeMyPassword")]
		public IHttpActionResult ChangeMyPassword(MyPasswordChangeBindingModel password)
		{
			if (ModelState.IsValid)
			{
				ApplicationUser foundUser = UserManager.FindById(User.Identity.GetUserId());
				if (foundUser != null)
				{
					IdentityResult result = Task.Run(async () => { return await UserManager.PasswordValidator.ValidateAsync(password.Password); }).Result;
					if (result.Succeeded)
					{
						string newPasswordHash = UserManager.PasswordHasher.HashPassword(password.Password);
						if(foundUser.PasswordHash != newPasswordHash)
						{
							foundUser.PasswordHash = newPasswordHash;
							if (UserManager.Update(foundUser).Succeeded)
							{
								return Ok();
							}
						}
					}
				}
			}
			return BadRequest();
		}

		[Authorize(Roles = "admin")]
		[Route("RemoveUser")]
		public IHttpActionResult RemoveUser(RemoveUserBindingModel model)
		{
			if (ModelState.IsValid && model.Username != null)
			{
				ApplicationUser foundUser = UserManager.FindByName(model.Username);
				if (foundUser != null)
				{
					if (UserManager.Delete(foundUser).Succeeded)
					{
						return Ok();
					}
				}
			}
			return BadRequest();
		}

		#endregion

		protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        private class ExternalLoginData
        {
            public string LoginProvider { get; set; }
            public string ProviderKey { get; set; }
            public string UserName { get; set; }

            public IList<Claim> GetClaims()
            {
                IList<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

                if (UserName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
                }

                return claims;
            }

            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }

                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
                    || String.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                return new ExternalLoginData
                {
                    LoginProvider = providerKeyClaim.Issuer,
                    ProviderKey = providerKeyClaim.Value,
                    UserName = identity.FindFirstValue(ClaimTypes.Name)
                };
            }
        }

        private static class RandomOAuthStateGenerator
        {
            private static RandomNumberGenerator _random = new RNGCryptoServiceProvider();

            public static string Generate(int strengthInBits)
            {
                const int bitsPerByte = 8;

                if (strengthInBits % bitsPerByte != 0)
                {
                    throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");
                }

                int strengthInBytes = strengthInBits / bitsPerByte;

                byte[] data = new byte[strengthInBytes];
                _random.GetBytes(data);
                return HttpServerUtility.UrlTokenEncode(data);
            }
        }

        #endregion
    }
}
