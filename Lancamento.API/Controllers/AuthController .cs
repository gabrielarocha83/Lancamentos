using Lancamento.Domain;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly Lancamento.Domain.Jwtsettings _jwtSettings;

    public AuthController(IOptions<Lancamento.Domain.Jwtsettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Lancamento.API.Dto.LoginRequest loginRequest)
    {
        // Validação de credenciais - Substituir por uma consulta ao banco de dados
        if (loginRequest.Username != "admin" || loginRequest.Password != "admin123")
        {
            return Unauthorized(new { Message = "Usuário ou senha inválidos" });
        }

        // Geração do token JWT
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, loginRequest.Username),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes),
            signingCredentials: creds
        );

        return Ok(new
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes)
        });
    }
}
