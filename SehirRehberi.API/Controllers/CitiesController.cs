using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.Data;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SehirRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;
        public CitiesController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        public ActionResult GetCities()
        {
            var cities = _appRepository.GetCities();

            var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);

            //var citites = _appRepository.GetCities().
            //    Select(x => new CityForListDto
            //    {
            //        Description = x.Description,
            //        Name = x.Name,
            //        PhotoUrl = x.Photos.Where(x => x.IsMain == true).FirstOrDefault().Url,

            //    }).ToList();
            return Ok(citiesToReturn);

        }

        [HttpPost]
        [Route("Add")]
        public ActionResult AddCity([FromBody] City city)
        {
            _appRepository.Add(city);
            _appRepository.SaveAll();

            return Ok(city);
        }

        [HttpGet]
        [Route("detail")]
        public ActionResult GetCityById(int id)
        {

            var city = _appRepository.GetCityById(id);

            var cityToReturn = _mapper.Map<CityForDetailDto>(city);
            //var options = new JsonSerializerOptions
            //{
            //    ReferenceHandler = ReferenceHandler.Preserve
            //};

            //string jsonString = JsonSerializer.Serialize(cityToReturn, options);
            //var deserializedObj = JsonSerializer.Deserialize<CityForDetailDto>(jsonString, options);

            return Ok(cityToReturn);

        }

        [HttpGet]
        [Route("photos")]
        public ActionResult GetPhotosByCity(int cityId)
        {
           var photos =_appRepository.GetPhotosByCity(cityId);
            return Ok(photos);
        }

    }
}
