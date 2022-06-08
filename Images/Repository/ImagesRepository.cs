using Images.DbContexts;
using Model.Images;

namespace Images.Repository
{
    public class ImagesRepository : IImagesRepository
    {
        private readonly ImagesContext _dbContext;
        public ImagesRepository(ImagesContext imagesContext)
        {
            _dbContext = imagesContext;
        }

        public Task<int> CreateImages(List<byte[]> imagesHash, Guid adGuid)
        {
            var images = imagesHash.Select(hash => new Image(adGuid) { ImageHash  = hash });
            _dbContext.Images.AddRange(images);
            return _dbContext.SaveChangesAsync();
        }

        public List<Image> GetImages(Guid adGuid)
            => _dbContext.Images.Where(image => image.AdGuid == adGuid).ToList();

        public List<Image> GetImages() => _dbContext.Images.ToList();
    }

}
