using Core.Common;

namespace Core.Entities;

public class City : BaseEntity<int> {

    public required string Name {get; set;}
    public int CountryId { get; set;}
    public Country Country { get; set; } = null!;

}