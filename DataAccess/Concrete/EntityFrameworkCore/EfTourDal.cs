using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.EntityFrameworkCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Concrete.EntityFrameworkCore
{
    public class EfTourDal : EfEntityRepositoryBase<tour, AppDbContext>, ITourDal
    {

    }
}
