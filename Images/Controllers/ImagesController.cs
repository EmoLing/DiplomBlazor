using Images.Repository;
using Microsoft.AspNetCore.Mvc;
using Model.Images;
using ViewModels.Images;
namespace Images.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : Controller
    {
        private readonly IImagesRepository _imagesRepository;
        public ImagesController(IImagesRepository imagesRepository)
        {
            _imagesRepository = imagesRepository;
        }

        // GET: api/<ImagesController>
        [HttpGet]
        [Route("/api/images/{guid}")]
        public List<Image> Get(Guid adGuid) => _imagesRepository.GetImages(adGuid);


        // GET: api/<ImagesController>
        [HttpGet]
        [Route("/api/images/")]
        public List<Image> Get() => _imagesRepository.GetImages();


        // POST api/<ImagesController>
        [HttpPost]
        public async Task<IActionResult> Post(ImagesViewModel imagesViewModel)
        {
            try
            {
                var countNotestSaveInDb = await _imagesRepository.CreateImages(imagesViewModel.ImagesHash, imagesViewModel.adGuid);

                return countNotestSaveInDb > 0 ? Ok(countNotestSaveInDb) : BadRequest("Не удалось записать фотографии");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
