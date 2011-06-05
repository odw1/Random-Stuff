using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AutoMapperProfiles.Tasks.Installers
{
    public class TasksInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                AllTypes.FromThisAssembly().Where(type => type.Name.EndsWith("Tasks")).WithService.DefaultInterface().
                    Configure(c => c.LifeStyle.Transient));
        }
    }
}
