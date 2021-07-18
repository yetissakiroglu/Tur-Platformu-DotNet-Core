using Autofac;
using Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dependecy_Resolves.Infrastructure
{
    public class FileSystemWrapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileWrapper>().As<IFileWrapper>().SingleInstance();
            builder.RegisterType<DirectoryWrapper>().As<IDirectoryWrapper>().SingleInstance();
            builder.RegisterType<PathWrapper>().As<IPathWrapper>().SingleInstance();
            builder.RegisterType<FileSystemWrapper>().As<IFileSystemWrapper>().SingleInstance();
        }
    }
}
