using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoMapperProfiles.Domain.Contracts
{
    public interface IPersonRepository
    {
        Person GetById(int personId);
    }
}
