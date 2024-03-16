namespace Business.DTO;

public class QueryOfferResponseDTO{

    public required Guid Id { get; set; }
    public required string Mode { get; set;}
    public required string Country { get; set; }
    public required string City { get; set;}
    public required string PackageType { get; set;}
    private string _MovementType = Enums.MovementType.DoorToDoor;
    public required string MovementType { get => _MovementType; set {if(Enums.MovementType.IsValid(value)) _MovementType = value;}}
    private string _Incoterms = Enums.Incoterms.DAT;
    public required string Incoterms { get => _Incoterms; set {if(Enums.Incoterms.IsValid(value)) _Incoterms = value;}}
    private string _Unit1 = Enums.Unit1.CM;
    public required string Unit1 {get => _Unit1; set {if(Enums.Unit1.IsValid(value)) _Unit1 = value;}}
    private string _Unit2 = Enums.Unit2.KG;
    public required string Unit2
    {
        get => _Unit2;
        set { if (Enums.Unit2.IsValid(value)) _Unit2 = value; }
    }
    public required string Currency { get; set;}
    public required string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public required string UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    
}