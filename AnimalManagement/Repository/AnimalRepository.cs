using AnimalManagement.DbContexts;
using Helper.Ads.ViewModels;
using Model.Animals;

namespace AnimalManagement.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AnimalContext _dbContext;
        public AnimalRepository(AnimalContext animalContext)
        {
            _dbContext = animalContext;
        }

        public void CreateAnimal(Animal animal)
        {
            _dbContext.Animals.Add(animal);
            _dbContext.SaveChanges();
        }

        public List<Animal> GetAllAnimals() => _dbContext.Animals.ToList();

        public List<ColorOfAnimal> GetColorOfAnimals() => _dbContext.ColorsOfAnimals.ToList();

        public List<KindOfAnimal> GetKindOfAnimals() => _dbContext.KindsOfAnimals.ToList();

        public void RemoveAnimal(Guid guid)
        {
            throw new NotImplementedException();
        }

        public void RemoveAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public void UpdateAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public void UpdateAnimal(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
