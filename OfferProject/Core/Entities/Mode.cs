using Core.Common;

namespace Core.Entities;

public class Mode : BaseEntity<int>{
    public required string Value { get; set;}
}