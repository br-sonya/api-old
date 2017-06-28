using System;
using System.Security.Claims;
using System.Threading;

namespace Sonar.Framework.Security
{
    public class CurrentUser
    {
        public CurrentUser()
        {
            if(Thread.CurrentPrincipal.Identity.IsAuthenticated == true)
            {
                var claimsIdentity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;

                Id = Guid.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                Name = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();
            }
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
