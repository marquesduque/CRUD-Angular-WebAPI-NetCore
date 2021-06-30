using SampleWebApiAspNetCore.Repositories;
using System.Threading.Tasks;

namespace SampleWebApiAspNetCore.Services
{
    public interface IDataService
    {
        Task Initialize(productDbContext context);
    }
}
