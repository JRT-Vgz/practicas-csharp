namespace _06_demo_basicauth_asp.Services
{
    public interface IUserService
    {
        // Devuelve un boleano si el user está o no está. Necesitariamos un JWT para verificar esto.
        public bool IsUser(string email, string pass);
    }
}
