using IngSw_Application.DTOs;
using IngSw_Application.Services;
using IngSw_Domain.Entities;
using IngSw_Domain.Interfaces;
using IngSw_Domain.ValueObjects;
using Microsoft.Extensions.Configuration;
using NSubstitute;

namespace IngSw_Tests.RegisterPatient;

public class AuthServiceTest
{
	private readonly IAuthRepository _authRepository;
	private readonly AuthService _authService;
	public AuthServiceTest(/*IConfiguration configuration*/)
	{
		_authRepository = Substitute.For<IAuthRepository>();
		_authService = new AuthService(_authRepository/*, configuration*/);
	}

    [Fact]
    public async Task Login_WhenYouEnterTheCorrectEmailAndPassword_ThenYouLogIn_ShouldCreateThePatient()
	{
		// Arrange

		var userDto = new UserDto.Request("ramirobrito@gmail.com", "bocateamo");
		var userFound = new User
		{ 
			Email = "ramirobrito@gmail.com",
			Password = "bocateamo",
			Employee = new Employee
			{
				Name = "Ramiro",
				LastName = "Brito",
				Cuil = Cuil.Create("20-42365986-7"),
				PhoneNumber = "381754963",
				Email = "ramirobrito@gmail.com",
				Registration = "LO78Q"
			}
        };
		_authRepository.GetByEmail("ramirobrito@gmail.com")
			.Returns(Task.FromResult(userFound));

		// Act

		var result = await _authService.Login(userDto);

        // Assert

        await _authRepository.Received(1).GetByEmail(Arg.Any<string>());
        Assert.NotNull(result);
        Assert.Equal(userFound.Email, result.email);
        Assert.Equal(userFound.Employee.Name, result.name);
        Assert.Equal(userFound.Employee.LastName, result.lastName);

    }


}
