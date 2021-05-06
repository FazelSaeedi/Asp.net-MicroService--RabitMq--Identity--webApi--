using Microservice.Services.Activities.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Services.Activities.Domain.Repositoies
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(string name);
        Task<IEnumerable<Category>> BrowseAsync();
        Task AddAsync(Category category); 
    }
}
