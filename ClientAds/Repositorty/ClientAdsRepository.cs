using ClientAds.DbContexts;
using Model.ClientAds;
using ViewModels.ClientAds;

namespace ClientAds.Repositorty
{
    public class ClientAdsRepository : IClientAdsRepository
    {
        private readonly ClientAdsContext _dbContext;
        public ClientAdsRepository(ClientAdsContext clientAdsContext)
        {
            _dbContext = clientAdsContext;
        }

        public async Task<int> CreateClientAds(ClientAdsViewModel clientAdsViewModel)
        {
            _dbContext.ClientAds.Add(new Ad(clientAdsViewModel.UserGuid, clientAdsViewModel.TypeAd)
            {
                Guid = clientAdsViewModel.Guid,
                UserGuid = clientAdsViewModel.UserGuid,
                Name = clientAdsViewModel.Caption,
                Description = clientAdsViewModel.Description
            });

            return await _dbContext.SaveChangesAsync();
        }

        public void DeleteClientAds(ClientAdsViewModel clientAdsViewModel)
        {
            throw new NotImplementedException();
        }

        public List<Ad> GetClientsAds() => _dbContext.ClientAds.ToList();

        public Ad GetClientAds(Guid guid) => _dbContext.ClientAds.FirstOrDefault(a => a.Guid == guid);

        public void UpdateClientAds(ClientAdsViewModel clientAdsViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
