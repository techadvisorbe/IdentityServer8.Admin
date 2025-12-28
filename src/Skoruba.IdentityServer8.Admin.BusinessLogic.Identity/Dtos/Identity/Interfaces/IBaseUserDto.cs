namespace Skoruba.IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces
{
    public interface IBaseUserDto
    {
        object Id { get; }
        bool IsDefaultId();
    }
}
