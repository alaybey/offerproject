
namespace Business.DTO;
public class BaseQueryResponseModel<T>
where T : class
{
   public IEnumerable<T>? Data {get; set;}

   public int Pages {get; set;}

   public int Current {get; set;} 

   public int Total {get; set;}
}