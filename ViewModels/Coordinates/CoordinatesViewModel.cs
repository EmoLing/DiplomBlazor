using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Coordinates
{
    public record CoordinatesViewModel
    {
        public string Longitude { get; init; }
        public string Latitude { get; init; }
        public Guid AdGuid { get; init; }
    }
}
