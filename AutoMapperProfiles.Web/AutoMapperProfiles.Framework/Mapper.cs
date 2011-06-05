using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoMapperProfiles.Framework
{
    public class Mapper : IMapper
    {
        public T Map<T>(params object[] sources) where T : class
        {
            if (!sources.Any())
            {
                return default(T);
            }

            var initialSource = sources[0];

            var mappingResult = this.Map<T>(initialSource);

            // Now map the remaining source objects
            if (sources.Count() > 1)
            {
                this.Map(mappingResult, sources.Skip(1).ToArray());
            }

            return mappingResult;
        }

        public void Map(object destination, params object[] sources)
        {
            if (!sources.Any())
            {
                return;
            }

            var destinationType = destination.GetType();

            foreach (var source in sources)
            {
                var sourceType = source.GetType();
                AutoMapper.Mapper.Map(source, destination, sourceType, destinationType);
            }
        }

        private T Map<T>(object source) where T : class
        {
            var destinationType = typeof(T);
            var sourceType = source.GetType();

            var mappingResult = AutoMapper.Mapper.Map(source, sourceType, destinationType);

            return mappingResult as T;
        }
    }
}
