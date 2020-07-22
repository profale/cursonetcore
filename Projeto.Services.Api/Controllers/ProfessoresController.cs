using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Commands.Professores;
using Projeto.Application.Interfaces;
using Projeto.Services.Api.Adaptares;

namespace Projeto.Services.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessoresController : ControllerBase
    {
        //atributo
        private readonly IProfessorApplicationService _professorApplicationService;

        //construtor para injecao de dependencia
        public ProfessoresController(IProfessorApplicationService professorApplicationService)
        {
            _professorApplicationService = professorApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProfessorCommand command)
        {
            try
            {
                await _professorApplicationService.Add(command);
                return Ok(new { Message = "Professor Cadastrado com sucesso." });
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

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProfessorCommand command)
        {
            try
            {
                await _professorApplicationService.Update(command);
                return Ok(new { Message = "Professor Atualizado com sucesso." });
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var command = new DeleteProfessorCommand { Id = id };
                await _professorApplicationService.Remove(command);

                return Ok(new { Message = "Professor Excluído com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_professorApplicationService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(_professorApplicationService.GetById(id));
        }
    }
}