namespace ProjectFinalDemo.Application.Services.Interfaces
{
    public interface IJWTService
    {
        string GenerateToken(string UserName);
    }
}
