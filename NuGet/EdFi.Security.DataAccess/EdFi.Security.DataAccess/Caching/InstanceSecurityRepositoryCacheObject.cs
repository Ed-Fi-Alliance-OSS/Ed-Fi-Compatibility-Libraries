using System.Collections.Generic;
using EdFi.SecurityCompatiblity53.DataAccess.Models;

namespace EdFi.SecurityCompatiblity53.DataAccess.Caching
{
    public class InstanceSecurityRepositoryCacheObject
    {
        public Application Application { get; }

        public List<Action> Actions { get; }

        public List<ClaimSet> ClaimSets { get; }

        public List<ResourceClaim> ResourceClaims { get; }

        public List<AuthorizationStrategy> AuthorizationStrategies { get; }

        public List<ClaimSetResourceClaim> ClaimSetResourceClaims { get; }

        public List<ResourceClaimAuthorizationMetadata> ResourceClaimAuthorizationMetadata { get; }


        public InstanceSecurityRepositoryCacheObject(
            Application application,
            List<Action> actions,
            List<ClaimSet> claimSets,
            List<ResourceClaim> resourceClaims,
            List<AuthorizationStrategy> authorizationStrategies,
            List<ClaimSetResourceClaim> claimSetResourceClaims,
            List<ResourceClaimAuthorizationMetadata> resourceClaimAuthorizationMetadata)
        {
            Application = application;
            Actions = actions;
            ClaimSets = claimSets;
            ResourceClaims = resourceClaims;
            AuthorizationStrategies = authorizationStrategies;
            ClaimSetResourceClaims = claimSetResourceClaims;
            ResourceClaimAuthorizationMetadata = resourceClaimAuthorizationMetadata;
        }
    }
}