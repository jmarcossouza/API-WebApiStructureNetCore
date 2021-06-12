using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApiStructureNetCore.Validators
{
    public class RequiredValidator : RequiredAttribute
    {
        public RequiredValidator() : base()
        {
            ErrorMessage = "O campo é obrigatório.";
        }

    }
}
