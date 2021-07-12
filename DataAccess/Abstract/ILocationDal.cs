using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ILocationDal: IEntityRepository<Location>
    {

        List<Location> ListLocation();
        List<Location> ListLocationPaging(int page, int pageSize);
        List<Location> ListLocationPagingByTitle(string text, int page, int pageSize);
        List<Location> ListLocationPagingByTopLocationId(int locationId, int page, int pageSize);
        List<Location> ListLocationPagingByTopLocationIdAndByTitle(string text, int locationId, int page, int pageSize);
        Location GetLocationByLocationId(int locationId);
        List<Location> ListLocationByTopLocationId(int locationId);
        int CountLocationByTopLocationId(int locationId);

    }
}
