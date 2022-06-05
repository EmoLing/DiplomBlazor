using Diplom.RabbitMq;
using Helper.Ads.ViewModels;
using Model.Ads;

namespace Diplom.Data
{
    public class AdsMapService
    {
        //private RabbitMqService rabbitMqService = new RabbitMqService();
        public async Task<IQueryable<Ad>> GetAds()
        {
            //rabbitMqService.SendMessage("Test");
            //return new List<Ad>().AsQueryable();
            var ads = await GetRequest<List<Ad>>("http://ads-api/api/Ads");
            return ads.AsQueryable();
        }

        public async Task<IQueryable<Ad>> GetFilteredAds(FilterAdsViewModel filter)
        {
            var ads = await GetRequest<IQueryable<Ad>>($"http://ads-api/api/Ads/filteredads/{filter}");
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
