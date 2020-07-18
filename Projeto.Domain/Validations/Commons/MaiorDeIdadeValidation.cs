using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Validations.Commons
{
    public class MaiorDeIdadeValidation
    {
        public static bool IsValid(DateTime dataNascimento)
        {
            var idade = DateTime.Now.Year - dataNascimento.Year;

            //Verificar se ele nao fez aniversario
            if (DateTime.Now.DayOfWeek < dataNascimento.DayOfWeek)
                idade--;
            
            return idade >= 18;
        }
    }
}
