using Microservice.Services.Activities.Domain.Models;
using Microservice.Services.Activities.Domain.Repositoies;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace Microservice.Services.Activities.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        IMongoDatabase _database;

        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Activity> GetAsync(Guid id)
            => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.Id == id);


        public async Task AddAsync(Activity activity)
            => await Collection.InsertOneAsync(activity);

        public async Task DeleteAsync(Guid id)
            => await Collection.DeleteOneAsync(x => x.Id == id );



        private IMongoCollection<Activity> Collection => _database.GetCollection<Activity>("Activities");

    }
}
