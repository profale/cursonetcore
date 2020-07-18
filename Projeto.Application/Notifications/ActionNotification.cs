using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Notifications
{
    public enum ActionNotification
    {
        /*
         * Definindo as ações que serão gerenciadas pelo MediatR
         */
        Criar = 1,
        Atualizar = 2,
        Excluir = 3
    }
}
