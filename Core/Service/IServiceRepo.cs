using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IServiceRepo<T>
    {
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);

        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int id);
    }
}
