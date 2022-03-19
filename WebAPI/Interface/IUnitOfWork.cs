using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Interface
{
   public  interface IUnitOfWork
    {
        ICityRepository cityRepository { get; }

        IUserRepository userRepository { get; }

        IPropertyRepository propertyRepository { get; }


        Task<bool> SaveAsync();
     }
}
