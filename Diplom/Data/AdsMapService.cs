using Helper.Ads.ViewModels;
using Model.Ads;

namespace Diplom.Data
{
    public class AdsMapService
    {
        public async Task<IQueryable<Ad>> GetAds()
        {
            var ads = await GetRequest<List<Ad>>("https://localhost:7155/api/Ads");
            return ads.AsQueryable();
        }

        public async Task<IQueryable<Ad>> GetFilteredAds(FilterAdsViewModel filter)
        {
            var ads = await GetRequest<IQueryable<Ad>>($"https://localhost:7155/api/Ads/filteredads/{filter}");
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
