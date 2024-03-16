namespace Business.Enums;

public static class Unit1 {
    public static readonly string CM = "CM";
    public static readonly string IN = "IN"; 

    public static bool IsValid(string value){
        return new[]{CM, IN}.Contains(value);
    }
}

public static class Unit2 {
    public static readonly string KG = "KG";
    public static readonly string LB = "LB";

    public static bool IsValid(string value){
        return new[]{KG, LB}.Contains(value);
    }
}