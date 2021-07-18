using Autofac;
using Core.Services.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dependecy_Resolves.Infrastructure
{
    public class FileManagerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileManager>().As<IFileManager>();
        }
    }
}
