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

        void Başlıksızlar()
        {
            var a = ";";
            int @int;//@operatörü ile verilen isimlemeler sayesinde anlamlı keywordları kullanabiliyoruz
            dynamic x;//Bu şekilde tanımlama ile runtime a kadar x değişkeninin türü bilinmez. Program çalışınca türünü belirler. Var gibi ama vardan bir aşama sonra türü belirleniyor
                      //dynamic ile kararlı bir türe sahip değil.Değişkene önce string sonra int türü verebiliriz.
            a.GetType();// ile Türünü öğreniyoruz
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

        void ForYöntemleri()
        {
            #region ikli for döngüsü
            for (int i = 0, i2 = 0; i < 10 && i2 < 5; i2++, i++)
            { }
            #endregion

        }

        void StringTürü()
        {
            //Stringin değişken adı stackte, Değeri Heapte tutulur
            //String referans türü bir değişkendir ve özünde char dizisidir.

            #region Null-Empty
            string ai= string.Empty;
            //Eğer ki string null ise bu heapte herhangi bir alan kullanmıyor demektir
            //Empty de değeri yok ama alanı kullanıyor
            //Default değerlerin olduğu durumlar empty olarak geçer.
            //Null olan değer ile işlem yapmaya çalışınca rt hata alırken empty iken olmaz
            #endregion
            #region IsNullOrEmpty
            string.IsNullOrEmpty(ai);
            #endregion
            #region IsNullOrWhiteSpace
            string.IsNullOrWhiteSpace(ai);
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
