using FluentValidation.Results;
using Projeto.Services.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.Api.Adaptares
{
    public static class ValidationAdapter
    {
        /// <summary>
        /// Método para conversão de ValidationFailure em ValidationErrorModel
        /// </summary>
        /// <param name="erros">Lista de erros do FluentValidation</param>
        /// <returns>Lista de erros da class modelo do projeto API</returns>
        public static List<ValidationErrorModel> Parse(IEnumerable<ValidationFailure> erros)
        {
            List<ValidationErrorModel> result = erros.Select
                (er => new { PropertyName = er.PropertyName, Errors = er.ErrorMessage })
                .GroupBy(g => g.PropertyName).ToList()
                .Select(s => new ValidationErrorModel { PropertyName = s.Key, Errors = s.Select(m => m.Errors).ToList() }).ToList();
            return result;
        }
    }
}
