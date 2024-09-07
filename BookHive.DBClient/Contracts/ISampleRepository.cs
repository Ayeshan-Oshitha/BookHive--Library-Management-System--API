

using BookHive.DBClient.EntityModels;

namespace BookHive.DBClient.Contracts
{
    public interface ISampleRepository
    {
        IQueryable<Sample> getSampleData();
    }
}
