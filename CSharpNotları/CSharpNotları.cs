using Microsoft.Extensions.Primitives;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
namespace CSharpNotları
{
    public class CSharpNotları
    {
        void AritmetikOperatörYöntemleri()
        {
            #region Açıklamalar
            //Aritmatik operatörlerde iki farklı tür varsa küçük olanı büyük olana bilinçsiz olrak dönüştürererk türleri eşitler
            //İki byte üzerinde yapılan artimetik işlemde sonuç her zaman int döner
            //A ^ B / A yada B doğru olması gerekir.İkisi bir yada hiçbiri olmaz.
            //C#’ta eğer operatörler eşit öncelikliyse, soldan sağa işlem yapılır.
            //(x++, x--) > (+(pozitiflik), -(negatiflik), !, ~, ++x, --x, (Type)x) > (*,/,%) > (>>,>>>,<<) > (>,>=,<,<=, instanceof) > (==,!=) > (&) > (^) > (|) > (&&) > (||) > (?:) > (=, op =)
            #endregion
        }

        void ArrayYöntemleri()
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] b = { '1', '2', '3', '4' };

            #region CreateInstance Metodu
            var h = Array.CreateInstance(typeof(int), 5);//Array oluşturmaya yarar. Aslen array define buradan yapılıyor
            var i = Array.CreateInstance(typeof(int), 5, 2, 3);//Array  3 ranklı.1inci 5 2nci 2 3üncü 3 lengthe sahip 
            #endregion
            #region Clear Metodu
            Array.Clear(a, 0, a.Length);//a dizisinin 0.elemanından başlayıp son a.Length eleman kadar değerlerini default atar.
            #endregion 
            #region Copy Metodu
            Array.Copy(a, b, 3);//a dizisinden b dizisine 3 eleman kopyala
            #endregion
            #region Çok Boyutlu Dizilerde Varyasyonla Atama İşlemi
            int[,] sayılar =
            {
                { 1, 2, 3,},
                { 4, 5, 6,},
                { 5, 6, 7,}
            };
            #endregion
            #region Düzensiz Diziler
            int[][] sayilar = new int[3][];
            sayilar[0] = new int[3] { 3, 4, 5 };
            sayilar[1] = new int[5] { 1, 2, 3, 4, 5 };
            sayilar[2] = new int[6] { 1, 2, 3, 4, 5, 6 };
            #region Length Bulma
            var z = sayilar[0].Length + sayilar[1].Length + sayilar[2].Length;
            #endregion
            #region İç içe döngüde çalışma
            for (int q = 0; q < sayilar.Length; q++)
            {
                for (int w = 0; w < sayilar[q].Length; w++)
                {
                    Console.WriteLine(sayilar[q][w]);
                }
            }
            #endregion

