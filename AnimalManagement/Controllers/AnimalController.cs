using AnimalManagement.Repository;
using Helper.Ads.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Animals;

namespace AnimalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : Controller
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet]
        public List<Animal> Get() => _animalRepository.GetAllAnimals();

        [HttpGet]
        [Route("colorofanimals")]
        public ActionResult GetColorsOfAnimals() => new OkObjectResult(_animalRepository.GetColorOfAnimals());

        [HttpGet]
        [Route("kindofanimals")]
        public ActionResult GetKindOfAnimals() => new OkObjectResult(_animalRepository.GetKindOfAnimals());

        [HttpPost]
        public ActionResult CreateAnimal(Animal animal)
        {
            _animalRepository.CreateAnimal(animal);
            return new OkResult();
        }
    }
}
