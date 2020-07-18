using Projeto.Application.Commands.Turmas;
using Projeto.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Interfaces
{
    public interface ITurmaApplicationService
    {
        void Add(CreateTurmaCommand command);
        void Update(UpdateTurmaCommand command);
        void Remove(DeleteTurmaCommand command);

        List<TurmaDTO> GetAll();
        TurmaDTO GetById(string id);
    }
}
