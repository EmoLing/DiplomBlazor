using Diplom.RabbitMq;
using Helper.Ads.ViewModels;
using Model.Ads;

namespace Diplom.Data
{
    public class AdsMapService
    {
        #region Rabbitmq
        //private RabbitMqService rabbitMqService = new RabbitMqService();


        //rabbitMqService.SendMessage("Test"); //пример запрсоа
        //return new List<Ad>().AsQueryable();
        #endregion

        public async Task<IQueryable<Ad>> GetAds()
        {
            var ads = await GetRequest<List<Ad>>("http://api-gateway/api/Ads"); //http://ads-api/api/Ads запрос к микросервису
            return ads.AsQueryable();
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
