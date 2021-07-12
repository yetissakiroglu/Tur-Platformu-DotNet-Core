using Business.Abstract;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Managers
{
    public class LocationManager : ILocationService
    {

        private ILocationDal _locationDal;

        public LocationManager(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }

        public IDataResult<int> CountLocationByTopLocationId(int locationId)
        {
            return new SuccessDataResult<int>(_locationDal.CountLocationByTopLocationId(locationId));
        }

        public IResult Create(Location location)
        {
            _locationDal.Create(location);
            return new SuccessResult(Messages.SuccessTitle, Messages.Created);
        }

        public IResult Delete(Location location)
        {
            _locationDal.Delete(location);
            return new SuccessResult(Messages.SuccessTitle, Messages.Deleted);
        }

        public IDataResult<Location> GetLocationByLocationId(int locationId)
        {
            return new SuccessDataResult<Location>(_locationDal.GetLocationByLocationId(locationId));
        }

        public IDataResult<List<Location>> ListLocation()
        {
            return new SuccessDataResult<List<Location>>(_locationDal.ListLocation());
        }

        public IDataResult<List<Location>> ListLocationByTopLocationId(int locationId)
        {
            return new SuccessDataResult<List<Location>>(_locationDal.ListLocationByTopLocationId(locationId));
        }

        public IDataResult<List<Location>> ListLocationPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<Location>>(_locationDal.ListLocationPaging(page,pageSize));
        }

        public IDataResult<List<Location>> ListLocationPagingByTitle(string text, int page, int pageSize)
        {
            return new SuccessDataResult<List<Location>>(_locationDal.ListLocationPagingByTitle(text,page, pageSize));
        }

        public IDataResult<List<Location>> ListLocationPagingByTopLocationId(int locationId, int page, int pageSize)
        {
            return new SuccessDataResult<List<Location>>(_locationDal.ListLocationPagingByTopLocationId(locationId, page, pageSize));
        }

        public IDataResult<List<Location>> ListLocationPagingByTopLocationIdAndByTitle(string text, int locationId, int page, int pageSize)
        {
            return new SuccessDataResult<List<Location>>(_locationDal.ListLocationPagingByTopLocationIdAndByTitle(text,locationId, page, pageSize));
        }

        public IResult Update(Location location)
        {
            _locationDal.Update(location);
            return new SuccessResult(Messages.SuccessTitle, Messages.Updated);
        }
    }
}
