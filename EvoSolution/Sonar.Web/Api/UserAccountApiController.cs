using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sonar.Web.UoW;
using System.Web.Http;
using Sonar.Entities;
using System.Threading.Tasks;
using Sonar.BLL.Exceptions;
using Sonar.Framework.Security;

namespace Sonar.Web.Api
{
    public class UserAccountApiController : SonarBaseApiController
    {
        private UserAccountUoW _userAccountUoW;
        public UserAccountApiController(UserAccountUoW userAccountUoW) : base(userAccountUoW)
        {
            _userAccountUoW = userAccountUoW;
        }

        [Route("api/useraccount/add"), HttpPost]
        public async Task<IHttpActionResult> AddUserAccount([FromBody] UserAccount userAccount)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _userAccountUoW.UserAccountBLL.AddAccount(userAccount);
                return Ok();
            }
            catch (BusinessException bex)
            {
                return BadRequest(bex.Message);
            }
        }

        [Route("api/useraccountinfo"), HttpPost]
        public async Task<IHttpActionResult> GetUserInfo()
        {
            try
            {
                var account = await _userAccountUoW.UserAccountBLL.GetUserInfoAsync(new CurrentUser().Id);
                var mappedAccount = new
                {
                    account.Id,
                    account.Name,
                    account.Email
                };
                return Ok(mappedAccount);
            }
            catch (BusinessException bex)
            {
                return BadRequest(bex.Message);
            }
        }
    }
}