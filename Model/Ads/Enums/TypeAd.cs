using System.ComponentModel.DataAnnotations;

namespace Model.Ads.Enums
{
    public enum TypeAd
    {
        [Display(Name ="Пропажа")]
        Loss,
        [Display(Name ="Находка")]
        Find
    }
}
