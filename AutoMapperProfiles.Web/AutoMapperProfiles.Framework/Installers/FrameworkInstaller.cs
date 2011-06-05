using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AutoMapperProfiles.Framework.Installers
{
    public class FrameworkInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IMapper>()
                    .ImplementedBy<Mapper>()
                    .LifeStyle.Transient
                );
        }
    }
}
