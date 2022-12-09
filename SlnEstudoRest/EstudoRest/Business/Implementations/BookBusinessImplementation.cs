using EstudoRest.Data.Converter.Implementations;
using EstudoRest.Data.VO;
using EstudoRest.HyperMedia.Utils;
using EstudoRest.Model;
using EstudoRest.Model.Context;
using EstudoRest.Repository;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;

namespace EstudoRest.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IGenericRepository<Book> _repository;
        private readonly BookConverter _converter;



        public BookBusinessImplementation(IGenericRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();

        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {

            _repository.Delete(id);

        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }


        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PagedSearchVO<BookVO> FindWithPagedSearch(string title, string sortDirection, int pageSize, int currentPage)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = currentPage > 0 ? (currentPage - 1) * size : 0;


            string query = @"select * from book p where 1 = 1 ";

            if (!string.IsNullOrWhiteSpace(title)) query = query + $"and p.title like '%{title}%' ";

            query += $" order by p.title {sort} limit {size} offset {offset} ";

            var books = _repository.FindWithPagedSearch(query);


            string countQuery = @"select count(*) from book p where 1=1 ";

            if (!string.IsNullOrWhiteSpace(title)) countQuery = countQuery + $"and p.title like '%{title}%' ";

            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<BookVO>
            {
                CurrentPage = offset,
                List = _converter.Parse(books),
                PageSize = size,
                SortDirection = sort,
                TotalResults = totalResults
            };
        }

        public BookVO Update(BookVO book)
        {

            var personEntity = _converter.Parse(book);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);

        }
    }
}
