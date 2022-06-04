using Model.Ads.Animals;
using Model.Ads.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Ads.ViewModels
{
    public class FilterAdsViewModel
    {
        public bool DisableKind { get; set; } = true;
        public bool DisableColor { get; set; } = true;
        public bool DisableSex { get; set; } = true;
        public bool DisableTypeAd { get; set; } = true;

        public IEnumerable<Guid> KindOfAnimal { get; set; }
        public IEnumerable<Guid> Color { get; set; }
        public IEnumerable<SexAnimal> SexAnimal { get; set; }
        public IEnumerable<TypeAd> TypeAd { get; set; }
    }
}
