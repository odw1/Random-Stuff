using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace AutoMapperProfiles.Web
{
    public static class AutoMapperConfiguration
    {
        public static void Configure(Profile[] profiles)
        {
            Mapper.Initialize(x => BuildAutoMapperConfiguration(Mapper.Configuration, profiles));
        }

        private static void BuildAutoMapperConfiguration(IConfiguration configuration, IEnumerable<Profile> profiles)
        {
            foreach (var profile in profiles)
            {
                configuration.AddProfile(profile);
            }
        }
    }
}