using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dtos;
using WebAPI.Interface;

namespace WebAPI.Controllers
{
    public class PropertyTypeController :BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public PropertyTypeController(IUnitOfWork uow,IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet("list")]
        [AllowAnonymous]
        public async Task<ActionResult> GetPropertyTypes()
        {
            var properyTypes = await uow.propertyTypeRepository.GetPropertyTypesAsync();
            var propertyTypesDto = mapper.Map<IEnumerable<KeyValuePairDto>>(properyTypes);
            return Ok(propertyTypesDto);
            
        }
    }
}
