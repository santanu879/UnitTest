using EF_Api.DB.Interface;
using EF_Api.DB.models;
using EF_Api.External_Api.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EF_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly ILogger<PublisherController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHolidaysApiService _holidayApiService;
        public PublisherController(ILogger<PublisherController> logger,
             IUnitOfWork unitOfWork, IHolidaysApiService holidaysApiService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _holidayApiService = holidaysApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = _unitOfWork.Publisher.GetAll();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Publisher publisher)
        {
            try
            {
                _unitOfWork.Publisher.Add(publisher);
                var result=_unitOfWork.Complete();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
