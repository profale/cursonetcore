using Projeto.Domain.Interfaces.IServices;
using Projeto.Domain.Interfaces.Repositories;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class TurmaDomainService : BaseDomainService<Turma>, ITurmaDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public TurmaDomainService(IUnitOfWork unitOfWork)
            :base(unitOfWork.TurmaRepository)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
