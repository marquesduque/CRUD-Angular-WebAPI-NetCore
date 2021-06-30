using SampleWebApiAspNetCore.Entities;
using SampleWebApiAspNetCore.Helpers;
using SampleWebApiAspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace SampleWebApiAspNetCore.Repositories
{
    public class productSqlRepository : IRepository
    {
        private readonly productDbContext _productDbContext;

        public productSqlRepository(productDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public productEntity GetSingle(int id)
        {
            return _productDbContext.productItems.FirstOrDefault(x => x.id == id);
        }

        public void Add(productEntity item)
        {
            _productDbContext.productItems.Add(item);
        }

        public void Delete(int id)
        {
            productEntity productItem = GetSingle(id);
            _productDbContext.productItems.Remove(productItem);
        }

        public productEntity Update(int id, productEntity item)
        {
            _productDbContext.productItems.Update(item);
            return item;
        }

        public List<productEntity> GetAll(QueryParameters queryParameters)
        {
            return  _productDbContext.productItems.ToList();

        }

        public int Count()
        {
            return _productDbContext.productItems.Count();
        }

        public bool Save()
        {
            return (_productDbContext.SaveChanges() >= 0);
        }

    }
}
