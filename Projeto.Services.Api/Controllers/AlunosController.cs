using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Commands.Alunos;
using Projeto.Application.Interfaces;
using Projeto.Services.Api.Adaptares;

namespace Projeto.Services.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        //atributo
        private readonly IAlunoApplicationService _alunoApplicationService;

        //construtor para injecao de dependencia
        public AlunosController(IAlunoApplicationService alunoApplicationService)
        {
            _alunoApplicationService = alunoApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAlunoCommand command)
        {

            try
            {
                await _alunoApplicationService.Add(command);
                return Ok(new { Message = "Aluno Cadastrado com sucesso." });
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
        public async Task<IActionResult> Put(UpdateAlunoCommand command)
        {
            try
            {
                await _alunoApplicationService.Update(command);
                return Ok(new { Message = "Aluno Atualizado com sucesso." });
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
            var command = new DeleteAlunoCommand { Id = id };
            await _alunoApplicationService.Remove(command);
            return Ok(new { Message = "Aluno excluído com sucesso." });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_alunoApplicationService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(_alunoApplicationService.GetById(id));
        }

    }
}