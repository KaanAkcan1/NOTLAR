namespace CSharpNotları
{
    public class JquerryNotları
    {
        void Deneme()
        {

        }


        void ElementSeçiciler()
        {
            #region DocumentReady
            //$(document).ready(function(){
            //    JQuerry Codes.
            //});
            // döküman yüklenmeden kodlrın çalışmaması için kullanılır. 
            #endregion
            #region Seçiciler
            //$(this)                   => Geçerli elemanı seçer
            //$("p")                    => Tüm <p> etiketlerini seçer
            //$(".a")                   => Tüm a classına sahip elementleri seçer
            //$("#a")                   => Tüm a id'sine sahip elementleri seçer
            //$("A B")                  => A nesnesi içinde olan B çocuk ve torun nesnelerini seçer.
            //$("A>B")                  => A nesnesi içinde olan B çocuk nesnelerini seçer.
            //$("A+B")                  => A nesnesinden hemen sonra gelen ve aynı seviyede olan B nesnesini seçer
            //$("A~B")                  => A nesnesinden sonra gelen ve aynı seviyede olan bütün B nesnelerini seçer.
            //$("p:first")              => İlk <p> etiketine sahip elemanı seçer//pseudocode diye araştır 
            //$("ul li:first-child")    => Ne kadar ul li varsa hepsinin ilk elemanını seçer
            //$("p .a")                  => <p> etiketi içindeki a clasına sahipleri seçer
            //$("[href]")               => tüm href attribütlerini seçer
            //$("a[target='_blank']")   => taget attrsi _blank olan elemanları seçer
            //$("a[target!='_blank']")  => taget attrsi _blank olmayan elemanları seçer
            //$("tr:even")              => trlerden çift sayılı indexi olanları seçer
            //$('[src]')                => src özniteliğine sahip bütün nesneleri seçer.
            //$('img[alt="resim1"]')    => alt özniteliği "resim1" e eşit olan img etiketlerini seçer.
            //$('img[alt!="resim1"]')   => alt özniteliği "resim1" e eşit olmayan img etiketlerini seçer.
            //$('img[src^="images/"]')  => src özniteliği "images/" değeriyle başlayan img etiketlerini seçer.
            //$('img[src$=".jpg"]')     => src özniteliği ".jpg" değeriyle biten img etiketlerini seçer.
            //$('img[id*="img"]')       => id özniteliği içerisinde "img" değeri geçen img etiketlerini seçer.
            //$(':input')               => Bütün input elemanlarını seçer.
            //$(':text')                => text tipindeki bütün input elemanlarını seçer.
            //$(':password')            => password tipindeki bütün input elemanlarını seçer.
            //$(':radio')               => radio tipindeki bütün input elemanlarını seçer.
            //$(':checkbox')            => checkbox tipindeki bütün input elemanlarını seçer.
            //$(':submit')              => submit tipindeki bütün input elemanlarını seçer.
            //$(':reset')               => reset tipindeki bütün input elemanlarını seçer.
            //$(':button')              => button tipindeki bütün input elemanlarını seçer.
            //$(':image')               => image tipindeki bütün input elemanlarını seçer.
            //$(':file')                => file tipindeki bütün input elemanlarını seçer.
            //$(':enabled')             => enabled özelliği olan bütün input elemanlarını seçer.
            //$(':disabled')            => disabled özelliği olan bütün input elemanlarını seçer.
            //$(':selected')            => selected özelliği olan bütün input elemanlarını seçer.
            //$(':checked')             => checked özelliği olan bütün input elemanlarını seçer.
            //$(":contains()")          => Parametredeki metni içeren elemementi seçer
            //$(":has()")               => Parametreolarak gönderilen element çocukları arasında bulunan elemementleri seçer
            //$(":header")              => h1,h2,h3 gibi başlık elemanlarını seçer
            //$(":empty")               => Metinler dahil hiçbir alt elementi olmayan elementleri seçer
            //$(":not()")               => Parametre olarak gönderdiğimiz kritere uymayanları seçer
            //$(":odd")                 => Tek numaral sıradaki elemanı seçer
            //$(":visible")             => Görünür durumdaki elementleri seçer
            //$(":last")                => Kriterlere uyan son elementi seçer
            //$("A, B, C")              => Birden fazla seçim yapmak için kullanılır. OR gibi düşünebiliriz.

            #endregion
        }


        void EventMetodlar()
        {
            #region MouseEvents
            #region click    =>Tıklama da kullanılıyor

            #endregion
            #region dblclick => çift tıklama yapıldığında

            #endregion
            #region mouseenter => fare üzerine geldiğinde

            #endregion
            #region mouseleave => fare üstünden ayrıldığında

            #endregion
            #region mousedown => farenin tıklamasına bastığında

            #endregion
            #region mouseup => farenin tıklamasından kaldırdığında

            #endregion
            #region mousemove => fare hareket ettikçe
            //$("p").mousemove(function(){
            //  $("#result").text(x+=1);
            //});
            #endregion
            #region mouseover => fare o alana girince
            //$("p").mouseover(function(){
            //  $("p").css("background-color", "red");
            //});
            #endregion
            #region mouseout => mause o nesnenin dışına çıktığı anda
            //$("p").mouseout(function(){
            //  $("p").css("backgroun-color", "yellow");
            //});
            #endregion
            #region hover   => bildiğimiz hover işte
            //$("p").hover(function(){
            //    alert("Paragrafa girdin");
            //},function(){
            //    alert("Paragraftan çıktın");
            //});
            #endregion

            #endregion

            #region KeyboardEvents
            #region keypress => keyup+keydown birlikte olduğunda

            #endregion
            #region keydown  => klavyede tuşa bastığın anda

            #endregion
            #region keyup   => klavyedeki tuştan parmağını çektiğinde

            #endregion

            #endregion

            #region FormEvents
            #region submit

            #endregion
            #region change

            #endregion
            #region focus  => inputa odaklandığında, tıkladığında

            #endregion
            #region focusin => Bir elemente yada altındaki herhangi bir ögeye odaklanıldığında tetiklenir
            //$("div").focusin(function(){
            //  $(this).css.("background-color","darkred");
            //});
            #endregion
            #region focusout => Bir elementten yada altındaki herhangi bir ögeden odağı kaybettiğimizde tetiklenir
            //$("div").focusout(function(){
            //  $(this).css.("background-color","darkgoldenrod");
            //});
            #endregion
            #region blur  => inputtakifocus sona erdiği anda

            #endregion

            #endregion

            #region Document/Window Events
            #region load (3.0 da kaldırıldı)

            #endregion
            #region resize => Ekran boyutu değiştirince tetikleniyor
            //var w,h;
            //w = $(window).width();
            //h = $(window).heigth();
            //$("#width").text(w);
            //$("#height").text(h);
            //$(window).resize(function(){
            //  w = $(window).width();
            //  h = $(window).heigth();
            //  $("#width").text(w);
            //  $("#height").text(h);
            //});
            #endregion
            #region scroll
            //$("div").scroll(function(){
            //    $("span").text(x+=1);
            //});
            #endregion
            #region unload

            #endregion

            #endregion

            #region on  => Birden fazla event kullanmak için kullanımı
            //$("p").on("click mouseleave", function(){ //or gibi çalışır
            //    codes
            //});

            /*$("p").on({
             *  mouseenter:function(){
             *      Codes....
             *  },
             *  mouseleave:function(){
             *      Codes....
             *  }    
             * });
             * 
             */

            #endregion

            #region on-off kullanımı (sürüm 3.0 dan önce bind unbind bu işlemi gerçekleştiriyordu)
            //On ile tetiklenen eventi kapatmak için kullanılır
            //$("p").on("click", function(){
            //    $(this).css("color", "red");
            //});
            //$("#btn").click(function(){
            //    $("p").off("click");
            //});
            #endregion

            #region Change-Select
            //On ile tetiklenen eventi kapatmak için kullanılır
            //$("#username").change(function(){
            //    alert("Kutuda değişiklik yapınca değişir");
            //});
            //$("#seçici").select(function(){
            //    $("#result").text("Seçim sağlanınca tetiklendi");
            //});
            #endregion

            #region One
            //Bir fonksiyonu sadece ilk tetiklendiğinde çalıştırır
            //$("p").one("click", function(){
            //    $(this).css("color", "red");
            //});

            #endregion

            #region Proxy
            //Proxy ile mevcut fonksiyonu alıp belirlibir bağlamda yenisini durdurabiliriz
            //$(function(){
            //  var objPerson={
            //      name:"Ayfer UYAR",
            //      age:30,
            //      test:function(){
            //          $("p").text("İsim: "+this.name+" Yaş: "this.age);
            //      }
            //  };
            //  $("#btn").click($.proxy(objPerson, "test"));
            //});
            #endregion

            #region ready => Hazır olduğunda tetiklenir

            #endregion

            #region trigger => bir eventi tetikler
            //$("input").select(function(){
            //  $("#result").text("Metni seçtin");
            //});
            //$("#btn").click(function(){
            //  $("input").trigger("select");
            //});
            #endregion
        }


        void EventProperty()
        {
            #region event.currentTarget
            //Etkinlik köpürme aşamasındaki geçerli dom ögesi
            #endregion

            #region event.data
            //Geçerli yürütme işleyicisi bağlı olduğunda bir olay 
            //yönetimine iletilen isteğe bağlı veriler
            #endregion

            #region event.deleteTarget
            //Şu anki jquerry olay işleyicisinin etkilendiği ögeyi döndürür
            #endregion

            #region event.preventDefault
            //Eventin varsayılan eylemini engeller
            #endregion

            #region event.isDefaultPrevented
            //event nesnesi için prevenddefault metodunun çağrılıp çağrılmadığını döndürür
            #endregion

            #region event.namespace
            //Etkinlik tetiklendiğinde belirtilen ad alanını döndürür
            #endregion

            #region event.pageX
            //Belgenin sol kenarına göre x düzleminde konumunu döndürür
            #endregion

            #region event.pageY
            //Belgenin üst kenarına göre y düzleminde konumnunu döndürür
            #endregion

            #region event.relatedTarget
            //Fare hareketi sırasında hangi ögenin girildiğini veya çıkıldığını döndürür
            #endregion

            #region event.isİmmediatePropagation
            //event nesnesi için stopİmmediatePropagation methodu çağrılıp çağrılmadığını döndürür
            #endregion

            #region event.isPropagationStopped
            //event nesnesi için stopPropagation metodu çağrılıp çağrılmadığını dönder
            #endregion

            #region event.result
            //Belirtilen olay tarafından tetiklenen bir olay işleyicisinin döndürdüğü
            //son/önceki değeri içerir
            #endregion

            #region event.stopImmediatePropagation
            //Diğer olay işleyicilerinin çağrılmasını engeller
            #endregion

            #region event.stopPropagation
            //Etkinliğin Dom ağacını köpürtmesini ve ana işleyicilerin etkinlikten
            //haberdar olmasını engeller
            //div içine p içine span olduğunu varsayalım. Spana tıkladığımızda sadece ona tıklanmış gibi
            //gösterir. Aile nodalarda uygulama göstermez
            #endregion

            #region event.target
            //Hangi dom ögesinin olayı tetiklediğini döndürür
            #endregion

            #region event.timeStamp
            //1 ocak 1970'ten bu yana geçen milisaniye değerini dönderir
            #endregion

            #region event.which
            //Etkinlik için hangi klavye tuşuna veya fare düğmesine basıldığını dönderir
            #endregion
        }
    }
}
