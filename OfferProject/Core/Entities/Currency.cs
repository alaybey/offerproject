using Core.Common;

namespace Core.Entities;

public class Currency : BaseEntity<int> { 

    public required string Code {get; set;}
    public required string Name {get; set;}

}