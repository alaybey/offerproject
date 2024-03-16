namespace Business.Enums;
public static class MovementType
{
    public static readonly string DoorToDoor = "Door to Door";
    public static readonly string PortToDoor = "Port to Door";
    public static readonly string DoorToPort = "Door to Port";
    public static readonly string PortToPort = "Port to Port";

    public static bool IsValid(string value){
        return new[]{
            MovementType.DoorToDoor,
            MovementType.PortToDoor,
            MovementType.DoorToPort,
            MovementType.PortToPort
            }.Contains(value);
    }
}