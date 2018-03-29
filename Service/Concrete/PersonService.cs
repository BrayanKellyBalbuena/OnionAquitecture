using Data.Models;
using Service.Abstracts;

namespace Service.Concrete
{
    public class PersonService : GenericService<Person>, IPersonService
    {
    }
}
