using Coordinates.Repository;
using Microsoft.AspNetCore.Mvc;
using Model.Coordinates;
using ViewModels.Coordinates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Coordinates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordinatesController : ControllerBase
    {
        private readonly ICoordinatesRepository _coordinatesRepository;
        public CoordinatesController(ICoordinatesRepository coordinatesRepository)
        {
            _coordinatesRepository = coordinatesRepository;
        }

        // GET: api/<CoordinatesController>/{guid}
        [HttpGet]
        [Route("/api/coordinates/{guid}")]
        public AdCoordinates Get(Guid adGuid) => _coordinatesRepository.GetCoordinates(adGuid);

        // GET: api/<CoordinatesController>
        [HttpGet]
        [Route("/api/coordinates/")]
        public List<AdCoordinates> Get() => _coordinatesRepository.GetCoordinates();

        // POST api/<CoordinatesController>
        [HttpPost]
        public async Task<IActionResult> Post(CoordinatesViewModel coordinatesViewModel)
        {
            try
            {
                var countNotestSaveInDb = await _coordinatesRepository
                    .CreateCoordinates(coordinatesViewModel.Longitude,
                    coordinatesViewModel.Latitude, coordinatesViewModel.AdGuid);

                return countNotestSaveInDb > 0 ? Ok(countNotestSaveInDb) : BadRequest("Не удалось запись координаты");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
