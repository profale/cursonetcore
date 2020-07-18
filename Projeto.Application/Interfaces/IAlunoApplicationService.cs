using Projeto.Application.Commands.Alunos;
using Projeto.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Interfaces
{
    public interface IAlunoApplicationService
    {
        void Add(CreateAlunoCommand command);
        void Update(UpdateAlunoCommand command);
        void Remove(DeleteAlunoCommand command);

        //Queries
        List<AlunoDTO> GetAll();
        AlunoDTO GetById(string id);
    }
}
