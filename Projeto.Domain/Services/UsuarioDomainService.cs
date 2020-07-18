using Projeto.Domain.Interfaces.Cryptography;
using Projeto.Domain.Interfaces.IServices;
using Projeto.Domain.Interfaces.Repositories;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class UsuarioDomainService : BaseDomainService<Usuario>, IUsuarioDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMD5Service md5Service;

        public UsuarioDomainService(IUnitOfWork unitOfWork, IMD5Service md5Service)
        :base(unitOfWork.UsuarioRepository)
        {
            _unitOfWork = unitOfWork;
            this.md5Service = md5Service;
        }
        public override void Add(Usuario obj)
        {
            //criptografando e sobrescrevendo a senha
            obj.Senha = md5Service.Encrypt(obj.Senha);
            base.Add(obj);
        }
        public override void Update(Usuario obj)
        {
            //criptografando e sobrescrevendo a senha
            obj.Senha = md5Service.Encrypt(obj.Senha);
            base.Update(obj);
        }
        public Usuario Get(string email)
        {
            return _unitOfWork.UsuarioRepository.Get(email);
        }

        public Usuario Get(string email, string senha)
        {
            return _unitOfWork.UsuarioRepository.Get(email, md5Service.Encrypt(senha));
        }
    }
}
