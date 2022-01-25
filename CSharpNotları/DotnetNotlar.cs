namespace CSharpNotları
{
    public class DotnetNotlar
    {

        class ÖrnekModel
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public int ListPrice { get; set; }
            public string Category { get; set; }
            public string ProductName { get; set; }
            public int Price { get; set; }

        }

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
            if (directoryInfos.Any())
            {
                foreach (DirectoryInfo directory in directoryInfos)
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

        
        void Linq()
        {
            
            var list = new List<ÖrnekModel>();
            list.Take(5);                               //En üstten ilk beşini alır
            list.OrderByDescending(x => x.Id);           //Id ye göre terseten sıralar
            list.Select(u => new { u.Id,u.FirstName });   //listeyi Id ve FirstName alanına göre yeni listeye çevirir.
            list.Average(u => u.ListPrice);             //Ortalama Değerini döndürür
            list.Count(u => u.Category == "muhittin");      //Kategorisi muhittin olanların toplamı
            list.Sum(u => u.ListPrice);                 //ListPrice değerlerini toplar
            list.Where(u => u.ProductName.Contains("elma")); //ProductName i elma içerenleri dönderir.
            list.Min(u => u.Price);  //Minimum değerini dönderir
            list.Max(u => u.Price);   //Maximum değerini dönderir
            
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


        void MinimalApi()
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var connectionString = builder.Configuration.GetConnectionString("");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


            var app = builder.Build();

            if (app.Enviroment.IsDevelopment())
            {
                app.UseSwagger();
                app.SwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapGet("v1/Todo", async (AppDbContext db) =>
            {
                var bla = await db.blabla.ToListAsync();
                return Results.Ok(bla);
            }).WithName("BlaBla").Produces(200).Prdoduces<List<blaModel>>();


            app.MapGet("v1/Doto/{id}", async (AppDbContxt db,int id) =>
            {
                var bla = await db.blabla.FistOrDefault(x => x.Id == id);
                if(bla==null)
                    return Results.NotFound();
                return Results.Ok(bla);
            });


            app.MapPost("v1/Todo", async (AppDbContext db, blaModel blaa) =>
            {

            }).WithName("PostBla");

            app.Run();

        }

    }

}
