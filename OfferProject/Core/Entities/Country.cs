using Core.Common;

namespace Core.Entities;


public class Country : BaseEntity<int> {
    public required string Name {get; set;}

    public ICollection<City> Cities { get; } = new List<City>();
}