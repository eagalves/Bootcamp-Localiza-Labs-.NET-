using curso.api.Models.Cursos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [Route("api/v1/cursos")]
    [ApiController]
    [Authorize]

    public class CursoController : ControllerBase
    {
        ///<summary>
        ///Este serviço permite cadastrar curso para o usuário autenticado.
        ///</summary>
        ///<returns> Retorna status 201 e dados do curso do usuário </returns>

        [SwaggerResponse(statusCode: 201, description: "Sucesso ao Cadastrar o curso", Type = typeof(CursoViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "Não Autorizado")]

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CursoViewModelInput cursoViewModelInput)
        {
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            return Created("", cursoViewModelInput);
        }


        ///<summary>
        ///Este serviço permite obter todos os cursos ativos do usuario.
        ///</summary>
        ///<returns> Retorna status ok e dados do usuário </returns>

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter os cursos", Type = typeof(CursoViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "Não Autorizado")]

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            //var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var cursos = new List<CursoViewModelOutput>();

            cursos.Add(new CursoViewModelOutput()
            {
                Login = "",
                Descricao = "teste",
                Nome = "teste"


            });


            return Ok(cursos);
        }
    }
}
