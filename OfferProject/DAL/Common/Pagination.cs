using System.ComponentModel.DataAnnotations;

namespace DAL.Commons;

public class Pagination([Range(1, int.MaxValue)] int page, [Range(1, int.MaxValue)] int size)
{
    public int Page { get; set; } = page;
    public int Size { get; set; } = size;
    public string? OrderBy {get; set;}
}