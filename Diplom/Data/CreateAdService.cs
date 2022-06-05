using Helper.Ads.ViewModels;
using Helper.Images;
using Microsoft.AspNetCore.Components.Forms;
using Model.Ads.Animals;
using System.Security.Claims;

namespace Diplom.Data
{
    public class CreateAdService
    {
        public async Task<NewAdViewModel> OnInitialized()
        {
            var colorOfAnimals = await GetRequest<List<ColorOfAnimal>>("http://api-gateway/api/Animal/colorofanimals"); //http://animals-api/api/Animal/colorofanimals
            var kindOfAnimals = await GetRequest<List<KindOfAnimal>>("http://api-gateway/api/Animal/kindofanimals"); //http://animals-api/api/Animal/kindofanimals

            var adViewModel = new NewAdViewModel()
            {
                ColorOfAnimals = colorOfAnimals.OrderBy(coa => coa.Position).ToList(),
                KindOfAnimals = kindOfAnimals.OrderBy(koa => koa.Position).ToList()
            };

            return await Task.FromResult(adViewModel);
        }
        //"http://ads-api/api/ads/uploadfiles/" + '{' + _user.Identity.Name + '}'
        public async Task<bool> CreateAd(AdViewModel adViewModel, ClaimsPrincipal user)
        {
            if (String.IsNullOrWhiteSpace(adViewModel.Longitude) || String.IsNullOrWhiteSpace(adViewModel.Latitude))
                throw new Exception("Не выбрано место утери/находки");

            var stringGuid = user.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!Guid.TryParse(stringGuid, out var guid))
                throw new Exception("Не создан пользователь");

            adViewModel.UserGuid = guid;
            adViewModel.UserName = user.Identity.Name;
            adViewModel.Photo =  ImageHelper.GetImageFromRequest($"{Directory.GetCurrentDirectory()}/files/"
                + adViewModel.UserName + '/', user.Identity.Name);

            using var httpClient = new HttpClient();
            using var result = await httpClient
                .PostAsJsonAsync("http://api-gateway/api/Ads/CreateAd", adViewModel); //http://ads-api/api/Ads/CreateAd

            DeleteUserFiles(user.Identity.Name);

            return result.StatusCode is System.Net.HttpStatusCode.OK;
        }

        private void DeleteUserFiles(string userName)
        {
            var dirInfo = new DirectoryInfo($"{Directory.GetCurrentDirectory()}/files/{userName}/");
            if (!dirInfo.Exists)
                return;

            var userFiles = dirInfo.GetFiles().Where(f => f.Name.Contains(userName));
            foreach (var file in userFiles)
                file.Delete();
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
