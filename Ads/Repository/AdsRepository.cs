using Ads.DbContexts;
using Helper.Ads.ViewModels;
using Microsoft.EntityFrameworkCore;
using Model.Ads;
using Model.Ads.Animals;

namespace Ads.Repository
{
    public class AdsRepository : IAdsRepository
    {
        private readonly AdContext _dbContext;
        public AdsRepository(AdContext adContext)
        {
            _dbContext = adContext;
        }

        public void CreateAd(Ad ad)
        {
            _dbContext.Images.AddRange(ad.Photo);
            _dbContext.AdCoordinates.Add(ad.Coordinates);

            _dbContext.Animals.Add(ad.Animal);

            _dbContext.Ads.Add(ad);

            _dbContext.SaveChanges();
        }

        public void Close(Guid adGuid)
        {
            throw new NotImplementedException();
        }

        public Ad GetAd(Guid adGuid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ad> GetAds()
        {
            _dbContext.Ads.Load();
            _dbContext.AdCoordinates.Load();
            _dbContext.Images.Load();
            _dbContext.Animals.Load();
            _dbContext.KindsOfAnimals.Load();
            _dbContext.ColorsOfAnimals.Load();

            return _dbContext.Ads
                .Include(a => a.Coordinates)
                .ToList();

            //return _dbContext.Ads
            //    .Include(a => a.Coordinates)
            //    .Include(a => a.Photo)
            //    .Include(a => a.Animal)
            //    .Include(a => a.Animal.KindOfAnimalGuid)
            //    .Include(a => a.Animal.ColorOfAnimalGuid)
            //    .ToList();
        }


        public void Publication()
        {
            throw new NotImplementedException();
        }

        public void SendToArchive(Guid adGuid)
        {
            throw new NotImplementedException();
        }
    }
}
