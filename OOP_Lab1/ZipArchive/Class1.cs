using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PluginFramework;
using Ionic.Zip;

namespace ZipArchive
{
    public class ZipArchive : IPlugin
    {
        public string Name => "Zip";

        public void Archive(FileStream file)
        {
            string fileName = file.Name;
            string filePath = Path.GetDirectoryName(fileName);
            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(fileName, "");
                zip.Save(filePath + @"\\" + Path.GetFileNameWithoutExtension(fileName) + ".zip");
            }
        }

        public FileStream DeArchive(FileStream file, ref string extension)
        {
            string filePath = Path.GetDirectoryName(file.Name);
            using (ZipFile zip = ZipFile.Read(file))
            {
                ZipEntry e = zip[0];
                    e.FileName = "temp" + e.FileName;
                    e.Extract(Path.GetDirectoryName(file.Name));
                    extension = Path.GetExtension(e.FileName);
                    file.Close();
                    file = new FileStream(filePath + @"\\" + e.FileName, FileMode.Open, FileAccess.Read);
                return file;
            }
        }
    }
}
