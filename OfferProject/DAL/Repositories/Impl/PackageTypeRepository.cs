using Core.Entities;
using DAL.Persistence;

namespace DAL.Repositories;


public class PackageTypeRepository(DatabaseContext context) : BaseRepository<PackageType>(context), IPackageTypeRepository{

}