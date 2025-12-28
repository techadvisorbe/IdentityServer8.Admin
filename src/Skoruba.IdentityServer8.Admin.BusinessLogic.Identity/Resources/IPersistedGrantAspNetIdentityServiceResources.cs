using Skoruba.IdentityServer8.Admin.BusinessLogic.Identity.Helpers;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Identity.Resources
{
    public interface IPersistedGrantAspNetIdentityServiceResources
    {
        ResourceMessage PersistedGrantDoesNotExist();

        ResourceMessage PersistedGrantWithSubjectIdDoesNotExist();
    }
}
