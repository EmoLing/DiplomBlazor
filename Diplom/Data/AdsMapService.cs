using Diplom.RabbitMq;
using Helper.Ads.ViewModels;
using Model.Animals;
using Model.ClientAds;
using Model.Coordinates;
using Model.Images;
using ViewModels.Ads;

namespace Diplom.Data
{
    public class AdsMapService
    {
        #region Rabbitmq
        //private RabbitMqService rabbitMqService = new RabbitMqService();


        //rabbitMqService.SendMessage("Test"); //пример запрсоа
        //return new List<Ad>().AsQueryable();
        #endregion
        public async Task<IQueryable<AdsViewModel>> GetAds(IHttpClientFactory _httpClientFactory)
        {
            using var client = _httpClientFactory.CreateClient();

            var images = await client.GetFromJsonAsync<List<Image>>("http://api-gateway/api/images/");
            var animals = await client.GetFromJsonAsync<List<Animal>>("http://api-gateway/api/animal/");
            var coordinates = await client.GetFromJsonAsync<List<AdCoordinates>>("http://api-gateway/api/coordinates/");
            var clientAds = await client.GetFromJsonAsync<List<Ad>>("http://api-gateway/api/clientads/");

            var adsViewModels = new List<AdsViewModel>(clientAds.Count);
            adsViewModels.AddRange(clientAds.Select(ca => new AdsViewModel() { Ad = ca }));
            adsViewModels.ForEach(vm =>
            {
                vm.Animal = animals.FirstOrDefault(a => a.AdGuid == vm.Ad.Guid);
                vm.AdCoordinates = coordinates.FirstOrDefault(c => c.AdGuid == vm.Ad.Guid);
                vm.Images = images.Where(i => i.AdGuid == vm.Ad.Guid).ToList();
            });

            return adsViewModels.AsQueryable();
        }

        public async Task<IQueryable<Ad>> GetFilteredAds(FilterAdsViewModel filter)
        {
            var ads = await GetRequest<IQueryable<Ad>>($"http://api-gateway/api/Ads/filteredads/{filter}"); //http://ads-api/api/Ads/filteredads/{filter} запрос к микросервису
            return ads;
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
