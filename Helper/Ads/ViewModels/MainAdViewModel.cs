using Model.Ads.Animals;
using Model.Ads.Enums;
using System.ComponentModel.DataAnnotations;

namespace Helper.Ads.ViewModels
{
    public abstract class MainAdViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid Color { get; set; }
        [Required]
        public Guid KindOfAnimal { get; set; }
        public string OtherKind { get; set; }
        [Required]
        public SexAnimal SexAnimal { get; set; }
        public string OtherColor { get; set; }
        [Required]
        public string Caption { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public TypeAd TypeAd { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
