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

    public class DotNet6
    {
        void ProgramCsHakkında()
        {
            var builder = WebApplication.CreateBuilder(args);
            // Bu builder nesnesi üzerinden uygulamada ayağa kalkacak servisleri tanımlıyoruz.Buradan var app e kadar servis eklenebilir

            builder.Services.AddCors();//Servis ekleme örneği
            builder.Services.AddHttpContextAccessor();//Requestten http cntexe ulaşmak için servis ekledik
            builder.Services.AddControllersWithViews();//Controller view kullanmak için servis

            Console.WriteLine(builder.Configuration["Conf:A"]);//appsettings.jsondan okuma yapar. Conf içindeki anın değerini okur

            var app = builder.Build();//Builderi app nesnesine build ettik. Buradan app.Run akadar middleware tanımlanabilir.
            //Eklediğimiz servislere ulaşmak için buradan sonraki kodları yazıyoruz. Servisi ekledik buildledik. Onu kullanıyoruz

            app.UseCors();//app nesnesine middleware tanımlaması yaptık
            app.Services.GetService<IHttpContextAccessor>();//Kullanabilmek içinde onu çektik. Dependency injection ile kullanabiliriz artık.
            
            app.MapGet("/", () => "Hello Fucking World!");//Minimal api get methodu tanımlaması

            //Başka bir json dosyasından konfigurasyon dosyası alma yöntemi
            ConfigurationManager cm = new();
            cm.AddJsonFile("conf.json");
            Console.WriteLine(cm["Conf:A"]);



            app.Run();//app i çalıştırdık. GG


            //Iconfiguration: Middleware'ler üzerinde konfigürasyonel değere erişim ihtiyacı varsa kullanılır. app.Configuration

            //ConfigurationManager: Service entegrasyonları sürecinde herhangi bir konfigursayonel değere ihtiyacımız varsa
            //(appsettings.json, environment variable vs.) bu değeri bize getiren türdür. builder.Configuration[...]
            //Dotnet5 te aşşağıdaki gibi yapıp buıild ettiğimiz için çok maaliyetli idi.
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("conf.json");
            IConfigurationRoot configurationRoot = configurationBuilder.Build();
            var sonuc = configurationRoot["Conf:A"];

        }

    }

}
