using EstudoRest.Model;
using EstudoRest.Model.Context;
using EstudoRest.Repository;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;

namespace EstudoRest.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IBookRepository _repository;

       
        public BookBusinessImplementation(IBookRepository repository)
        {
            _repository = repository;

        }

        public Book Create(Book book)
        {
             return _repository.Create(book);
        }

        public void Delete(long id)
        {

            _repository.Delete(id);

        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }


        public Book FindById(long id)
        {
            return _repository.FindById(id); 
        }

        public Book Update(Book book)
        {

            return _repository.Update(book);

        }
    }
}
