using Projeto.Application.Commands.Professores;
using Projeto.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Interfaces
{
    public interface IProfessorApplicationService
    {
        Task Add(CreateProfessorCommand command);
        Task Update(UpdateProfessorCommand command);
        Task Remove(DeleteProfessorCommand command);

        List<ProfessorDTO> GetAll();
        ProfessorDTO GetById(string id);
    }
}
