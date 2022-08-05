using EF_Api.DB.Interface;
using EF_Api.DB.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_Api.External_Api.Models;
using EF_Api.External_Api;
using EF_Api.External_Api.Interface;

namespace EF_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHolidaysApiService _holidayApiService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
             IUnitOfWork unitOfWork, IHolidaysApiService holidaysApiService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _holidayApiService = holidaysApiService;
        }

        [HttpGet]
        public async Task<IEnumerable<Publisher>> GetPublisher()
        {
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})

            var data = _unitOfWork.Publisher.GetAll();

            Publisher publisher = new Publisher();
            publisher.PublisherName = "HBO-2";
            //publisher.Book.Add(new Book() { Title = "HBO-2" });

            _unitOfWork.Publisher.Add(publisher);
            _unitOfWork.Complete();

            return data;


            //.ToArray();

        }

        [HttpGet]
        [Route("GetHoliday")]
        public async Task<IEnumerable<HolidayModel>> GetHoliday()
        {           
            var data = await _holidayApiService.GetHolidays("US", 2021);
            return data;
        }
    }
}
