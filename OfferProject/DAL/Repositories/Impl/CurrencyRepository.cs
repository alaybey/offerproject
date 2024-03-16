using Core.Entities;
using DAL.Persistence;

namespace DAL.Repositories;

public class CurrencyRepository(DatabaseContext context) : BaseRepository<Currency>(context), ICurrencyRepository
{
}