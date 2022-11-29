using EstudoRest.Data.VO;
using EstudoRest.Model;

namespace EstudoRest.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);

        List<Person> FindByName(string firstName, string secondName);

    }
}
