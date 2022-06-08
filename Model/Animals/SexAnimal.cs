using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Animals
{
    public enum SexAnimal
    {
        [Display(Name = "М")]
        Male = 0,
        [Display(Name = "Ж")]
        Female = 1,
        [Display(Name = "Не могу определить")]
        Undefined = 2
    }
}
