using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILocationService
    {


        IDataResult<Location> GetLocationByLocationId(int locationId);
        IDataResult<List<Location>> ListLocationByTopLocationId(int locationId);
        IDataResult<int> CountLocationByTopLocationId(int locationId);

        IResult Create(Location location);
        IResult Update(Location location);
        IResult Delete(Location location);

        IDataResult<List<Location>> ListLocation();
        IDataResult<List<Location>> ListLocationPaging(int page, int pageSize);
        IDataResult<List<Location>> ListLocationPagingByTitle(string text, int page, int pageSize);
        IDataResult<List<Location>> ListLocationPagingByTopLocationId(int locationId, int page, int pageSize);
        IDataResult<List<Location>> ListLocationPagingByTopLocationIdAndByTitle(string text, int locationId, int page, int pageSize);


    }
}
