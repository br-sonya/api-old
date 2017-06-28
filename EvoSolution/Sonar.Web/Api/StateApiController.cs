using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sonar.Web.UoW;
using System.Web.Http;
using System.Threading.Tasks;
using Sonar.BLL.Exceptions;
using Sonar.Entities;

namespace Sonar.Web.Api
{
    public class StateApiController : SonarBaseApiController
    {
        private StateUoW _stateUoW;
        public StateApiController(StateUoW stateUoW) : base(stateUoW)
        {
            _stateUoW = stateUoW;
        }

        [Route("api/state/add"), HttpPost]
        public async Task<IHttpActionResult> AddState([FromBody]State state)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _stateUoW.StateBLL.AddState(state);
                return Ok();
            }catch(BusinessException bex)
            {
                return BadRequest(bex.Message);
            }
        }

        [Route("api/state"), HttpGet]
        public async Task<IHttpActionResult> GetStates()
        {
            var states = await _stateUoW.StateBLL.GetStatesAsync();

            var mappedStates = states.OrderBy(x => x.Name).Select(x => new
            {
                x.Id,
                x.Uf,
                x.Name
            }).ToList();

            return Ok(mappedStates);
        }
    }
}