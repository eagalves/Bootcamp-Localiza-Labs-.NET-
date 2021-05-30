using curso.api.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using curso.api.Filters;
using Microsoft.EntityFrameworkCore;
using curso.api.Infraestrutura.Data;

namespace curso.api.Controllers
{
    [Route("api/v1/usuario/")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        ///<summary>
        ///teste
        ///</summary>
        ///<param name="loginViewModelInput"/>
        ///<returns></returns>

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]


        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(new ValidaCampoViewModelOutput(ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage)));
            //} Linha comentada pois iramos criar uma pasta(Filters) só para fazer isso

            var usuarioViewModelOutput = new UsuarioViewModelOutput() // Serve para gerar o token
            {
                Codigo = 1,
                Login = "evandro",
                Email = "evandro@email.com"
            };


            var tokenService = new Services.TokenService();

            var token = tokenService.GenerateToken(usuarioViewModelOutput);

            return Ok(new
            {
                Token = token,
                Usuario = loginViewModelInput
            });
        }



        ///<summary>
        ///teste
        ///</summary>
        ///<param name="registroViewModelInput">View Model de Registro de Login</param>
        ///<returns></returns>

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]

        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CursosDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CURSOS;Trusted_Connection=True");
            CursosDbContext contexto = new CursosDbContext(optionsBuilder.Options);

            var migracoesPendentes = contexto.Database.GetPendingMigrations();
            if (migracoesPendentes.Count() > 0)
            {
                contexto.Database.Migrate();
            }

            return Created("", registroViewModelInput);
        }
    }
}
