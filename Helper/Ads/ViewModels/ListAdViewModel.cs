using Model.Animals;
using Model.Ads.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Ads.ViewModels
{
    public class ListAdViewModel
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string KindAnimal { get; set; }
        public string OtherKind { get; set; }
        public SexAnimal SexAnimal { get; set; }
        public string OtherColor { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public TypeAd TypeAd { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Guid UserGuid { get; set; }
        public string User { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
