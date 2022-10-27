using EstudoRest.Model;
using EstudoRest.Model.Base;

namespace EstudoRest.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);

        Person FindById(long id);

        List<T> FindAll();

        Person Update(T item);

        void Delete(long id);

        bool Exists(long id);

    }
}
