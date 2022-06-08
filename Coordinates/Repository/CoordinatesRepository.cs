using Coordinates.DbContexts;
using Model.Coordinates;
using System.Linq;

namespace Coordinates.Repository
{
    public class CoordinatesRepository : ICoordinatesRepository
    {
        private readonly CoordinatesContext _dbContext;
        public CoordinatesRepository(CoordinatesContext coordinatesContext)
        {
            _dbContext = coordinatesContext;
        }

        public async Task<int> CreateCoordinates(string longitude, string latitude, Guid adGuid)
        {
            var lon = AdCoordinates.GetDecimalFromString(longitude);
            var lat = AdCoordinates.GetDecimalFromString(latitude);

            var adCoordinates = new AdCoordinates(adGuid) { Latitude = lat, Longitude = lon };

            _dbContext.Add(adCoordinates);
            return await _dbContext.SaveChangesAsync();
        }

        public AdCoordinates GetCoordinates(Guid adGuid)
        {
            return _dbContext.AdCoordinates.FirstOrDefault(c => c.AdGuid == adGuid);
        }

        public List<AdCoordinates> GetCoordinates()
        {
            return _dbContext.AdCoordinates.ToList();
        }
    }
}
