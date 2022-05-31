namespace CSharpNotları.Docker
{
    public class DockerNotlar
    {
        #region İmage indirme yükleme Çalıştırma
        //docker pull mongo
        //=> mongo image indirir

        //docker run mongo
        //=> mongo image çalıştırır yoksa indirir

        //docker run it --name bash_ubuntu ubuntu
        //=> ubuntu image'i bash_ubuntu ismiyle çalıştırır

        //docker run it ubuntu
        //=>ubuntuyu çalıştırır ve kapanmasını engeller. Normalde çalışır vaziyette kalmaz.

        //docker run ubuntu sleep 3
        //=> 3 saniyelik çalışır vaziyette kalır

        //docker run -d ubuntu
        //=>detach modda çalışır. yani arkaplanda çalışır

        //docker run -it ubuntu
        //=> interaktive terminali açarak çalışma esnasında kullanıcıdan cevap isterse onu beklemesini sağlar.

        //docker attach 56cc
        //=> id değeri girerek arka planda çalışan uygulamayı öne alır

        //docker container logs 08589
        //=> id değerindeki containerin çalıştığı andan bu yanaki loglarını gösterir.

        //docker start bash_ubuntu
        //=> bash ubuntu ismindeki containerı çalıştırır. Container Id de kullanılabilir.

        //docker stop bash_ubuntu
        //=> containeri durdurur

        //docker rm 03 bf 22
        //=> boşluk bırakılarak yazılabilen çoklu ve ya tek yaılan container geçmişini siler

        //docker container rm $(docker container ls -aq)
        //=>bütün hepsini siler
        #endregion
        #region Çalışan veya çalışmış container listeleme
        //ll

        //ls

        //docker ps
        //=> çalışan containerlerı gösterir

        //docker ps -a
        //=> Geçmişe dair çalışanları gösterir

        //docker container ls
        //=> aktif olan containerlar

        //docker container ls -a
        //=> aktif olan yada olmayan tüm containerlerı gösterir

        //docker images
        //=> var olan imageleri gösterir

        //exit
        //=> kapama


        #endregion
        #region Bağlanma
        //docker run -p DIS_PORT:IC_PORT mongo
        //docker run -p 27018:27017 mongo//Doldurulmuş hali
        //=> dışarıdan mongoya bağlanmak için gerekli port numaralarını tanımlama şekli. 
        #endregion
    }
}
