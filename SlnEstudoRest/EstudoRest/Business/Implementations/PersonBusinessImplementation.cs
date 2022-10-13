using EstudoRest.Model;
using EstudoRest.Model.Context;
using EstudoRest.Repository;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;

namespace EstudoRest.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

       
        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;

        }

        public Person Create(Person person)
        {
             return _repository.Create(person);
        }

        public void Delete(long id)
        {

            _repository.Delete(id);

        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }


        public Person FindById(long id)
        {
            return _repository.FindById(id); 
        }

        public Person Update(Person person)
        {

            return _repository.Update(person);

        }
    }
}
