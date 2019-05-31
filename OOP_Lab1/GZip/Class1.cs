using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginFramework;
using Ionic.Zlib;

namespace GZip
{
    public class GZip : IPlugin
    {
        public string Name => "gz";

        public void Archive(FileStream file)
        {
            var bytes = File.ReadAllBytes(file.Name);
            string fileName = file.Name;
            string filePath = Path.GetDirectoryName(fileName);
            FileStream compressedFile = File.Create(filePath + @"\\" + Path.GetFileName(fileName) + ".gz");

            using (GZipStream gzip = new GZipStream(compressedFile, CompressionMode.Compress, CompressionLevel.Level8, false))
            {
                gzip.FileName = file.Name;
                file.CopyTo(gzip);
                //gzip.Write(bytes, 0, bytes.Length);
            }
        }

        public FileStream DeArchive(FileStream file, ref string extension)
        {
            string filePath = Path.GetDirectoryName(file.Name);
            string fileExtension1 = Path.GetFileNameWithoutExtension(file.Name);
            extension = Path.GetExtension(fileExtension1);
            using (GZipStream gzip = new GZipStream(file, CompressionMode.Decompress))
            {
                FileStream tempFile = new FileStream(filePath + @"\\" + "temp" + fileExtension1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                gzip.CopyTo(tempFile);
                //extension = Path.GetExtension(e.FileName);
                file.Close();
                return tempFile;
            }
        }
    }
}
