using Model.Animals;
using Model.ClientAds;
using Model.Coordinates;
using Model.Images;

namespace ViewModels.Ads
{
    public class AdsViewModel
    {
        public Ad Ad { get; set; }
        public Animal Animal { get; set; }
        public List<Image> Images { get; set; }
        public AdCoordinates AdCoordinates { get; set; }
    }
}
