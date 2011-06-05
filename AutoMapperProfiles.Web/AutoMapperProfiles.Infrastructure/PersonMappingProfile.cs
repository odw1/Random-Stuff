using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapperProfiles.Domain;

namespace AutoMapperProfiles.Infrastructure
{
    public class PersonMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "PersonMapperProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<PersonDataEntity, Person>();
        }
    }
}
