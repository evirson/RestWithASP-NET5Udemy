using EstudoRest.Data.VO;
using EstudoRest.HyperMedia.Utils;
using EstudoRest.Model;

namespace EstudoRest.Business
{
    public interface ICadGruBusiness
    {
        CadGruVO Create(CadGruVO cadGru);

        CadGruVO Update(CadGruVO cadGruVO);

        void Delete(string codGru);

        List<CadGruVO> FindByCodGru(string codGru);

        PagedSearchVO<CadGruVO> FindWithPagedSearch(string nomGru, string sortDirection, int pageSize, int currentPage);

    }
}