            #endregion
            #region IndexOf Metodu
            Array.IndexOf(a, 4);//a dizisinde + ü arayıp varsa indexini yoksa -1 dönderiyor
            Array.IndexOf(a, 4, 1, 2);//1.elemandan başlayıp 2 elemana bakar 
            #endregion            
            #region IsReadOnly Property
            var c = a.IsReadOnly;//sadece okunabilir olup olmadığını bize bildirir
            #endregion
            #region IsFixedSize Property
            var d = a.IsFixedSize;//Eleman sayısının sınırlı olup olmamasını sorgular
            #endregion
            #region Length Property
            var e = a.Length;//dizi boyunu gösteriyor
            #endregion
            #region Rank Property
            var f = a.Rank;//dizinin derecesini rankını verir
            #endregion
            #region Ranges and Indices- System.Index Türü
            Index index = 3;//Normal index tanımlaması
            index = ^3;//İndexi tersten tanımlıyor. Sondan 3.eleman. 1'den başlayarak sayıyor.
            #endregion
            #region Ranges and Indices- System.Range Türü
            Range range = 3..7;//index numarası 3 ile 7-1 arası ve bu indexler dahil array döndürür => 4,5,6,7
            range = ^7..^3;// sağdan 7.  ile 3+1.  arası ve bu değerlin bulunduğu arrayi döndürür => 2,3,4,5
            var j = a[range];
            #endregion
            #region Reverse Metodu
            Array.Reverse(a);//Diziyi tersine çevirir
            #endregion
            #region Sort Metodu
            Array.Sort(a); // Küçükten büyüğe yada alfabetik sıralıyor
            #endregion


        }

        void ArrayVeriselPerformans()
        {
            #region ArraySegment
            int[] sayilar = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
            // Dizinin belirli bir kısmı lazım olduğunda onun için başka bir dizi yaratıp onu
            //diğerinin içine atmak çok maaliyetli olur ram için. Bu yüzden kullanılır
            ArraySegment<int> segment1 = new ArraySegment<int>(sayilar);
            ArraySegment<int> segment2 = new ArraySegment<int>(sayilar, 2, 5);//30,40,50
            ArraySegment<int> segment3 = segment1.Slice(0, 3);//10,20,30
            ArraySegment<int> segment4 = segment1.Slice(4, 7);
            #endregion
            #region StringSegment
            var text = "Yüzyüzeyken Konuşuruz";
            StringSegment segment5 = new StringSegment(text);
            StringSegment segment6 = new StringSegment(text, 2, 5);//2.indexten başlayıp 5 karakter alıyoruz

            #endregion
            #region StringBuilder
            //StringBuilder + operatöründen daha az maaliyetli ve hızlı birleştirme yapan bir sınıftır
            StringBuilder builder = new StringBuilder();
            builder.Append("Merhaba").Append(" ").Append("Dünya!");
            Console.WriteLine(builder.ToString());
            #endregion
        }

        void ArrayListKoleksiyonu()
        {
            #region Tanımlama, Değer Atama ve Kullanma
            ArrayList _yaslar = new ArrayList();
            _yaslar.Add(23);
            var azax = (int)_yaslar[0];
            #endregion
            #region İnitializers
            ArrayList arrayList = new ArrayList()
            {
                "Ahmet",
                22,
                "Wtf"
            };
            #endregion
        }

        void Başlıksızlar()
        {
            var a = ";";
            int @int;//@operatörü ile verilen isimlemeler sayesinde anlamlı keywordları kullanabiliyoruz
            dynamic x;//Bu şekilde tanımlama ile runtime a kadar x değişkeninin türü bilinmez. Program çalışınca türünü belirler. Var gibi ama vardan bir aşama sonra türü belirleniyor
                      //dynamic ile kararlı bir türe sahip değil.Değişkene önce string sonra int türü verebiliriz.
            a.GetType();// ile Türünü öğreniyoruz
        }

        void DateTimeStruct()
        {
            #region Now
            DateTime dateTime = DateTime.Now;//Yıldan başlayıp saniyeye kadar o anın tarihini verir
            #endregion
            #region Today
            dateTime = DateTime.Today;//GünAyYıl bilgisi döndürür
            #endregion
            #region Compare
            DateTime tarih1 = new DateTime(2021, 01, 01);
            DateTime tarih2 = new DateTime(2022, 01, 01);
            int result = DateTime.Compare(tarih1, tarih2);//result=-1 tarih1<tarih2
                                                          //result =0 ise eşitler result=1 ise tarih1>tarih2
            #endregion
            #region AddDays,AddHours,AddMonths,AddYears,AddMiliseconds
            DateTime.Now.AddYears(1453);
            #endregion
            #region TimeSpan
            TimeSpan span = tarih2 - tarih1;
            var a = span.Days;//İki zaman arasındaki farkı farklı çeşitlerde öğrenmemize yarar
            #endregion
        }

        void ForYöntemleri()
        {
            #region ikli for döngüsü
            for (int i = 0, i2 = 0; i < 10 && i2 < 5; i2++, i++)
            { }
            #endregion

        }

        void ForEachİterasyonuYöntemleri()
        {
            //Foreach döngü değil iterasyondur. Foreach içinde collectiona etki edicek kodlar çalıştırılamaz.              
        }

        void Methodlar()
        {
            #region Non-Trailing Named Arguments Sırasız değişken girme
            //Function(c: "asd", a: 12, d: "123", b: 21);
            #endregion
            #region In Parameters Parametreyi readonly yapma
            static void X(in int a)//in ile tanımlama yapınca  daha sonra değerde değişiklik yapamıyoruz
            {
                a = 123;
            }
            #endregion
            #region Static method
            //Local functionlar normalde üst methoddaki değişkenlere erişebiliyor. 
            //Local functionu static yaparak bu erişimden kurtarabiliriz.
            #endregion
            #region Overload Method
            //void Y(int a)
            //{ };
            //void Y(int a,int b)
            //{ };
            //Parametre isimleri veya türlerini farklı yaparak overload yapabiliriz
            //Geri dönüşüm değeri değiştirilemez
            #endregion
        }

        void OutKeywordü()
        {
            int X(out int k, int l, out string m)//out ile kullanılan parametreye değer verilemez.Değişken olmalı
            {//out ile dışarı parametre değeri gönderilebiliyor
                k = 0;
                m = "0";
                return 0;
            }
            int _k = 1;
            string _m = "asd";
            int n = X(out _k, 22,out _m);

            #region TryParse
            string a = "123";
            int.Parse(a);//Normalde bunu kullanır insanlar, ancak değiştirilemez bir a değeri
            //girdiğimizde kodumuz patlar. Bu yüzden TryPArse methodunu aşşağıdaki gibi kullanırız
            //Try parse methodu boolean bir sonuç dönderir. O yüzden ifle kullandık.
            if (int.TryParse(a, out int r))//Dönüşmek istediğimiz değer,Dönüştürülmüş değer
            {//char.TryParse, bool.TryParse gibi türleri var
                Console.WriteLine("Dönüşüm gerçekleştirildi.");
            }
            else
            {
                Console.WriteLine("Dönüşüm gerçekleştirilemedi.");
            }
            #endregion
        }

        void PatternYöntemleri()
        {
            object x = "Kaan";
            #region is pattern
            if (x is string a)//a="Kaan" stringi oldu. Objedeki nesnenin cinsi string ise onu stringe çevirip a ya atadık.
            {
                var y = a;//a sadece ifin içinde kullanmalıyız.iften çıkınca kullanınca hata gösterir.
            }
            #endregion
            #region constant pattern//object dışında işlem de yapabilir
            object b = 5;
            if (b is 5)//(b==5) gibi çalışır
                b = 3;
            #endregion
            #region var pattern
            if (x is var c)//c="Kaan" oldu. Objedeki nesnenin cinsi ne ise onu var olarak ona çevirip a ya atadık.
                c = 5;
            #endregion
            #region  not patern
            if (x is not "Kaaan")//değilse gibi
                x = "Kaaan";
            #endregion

        }    

        void RandomSınıfı()
        {
            Random random = new Random();
            #region Next Fonksiyonu
            random.Next();//0-sonsuz
            random.Next(100);//100 e kadar.!00 dahil değil
            random.Next(50,100);//50 dahil 100 e kadar.100 dahil değel
            #endregion
            #region NextDouble Fonksiyonu
            random.NextDouble();//0 ile 1 arasında
            #endregion
        }

        void RefKeywordü()
        {
            //Deep copy : Normalde assignment yaptığımızda int b=a dediğimizde
            //b için anın değerinde yeni bir kayıt açılır.Bellekte yer kaplar.
            //Shallow copy ise değer aynı kalırken onu refere eden değişken sayısını 
            //arttırır.
            #region Ref Keywordu
            int a = 5;//Değer türlü değişkenlerde shallowcopy etmemize olanak sağlar
            ref int b = ref a;
            /******/
            int y = 10;
            X(ref y);
            void X(ref int c)
            {
                c = 11;
            }
            #endregion
            #region Ref Returns

            #endregion
        }

        void RegularExpressions()
        {
            #region ^Operatörü
            //Satır başının istenen ifade ile başlamasını sağlar
            string text = "999989554";
            Regex regex = new Regex("^9");
            Regex regex1 = new Regex("^99");
            Match match = regex.Match(text);
            var booleanaa = match.Success;
            #endregion
            #region \Operatörü
            //\D: Metinsel değerin ilgili yerinde rakam olmayan tek bir karakterin olması gerektiği belirtilir.
            //\d: Metinsel değerin ilgili yerinde rakam olan tek bir karakterin olması gerektiği belirtilir.
            // Alfanümerik karakterler: a-z A-Z 0-9
            //\W: Metinsel değerin ilgili yerinde alfanümerik olmayan karakterin olması gerektiği belirtilir.
            //\w: Metinsel değerin ilgili yerinde alfanümerik olan karakterin olması gerektiği belirtilir.
            //\S: Metinsel değerin ilgili yerinde boşluk karakterleri dışında herhangi bir karakterin olamayacağını belirtilir.
            //\s: Metinsel değerin ilgili yerinde boşluk karakterlerinin olacağı belirtilir.

            //9ile başlayan, ikinci karakteri herhangi bir sayı olan ve 3. karakteri boşluk olmayan bir düzenli ifade
            Regex regex2 = new Regex(@"^9\d\S");//İndexe göre ilerliyor
            match = regex.Match(text);
            #endregion
            #region +Operatörü
            //9ile başlayan, arada herhangi bir sayısal değeri olan ve son karakteri boşluk olmayan bir düzenli ifade
            Regex regex3 = new Regex(@"^9\d+\S");//İkinci ve fazlası sayısal değer oldu
            #endregion
            #region |Operatörü
            Regex regex4 = new Regex(@"a|b|c");//a yada b yada c ile olan
            #endregion
            #region {n}Operatörü
            //507-6111600
            Regex regex5 = new Regex(@"\d{3} -\d{7}");
            #endregion
            #region ?Operatörü
            //Sağına geldiği ifadenin en fazla 1 tane olabileceğini gösterir
            Regex regex6 = new Regex(@"\d{3}B?A");
            //3 tane rakam En fazla bir B en son da A
            #endregion
            #region .Operatörü
            // \n karakteri dışında herhangi bir karakter bulunabilir
            Regex regex7 = new Regex(@"\d{3}.A");
            #endregion
            #region \b \B Operatörü
            //\B: Bu ifade ile kelimenin başında yada sonunda olmaması gereken karakterler belirtilir.
            //\b: Bu ifade ile kelimenin belirtilen karakter ile sonlanmasını sağlar
            Regex regex8 = new Regex(@"\d{3}dır\B");
            #endregion
            #region [n]Operatörü
            //Metinsel ifadede karakter aralığını belirler. Ayrıca özelkarakterlerin yerinde yazılmasını da ifade eder.
            Regex regex9 = new Regex(@"\d{3}[A-E]");//123C true, 251F false
            Regex regex10 = new Regex(@"[(]\d{3}[)]\s\d{3}\s\d{2}\s\d{2}"); //(507) 611 16 00 çıktısını doğrular
            #endregion
            #region MatchSınıfı Özellikleri
            Match match1 = regex10.Match(text);
            //match1.Success => True False
            //match1.Value => text i dönderir
            //match1.Index => Kaçıncı indexten doğrılamaya başladık
            //match1.Length => Kaç eleman doğruladık


            #endregion

        }

        void SpanVeMemoryTürleri()
        {
            //Bellek üzerinde belirli bir alanı temsil ederek işlemler gerçekleştirmemizi sağlayan bir struct'tır
            //Span: Heap'ta tahsis edilememe, object, dynamic yahut interface türleri aracılığıyla referans edilememe
            //yahut bir class içerisinde  field veya property olarak tanımlanamama gibi kısıtlamaları vardır.
            //Memory türü bu kısıtlamalardan etkilenmeyen bir span gibi düşünebiliriz
            int[] sayilar2 = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
            string text2 = "Bye Bye Happiness";
            Span<int> span = new Span<int>(sayilar2);
            Span<int> span1 = new Span<int>(sayilar2, 3,5);//3.indexten başlayıp 5 karakter alır
            Span<int> span2 = sayilar2.AsSpan(3, 5);
            ReadOnlySpan<char> span3 = text2.AsSpan(3,5);//stringde çalışırken ReadOnlySpan kullanmak zorundayız

        }

        void StringTürü()
        {
            var metin = "Dolu Kadehi Ters Tut";
            //Stringin değişken adı stackte, Değeri Heapte tutulur nesne türü olduğu için.
            //String referans türü bir değişkendir ve özünde char dizisidir. Yani nesnedir.
            #region @ Verbatim operatörü
            string ani = @"Hava çok ""güzel""";// Başına @ koyarak " gibi özel operatörleri çiftleyip özelliklerinden kurtarıp metinleştiriyoruz
            // Hava çok "güzel"çıktısını verir
            ani = @"Selam
                   Bebek";//Normalde alt alta string giremeyiz. Ama @ sayesinde yapabiliyoruz.Enterı uygular.
            string kele = "Kelebek";//İnterpolution ile bir kullanırken önce @ sonra $ yazılmalı
            ani = @$"Ben
                {kele}";//Böyle kullanımda \n gibi ifadeleri metin olarak algılar ayrıca yazarken tab kullandığımız için onuda
                        //ve enter ı da uygular
            #endregion
            #region Compare
            int sonnuc = string.Compare(metin, "a");// eğer ikisi birbirine eşitse 0
            //metin soldaki sağdakinden alfabetik olarak büyükse 1
            //alfabetik olarak küçükse -1 döner. Karakter sayısı değil fihristik şekilde.
            #endregion
            #region CompareTo
            sonnuc = metin.CompareTo("asdasd");//Compare'in aynısı sadece kullanılışı farklı.
            #endregion
            #region Contains
            bool sonuc = metin.Contains("Ters");
            #endregion
            #region EndsWith
            sonuc = metin.EndsWith("Tut");
            #endregion
            #region Equals
            sonuc = metin.Equals("Dolu Kadehi Ters Tut");
            #endregion
            #region Escape Kaçış Karakterleri
            // \ karakteri sonraki ifadenin özel karkter olmasını engeller. " falan içine yazdırabilmek için
            // \o Dosya yada veri kanalının bitişini belitrmek için kullanılır
            // \a Bip sesini çıkaran karakterdir
            // \b Backspace-Geri-Önceki karakteri silme
            // \t tab
            // \r Satırbaşı
            // \n Bir alt satıra iner
            // \v Dikey tab
            // \f Sayfa ilerleme
            // \' Tek tırnak
            // \" Çift tırnak

            #endregion
            #region IndexOf
            sonnuc = metin.IndexOf("Kadehi");//5 döner. İlk eşleşen değerin indexini döndürür
            #endregion
            #region Insert
            metin = metin.Insert(2,"oo");//Dooolu Kadehi Ters Tut çıktısı verir
            #endregion
            #region IsNullOrEmpty
            var ai = "ai";
            string.IsNullOrEmpty(ai);
            #endregion
            #region IsNullOrWhiteSpace
            string.IsNullOrWhiteSpace(ai);
            #endregion
            #region Null-Empty
            ai = string.Empty;
            //Eğer ki string null ise bu heapte herhangi bir alan kullanmıyor demektir
            //Empty de değeri yok ama alanı kullanıyor
            //Default değerlerin olduğu durumlar empty olarak geçer.
            //Null olan değer ile işlem yapmaya çalışınca rt hata alırken empty iken olmaz
            #endregion
            #region Remove
            metin = metin.Remove(4);//Kadehi Ters Tut çıktısı verir
            metin = metin.Remove(4, 6);//4.indexten başla 6 karakter sil
            #endregion
            #region Replace
            metin = metin.Replace("K", "k").Replace("T","t");//Dolu kadehi ters tut çıktısı verir
            #endregion
            #region Split
            var zzz = metin.Split(" ");//Boşluklardan stringi diziye parçalar
            zzz = metin.Split(' ', 'o');//Boşluk vr o lardan ayırır.
            #endregion
            #region StartsWith
            sonuc = metin.StartsWith("Dolu");
            #endregion
            #region Substring
            metin = metin.Substring(5);//5.indexten sonuna kadar charların oluşturduğu stringi verir
            metin = metin.Substring(5, 5);//5. indexten başlayıp 5 karakteri alıp dönüş yapar
            #endregion
            #region String Formantlandırma

            #region string.Format
            string.Format("{0}a{2}e{1}", "k", "m", "l"); //kalem  çıktısı verir
            #endregion
            #region $string Interpolation yöntemi en yeni ve iyisi
            var kstring = "k";
            var lstring = "l";
            var mstring="m";
            var oss = $"{kstring}a{lstring}e{mstring}";
            //string interpolution kullanırken {} kullanmak için {{}} yapmamız lazım
            #endregion

            #endregion
            #region ToLower
            metin = metin.ToLower();
            #endregion
            #region ToUpper
            metin = metin.ToUpper();
            #endregion
            #region Trim
            metin = metin.Trim();//Başında ve sonunda boşluk varsa siliyor
            #endregion
            #region TrimEnd
            metin = metin.TrimEnd();//sonundakini trimler
            #endregion
            #region TrimStart
            metin = metin.TrimStart();//başındakini
            #endregion
        }

        void SwitchYöntemleri()
        {
            var a = 1;
            var x = 2;
            var y = 3;
            #region when kullanımı
            switch (a)
            {
                case 100 when (x == y)://case'in 100 olduğu durumda x ve y eşitlik şartı aranır.
                    break;
            }
            #endregion
            #region goto kullanımı
            switch (a)
            {
                case 'a':
                    //bi sürü algoritma
                    break;
                case 'b':
                    goto case 'a';//break yok.Koddan kar etmek için kullanılır
            }

            #endregion
            #region expression//kısa kullanım taktiği
            string mesaj = DateTime.Now.DayOfWeek switch
            {
                DayOfWeek.Monday => "Bu gün Pazartesi",
                DayOfWeek.Tuesday => "Bu gün Salı",
                DayOfWeek.Wednesday => "Bu gün çARŞAMBA",
                DayOfWeek.Thursday => "Bu gün Perşembe",
                DayOfWeek.Friday => "Bu gün Cuma",
                DayOfWeek.Saturday => "Bu gün Cumartesi",
                DayOfWeek.Sunday => "Bu gün Pazar",
            };
            #endregion
            #region expression + when
            var i = 5;
            string isim = i switch
            {
                5 when (x == 7) && (x % 2 != 0) => "Rıfkı",
                5 when 3 == 3 => "Hilmi",
                10 => "Gençay",
                _ => "SAD"//HİÇBİRİ DURUMU 
            };
            #endregion
            #region tuple kullanımı
            var adi = "";
            var yasi = 0;

            mesaj = (adi, yasi) switch//when kullanabiliyoruz...
            {
                ("Hüseyin", 20) => mesaj = "Hoşgeldin Hüse",
                ("Casnu", 25) => mesaj = "Hoşgeldin Casnu"
            };
            //or
            switch (adi, yasi)
            {
                case ("Hüseyin", 20):
                    mesaj = "Hoşgeldin Hüse";
                    break;
                case ("Casnu", 25):
                    mesaj = "Hoşgeldin Casnu";
                    break;
            }

            #endregion
            #region model ile kullanımı

            var ogrenci1 = new ogrenci
            {
                Adi = x,
                Soyadı = y,
                Meslek = "Yazılımcı"
            };
            double maas = ogrenci1 switch
            {
                { Meslek: "Kasap" } => 50,
                { Meslek: "Tesisat Şöförü" } => 45,
                { Meslek: "Yazılımcı" } => 53
            };
            #endregion
            #region relational pattern
            int number = 1;
            string result = number switch
            {
                < 50 => "50'den küçük",
                > 50 => "50'den büyük",
                _ => "Hiçbiri"
            };

            #endregion
            #region logical Pattern
            result = number switch
            {
                > 10 and < 50 => "10 ile 50 arasında",
                > 50 or < 100 and 60 => "50 ile 100 arasında ve 60 a eşit",
            };
            #endregion
            #region Not operator
            string GetProduct(IProduct p) => p switch
            {
                Technologic => "a",
                Computer => "b",
                not Googles => "c"
            };
            #endregion


            #region Clear Metodu

            #endregion
        }

        void TryCatchYöntemleri()
        {
            var x = "";
            #region When kullanımı
            try
            { }
            catch (Exception ex) when (x == "a")//Catch sadece x a ya eşit olunca düşer
            { }
            #endregion
        }

        void TürDönüşümü()
        {
            var i = 5;
            var x = "";
            #region Type.Parse(x)
            int.Parse(x);//x Stringini type türüne değiştirir.
            #endregion
            #region Convert.ToType(x)
            Convert.ToInt32(x);//Verilen x'i belirtilen türe dönüştürür
            Convert.ToBoolean(i); //i = 0ise false diğer sayılarda true
            #endregion
            #region ToString()
            x.ToString();//x'i String türüne dönüştürür
            #endregion
            #region Excplit Bilinçli dönüşüm
            var z = (float)i;//(type)i;//x'i type türüne dönüştürür//Bilinçli (excplit) tür dönüşümü 
            //Excplit tür dönüşümünde veri kaybı olması durumunda runtime içerisinde uyarı fırlatması için
            checked
            {
                var q = (float)i;
            }//içine yazılır.
             //Bilinçli tür dönüşümünde char karakteri int e çevirirsek asci kodları gelir.
            #endregion
        }
    }
}
