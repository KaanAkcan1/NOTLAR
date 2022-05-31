namespace CSharpNotları
{
    public class DesignTurkey
    {
        #region Ana Notlar
        /*
        designturkey remote bilgileri
        217.195.206.27:9816
        administrator
        şifre:T1mB5c48
        
        
        !!Designer.index.cshtml viewinde applicationtype üzerinden kavramsal tasarımı kaldırdık.
        
        
        Remote Dekstop üzerinden giriş yapınca AnaKlasör=Bilgisayar/D/Webroot/designturkey.org.tr/Modules/turklinedesign_turkey içine geliyoruz.
        Viewsler içinden değişikliklerimizi yapabiliriz.
        
        T içerisindeki değerler veya tanımlı şeyleri değiştirirken
        Her değişiklikte AnaKlasör/AppData/Localization/tr-TR içindeki dosyayı açıp yapacağımız değişikliği eklememiz gerekebilir.
        
        
        D:\Webroot\designturkey.org.tr\Media\Default\pdf  pdf eklemek için
        Pdf ekledikten sonra sayfayı adminden açıp. Html görünümünü açıp oradan taglerin içindeki yeni yolları verebiliyoruz
         
         */
        #endregion


        #region Bak alma
        /*
        MSsql de 
        dbDesignTurkey//sağ tık
        tasks//
        backup//
        Add
        Yolu seç    C:\Program Files\Microsoft SQL Server\MSSQL12.TIMVM22014\MSSQL\Backup
        İsimlendirme yap .bak yaz
        
        ok
        
        C:\Program Files\Microsoft SQL Server\MSSQL12.TIMVM22014\MSSQL\Backup  
        */
        #endregion


        #region designGallery
        /*Öncelikle database açıp
        backup olan table ın üzerine gelip; script table as->create to->new query editor window seçeneklerini seçiyoruz
        DAha sonra Programmability->Stored Procedures->CreateDesignGalleryForProducts a sağ tıklayıp Modify diyoruz
        Orada backup tableımızın ismini düzeltiyoruz.
        Daha sonraCreateDesignGalleryForProducts a tekrar sağ tıklayıp Execute Store Procedure saçiyoruz.ORadan value ye yılo 2021 ise 21 yazıyoruz
        Çalıştırıyoruz. Tata oldu da bitti
        
        Daha sonra localimizdeki AdminController a DesignGallery21 ekledik.
        Oradaki örnektekini kopyalayıp yeni açtığımız backup table ismini yazarak.
        Başına[HttpGet] ekleyip return View kısmını değiştirdik.
        Sonra Rebuild yapıyoruz o modülü.Dosyalarımız içinden Modules-Turkline.DesignTurkey-bin-TurklineDesignTurkey.dll
        dosyasını kopyalayıp remotadaki dosyayı bakladıktan sonra remote a atıyoruz
        Contollerımızı da aynı şekilde alıp remote a atıyoruz.
        Remota da webroot-designturkey.org.tr de webconfig i açıp bir yere boşluk bırakıp geri silip saveliyoruz.
        Admin/DesignTurkey/DesignGallery21 linkine gidiyoruz
        OldPArticipantRecordda yeni bilgiler geldiyse tamamdır.
        
        UploadedProductİmages Klasöründeki o yıla ait resimlerin hepsini kopyalayıp OldParticipints a yapıştırdık
        SubDesc i aratıp Themes->DesignTurkeyTheme-> Views içindeki Slider cs.html içerisindeki design-gallery? Year = 2019 u düzelttik.
        Application.OldParticipant.cshtml e <li> a 2021</li> ekledik
        Adminpanelden navigasyonda TasarımGalerisi linkini güncelledik
        Eğerki filtreleme çalışmıyorsa database de OldParticipantRecords tableında*/
        #endregion


        #region Puan değiştirme işlemleri
        /*
         JuryPointPartRecor da verilen oylar var. Oylama silineceği zaman oradan all kayıtları siliyoruz
         UserPartRecord üzerinden bilgilere ulaşabiliriz.
         ApplicationPartRecord ile Application durumunu değiştirebiliyoruz
         
          where Email like 'juryuserd%'
        */
        #endregion
    }
}
