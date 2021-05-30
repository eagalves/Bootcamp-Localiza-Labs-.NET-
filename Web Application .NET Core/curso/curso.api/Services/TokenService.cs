using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using curso.api.Models.Usuarios;

namespace curso.api.Services
{
    public class TokenService
    {

       
        public string GenerateToken(UsuarioViewModelOutput usuarioViewModelOutput)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e"); //comitando a chave
            var tokenDescriptor = new SecurityTokenDescriptor  //configurando a descrição do token
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   // new Claim(ClaimTypes.Name, user.Username.ToString()),
                  //  new Claim(ClaimTypes.Role, user.Role.ToString())

                    new Claim(ClaimTypes.NameIdentifier, usuarioViewModelOutput.Codigo.ToString()),
                     new Claim(ClaimTypes.Name, usuarioViewModelOutput.Codigo.ToString()),
                     new Claim(ClaimTypes.Email, usuarioViewModelOutput.Codigo.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) // algoritmo de criptografia do token
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
