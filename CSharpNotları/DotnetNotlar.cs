namespace CSharpNotları
{
    public class DotnetNotlar
    {
        void Dosyaİşlemleri()
        {
            #region İndirtme işlemi için
            var folderPath = Path.Combine(_host.WebRootPath, "Upload3", "apple.json");
            var memory = new MemoryStream();
            using (var stream = new FileStream(folderPath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;
            var ext = Path.GetExtension(folderPath).ToLowerInvariant();
            return File(memory, GetMimeTypes()[ext], Path.GetFileName(folderPath));
            //dışarıda bir yere GetMimeTpes Tanımlaması gerek

            private Dictionary<string, string> GetMimeTypes()
            {
                return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".json", "application/json"},
            };
            }
            #endregion


        }
        List<FileInfo> DosyaYazdir(string path)
        {
            List<FileInfo> fileInfos = new();
            DirectoryInfo directoryInfo = new(path);
            DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
            if(directoryInfos.Any())
            {
                foreach(DirectoryInfo directory in directoryInfos)
                {
                    fileInfos.AddRange(DosyaYazdir(directory.FullName));
                }
            }
            else
            {
                fileInfos.AddRange(directoryInfo.GetFiles());
            }
            return fileInfos;
        }
    }

}
