using EstudoRest.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EstudoRest.Repository
{

    public interface ICadGruRepository 
    {
        CadGru Create(CadGru cadGru);

        CadGru Update(CadGru cadGru);

        void Delete(string codGru);

        List<CadGru> FindByCodGru(string codGru);

        List<CadGru> FindByNomGru(string nomGru);

        bool Exists(string codGru);

        int GetCount(string query);

    }
}
