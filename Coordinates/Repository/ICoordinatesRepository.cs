using Model.Coordinates;

namespace Coordinates.Repository
{
    public interface ICoordinatesRepository
    {
        public Task<int> CreateCoordinates(string longitude, string latitude, Guid adGuid);
        public AdCoordinates GetCoordinates(Guid adGuid);
        public List<AdCoordinates> GetCoordinates();
    }
}
