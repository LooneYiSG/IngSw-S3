using IngSw_Application.DTOs;
using IngSw_Application.Exceptions;
using IngSw_Application.Interfaces;
using IngSw_Domain.Entities;
using IngSw_Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IngSw_Application.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    //private readonly IConfiguration _configuration;
    public AuthService(IAuthRepository authRepository/*, IConfiguration configuration*/)
    {
        _authRepository = authRepository;
        // _configuration = configuration;
    }
    public async Task<UserDto.Response?> Login(UserDto.Request? userData)
    {
        var userFound = await _authRepository.GetByEmail(userData!.email!);
        if (userFound == null /*|| !VerifyPassword(userData!.password!, userFound.Password!)*/) throw new EntityNotFoundException("Usuario o contraseña incorrecto.");
        if (userFound.Employee == null) throw new NullException("El usuario no tiene un empleado asociado");
        return userFound != null ? new UserDto.Response
        (
            userFound.Employee.Email!,
            userFound.Employee.Name!,
            userFound.Employee.LastName!,
            userFound.Employee.Registration!,
            userFound.Employee.PhoneNumber!,
            userFound.Employee.GetType().Name,
            ""
            // TokenGenerator(userFound)
        ) : null;
    }
    //private string TokenGenerator(User user)
    //{
    //    var userClaims = new[]
    //    {
    //        new Claim(ClaimTypes.NameIdentifier, user.Employee!.Id.ToString()!),
    //        new Claim(ClaimTypes.Name, user.Employee!.Name!),
    //        new Claim(ClaimTypes.Role, user.Employee.GetType().Name!)
    //    };

    //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!));
    //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

    //    var jwtConfig = new JwtSecurityToken(
    //        claims: userClaims,
    //        expires: DateTime.UtcNow.AddMinutes(10),
    //        signingCredentials: credentials
    //        );
    //    return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
    //}
    private bool VerifyPassword(string passwordInput, string hashedPassword) => BCrypt.Net.BCrypt.Verify(passwordInput, hashedPassword);
}
