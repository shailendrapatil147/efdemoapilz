using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LZ.Common.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace LZ.BusinessLayer.efdemo.Authorization
{
    public class CustomerAuthorizationHandler :
        ResourceAuthorizationHandler<OperationAuthorizationRequirement, string, string>
    {
        private IEnumerable<OperationAuthorizationRequirement> _allowed = new[] {Operations.CustomerProtection};

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            string resource)
        {
            if (_allowed.Contains(requirement))
            {
                await base.HandleRequirementAsync(context, requirement, resource).ConfigureAwait(false);
            }
        }

        public override string Owner { get; set; }

        public override async Task<string> GetResource(string resource)
        {
            Owner = resource;
            return Owner;
        }

        public override bool ValidateResourceOwner(string requiredOwner)
        {
            return requiredOwner == Owner;
        }
    }
}
