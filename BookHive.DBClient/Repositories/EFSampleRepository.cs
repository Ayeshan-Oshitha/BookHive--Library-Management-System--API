using BookHive.DBClient.Contracts;
using BookHive.DBClient.EntityModels;

namespace BookHive.DBClient.Repositories
{
    public class EFSampleRepository : ISampleRepository
    {
        public EFDbContext _DbContext { get; set; }

        public EFSampleRepository(EFDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public IQueryable<Sample> getSampleData()
        {
           return _DbContext.Samples;
        }
    }
}
