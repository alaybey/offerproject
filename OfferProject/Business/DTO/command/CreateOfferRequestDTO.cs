using Business.Enums;
using Core.Entities;

namespace Business.DTO;

public class CreateOfferRequestDTO{

    public required int Mode { get; set;}
    public required int Country { get; set; }
    public required int City { get; set;}
    public required int PackageType { get; set;}
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

    
}