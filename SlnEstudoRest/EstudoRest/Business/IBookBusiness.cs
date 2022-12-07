using EstudoRest.Data.VO;
using EstudoRest.HyperMedia.Utils;
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

        PagedSearchVO<BookVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int currentPage);

    }
}
