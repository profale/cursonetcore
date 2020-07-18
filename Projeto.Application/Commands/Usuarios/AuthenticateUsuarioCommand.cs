using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Commands.Usuarios
{
    public class AuthenticateUsuarioCommand
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
