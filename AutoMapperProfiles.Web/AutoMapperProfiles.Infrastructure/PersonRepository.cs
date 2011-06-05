using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapperProfiles.Domain;
using AutoMapperProfiles.Domain.Contracts;
using AutoMapperProfiles.Framework;

namespace AutoMapperProfiles.Infrastructure
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMapper _mapper;

        public PersonRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Person GetById(int personId)
        {
            var dataEntity = new PersonDataEntity {Id = personId, Firstname = "John", Surname = "Doe"}; // Call EF or something here
            var person = _mapper.Map<Person>(dataEntity);

            return person;
        }
    }
}
