using Model.Ads.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Ads.ViewModels
{
    public class NewAdViewModel
    {
        public List<KindOfAnimal> KindOfAnimals { get; set; }
        public List<ColorOfAnimal> ColorOfAnimals { get; set; }
        public SexAnimal SexAnimal { get; set; }

        public static SexAnimal GetSexAnimal(string sexAnimal)
            => sexAnimal switch
        {
            "М" => SexAnimal.Male,
            "Ж" => SexAnimal.Female,
            _ => SexAnimal.Undefined
        };
    }
}
