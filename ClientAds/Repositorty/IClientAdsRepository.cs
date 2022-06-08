using ViewModels.ClientAds;
using Model.ClientAds;

namespace ClientAds.Repositorty
{
    public interface IClientAdsRepository
    {
        public Task<int> CreateClientAds(ClientAdsViewModel clientAdsViewModel);
        public Ad GetClientAds(Guid guid);
        public void UpdateClientAds(ClientAdsViewModel clientAdsViewModel);
        public void DeleteClientAds(ClientAdsViewModel clientAdsViewModel);
        public List<Ad> GetClientsAds();
    }
}
