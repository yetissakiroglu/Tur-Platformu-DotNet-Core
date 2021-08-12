using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YonetimUI.Extensions;

namespace YonetimUI.Dependecy_Resolves.Extensions
{
    public class TreeviewLocationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TreeviewLocation>().As<ITreeviewLocation>();
        }
    }
}
