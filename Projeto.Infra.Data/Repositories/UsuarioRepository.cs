using Projeto.Domain.Interfaces.Repositories;
using Projeto.Domain.Models;
using Projeto.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SqlContext context)
            :base(context)
        {

        }
        public Usuario Get(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email.Equals(email));
        }

        public Usuario Get(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email.Equals(email) 
                                                        && u.Senha.Equals(senha));
        }
    }
}
