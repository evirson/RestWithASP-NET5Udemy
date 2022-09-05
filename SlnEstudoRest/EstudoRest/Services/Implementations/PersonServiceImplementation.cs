﻿using EstudoRest.Model;

namespace EstudoRest.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0;i < 8; i++) 
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
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
            return new Person
            {
                Id = 1,
                FirstName = "Evirson",
                LastName = "Fiorilo",
                Address = "Curitiba",
                Gender = "Male"

            };
        }

        public Person Update(Person person)
        {
            return person;
           
        }
    }
}