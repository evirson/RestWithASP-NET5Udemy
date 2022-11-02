using EstudoRest.Model;

namespace EstudoRest.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO Book);

        BookVO FindById(long id);

        List<BookVO> FindAll();

        BookVO Update(BookVO Book);

        void Delete(long id);

    }
}
