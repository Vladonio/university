using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginFramework
{
    public interface IPlugin
    {
        string Name { get; }

        void Archive(FileStream file);

        FileStream DeArchive(FileStream file, ref string extension);
    }
}
