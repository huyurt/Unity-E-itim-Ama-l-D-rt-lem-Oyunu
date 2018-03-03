# Unity Eğitim Amaçlı Dört İşlem Oyunu

Unity, C#, Sql (2017)

* [android için apk](http://bit.ly/2oF3Ku6)

Proje iki kısımdan oluşmaktadır:

**Sunucu tarafı:** Sisteme oyunu kullanacak olan kullanıcıların kayıt edilmesinin kontrolünü, düzenlenmesini içerir. Bu işlemleri sistem yöneticisi takip eder. Sistem yöneticisi, sistemin sunucu tarafının kontrolünü, bakımını sağlar. Sisteme kullanıcıların kayıt edilmesi işlemlerini kontrol eder. Kullanıcıların kayıt işlemlerinde ve diğer işlemlerde yaşayabilecekleri sorunlarda, kullanıcıların sorunlarını çözer.

**Mobil tarafı:** Oyunun kullanıcılar tarafından oynanabildiği kısımdır. Oyun yazılımı üzerinden kayıt olarak oyuna erişim sağlayabilir ve soruları çözebilirler.

**1.1.** Sunucu Tarafı

Projenin, kullanıcıların oyun yazılımı üzerinden sisteme kayıt olmasıyla, kullanıcıların kayıt bilgilerinin, çözdüğü soru sayılarının, bu sorulara verdiği doğru cevap sayılarının ve doğru cevaplarının sonucunda kazandığı toplam puanının veri tabanı aracılığıyla tutulduğu ve çeşitli istatistik bilgilerinin oyun yazılımı aracılığıyla gösterilmesi için oyun yazılımı ile veri tabanı arasındaki iletişimin ve işlemlerin yapıldığı kısmıdır. Projenin sunucu tarafında veri tabanı ve veri tabanı ile oyun yazılımı arasındaki iletişim ve işlemlerin yapılabilmesi için sistem tarafından kullanılan PHP dosyaları bulunur.

Projenin sunucu tarafında, veri tabanı ile oyun yazılımı arasında yapılan işlemler:

1.1.1._Kullanıcı Kaydı_

Kullanıcının, oyun yazılımını kullanabilmesi için öncelikle sisteme kayıt olması gerekir. Kullanıcının sisteme kayıt olabilmesi için kullanıcı adı, şifre, ismi, soy ismi ve mailini doğru bir şekilde yazarak gerçekleştirilir. Ayrıca bu bilgilerini hatalı girmemesi için kontroller yapılarak hata durumuna göre kullanıcının hatasını düzeltmesi için geri bildirim yapılır.

 1.1.2._Kullanıcı Girişi_

Kullanıcı, oyun yazılımı aracılığıyla kullanıcı adını ve şifresini doğru bir şekilde girerek sisteme erişimi sağlar.

 1.1.3._Kullanıcı Düzenleme_

Kullanıcı, oyun yazılımı aracılığıyla eğer başkası tarafından kullanılmıyorsa kullanıcı adını ve mailini değiştirebilir. Bunun yanında şifresini, ismini ve soy ismini de değiştirebilir.

 1.1.4._Kullanıcı İstatistiği_

Kullanıcının, oyun yazılımı aracılığıyla çözdüğü toplam soru sayısı, toplam doğru cevapladığı soru sayısı, toplam soru sayısı ve toplam doğru cevabın oranlandığı başarı oranı ve toplam puana göre tüm kullanıcılar arasındaki sıralamasının gösterilmesidir.

1.1.5._Sıralama_

Tüm kullanıcılar arasında en yüksek puana sahip ilk beş kullanıcının isim, soy isim ve puan bilgilerinin elde edilmesidir.

 1.1.6._Kullanıcı Puan Ekleme_

Kullanıcı, oyun yazılımında çözeceği on soru sonunda kazanacağı puanın veri tabanında tutulan toplam puanına eklenmesidir.

**1.2.** Mobil Tarafı

Projenin, kullanıcıların oyun yazılımı aracılığı ile kayıt olduktan sonra kullanıcı adı ve şifresini girerek toplama, çıkarma, çarpma ve bölme yeteneklerini üç farklı modda geliştirebileceği, oyunu oynayabilecekleri kısmıdır.

Kullanıcı oyun yazılımını mobil cihaza yükledikten ve yazılımı çalıştırdıktan sonra, kullanıcının giriş yapabilmesi için giriş ekranı karşılar.

 ![](https://1.bp.blogspot.com/-bodoySwFcU8/Wprb3Xf3Q_I/AAAAAAAAAF0/Cnq4mJp7Dpo3WHOy6v-vu4xSoA16IVJCQCLcBGAs/s320/1.png)

Şekil 1. _Kullanıcı Giriş Sahnesi_

Projenin mobil tarafında, kullanıcının oyun yazılımı üzerinde yapabildiği işlemler:

 1.2.1._Kullanıcı Kaydı Sahnesi_

Kullanıcının oyunu erişebilmesi için eğer önceden kayıtlı olmamışsa, sistemde benzersiz kullanıcı adı, şifre, isim, soy isim, sistemde benzersiz mailini girerek kayıt olması.

 ![](https://4.bp.blogspot.com/-A4L_m70zE0s/WprcxzTwShI/AAAAAAAAAF8/TFTJIfYrtA8n4O1XdTyyixMYBZgn4ZDsQCLcBGAs/s320/1.png)

Şekil 2. _Kullanıcı Kayıt Sahnesi_

 1.2.2._Kullanıcı Şifre Yenileme Sahnesi_

Sisteme kayıtlı olan kullanıcıların şifrelerini hatırlamamaları durumunda sisteme kayıt oldukları kullanıcı adı ve mailini doğru bir şekilde girerek şifresini yenileyebilir. Böylece kullanıcı adı ve yeni şifresiyle oyuna giriş yapabilir.

 ![](https://4.bp.blogspot.com/-L0lhSTSD4qk/Wprc_TKO-pI/AAAAAAAAAGA/YVKOuY823-c60ga-51HFxbnKTDnIWpR2wCLcBGAs/s320/1.png)

Şekil 3. _Kullanıcı Şifre Yenileme Sahnesi_

 1.2.3._Kullanıcı Girişi Sahnesi_

Sisteme kayıtlı olan kullanıcının kullanıcı adı ve şifresini doğru bir şekilde girerek oyun yazılımının ana ekranına ulaşabilir.

 ![](https://1.bp.blogspot.com/-2_CfOe0ERiI/WprdPR8pLyI/AAAAAAAAAGE/wAofPx3N8Agei4ye3ZC0It3xAbbTWYl_QCLcBGAs/s320/1.png)

Şekil 4. _Kullanıcı Giriş Sahnesi_

 1.2.4._Oyun Ana Sahnesi_

Kullanıcı, doğru bir şekilde giriş yaptıktan sonra oyunun ana sahnesi gelir. Burada giriş yapan kullanıcının ismi, soy ismi ve toplam puanı, oyunu oynayan toplam puanı en yüksek ilk beş kullanıcının ismi, soy ismi ve puanlarının listesi, oyunu oynayacak kişinin toplama, çıkarma, çarpma, bölme ya da dördünü birden çözebileceği on soruluk oyuna girebilmesi için beş adet buton ve ayar butonu vardır.

 ![](https://3.bp.blogspot.com/-0l4H0ZsAWe4/WprdacmTA2I/AAAAAAAAAGM/A0M5pI5fFaEBlhlaT7Oal6LdvoUILNuaACLcBGAs/s320/1.png)

Şekil 5. _Oyun Ana Sahnesi_

 1.2.5._Oyun Ana Sahnesi 2_

Kullanıcı bir önceki ana sahneden toplama, çıkarma, çarpma, bölme ya da dördünü birden çözebileceği işlemi seçtikten sonra karşısına seçmesi gereken üç mod butonları ve bir önceki ana sahneye dönebileceği geri butonu listelenir. Bu üç mod butonu test, doğru yanlış ve hangisi modlarıdır.

 ![](https://1.bp.blogspot.com/-TTfAhPB4pFM/WprdmJcuOyI/AAAAAAAAAGQ/r104PL5njicT3uSvoRE7vpUJHRWP4YKGgCLcBGAs/s320/1.png)

Şekil 6.  _Oyun Ana Sahnesi 2_

 1.2.6._Oyun Sahnesi_

Kullanıcı, oyunu oynamak istediği matematiksel dört temel işlemden birini ve modu seçtikten sonra oyun başlar. Oyunun akışı seçilebilecek üç moda göre değişir.

**Test Modu:** Test modunda, kullanıcıdan rastgele üretilen toplama, çıkarma ve bölme işlemlerinde en fazla üç basamaklı, çarpma işleminde en fazla iki basamaklı iki sayının kullanıcının önceden seçtiği işleme göre işlemi yapılarak doğru sonucun ne olduğunu verilen dört seçenekten bulması istenir.

 ![](https://4.bp.blogspot.com/-IB1MxZ4K6ww/WprdwPdNIFI/AAAAAAAAAGY/ltWLbh7EfNoikXg6i5c6hzkbRl18tRFsgCLcBGAs/s320/1.png)

Şekil 7. _Test Modu_

**Doğru Yanlış Modu:** Doğru yanlış modunda, kullanıcıdan rastgele üretilen toplama, çıkarma ve bölme işlemlerinde en fazla üç basamaklı, çarpma işleminde en fazla iki basamaklı iki sayının kullanıcının önceden seçtiği işleme göre işlemi yapılır ve yine rastgele bir şekilde doğru ya da rastgele üretilmiş bir sayı yanlış cevap olarak gösterilir. Kullanıcıdan bu işlemin doğru ya da yanlış yapılıp yapılmadığını, doğru ya da yanlış yazan iki seçenekten birini işaretleyerek kullanıcının bilmesi istenir.

 ![](https://1.bp.blogspot.com/-37IwfSg4-QU/Wprd5kZM2_I/AAAAAAAAAGc/IJlk36LGDkMCm8CNQa72NOyJEsRRMPe_wCLcBGAs/s320/1.png)

Şekil 8. _Doğru Yanlış Modu_

**Hangisi Modu:** Hangisi modunda, kullanıcıdan rastgele üretilen toplama, çıkarma ve bölme işlemlerinde en fazla üç basamaklı, çarpma işleminde en fazla iki basamaklı iki sayının kullanıcının önceden seçtiği işleme göre işlemi yapılarak bu iki sayıdan doğru cevabı verecek olanın hangisi olduğunu verilen dört seçenekten bulması istenir.

 ![](https://2.bp.blogspot.com/-0HC0m2BDmuA/WpreELaSUEI/AAAAAAAAAGg/oV_n_lHFDtgFqsvf3FpiOnJPIQMQUVqUQCLcBGAs/s320/1.png)

Şekil 9. _Hangisi Modu_

Eğer kullanıcı doğru cevabı bilirse, kullanıcının bildiği doğru sayısı bir arttırılır. Kullanıcı seçeneklerden birini işaretledikten sonra kullanıcının doğru ya da yanlış olanı işaretlemesine göre oyun yazılımı tarafından kullanıcıya sesli ve görsel geri bildirim gönderilir. Bu şekilde on soruyu kullanıcının çözmesi istenir. On sorunun sonunda, kullanıcının doğru cevap sayısı, yanlış cevap sayısı ve kazandığı puan kullanıcıya gösterilir. Kullanıcının oyun sonunda kazanacağı puan:

Floor (doğru cevap sayısı / 3) formülüne göre hesaplanır.

 ![](https://2.bp.blogspot.com/-LkBzfYogfVk/WpreNDChr5I/AAAAAAAAAGo/OfJVgKys9qUN1OzSUEsJJEg44MJ1jF8igCLcBGAs/s320/1.png)

Şekil 10.  _Oyun Sonu Görüntüsü_

 1.2.7._Kullanıcı İstatistiği Sahnesi_

Kullanıcı, oyun ana sahnesinde ayar simgesine tıklayarak kendi istatistiklerini görüntüleyebileceği sahne açılır. Burada kullanıcının ismi, soy ismi, o ana kadar çözdüğü toplam soru sayısı, doğru cevapladığı toplam soru sayısı, başarısı ve tüm kullanıcılar içinde toplam puanına göre sıralaması görüntülenir. Ayrıca profilini düzenleyebilmesi için buton ve çıkış yapabileceği buton bulunur. Kullanıcının başarısı:

Floor (toplam doğru sayısı \* 100 / toplam çözdüğü soru sayısı) formülü ile bulunur.

 ![](https://4.bp.blogspot.com/-i6a-ZeC3oAY/WpreV7fLgtI/AAAAAAAAAGw/sr2BzVabTfYeWTqwqQEe2eDlxVKcLitnQCLcBGAs/s320/1.png)

Şekil 11.  _Kullanıcı İstatistiği Sahnesi_

 1.2.8._Kullanıcı Profil Düzenleme Sahnesi_

Kullanıcı istatistiğini görüntüleyebildiği sahnedeki Profil Düzenle butonuna tıklayarak sistemde benzersiz olmak koşuluyla kullanıcı adını, şifresini, ismini, soy ismini, sistemde benzersiz olmak koşuluyla mailini güncelleyebilir.

 ![](https://2.bp.blogspot.com/-QFtbhqIs7nc/Wpree9Uvf8I/AAAAAAAAAG4/UWpD8G_5mhk9DeULQ29lgKvNpRN_zG1WwCLcBGAs/s320/1.png)

Şekil 12. _Kullanıcı Profil Düzenleme Sahnesi_

 1.2.9._Kullanıcı Çıkışı_

Kullanıcı istatistik sahnesinde Çıkış Yap butonuna tıklayarak hesabından çıkış yapabilir ve böylece kullanıcı girişi sahnesine geri dönebilir.

**1.2.** Oyun Yazılımı Genel Akış Şeması

Projenin genel olarak akış şeması:

 ![](https://2.bp.blogspot.com/-Kufg9hOVw-0/Wprer9zRutI/AAAAAAAAAHA/sXoKnl5e7Ls6mOs9Ov1DScO_MFyiSJUXACLcBGAs/s1600/1.png)

Şekil 13. _Proje Akış Şeması_

**1.3.** Veri Tabanı Yapısı

Projenin veri tabanı yapısı, sisteme kayıtlı olan kullanıcıların bilgilerinin saklandığı kullanicilar tablosu, kullanıcıların giriş yaptığı zaman kötü niyetli kişilerce oturum çalma işlemini engellemek amaçlı session bilgilerinin saklandığı sessions tablosu olmak üzere iki tablodan oluşmaktadır.

Proje veri tabanının er diyagramı:

 ![](https://3.bp.blogspot.com/-OI-X0LuRdZI/Wpre6KgJ5gI/AAAAAAAAAHE/ZSOg4ECYickTaQkHIWpLz4WAPgd7Q5IFQCLcBGAs/s1600/1.png)

Şekil 14.  _Proje ER Diyagramı_

 ![](https://2.bp.blogspot.com/-tCmrtsvZmJ8/WprfEniT7mI/AAAAAAAAAHM/scckOt7OPZInbmGpACnE9hcx2RNEj-dAgCLcBGAs/s400/1.png)

Şekil 15. _Veri Tabanı Şeması_
