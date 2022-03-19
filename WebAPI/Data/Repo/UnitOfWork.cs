using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interface;

namespace WebAPI.Data.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;

      


        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }
        public ICityRepository cityRepository => new CityRepository(dc);

        public IUserRepository userRepository => new UserRepository(dc);

        public IPropertyRepository propertyRepository => new PropertyRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;

        }
    }
}
