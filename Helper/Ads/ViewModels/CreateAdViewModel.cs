using Helper.Images;
using Microsoft.AspNetCore.Http;

namespace Helper.Ads.ViewModels
{
    public class CreateAdViewModel : MainAdViewModel
    {
        public IFormFileCollection Photo { get; set; }

        public static implicit operator AdViewModel(CreateAdViewModel createAdViewModel)
        {
            var typeCreateAdViewModel = typeof(CreateAdViewModel);
            var typeAdViewModel = typeof(AdViewModel);
            var adViewModel = new AdViewModel();

            foreach (var property in typeCreateAdViewModel.GetProperties())
            {
                if (property.Name == "Photo")
                {
                    continue;
                }

                typeAdViewModel.GetProperty(property.Name)
                    .SetValue(adViewModel, property.GetValue(createAdViewModel));
            }

            return adViewModel;
        }
    }
}
