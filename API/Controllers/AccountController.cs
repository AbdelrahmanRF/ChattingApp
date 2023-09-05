using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

public class AccountController : BaseController
{
    private readonly DataContext _context;
    private readonly ITokenService _tokenInterface;

    public AccountController(DataContext context, ITokenService tokenInterface)
    {
        _context = context;
        _tokenInterface = tokenInterface;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");
        using var hmac = new HMACSHA256();

        var user = new AppUser
        {
            UserName = registerDto.Username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };
        _context.Users.Add(user);

        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Login), new UserDto {
            Username = user.UserName,
            Token = _tokenInterface.CreateToken(user) 
        });
    }

    private async Task<bool> UserExists(string Username)
    {
        return await _context.Users.AnyAsync(u => u.UserName == Username.ToLower());
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login (LoginDto loginDto){

    var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.Username);

    if (user == null) return Unauthorized("Invalid Username");

    using var hmac = new HMACSHA256(user.PasswordSalt);

    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

    for (int i = 0; i < computedHash.Length; i++) {

        if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
    }

    return CreatedAtAction(nameof(Login), new UserDto
    {
        Username = user.UserName,
        Token = _tokenInterface.CreateToken(user)
    });
    }


}
