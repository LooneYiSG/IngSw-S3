using IngSw_Domain.Entities;
namespace IngSw_Domain.Interfaces;

public interface IAuthRepository
{
    Task<User?> Login(string userEmail, string userPassword);
    Task<User?> GetByEmail(string userEmail);
}
