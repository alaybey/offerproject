using Core.Entities;
using Dal.Repositories;
using DAL.Persistence;

namespace DAL.Repositories;


public class CountryRepository(DatabaseContext context) : BaseRepository<Country>(context), ICountryRepository
{
    
}
