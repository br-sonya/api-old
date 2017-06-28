using Sonar.Web.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Sonar.Web.Api
{
    public class SonarBaseApiController : ApiController
    {
        private UoWBase _uow;

        public SonarBaseApiController(UoWBase uow)
        {
            _uow = uow;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing == true)
            {
                _uow.Dispose();
            }
        }

    }
}