using Core.Entities;
using DAL.Persistence;

namespace DAL.Repositories;

public class OfferRepository(DatabaseContext context) : BaseRepository<Offer>(context), IOfferRepository
{
}