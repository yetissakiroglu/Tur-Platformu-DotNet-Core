using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository <T> where T:class,IEntity,new()
    {

        T Update(T entity);

        T Create(T entity);

        void Delete(T entity);           //bakılacak,öğrenilecek
                                       
        IList<T> GetAll(Expression<Func<T, bool>> filter = null); //bakılıp öğrenilcek

        T GetOne(Expression<Func<T, bool>> filter = null);

        T Get(Expression<Func<T, bool>> filter);




    }
}
