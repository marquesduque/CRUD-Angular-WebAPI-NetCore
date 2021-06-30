using System.Collections.Generic;
using System.Linq;
using SampleWebApiAspNetCore.Entities;
using SampleWebApiAspNetCore.Models;

namespace SampleWebApiAspNetCore.Repositories
{
    public interface IRepository
    {
        productEntity GetSingle(int id);
        void Add(productEntity item);
        void Delete(int id);
        productEntity Update(int id, productEntity item);
        List<productEntity> GetAll(QueryParameters queryParameters);

        int Count();

        bool Save();
    }
}
