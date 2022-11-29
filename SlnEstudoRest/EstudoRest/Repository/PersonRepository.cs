using EstudoRest.Model;
using EstudoRest.Model.Context;
using EstudoRest.Repository.Generic;

namespace EstudoRest.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(MySQLContext context) : base(context) { }

        public Person Disable(long id)
        {
            if (!_context.Persons.Any(p => p.Id.Equals(id))) return null;

            var user = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (user != null)
            {
                user.Enabled = false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);

                }
                catch (Exception)
                {
                    throw;
                }

            }

            return user;

        }

        public List<Person> FindByName(string firstName, string secondName)
        {
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(secondName))
            {
                return _context.Persons.Where(
                    p => p.FirstName.Contains(firstName)
                    && p.LastName.Contains(secondName)).ToList();
            }
            else if (string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(secondName))
            {
                return _context.Persons.Where(
                    p => p.FirstName.Contains(secondName)).ToList();
                    

            }
            else if (!string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(secondName))
            {
                return _context.Persons.Where(
                    p => p.FirstName.Contains(firstName)).ToList();

            }
            return null;

        }

    }
}
