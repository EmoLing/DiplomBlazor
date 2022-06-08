using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.Animals
{
    public class Animal
    {
        public Guid Guid { get; init; } = Guid.NewGuid();
        public Guid AdGuid { get; set; }
        public string AnimalName { get; set; }
        public Guid KindOfAnimalGuid { get; set; }
        public SexAnimal SexAnimal { get; set; } = SexAnimal.Undefined;
        public Guid ColorOfAnimalGuid { get; set; }
        public bool IsOtherKindOfAnimal { get; set; } = false;
        public string OtherKindOfAnimal { get; set; } = String.Empty;
        public bool IsOtherColorOfAnimal { get; set; } = false;
        public string OtherColorOfAnimal { get; set; } = String.Empty;

        public Animal()
        {
        }

        public Animal(Guid adGuid)
        {
            Guid = Guid.NewGuid();
            AdGuid = adGuid;
        }
    }
}
