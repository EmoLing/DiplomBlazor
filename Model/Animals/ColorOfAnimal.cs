using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Animals
{
    public class ColorOfAnimal
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string ColorName { get; set; }
        public int Position { get; set; }
    }
}
