
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dtos;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
       
      
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork uow,IMapper mapper)
        { 
          
           
            this.uow = uow;
            this.mapper = mapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await uow.cityRepository.GetCitiesAsync();

            var citiesDto = mapper.Map<IEnumerable<CityDto>>(cities);


            //var citiesDto = from city in cities
            //                select new CityDto()
            //                {
            //                    Name = city.Name
            //                };
            return Ok(citiesDto);
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Atlanta";
        }

       
        [HttpPost("post")]
       
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            var city = mapper.Map<City>(cityDto);
            city.lastUpdatedBy = 1;
            city.LastUpdatedOn =DateTime.Now;
            //var city = new City
            //{
            //    Name = cityDto.Name,
            //    lastUpdatedBy = 1,
            //    LastUpdatedOn = DateTime.Now
            //};

            uow.cityRepository.AddCity(city);
            await uow.SaveAsync();
            return StatusCode(201);
        }
      

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.cityRepository.DeleteCity(id);
            await uow.SaveAsync();
            return Ok(id);
        }
        

        //[HttpPost("add")]
        ////api/city/add?cityName=Miami
        //[HttpPost("add/{cityName}")]
        ////api/city/add/Miami
        //public async Task<IActionResult> AddCity(string cityName)
        //{
        //    City city = new City();
        //    city.Name = cityName;
        //    await dc.Cities.AddAsync(city);
        //    await dc.SaveChangesAsync();
        //    return Ok(city);
        //}

        //[HttpDelete("delete/{id}")]
        //public async Task<IActionResult> DeleteCity(int id)
        //{
        //    var city = await dc.Cities.FindAsync(id);
        //    dc.Cities.Remove(city);
        //    await dc.SaveChangesAsync();
        //    return Ok(id);
        //}
    }
}
