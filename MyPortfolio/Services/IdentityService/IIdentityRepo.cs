namespace MyPortfolio.Services.IdentityService
{
    public interface IIdentityRepo
    {
        Task<Guid?> Login(string username, string password);
    }
}
