using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AutoMapperProfiles.Web.Installers
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