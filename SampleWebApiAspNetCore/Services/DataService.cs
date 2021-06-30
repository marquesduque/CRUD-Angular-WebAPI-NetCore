using SampleWebApiAspNetCore.Entities;
using SampleWebApiAspNetCore.Repositories;
using System;
using System.Threading.Tasks;

namespace SampleWebApiAspNetCore.Services
{
    public class DataService : IDataService
    {
        public async Task Initialize(productDbContext context)
        {
            //context.productItems.Add(new productEntity() { Calories = 1000, Type = "Starter", Name = "Lasagne", Created = DateTime.Now });
            //context.productItems.Add(new productEntity() { Calories = 1100, Type = "Main", Name = "Hamburger", Created = DateTime.Now });
            //context.productItems.Add(new productEntity() { Calories = 1200, Type = "Dessert", Name = "Spaghetti", Created = DateTime.Now });
            //context.productItems.Add(new productEntity() { Calories = 1300, Type = "Starter", Name = "Pizza", Created = DateTime.Now });

            //await context.SaveChangesAsync();
        }
    }
}
