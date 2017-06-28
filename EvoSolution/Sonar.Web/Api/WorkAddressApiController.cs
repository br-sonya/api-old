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
    public class WorkAddressApiController : SonarBaseApiController
    {
        private WorkAddressUoW _workAddressUoW;
        public WorkAddressApiController(WorkAddressUoW workAddressUoW) : base(workAddressUoW)
        {
            _workAddressUoW = workAddressUoW;
        }

        [Route("api/address/add"), HttpPost]
        public async Task<IHttpActionResult> AddHomeAddress([FromBody] Address workAddress)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                workAddress.UserAccountId = new CurrentUser().Id;
                await _workAddressUoW.WorkAddressBLL.AddAddress(workAddress);
                return Ok();
            }
            catch (BusinessException bex)
            {
                return BadRequest(bex.Message);
            }
        }

        [Route("api/address"), HttpPost]
        public async Task<IHttpActionResult> GetWorkAddressAsync()
        {
            try
            {
                var address = await _workAddressUoW.WorkAddressBLL.GetAddressAsync(new CurrentUser().Id);
                return Ok(address);
            }
            catch (BusinessException bex)
            {
                return BadRequest(bex.Message);
            }
        }
    }
}