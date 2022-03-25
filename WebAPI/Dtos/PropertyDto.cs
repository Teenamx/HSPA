using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public class PropertyDto
    {
        public int SellRent { get; set; }
       

        public string Name { get; set; }

        public string PropertyTypeId { get; set; }

        public string FurnishingTypeId { get; set; }

        public int price { get; set; }

        public int BHK { get; set; }

        public int BuiltArea { get; set; }

        public string CityId { get; set; }

        
        public bool readyToMove { get; set; }

        public int CarpetArea { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int FloorNo { get; set; }
        public int TotalFloors { get; set; }
        public string MainEntrance { get; set; }

        public int Security { get; set; } = 0;
        public bool Gated { get; set; }
        public int Maintenance { get; set; } = 0;
        public int Age { get; set; } = 0;
        public string Description { get; set; }


        public DateTime EstPossessionOn { get; set; }
    }
}
