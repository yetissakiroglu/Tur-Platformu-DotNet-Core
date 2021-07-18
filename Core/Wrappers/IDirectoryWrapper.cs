using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Wrappers
{
  public interface IDirectoryWrapper
    {
        bool Exists(string path);
        DirectoryInfo CreateDirectory(string path);
    }
}
