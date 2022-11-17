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

        //docker rmi redis
        //=>img silme işlemi
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

        //docker inspect #id
        //=>Containeri inceler

        //exit
        //=> kapama


        #endregion
        #region Bağlanma
        //docker run -p DIS_PORT:IC_PORT mongo
        //docker run -p 27018:27017 mongo//Doldurulmuş hali
        //=> dışarıdan mongoya bağlanmak için gerekli port numaralarını tanımlama şekli. 


        //docker run --name PostgreSQLL -p 5433:5433 -e POSTGRES_PASSWORD=123456 -v C:\Users\kaan\Documents\Docker:/var/lib/postgresql/dataa -d  postgres
        //postgre bağlantı

        //docker run -v C:\Users\kaan\Documents\Docker:/data/db -p 27017:27017 mongo 
        //=>Kalıcı bir şekilde database oluşturma
        #endregion
        #region Mysql phpmyadmin
        //docker run -e MYSQL_ROOT_PASSWORD = test123 - d mysql

        //docker run --name mysql-server -p 3306:3306 -e MYSQL_ROOT_PASSWORD=test123 -d mysql

        //docker run --name mysql-server -p 3306:3306 -v C:\Users\kaan\Documents\Docker:/etc/mysql/conf.d -e MYSQL_ROOT_PASSWORD = deneme - d mysql

        //docker run --name pmyadmin -p 8000:80 --link mysql-server:db -d phpmyadmin/phpmyadmin
        #endregion
        #region Network
        //docker network ls

        //docker network rm #id

        //docker network create --driver bridge --subnet 182.18.0.1/24 --gateway 182.18.0.1 custom-network

        //docker inspect #name

        //docker run --name mongo-server --net custom-network -d mongo

        //docker run --net custom-network -p 3000:3000 gkandemir/todo-app

        //docker run --net custom-network -p 3000:3000 gkandemir/todo-app


        #endregion
        #region Ubuntu image tasarımı
        //docker run -it ubuntu:18.04

        //apt-get update

        //apt-get install curl -y

        //curl -sL https://deb.nodesource.com/setup_10.x | bash
        //node js indirdik

        //apt-get install nodejs -y
        //kurduk

        //ls klasörleri listeler

        //cd opt klasör seçimi yapar

        //mkdir node-app  node-app isminde klasör oluşturdu

        //echo 'console.log("nodejsapp from ubuntu ...");' >index.js

        //cat index.js => index.js i açar çıktısı => console.log("nodejsapp from ubuntu ...");

        //node index.js => nodejsapp from ubuntu ... çıktısı verir.

        //history => kod geçmişini çıkarır
        #endregion

    }
}
