using System.IO;

namespace Business.Implementations
{
    public class FileBusinessImpl : IFileBusiness
    {
        public byte[] GetPDFFile()
        {
            string path = Directory.GetCurrentDirectory();

            string fullPath = path + "\\FilesDownload\\apsnet.pdf";
            return File.ReadAllBytes(fullPath);
        }
    }
}
