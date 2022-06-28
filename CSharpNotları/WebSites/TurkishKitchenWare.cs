namespace CSharpNotları
{
    public class TurkishKitchenWare
    {
        //Kullanıcı adı : admin
        //Şifre : Cruy7$GMkT4

        #region HataÇözümü1
        /* Vergi numarası ile admin sayfasında arama yapıyoruz
         * User açılıp açılmadığına bakkıyoruz
         * Açılmadıysa mongodb'den immib-b2b.companies database açıyoruz
         * Oradaki bilgileri güncelliyoruz.Notlar kısmında ss var
         * Şirketi admin olarak giriş yaptığımız sitelerden bakarak user gelmiş olduğunu kontrol ediyoruz
         * Düzenle diyip aktivasyon maili gönderiyoruz
         */

        #endregion

        #region Bazı bilgiler
        /*Commerce Service mongo kullanılan yer
         * AddVisit giriş sayfası için database e kayıt ekliyor
         */
        #endregion


        #region Debug etme
        /*Chromeda açılmıyor
         * IIS te add binding diyip  http ve https olarak turkishhardware365.com ve local.turkishhardware.com eklemeliyiz. Htpps de sol altta IIs seçiceksin
         * Proje çalışırken debug yapar
         * Host dosyasını açmak için=>C:/Windows/System32/drivers/etc deki host dosyasını açman lazım. Bunun için önce notepad admin olarak aç oradan aç de yolu seç.
         * Hostu seçmen lazım ve orada tüm uzantıları görebilmen şart
         * Host içeriği alt regionda yazıyor.
         * Üstteki üst aşama yapılı ama yinede kontrol et         
         * Ssl yok deyince devam et de
         * Local IIs te çalışıcak kod
         * Virtual eklemiceksin
         * Link https://local.turkishhardware365.com
        */
        #region Host içeriği
//# Copyright (c) 1993-2009 Microsoft Corp.
//#
//# This is a sample HOSTS file used by Microsoft TCP/IP for Windows.
//#
//# This file contains the mappings of IP addresses to host names. Each
//# entry should be kept on an individual line. The IP address should
//# be placed in the first column followed by the corresponding host name.
//# The IP address and the host name should be separated by at least one
//# space.
//#
//# Additionally, comments (such as these) may be inserted on individual
//# lines or following the machine name denoted by a '#' symbol.
//#
//# For example:
//#
//#      102.54.94.97     rhino.acme.com          # source server
//#       38.25.63.10     x.acme.com              # x client host

//# localhost name resolution is handled within DNS itself.
//#	127.0.0.1       localhost
//#	::1             localhost

//127.0.0.1	local.turkishkitchenware365.com
//127.0.0.1	local.turkishcopper365.com
//127.0.0.1	local.turkishhardware365.com
//127.0.0.1	local.turkishhorecaequipment365.com
//127.0.0.1	local.turkishcasting365.com
//# Added by Docker Desktop
//192.168.0.40 host.docker.internal
//192.168.0.40 gateway.docker.internal
//# To allow the same kube context to work on the host and the container:
//127.0.0.1 kubernetes.docker.internal
//# End of section

        #endregion
        #endregion
    }
}
