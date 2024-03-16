using Core.Entities;
using DAL.Persistence;

namespace DAL.Repositories;


public class ModeRepository(DatabaseContext context) : BaseRepository<Mode>(context), IModeRepository{
    
}