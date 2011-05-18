using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using IsEveryThingMapped.Data;
using IsEveryThingMapped.External;

namespace IsEveryThingMapped
{
    public class MapperProfile : Profile
    {
        public override string ProfileName { get { return "IsEveryThingMapped Profile"; } }

        protected override void Configure()
        {
            // External Entities

            AutoMapper.Mapper.CreateMap<AddressExternalEntity, Address>();

            AutoMapper.Mapper.CreateMap<PersonExternalEntity, Person>();

            AutoMapper.Mapper.CreateMap<PersonStatusResponse, PersonStatusResponseExternalEntity>();

            // Data Entities

            AutoMapper.Mapper.CreateMap<AddressDataEntity, Address>();
            AutoMapper.Mapper.CreateMap<Address, AddressDataEntity>();

            AutoMapper.Mapper.CreateMap<PersonDataEntity, Person>();
            AutoMapper.Mapper.CreateMap<Person, PersonDataEntity>();
        }
    }
}
