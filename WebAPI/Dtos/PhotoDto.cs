﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public class PhotoDto
    {
        public string ImageUrl { get; set; }

        public string publicId { get; set; }

        public bool IsPrimary { get; set; }
    }
}
