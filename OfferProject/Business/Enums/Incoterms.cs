
namespace Business.Enums;

public static class Incoterms {
    public static readonly string DDP = "Delivered Duty Paid";
    public static readonly string DAT = "Delivered At Place";

    public static bool IsValid(string value){
        return DDP.Equals(value) || DAT.Equals(value);
    }
}