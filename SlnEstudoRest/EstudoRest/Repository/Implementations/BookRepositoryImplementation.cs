using EstudoRest.Model;
using EstudoRest.Model.Context;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;

namespace EstudoRest.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
            {
        private MySQLContext _context;

        private volatile int count;

        
        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;

        }

        public Book Create(Book Book)
        {
            try
            {
                _context.Add(Book);

                _context.SaveChanges(); 

            }
            catch (Exception ex)
            {

                throw;
            }

            return Book;
        }

        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {


                try
                {

                    _context.Books.Remove(result);

                    _context.SaveChanges();

                }
                catch (Exception ex)
                {

                    throw;
                }
            }


        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Book FindById(long id)
        {
            return _context.Books.SingleOrDefault(p  => p.Id.Equals(id));
        }

        public Book Update(Book Book)
        {
            if (!Exists(Book.Id)) return null; 

            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(Book.Id));

            if (result != null)
            {


                try
                {

                    _context.Entry(result).CurrentValues.SetValues(Book);

                    _context.SaveChanges();

                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return Book;

        }

        public bool Exists(long id )
        {
            return _context.Books.Any(p => p.Id.Equals(id));
        }
    }
}
