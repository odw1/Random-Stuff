using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoMapperProfiles.Framework
{
    public interface IMapper
    {
        T Map<T>(params object[] sources) where T : class;

        void Map(object destination, params object[] sources);
    }
}
