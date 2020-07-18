using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Commands.Usuarios;
using Projeto.Application.Interfaces;
using Projeto.Services.Api.Adaptares;

namespace Projeto.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioApplicationService usuarioApplicationService;
        public UsuariosController(IUsuarioApplicationService usuarioApplicationService)
        {
            this.usuarioApplicationService = usuarioApplicationService;
        }

        [HttpPost]
        public IActionResult Post(CreateUsuarioCommand command)
        {
            try
            {
                usuarioApplicationService.Add(command);
                return Ok(new { Message = "Usuário cadastrado com sucesso." });
            }
            catch(ValidationException e)
            {
                return BadRequest(ValidationAdapter.Parse(e.Errors));
            }
            catch (Exception e )
            { 
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate(AuthenticateUsuarioCommand command)
        {
            try
            {
                var token = usuarioApplicationService.Authenticate(command);

                if (token != null)
                    return Ok(new 
                    { 
                        Message = "Usuário autenticado com sucesso",
                        AccessToken = token
                    });

                return BadRequest(new { Message = "Usuário não encontrado." });
            }
            catch (ValidationException e)
            {
                return BadRequest(ValidationAdapter.Parse(e.Errors));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}