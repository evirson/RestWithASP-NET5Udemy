using EstudoRest.Data.Converter.Implementations;
using EstudoRest.Data.VO;
using EstudoRest.HyperMedia.Utils;
using EstudoRest.Model;
using EstudoRest.Model.Context;
using EstudoRest.Repository;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Drawing.Text;

namespace EstudoRest.Business.Implementations
{
    public class CadGruBusinessImplementation : ICadGruBusiness
    {
        private readonly ICadGruRepository _repository;
        private readonly CadGruConverter _converter;

        public CadGruBusinessImplementation(ICadGruRepository repository)
        {
            _repository = repository;
            _converter = new CadGruConverter();
        }

        public CadGruVO Create(CadGruVO cadGru)
        {
            var cadGruEntity = _converter.Parse(cadGru);
            cadGruEntity = _repository.Create(cadGruEntity);
            return _converter.Parse(cadGruEntity);

        }

        public void Delete(string codGru)
        {
            _repository.Delete(codGru);
        }

        public List<CadGruVO> FindByCodGru(string codGru)
        {
            return _converter.Parse(_repository.FindByCodGru(codGru));
        }

        public PagedSearchVO<CadGruVO> FindWithPagedSearch(string nomGru, string sortDirection, int pageSize, int currentPage)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = currentPage > 0 ? (currentPage - 1) * size : 0;


            string query = @"select * from cadgru p where 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(nomGru)) query = query + $"and p.nomgru like '%{nomGru}%' ";

            query += $" order by p.nomgru {sort} limit {size} offset {offset} ";

            var grupos = _repository.FindByNomGru(query);


            string countQuery = @"select count(*) from cadgru p where 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(nomGru)) countQuery = countQuery + $"and p.nomgru like '%{nomGru}%' ";

            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<CadGruVO>
            {
                CurrentPage = offset,
                List = _converter.Parse(grupos),
                PageSize = size,
                SortDirection = sort,
                TotalResults = totalResults
            };
        }

        public CadGruVO Update(CadGruVO cadGruVO)
        {
            var personEntity = _converter.Parse(cadGruVO);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }
    }
}
