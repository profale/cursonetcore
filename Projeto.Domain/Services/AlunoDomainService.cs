using Projeto.Domain.Interfaces.IServices;
using Projeto.Domain.Interfaces.Repositories;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Domain.Services
{
    public class AlunoDomainService : BaseDomainService<Aluno>, IAlunoDomainService
    {
        //DIP
        private readonly IUnitOfWork unitOfWork;

        //Injecao de dependencia
        public AlunoDomainService(IUnitOfWork unitOfWork)
            :base(unitOfWork.AlunoRepository)
        {
            this.unitOfWork = unitOfWork;
        }

        public Aluno GetByMatricula(string matricula)
        {
            return unitOfWork.AlunoRepository.GetByMatricula(matricula);
        }

        public Aluno GetByCpf(string cpf)
        {
            return unitOfWork.AlunoRepository.GetByCpf(cpf);
        }

        //public override void Dispose()
        //{
        //    unitOfWork.Dispose();
        //}
    }
}
