using System.ComponentModel.DataAnnotations;

namespace Model.Ads.Enums
{
    public enum TypeAd
    {
        [Display(Name ="Пропажа", Description = "Пропажа")]
        Loss,
        [Display(Name ="Находка", Description = "Находка")]
        Find,
        [Display(Name = "Все", Description = "Все")]
        All
    }
}
