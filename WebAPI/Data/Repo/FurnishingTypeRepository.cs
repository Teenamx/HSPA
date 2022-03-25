using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Data.Repo
{
    public class FurnishingTypeRepository : IFurnishingTypeRepository
    {
        private readonly DataContext dc;
        public FurnishingTypeRepository(DataContext dc)
        {
            this.dc = dc;
        }
       
        public async Task<IEnumerable<FurnishingType>> GetFurnishingTypes()
        {
            return await dc.FurnishingTypes.ToListAsync();
        }
    }
}
