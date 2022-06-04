using Helper.Ads.ViewModels;
using Model.Ads.Animals;

namespace Diplom.Data
{
    public class FilterAdsService
    {
        public async Task<NewAdViewModel> OnInitialized()
        {
            var colorOfAnimals = await GetRequest<List<ColorOfAnimal>>("https://localhost:7094/api/Animal/colorofanimals");
            var kindOfAnimals = await GetRequest<List<KindOfAnimal>>("https://localhost:7094/api/Animal/kindofanimals");

            var adViewModel = new NewAdViewModel()
            {
                ColorOfAnimals = colorOfAnimals.OrderBy(coa => coa.Position).ToList(),
                KindOfAnimals = kindOfAnimals.OrderBy(koa => koa.Position).ToList()
            };

            return await Task.FromResult(adViewModel);
        }

        private async Task<T> GetRequest<T>(string url)
        {
            using var httpClient = new HttpClient();
            var result = await httpClient
                .GetFromJsonAsync<T>(url, CancellationToken.None);

            return result;
        }
    }
}
