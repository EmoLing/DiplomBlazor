using Helper.Ads.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Model.Ads.Animals;
using System.Security.Claims;

namespace Diplom.Data
{
    public class CreateAdService
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

        public async Task<bool> CreateAd(AdViewModel adViewModel, ClaimsPrincipal user)
        {
            if (String.IsNullOrWhiteSpace(adViewModel.Longitude) || String.IsNullOrWhiteSpace(adViewModel.Latitude))
                throw new Exception("Не выбрано место утери/находки");

            var stringGuid = user.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!Guid.TryParse(stringGuid, out var guid))
                throw new Exception("Не создан пользователь");

            adViewModel.UserGuid = guid;
            adViewModel.UserName = user.Identity.Name;

            using var httpClient = new HttpClient();
            using var result = await httpClient
                .PostAsJsonAsync("https://localhost:7155/api/Ads/CreateAd", adViewModel);

            return result.StatusCode is System.Net.HttpStatusCode.OK;
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
