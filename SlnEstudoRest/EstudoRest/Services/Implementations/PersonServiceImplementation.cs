using EstudoRest.Model;
using EstudoRest.Model.Context;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;

namespace EstudoRest.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;

        private volatile int count;

        
        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;

        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);

                _context.SaveChanges(); 

            }
            catch (Exception ex)
            {

                throw;
            }

            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {


                try
                {

                    _context.Persons.Remove(result);

                    _context.SaveChanges();

                }
                catch (Exception ex)
                {

                    throw;
                }
            }


        }

        public List<Person> FindAllMock()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Evirson" + i,
                LastName = "Fiorilo" + i,
                Address = "Curitiba",
                Gender = "Male"

            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p  => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person(); 

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {


                try
                {

                    _context.Entry(result).CurrentValues.SetValues(person);

                    _context.SaveChanges();

                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return person;

        }

        private bool Exists(long id )
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
