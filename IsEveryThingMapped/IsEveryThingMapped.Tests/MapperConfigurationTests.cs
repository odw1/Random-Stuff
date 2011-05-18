using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;
using NUnit.Framework;

namespace IsEveryThingMapped.Tests
{
    [TestFixture]
    public class MapperConfigurationTests
    {
        private List<TypeMap> _mappedTypes;

        [SetUp]
        public void SetUp()
        {
            AutoMapper.Mapper.AddProfile<MapperProfile>();
            _mappedTypes = AutoMapper.Mapper.GetAllTypeMaps().ToList();
        }

        [Test]
        public void verify_external_entities_all_mapped()
        {
            var assembly = Assembly.Load("IsEveryThingMapped.External");

            var types = assembly.GetTypes();
            var typesMissingFromMappings = types.Where(x => !_mappedTypes.Exists(t => t.SourceType == x || t.DestinationType == x)).Select(x => x.FullName);

            if (typesMissingFromMappings.Any())
            {
                Assert.Fail(string.Format("The following external entites are not mapped {0}", string.Join(",", typesMissingFromMappings)));
            }
        }

        [Test]
        public void verify_data_entites_all_mapped()
        {
            var assembly = Assembly.Load("IsEveryThingMapped.Data");

            var types = assembly.GetTypes();
            var typesMissingFromMappings = types.Where(x =>
                                                           {
                                                               var isSourceEntity =
                                                                   _mappedTypes.Exists(t => t.SourceType == x);
                                                               var isDestinationEntity =
                                                                   _mappedTypes.Exists(t => t.DestinationType == x);
                                                               return !(isSourceEntity && isDestinationEntity);
                                                           })
                .Select(x => x.FullName);

            if (typesMissingFromMappings.Any())
            {
                Assert.Fail(string.Format("The following data entites are not mapped {0}", string.Join(",", typesMissingFromMappings)));
            }
        }
    }
}
