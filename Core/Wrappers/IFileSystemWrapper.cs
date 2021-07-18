using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Wrappers
{
   public interface IFileSystemWrapper
    {
        IFileWrapper File { get; set; }
        IDirectoryWrapper Directory { get; set; }
        IPathWrapper Path { get; set; }
    }
}
