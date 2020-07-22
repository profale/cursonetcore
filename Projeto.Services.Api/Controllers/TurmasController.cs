using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Commands.Turmas;
using Projeto.Application.Interfaces;
using Projeto.Services.Api.Adaptares;

namespace Projeto.Services.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {

        private readonly ITurmaApplicationService _turmaApplicationService;

        public TurmasController(ITurmaApplicationService turmaApplicationService)
        {
            _turmaApplicationService = turmaApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateTurmaCommand command)
        {
            try
            {
                await _turmaApplicationService.Add(command);
                return Ok(new { Message = "Turma Cadastrada com sucesso." });
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
        public async Task<IActionResult> Put(UpdateTurmaCommand command)
        {
            try
            {
                await _turmaApplicationService.Update(command);
                return Ok(new { Message = "Turma Atualizada com sucesso." });
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
                var command = new DeleteTurmaCommand { Id = id};
                await _turmaApplicationService.Remove(command);

                return Ok(new { Message = "Turma Excluída com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_turmaApplicationService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(_turmaApplicationService.GetById(id));
        }
    }
}