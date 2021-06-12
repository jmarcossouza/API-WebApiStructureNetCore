using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStructureNetCore.Validators
{
    public class BaseValidator : ValidationAttribute
    {        
        protected BaseValidator()
        {
            
        }
        
    }
}
