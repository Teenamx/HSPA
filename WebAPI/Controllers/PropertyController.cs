using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dtos;
using WebAPI.Interface;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    public class PropertyController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IPhotoServicecs photoServicecs;

        public PropertyController(IUnitOfWork uow, IMapper mapper, IPhotoServicecs photoServicecs)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.photoServicecs = photoServicecs;
        }
        [HttpGet("list/{sellRent}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyList(int sellRent)
        {
            var properties = await uow.propertyRepository.GetPropertiesAsync(sellRent);
            var propertyListDTO = mapper.Map<IEnumerable<PropertyListDto>>(properties);
            return Ok(propertyListDTO);
        }
        [HttpGet("detail/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyDetail(int id)
        {
            var property = await uow.propertyRepository.GetPropertyDetailAsync(id);
            var propertyDTO = mapper.Map<PropertyDetailDto>(property);
            return Ok(propertyDTO);
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> addProperty(PropertyDto propertyDto)
        {

            var property = mapper.Map<Property>(propertyDto);


            var userId = GetUserId();
            property.PostedBy = userId;

            property.LastUpdatedBy = userId;

            uow.propertyRepository.AddProperty(property);
            await uow.SaveAsync();
            return StatusCode(201);

        }

        [HttpPost("add/photo/{id}")]
        [Authorize]
        public async Task<IActionResult> addPropertyPhoto(IFormFile file, int propId)
        {

            var result = await photoServicecs.UploadPhotoAsync(file);
            if (result.Error != null)
                return BadRequest(result.Error.Message);
            return Ok(201);
        }
    }
}
