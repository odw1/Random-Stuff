using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapperProfiles.Domain;

namespace AutoMapperProfiles.Web.Models
{
    public class PersonViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "PersonViewModelMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Person, PersonViewModel>()
                .ForMember(x => x.Name, y => y.ResolveUsing<PersonNameResolver>());
        }
    }

    public class PersonNameResolver : ValueResolver<Person, string>
    {
        protected override string ResolveCore(Person source)
        {
            return source.Surname + ", " + source.Firstname;
        }
    }
}