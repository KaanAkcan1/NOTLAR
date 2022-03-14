namespace CSharpNotları
{
    public class GitHub
    {
        /*
         * GİT NOTLARI
        Git yüklenir ve GitBash ile aşağıdaki gibi komutlar yazılarak kullanılır.
        Tüm silme, isim değiştirme, ekleme gibi işlemler ellede yapılabilir git üzerinden de yapılabilir.
        Git Kullanıcı Girişi
        $ git config --global user.email "egvrcn@gmail.com"
        $ git config --global user.name "Eren Güvercin"
        Kısa Kodlar
        $ pwd : bulunulan dizin gösterilir.
        $ ls : bulunulan klasördeki dosyaları listeler.
        $ ctrl + l : teemizleme yapar
        git init ile Proje Oluşturma
        Proje olmasını istediğimiz yerde "git init" yazılır.
        Bu an itibariyle artık bu klasör git ile versiyon takibine hazırdır.
        Commit ve Log
        Aşağıdaki komutlarla ekleme ve commit yapılır.
        . tüm dosyaları ekler, istenilen belli bir dosya varsa uzantısıyla birlikte adı yazılır.
        Silme duurmlarında da add kullanılabilir. Genellikle rm tercih edilir.
        $ git add .
        $ git commit -m "mesaj yaz"
        ** Tüm versiyonlar hakkında bilgileri gösterir **
        
        $ git log 
        ** Git üzerindeki durumu görmek için **
        
        $ git status
        Git Lifecycle
        [Working Directory - Çalışma Dizini] ==add==> [Staging Area - Geçiş Bölgesi] ==commit==> [Git Repository - Git Deposu]
        
        ** Değişikliklerin takibi **
        
        $ git diff
        yazarak değişiklikler hakkında bilgi alınabilir.
        
        $ git diff --staged
        depo ile stage area arasındaki farklılıkları gösterir.
        
        Unutursan git status kullan, seni yönlendirir.
        
        ** Bir klasör altındaki tüm dosyaları silmek ** r recursive anlamına gelir özyinelemeli olarak siler.
        
        $ git rm -r klasorAdi/
        Dosya İsimlendirme ve Taşıma
        mv komutu ile hem yeniden isimlendirme hem de taşıma işlemi yapılır.
        
        $ git mv isim.txt yeniIsim.txt   //Adlandırma
        $ git mv JSSon.js dosyalar/      //Taşıma
        Çok sayıda log dosyası vs varsa o döngüden çıkmak için "q" (quit) tuşuna basılır.
        
        Geri Alma İşlemi (Herhangi bir versiyona geri gitme - Kurtarma)
        Değişiklik yapıp herhangi bir şekilde add yada commit yapılmadan duran = çalışma dizini
        Değişiklik durumu (çalışma dizini) ve Silinen dosyayı geri getirme (çalışma dizini)
        "git checkout -- <file>..." to discard changes in working directory
        $ git checkout -- dosyaAdi
        Değişikliği Geri Alma (Geçiş bölgesi)
        "git reset HEAD <file>..." to unstage
        $ git reset HEAD dosyaAdi
        Buradan çalışma bölgesine atar.
        Çalışma bölgesinden çıkarmak için tekrar checkout yapılır.
        Versiyon Değiştirme
        v1 ==> v2 ==> v3 ==>> v2 kopyası
        
        . işareti projemdeki bütün dosyaları şu hash koda sahip versiyondaki hale getir demektir.
        ilk 7 haneyi girmekte yeterlidir.
        $ git checkout 7903c0fea7533abc23590b3562822b6e123864d1 -- .
        Yeni Dosya Ekleme
        $ touch README.md
        REMOTE(GİTLAB) İŞLEMLERİ
        ** Var Olan Bir Remote Projeye Entegrasyon **
        
        İlk defa uzaktan bir projeye bağlanıp onun git halini almak için aşağıdaki kod yazılır. Bu sayede ilgili git projesi son haliyle yüklenir ve otomatik olarak origin remote'u eklenir.
        
        git clone https://egvrcn@bitbucket.org/egvrcn/test.git(proje yolu)
        ** Kendimizde Bulunan Bir Projeyi Remote'a Entegre Etmek **
        
        $ git remote add origin https://gitlab.com/egvrcn/test.git
        $ git push -u origin --all
        $ git push -u origin --tags
        gitignore
        $ cat >> gitignore $ dosyaAdi
        
        gitignore daha sonra elle değiştirilebilir.
        Bir klasör altını gizlemek.
        dosyalar/*
        Herhangi birini açmak
        !dosyalar/1.html
        Remote'tan dosyaları çekmek
        $git pull
        Branch (Dallar)
        Dalları göstermek için
        $ git branch
        Remotetaki branchları çekmek için
        $ git branch --all
        Yeni Branch(Dal)
        $ git branch yenidal
        Dal seçmek
        $ git checkout yenidal
        İki dal arasındaki farklılıklar
        $ git diff master yeni
        Birleştirme (Merge İşlemi)
        $ git merge yenidal
        How do I resolve git saying “Commit your changes or stash them before you can merge”?
        You can't merge with local modifications. Git protects you from losing potentially important changes. You have three options.
        
        Commit the change using
        git commit -m "My message"
        Stash it. Stashing acts as a stack, where you can push changes, and you pop them in reverse order. To stash type:
        git stash
        Do the merge, and then pull the stash:
        
        git stash pop
        Discard the local changes
        using git reset --hard. or git checkout -t -f remote/branch
        a) Discard local changes for a specific file
        using git checkout filename
        RefLog ile Verileri Çekme
        $ git reflog
        ... snip ...
        cf42fa2... HEAD@{84}: checkout: moving to master
        73b9363... HEAD@{85}: commit: Don't symlink to themes on deployment.
        547cc1b... HEAD@{86}: commit: Deploy to effectif.com web server.
        1dc3298... HEAD@{87}: commit: Updated the theme.
        18c3f51... HEAD@{88}: commit: Verify with Google webmaster tools.
        26fbb9c... HEAD@{89}: checkout: moving to effectif
        git reset --hard 73b9363
        Soru => Git error on commit after merge - fatal: cannot do a partial commit during a merge
        You need to do git commit -m "your_merge_message". During a merge conflict you cannot merge one single file so you need to
        
        Stage only the conflicted file ( git add your_file.txt )
        git commit -m "your_merge_message"
        Soru => fatal: cannot do a partial commit during a merge.
        git commit -am "mergedMessage"
        Soru => PUBLISH HATASI - Use VS2017 to publish WebAPI , get stuck in preparing profile
        Go to your project folder ang go to "Properties\PublishProfile" and delete all profiles. Then try to publish again.
         */
    }
}
