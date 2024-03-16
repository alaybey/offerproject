using System.ComponentModel.DataAnnotations.Schema;
using Core.Common;

namespace Core.Entities;

[Table("offer")]
public class Offer : BaseEntity<Guid>, IAuditedEntity
{

    public int ModeId { get; set; } 
    public Mode? Mode { get; set; }
    public int CityId { get; set; }    
    public City City { get; set; }
    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public int CurrencyId { get; set; }
    public required Currency Currency { get; set; }
    public int PackageTypeId { get; set; }
    public PackageType? PackageType { get; set; }
    public required string MovementType { get; set; }
    public required string Unit1 { get; set; }
    public required string Unit2 { get; set; }
    public required string Incoterm { get; set; }
    public required string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public bool IsDeleted { get; set; }
}