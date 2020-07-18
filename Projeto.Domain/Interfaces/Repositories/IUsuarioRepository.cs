using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario Get(string email);
        Usuario Get(string email, string senha);
    }
}
