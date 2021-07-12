using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameworkCore
{
    public class EfLocationDal : EfEntityRepositoryBase<Location, AppDbContext>, ILocationDal
    {
       

        public int CountLocationByTopLocationId(int locationId)
        {
            using (var context = new AppDbContext())
            {
                var cntxt = context.Locations.AsQueryable();

                if (!string.IsNullOrEmpty(locationId.ToString()) && locationId != 0)
                {
                    cntxt = cntxt.Where(p => p.topLocation_Id == locationId);
                }
                return cntxt.Count();
            }
        }

        public Location GetLocationByLocationId(int locationId)
        {
            using (var context = new AppDbContext())
            {
                var cntxt = context.Locations.AsQueryable();
                return cntxt.SingleOrDefault(x => x.location_Id == locationId);
            }
        }

        public List<Location> ListLocation()
        {
            using (var context = new AppDbContext())
            {
                var cntxt = context.Locations.AsQueryable();
                return cntxt.ToList();
            }
        }

        public List<Location> ListLocationPagingByTitle(string text, int page, int pageSize)
        {
            using (var context = new AppDbContext())
            {
                var cntxt = context.Locations.AsQueryable();
                if (!string.IsNullOrEmpty(text))
                {
                    cntxt = cntxt.Where(q => q.title.Contains(text));
                }
                return cntxt.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Location> ListLocationByTopLocationId(int locationId)
        {
            using (var context = new AppDbContext())
            {
                var cntxt = context.Locations.AsQueryable();
                cntxt = cntxt.Where(q => q.topLocation_Id == locationId);
                return cntxt.ToList();
            }
        }

        public List<Location> ListLocationPaging(int page, int pageSize)
        {
            using (var context = new AppDbContext())
            {
                var cntxt = context.Locations.AsQueryable();
                return cntxt.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Location> ListLocationPagingByTopLocationId(int locationId, int page, int pageSize)
        {
            using (var context = new AppDbContext())
            {
                var cntxt = context.Locations.AsQueryable();
                if (!string.IsNullOrEmpty(locationId.ToString()) && locationId != 0)
                {
                    cntxt = cntxt.Where(q => q.topLocation_Id==locationId);
                }
                return cntxt.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Location> ListLocationPagingByTopLocationIdAndByTitle(string text, int locationId, int page, int pageSize)
        {
            using (var context = new AppDbContext())
            {
                var cntxt = context.Locations.AsQueryable();
                if (!string.IsNullOrEmpty(text))
                {
                    cntxt = cntxt.Where(q => q.title.Contains(text));
                }
                if (!string.IsNullOrEmpty(locationId.ToString()) && locationId != 0)
                {
                    cntxt = cntxt.Where(q => q.topLocation_Id == locationId);
                }
                return cntxt.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
    }
}
