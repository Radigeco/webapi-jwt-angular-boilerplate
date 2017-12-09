using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Identity;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Thinktecture.IdentityModel.Extensions;
using Utilities;
using Websolution.Controllers.Base;
using Websolution.Models;

namespace Websolution.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : BaseApiController
    {
        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<IHttpActionResult> Login(UserLogin viewModel)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings["IssuingUrl"]) };
            string url = VirtualPathUtility.ToAbsolute(ConfigurationManager.AppSettings["TokenEndpoint"]);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", viewModel.UserName),
                new KeyValuePair<string, string>("password", viewModel.Password),
                new KeyValuePair<string, string>("grant_type", "password")
            };
            request.Content = new FormUrlEncodedContent(keyValues);
            HttpResponseMessage result = await client.SendAsync(request);

            if (!result.IsSuccessStatusCode)
                return Ok(new { success = false, reason = result.ReasonPhrase });

            string jsonMessage;
            using (Stream responseStream = await result.Content.ReadAsStreamAsync())
            {
                jsonMessage = new StreamReader(responseStream).ReadToEnd();
            }
            TokenResponseModel tokenResponse = (TokenResponseModel)JsonConvert.DeserializeObject(jsonMessage, typeof(TokenResponseModel));
            //Expire date is 5 minutes less then it should be, so the client authenticates earlier then
            Int64 expireDate = DateTime.Now.ToEpochTime() + tokenResponse.ExpiresIn - 300;
            return Ok(new { success = true, tokenResponse.AccessToken, tokenResponse.ExpiresIn, tokenResponse.TokenType, issueDate = DateTime.Now.ToEpochTime(), expireDate, tokenResponse.RefreshToken });
        }

        [Authorize]
        [HttpGet]
        [Route("users")]
        public IHttpActionResult GetUsers()
        {
            return Ok(AppUserManager.Users.ToList().Select(u => TheModelFactory.Create(u)));
        }

        [Authorize]
        [HttpGet]
        [Route("user/{id:guid}", Name = "GetUserById")]
        public async Task<IHttpActionResult> GetUser(string id)
        {
            var user = await AppUserManager.FindByIdAsync(id);

            if (user != null)
            {
                return Ok(TheModelFactory.Create(user));
            }

            return NotFound();

        }

        [Authorize(Roles = "Admin")]
        [Route("user/{username}")]
        public async Task<IHttpActionResult> GetUserByName(string username)
        {
            string userName = Base64Helper.Base64Decode(username);
            ApiUser user = await AppUserManager.FindByNameAsync(userName);

            if (user != null)
            {
                return Ok(TheModelFactory.Create((ApiUser)user));
            }

            return NotFound();

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("create")]
        public async Task<IHttpActionResult> CreateUser(CreateUser createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApiUser()
            {
                UserName = createUserModel.Email,
                Email = createUserModel.Email,
                FirstName = createUserModel.FirstName,
                LastName = createUserModel.LastName,
                Level = 3,
                JoinDate = DateTime.Now.Date,
            };

            IdentityResult addUserResult = await AppUserManager.CreateAsync(user, createUserModel.Password);

            if (!addUserResult.Succeeded)
            {
                return GetErrorResult(addUserResult);
            }

            string code = await this.AppUserManager.GenerateEmailConfirmationTokenAsync(user.Id);

            var callbackUrl = new Uri(Url.Link("ConfirmEmailRoute", new { userId = user.Id, code = code }));

            await this.AppUserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

            Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

            return Created(locationHeader, TheModelFactory.Create(user));
        }

        [Authorize(Roles = "Admin")]
        [Route("admincreate")]
        public async Task<IHttpActionResult> CreateUserAdmin(CreateUser createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApiUser user = new ApiUser()
            {
                Email = createUserModel.Email,
                FirstName = createUserModel.FirstName,
                LastName = createUserModel.LastName,
                UserName = createUserModel.Email,
                Level = 3,
                JoinDate = DateTime.Now.Date,
                EmailConfirmed = true
            };

            IdentityResult addUserResult = await AppUserManager.CreateAsync(user, createUserModel.Password);

            if (!addUserResult.Succeeded)
            {
                return GetErrorResult(addUserResult);
            }

            Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

            return Created(locationHeader, TheModelFactory.Create(user));
        }

        [Authorize]
        [HttpPost]
        [Route("changepassword")]
        public async Task<IHttpActionResult> ChangePassword([FromBody]ChangePassword model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await AppUserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        [Authorize]
        [HttpDelete]
        [Route("user/{id:guid}")]
        public async Task<IHttpActionResult> DeleteUser(string id)
        {

            //Only SuperAdmin or Admin can delete users (Later when implement roles)

            var appUser = await AppUserManager.FindByIdAsync(id);

            if (appUser != null)
            {
                IdentityResult result = await AppUserManager.DeleteAsync(appUser);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok();

            }

            return NotFound();

        }

        [HttpGet]
        [Route("ConfirmEmail", Name = "ConfirmEmailRoute")]
        public async Task<IHttpActionResult> ConfirmEmail(string userId = "", string code = "")
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }

            IdentityResult result = await AppUserManager.ConfirmEmailAsync(userId, code);

            if (result.Succeeded)
            {
                return Ok();
            }
            return GetErrorResult(result);
        }

    }
}
