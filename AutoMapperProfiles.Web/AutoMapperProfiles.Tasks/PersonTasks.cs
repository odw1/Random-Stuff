using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapperProfiles.Domain;
using AutoMapperProfiles.Domain.Contracts;

namespace AutoMapperProfiles.Tasks
{
    public class PersonTasks : IPersonTasks
    {
        private readonly IPersonRepository _personRepository;

        public PersonTasks(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person Get(int personId)
        {
            var person = _personRepository.GetById(personId);
            return person;
        }
    }
}
