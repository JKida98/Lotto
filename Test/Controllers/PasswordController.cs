using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers;

[ApiController]
[Route("[controller]")]
public class PasswordController : ControllerBase
{
    [HttpGet]
    public Password Get()
    {
        var generatePassword = GenerateRandomPassword();
        return generatePassword;
    }

    [HttpGet("{passwordsNumber:int}")]
    public List<Password> GetPasswords(int passwordsNumber)
    {
        var passwords = new List<Password>();

        for (var i = 0; i < passwordsNumber; i++)
        {
            var generatePassword = GenerateRandomPassword();
            passwords.Add(generatePassword);
        }

        return passwords;
    }

    private Password GenerateRandomPassword()
    {
        var random = new Random();
        var characters = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+{}|:?>;";
        var passwordLength = 60;
        var password = new char[passwordLength];

        for (var i = 0; i < passwordLength; i++)
        {
            var pickedIndex = random.Next(characters.Length);
            var passwordCharacter = characters[pickedIndex];
            password[i] = passwordCharacter;
        }

        var stringPassword = string.Join("", password);

        return new Password
        {
            Value = stringPassword
        };
    }
}