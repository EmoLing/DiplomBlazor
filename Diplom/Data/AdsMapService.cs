using Model.Ads;

namespace Diplom.Data
{
    public class AdsMapService
    {
        public async Task<List<Ad>> GetAds()
        {
            var ads = await GetRequest<List<Ad>>("https://localhost:7155/api/Ads");
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
