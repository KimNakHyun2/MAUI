﻿using Icecream.Shared.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Icecream.API.Services;

public class TokenService
{
    private readonly IConfiguration _configuration;
    public TokenService(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration) =>
        new TokenValidationParameters()
        {
            ValidateAudience = false,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            IssuerSigningKey = GetSecurityKey(configuration)
        };
    

    public string GenerateJwt(LoggedInUser user)
    {
        //var secretKey = _configuration["Jwt:SecretKey"]; //Guid.NewGuid().ToString();
        //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
        var securityKey = GetSecurityKey(_configuration);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256 );

        Claim[] claims = [
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.StreetAddress, user.Address),
            ];

        var issuer = _configuration["Jwt:Issuer"];
        var expireInMinutes = Convert.ToInt32( _configuration["Jwt:ExpireInMinute"]);
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: "*",
            claims: claims,
            expires: DateTime.Now.AddMinutes(expireInMinutes),
            signingCredentials: credentials
            );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    private static SymmetricSecurityKey GetSecurityKey(IConfiguration configuration)
    {
        var secretKey = configuration["Jwt:SecretKey"]; //Guid.NewGuid().ToString();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));

        return securityKey;
    }
}
