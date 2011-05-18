using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IsEveryThingMapped.Data;
using IsEveryThingMapped.External;

namespace IsEveryThingMapped.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Rules
             * 
             * External entities are only mapped one way (either to or from)
             * Data entities are mapped both ways
             **/

            AutoMapper.Mapper.AddProfile<MapperProfile>();

            // External Entites
            var addressExternalEntity = new AddressExternalEntity { Id = 1, Line1 = "Line1", Line2 = "Line2", Line3 = "Line3" };
            AutoMapper.Mapper.Map<AddressExternalEntity, Address>(addressExternalEntity);

            var personExternalEntity = new PersonExternalEntity {Id = 10, Name = "Bob"};
            AutoMapper.Mapper.Map<PersonExternalEntity, Person>(personExternalEntity);

            var personStatusResponse = new PersonStatusResponse {PersonId = 324};
            AutoMapper.Mapper.Map<PersonStatusResponse, PersonStatusResponseExternalEntity>(personStatusResponse);

            // Data Entities
            var address = new Address { Id = 1, Line1 = "Line1", Line2 = "Line2", Line3 = "Line3" };
            var addressDataEntity = AutoMapper.Mapper.Map<Address, AddressDataEntity>(address);
            address = AutoMapper.Mapper.Map<AddressDataEntity, Address>(addressDataEntity);

            var person = new Person { Id = 10, Name = "Bob" };
            var personDataEntity = AutoMapper.Mapper.Map<Person, PersonDataEntity>(person);
            person = AutoMapper.Mapper.Map<PersonDataEntity, Person>(personDataEntity);

            Console.ReadKey();
        }
    }
}
