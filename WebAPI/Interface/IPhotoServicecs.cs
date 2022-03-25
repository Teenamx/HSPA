using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Interface
{
    public interface IPhotoServicecs
    {
        Task<ImageUploadResult> UploadPhotoAsync(IFormFile photo);
    }
}
