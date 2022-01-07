namespace CSharpNotları
{
    public class OOP
    {
        #region Constructor Method
        //Nesne üretirken üretilen ilk fonksiyondur. Static Constructor hariç. 
        class MyClass2 {
            MyClass2()
            {
                Console.WriteLine("");//Constructır tnaımlaması
            }
            MyClass2(int a) : this ()
            {
                Console.WriteLine (a);//Overload Constructor
            }
            MyClass2(int a,int b) : this(a)
            {
                Console.WriteLine(a+b);//Overload Constructor
            }
        }
        new MyClass2(5,10);//Bunda önce MyClass2(), sonra MyClass2(5) en sonda MyClass2(5,10)çalışır.
        //İlk this 2. overloadı tetikler. İkinci overloaddaki this asıl classı tetikler. Sırasıyla
        //asıl ikinci ve üçüncü overloadların consolewriteline ları yazılır.
        new MyClass2(5);//Bunda önce MyClass2() çalışır sonra diğeri. Çünkü this kullanımından
        new MyClass2();//Kullanımları
        #endregion

        #region Deconstruct Method
        //Sınıftan geriye hızlıca bir Tuple değer döndürmemizi sağlar 
        //Overload edilebilir
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public void Deconstruct (out string name, out int age)
            {
                name = Name;
                age = Age;
            }
            //Kullanımı:
            //Person person = new Person
            //{
            //    Name = "Kaan",
            //    Age = 15
            //};
            //var(x,y) = person;
        }
        #endregion

        #region Destructor Method//Yıkıcı Method
        /*Bir nesnenin imha edilmesi için:
            *İlgili nesne herhangi bir referans tarafında işaretlenmiyorsa
            *Yahut nesnenin oluşturulduğu ve kullanıldığı scope sona ermişse
            *Yani anlaşılan nesneye birdaha erişilemez hale gelmeli
        */
        /*Garbage Collector: Nesnelerin imhasını sağlayan yapı.
        Ne zaman iş göreceği tahmin edilemez. Yazılımcıların müdehale etmesi önerilmez.
        */
        class MyClass3
        {
            ~MyClass3()//Destructor tanımlaması. İmhadan hemen önce çalışır
            {

            }
        }
        #region GarbageCollector Tetikleme
        //GC.Collect();
        #endregion

        #endregion

        #region DeepCopy
        class MyClass
        {
            public MyClass Clone()
            {
                return (MyClass)this.MemberwiseClone();
            }
        }
        MyClass m1 = new MyClass();
        MyClass m2 = m1;//Shallow Copy:Referansı işaret eder kopyalam oluşturmaz
        MyClass m3 = m1.Clone();//deep Copy:Aynısından bir başka oluşturur
        #endregion

        #region Inheritance (Kalıtım)

        //17.22 ilk video 



        #endregion

        #region Propertyİmzaları()

        int yasi;
        string b;
        #region FullProperty
        //[erişimbelirleyici][içeriktipi][propertyadı]
        //{
        //    get { }/* =>Property'den veri istendiğinde tetiklenir.*/
        //    set{ } //=> Propertyİmzaları'e veri gönderildiğinde tetiklenir.
        //    //    Gönderilen veriyi value keywordü ile yakalar.
        //    // Set bloğu tanımlanmazsa readonly, get bloğu tanımlanmazsa writeonly olur
        //}
        public int Yasi
        {
            get { return yasi; }
            set { yasi = value; }
        }

        #endregion
        #region Prop
        //Readonly only yapabiliriz ama writeonly yapamayız.
        #endregion
        #region Auto Property Initializer
        public string B { get; set; } = "sadas";
        #endregion
        #region RefReadOnlyProperty
        string adi = "KaanaKCAN";//Sürekli nesne oluşturmaktansa reerans ile bellek optimizasyonu yapmamıza olanak sağlar.
        public ref readonly string Adi => ref adi;
        #endregion
        #region ComputedProperties
        int a = 10;
        int f = 15;
        public int Topla
        {
            get { return a + f; }
        }
        #endregion
        #region Expression-Bodied Property
        public string Cinsiyet => "Erkek";//Sadece readonly de kullanılıyor
        #endregion
        #region Inıt-Only Properties-Inıt Accessor
        class Book//bu property ile ilk tanımlamada değer verebildiğimiz
                  //Sonra readonly olan fieldlar tanımlayabiliyoruz
        {
            public int Id { get; init; }
            public int MyProperty { get; init; }
        }
        #endregion
        #region Indexer
        public int this[int y]
        {
            get { return y; }
        }
        #endregion
        #endregion

        #region Record
        record MyRecord//Recordlarlar classtaki tüm fieldlar init-only ise kullanılır
        {//içerisinde method vs herşey tanımlanabilir.
            public int MyProperty { get; init; }
        }

        #region Record güncelleme
        MyRecord m = new MyRecord
        {
            MyProperty = 5
        };
        MyRecord m2 = m with { MyProperty = 10 };
        #endregion

        #region Positional Record
        //Nominal Recorlar Object Initializer ile ilk değerleri verilerek üretilebilen readonly datalardı
        //Positional REcorlar ise esasında Recorlar içerisinde tanımlama yapabildiğimiz constructor ve deconstructor
        //kullanımları daha da özelleştirilerek kullanılmasını sağlamaktadır.

        /*Normalde*/
        record MyRecord2
        {
            public MyRecord2()
            {

            }
            public void Deconstruct()
            {

            }
        }

        /*Positional*/
        record MyRecord3(string name, string surname)
        {//Üstteki tanımla yapıldığında kendi kendine name,surname propertylerini init olarak tanımlar
        //Deconstructlarını oluşturur                        
        }
        //Kullanımı
        //MyRecord3 m = MyRecord3("Kaan", "Akcan");
        //var(n,s) = m;
        #endregion

        #region PositonalREcordda ayrıca Constructır tanımala
        record MyRecord4(string name, string surname)
        {
            public MyRecord4() : this("asdasd", "asdasd")
            {

            }
            public MyRecord4(string name) : this()
            {

            }
            public string Name => name;//Buda dışardan küçük harfle başlattığımız değişkenleri büyükharfle başlatmak için
            public string Surname => surname;
        }
        #endregion

        #endregion

        #region SingletonDatebase with Static Constructor Method
        //Bir sınıftan ugulama bazında sadece tek bir nesne oluşmasını istiyorsak kullabileceğimiz pattern
        class Database
        {
            Database()// hiçbirşey yazmazsak private oluyor
            {

            }
            public string ConnectionString { get; set; }
            static Database database;
            static public Database GetInstance { get { return database; } }
            static Database()
            {
                database = new Database();
            }

        }

        var database1 = Database.GetInstance;
        var database2 = Database.GetInstance;
        var database3 = Database.GetInstance;
        database1.ConnectionString = "asdasd";//Yaptığımızda bütün hepsi değişir
        #endregion

        #region Static Constructor Method
        // Bir sınıftan nesne üretilirken ilk tetiklenen fonksiyon Constructur dır () yani.
        //Ancak bir sınıftan ilk nesne üretirken ilk tetiklenen fonksiyon Static Constructırdır.
        class MyClass5
        {
            public MyClass5()
            {
                //Constructır tanımlaması
            }
            static MyClass5()
            {
                //Statik Constructır tanımlaması. Overloading yapılmaz.Parametre almaz.
                //İsmi sınıf ismi ile aynı olmak zorunda
            }
        }
        #endregion

    }
}
