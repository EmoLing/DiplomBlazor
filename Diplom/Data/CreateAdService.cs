using Helper.Ads.ViewModels;
using Helper.Images;
using Microsoft.AspNetCore.Components.Forms;
using Model.Animals;
using System.Security.Claims;
using ViewModels.ClientAds;
using ViewModels.Coordinates;
using ViewModels.Images;

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

            var adGuid = Guid.NewGuid();

            using var httpClient = new HttpClient();
            using var result = await httpClient
                .PostAsJsonAsync("http://api-gateway/api/clientads/", new ClientAdsViewModel()
                {
                    Guid = adGuid,
                    Caption = adViewModel.Caption,
                    Description = adViewModel.Description,
                    TypeAd = adViewModel.TypeAd,
                    UserGuid = adViewModel.UserGuid
                }); //http://ads-api/api/Ads/CreateAd

            using var httpClient2 = new HttpClient();
            using var result2 = await httpClient
                .PostAsJsonAsync("http://api-gateway/api/coordinates/", new CoordinatesViewModel()
                {
                    Latitude = adViewModel.Latitude,
                    Longitude = adViewModel.Longitude,
                    AdGuid = adGuid
                }); //http://ads-api/api/Ads/CreateAd

            using var httpClient3 = new HttpClient();
            using var result3 = await httpClient
                .PostAsJsonAsync("http://api-gateway/api/images/", new ImagesViewModel()
                {
                    adGuid = adGuid,
                    ImagesHash = adViewModel.Photo.ToList()
                }); //http://ads-api/api/Ads/CreateAd

            using var httpClient4 = new HttpClient();
            using var result4 = await httpClient
                .PostAsJsonAsync("http://api-gateway/api/animal/", new Animal(adGuid)
                {
                    AnimalName = adViewModel.Name,
                    ColorOfAnimalGuid = adViewModel.Color,
                    KindOfAnimalGuid = adViewModel.KindOfAnimal,
                    IsOtherColorOfAnimal = String.IsNullOrWhiteSpace(adViewModel.OtherColor),
                    IsOtherKindOfAnimal = String.IsNullOrWhiteSpace(adViewModel.OtherKind),
                    OtherColorOfAnimal = adViewModel.OtherColor,
                    OtherKindOfAnimal = adViewModel.OtherKind,
                    SexAnimal = adViewModel.SexAnimal
                }); 

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
