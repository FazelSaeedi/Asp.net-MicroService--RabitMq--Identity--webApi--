using System;
using System.Threading.Tasks;

namespace Microservice.Services.Activities.Domain.Repositoies
{
    public interface IActivityRepository
    {
        Task<Models.Activity> GetAsync(Guid id);
        Task AddAsync(Models.Activity activity);
        Task DeleteAsync(Guid id);
    }
}
