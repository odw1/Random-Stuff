using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AutoMapperProfiles.Infrastructure.Installers
{
    public class AutoMapperProfilesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                AllTypes.FromThisAssembly().BasedOn<Profile>().Configure(
                    c => c.LifeStyle.Transient.Named(c.Implementation.Name)));
        }
    }
}
