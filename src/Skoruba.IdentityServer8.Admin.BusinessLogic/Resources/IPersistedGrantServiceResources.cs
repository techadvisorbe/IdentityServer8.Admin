using Skoruba.IdentityServer8.Admin.BusinessLogic.Helpers;

namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Resources
{
    public interface IPersistedGrantServiceResources
    {
        ResourceMessage PersistedGrantDoesNotExist();

        ResourceMessage PersistedGrantWithSubjectIdDoesNotExist();
    }
}
