using TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Helpers;

namespace TechAdvisor.IdentityServer8.Admin.BusinessLogic.Identity.Resources
{
    public interface IPersistedGrantAspNetIdentityServiceResources
    {
        ResourceMessage PersistedGrantDoesNotExist();

        ResourceMessage PersistedGrantWithSubjectIdDoesNotExist();
    }
}
