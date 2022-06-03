using Helper.Ads.ViewModels;
using Model.Ads.Animals;

namespace AnimalManagement.Repository
{
    public interface IAnimalRepository
    {
        public void CreateAnimal(Animal animal);
        public void RemoveAnimal(Guid guid);
        public void RemoveAnimal(Animal animal);
        public void UpdateAnimal(Animal animal);
        public void UpdateAnimal(Guid guid);
        public List<Animal> GetAllAnimals();
        public List<ColorOfAnimal> GetColorOfAnimals();
        public List<KindOfAnimal> GetKindOfAnimals();

    }
}
