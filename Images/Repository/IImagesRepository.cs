using Model.Images;

namespace Images.Repository
{
    public interface IImagesRepository
    {
        public Task<int> CreateImages(List<byte[]> images, Guid adGuid);
        public List<Image> GetImages(Guid adGuid);
        public List<Image> GetImages();
    }
}
