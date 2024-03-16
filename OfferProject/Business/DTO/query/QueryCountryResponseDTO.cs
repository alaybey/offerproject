namespace Business.DTO;

public class QueryCountryResponseDTO{

    public int Id {get; set;}
    public required string Name {get; set;}
    public required ICollection<QueryCityResponseDTO> Cities { get; set;}
}