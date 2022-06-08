using ClientAds.Repositorty;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.ClientAds;
using ViewModels.ClientAds;

namespace ClientAds.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientAdsController : ControllerBase
    {
        private readonly IClientAdsRepository _clientAdsRepository;
        //private readonly RabbitMqListener _rabbitMqListener;
        public ClientAdsController(IClientAdsRepository clientAdsRepository)
        {
            _clientAdsRepository = clientAdsRepository;
            //_rabbitMqListener = new RabbitMqListener();
        }

        [HttpGet]
        [Route("/api/clientads/")]
        public List<Ad> Get() => _clientAdsRepository.GetClientsAds();

        // GET: api/<CoordinatesController/{guid}>
        [HttpGet]
        [Route("/api/clientads/{guid}")]
        public Ad Get(Guid adGuid) => _clientAdsRepository.GetClientAds(adGuid);


        // POST api/<CoordinatesController>
        [HttpPost]
        public async Task<IActionResult> Post(ClientAdsViewModel clientAdsViewModel)
        {
            try
            {
                var countNotestSaveInDb = await _clientAdsRepository.CreateClientAds(clientAdsViewModel);

                return countNotestSaveInDb > 0 ? Ok(countNotestSaveInDb) : BadRequest("Не удалось запись координаты");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
