using Ads.Repository;
using Helper.Ads.ViewModels;
using Helper.Images;
using Microsoft.AspNetCore.Mvc;
using Model.Ads;
using Model.Ads.Animals;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly IAdsRepository _adsRepository;
        public AdsController(IAdsRepository adsRepository)
        {
            _adsRepository = adsRepository;
        }

        // GET: api/<AdsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ads = _adsRepository.GetAds();
            return new OkObjectResult(ads);
        }

        // GET api/<AdsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdsController>
        [HttpPost]
        [Route("CreateAd")]
        public async Task<IActionResult> CreateAd(AdViewModel adViewModel)
        {
            if (adViewModel is null)
                return BadRequest();
            try
            {
                var ad = new Ad(adViewModel.UserGuid, adViewModel.TypeAd)
                {
                    Name = adViewModel.Name,
                    Description = adViewModel.Description,
                };

                var animal = new Animal()
                {
                    Ad = ad,
                    AdGuid = ad.Guid,
                    AnimalName = adViewModel.Name,
                    SexAnimal = adViewModel.SexAnimal,
                    KindOfAnimalGuid = adViewModel.KindOfAnimal,
                    ColorOfAnimalGuid = adViewModel.Color
                };

                ad.Animal = animal;

                ad.Coordinates = new AdCoordinates(ad.Guid)
                {
                    Latitude = AdCoordinates.GetDecimalFromString(adViewModel.Latitude),
                    Longitude = AdCoordinates.GetDecimalFromString(adViewModel.Longitude),
                };

                var imagesHash = ImageHelper.GetImageFromRequest($"{Directory.GetCurrentDirectory()}/files/" 
                    + adViewModel.UserName + '/', adViewModel.UserName);
                var images = new List<Image>(imagesHash.Count);

                foreach (var image in imagesHash)
                    images.Add(new Image(ad.Guid) { ImageHash = image });

                ad.Photo = images;


                _adsRepository.CreateAd(ad);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            finally
            {
                DeleteUserFiles(adViewModel.UserName);
            }

            return Ok();
        }

        [HttpPost()]
        [Route("uploadfiles/{login}")]
        public async Task<IActionResult> UploadFiles(string login)
        {
            login = login.Trim('{', '}');
            var files = Request.Form.Files;
            if (!files.Any())
                return Problem("Файл не загружен");

            try
            {
                var dirInfo = new DirectoryInfo($"{Directory.GetCurrentDirectory()}/files/{login}/");
                if (!dirInfo.Exists)
                    dirInfo.Create();

                for (int i = 0; i < files.Count; i++)
                {
                    var fileName = $"{login}_{i}_{files[i].FileName}";
                    string path = $"{dirInfo.FullName}/{fileName}";

                    using var fileStream = new FileStream(path, FileMode.Create);
                    await files[i].CopyToAsync(fileStream);
                }

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private void DeleteUserFiles(string userName)
        {
            var dirInfo = new DirectoryInfo($"{Directory.GetCurrentDirectory()}/files/{userName}/");
            if (!dirInfo.Exists)
                return;

            var userFiles = dirInfo.GetFiles().Where(f => f.Name.Contains(userName));
            foreach (var file in userFiles)
                file.Delete();
        }



        // PUT api/<AdsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
