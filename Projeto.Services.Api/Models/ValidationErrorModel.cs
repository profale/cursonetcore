﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.Api.Models
{
    public class ValidationErrorModel
    {
        public string PropertyName { get; set; }
        public List<string> Errors { get; set; }
    }
}
