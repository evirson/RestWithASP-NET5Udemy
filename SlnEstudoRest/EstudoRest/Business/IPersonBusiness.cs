using EstudoRest.Data.VO;
using EstudoRest.Model;

namespace EstudoRest.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);

        PersonVO FindById(long id);

        List<PersonVO> FindAll();

        PersonVO Update(PersonVO person);

        void Delete(long id);

        PersonVO Disable(long id);

        List<PersonVO> FindByName(string firstName, string secondName);

    }
}
