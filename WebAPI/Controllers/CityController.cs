
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;


using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
       
      
        private readonly IUnitOfWork uow;

        public CityController(IUnitOfWork uow)
        { 
          
           
            this.uow = uow;
        }
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await uow.cityRepository.GetCitiesAsync();
            return Ok(cities);
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Atlanta";
        }

       
        [HttpPost("post")]
       
        public async Task<IActionResult> AddCity(City city)
        {

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
