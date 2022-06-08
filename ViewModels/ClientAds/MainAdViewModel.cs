using Model.Animals;
using Model.Ads.Enums;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.ClientAds
{
    public abstract class MainAdViewModel
    {
        public Guid UserGuid { get; set; }
        [Required]
        public string Caption { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public TypeAd TypeAd { get; set; }
    }
}
