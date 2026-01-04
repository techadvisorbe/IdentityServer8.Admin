using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Helpers;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Resources
{
    public interface IPersistedGrantServiceResources
    {
        ResourceMessage PersistedGrantDoesNotExist();

        ResourceMessage PersistedGrantWithSubjectIdDoesNotExist();
    }
}
