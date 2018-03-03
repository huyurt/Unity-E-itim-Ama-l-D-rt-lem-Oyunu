<?php
include_once ("veritabaniBaglantisi.php");

if(isset($_POST["kullaniciAd"]) && isset($_POST["kullaniciSifre"]) && isset($_POST["kullaniciSifreTekrar"]) && isset($_POST["kullaniciIsim"]) && isset($_POST["kullaniciSoyisim"]) && isset($_POST["kullaniciMail"])) {
    $adKontrolu = 0;
    $sifreKontrolu = 0;
    $isim1Kontrolu = 0;
    $soyisimKontrolu = 0;
    $mailKontrolu = 0;
    $adHataMesaji = NULL;
    $sifreHataMesaji = NULL;
    $isim1HataMesaji = NULL;
    $soyisimHataMesaji = NULL;
    $mailHataMesaji = NULL;
    $kullaniciGuncellendiMesaji = NULL;

    include_once ("kontroller/kullaniciAdiKontrol.php");
    include_once ("kontroller/sifreKontrol.php");
    include_once ("kontroller/mailKontrol.php");
    include_once ("kontroller/isim1Kontrol.php");
    include_once ("kontroller/soyisimKontrol.php");
    if($adKontrolu == 1)
        echo $adHataMesaji . "\n";
    if($sifreKontrolu == 1)
        echo $sifreHataMesaji . "\n";
    if($isim1Kontrolu == 1)
        echo $isim1HataMesaji . "\n";
    if($soyisimKontrolu == 1)
        echo $soyisimHataMesaji . "\n";
    if($mailKontrolu == 1)
        echo $mailHataMesaji;

    if ($adKontrolu == 0 && $sifreKontrolu == 0 && $isim1Kontrolu == 0 && $soyisimKontrolu == 0 && $mailKontrolu == 0) {
        $key = dechex(mt_rand(0, 2147483647)) . dechex(mt_rand(0, 2147483647));
        $sifre = hash('sha256', $sifre . $key);
        for ($round = 0; $round < 65536; $round++) {
            $sifre = hash('sha256', $sifre . $key);
        }
        $isim1 = ucfirst(mb_strtolower($isim1));
        $soyisim = ucfirst(mb_strtolower($soyisim));
        $kullaniciEkle = $baglanti->prepare("INSERT INTO kullanicilar (kullaniciAd, kullaniciSifre, kullaniciIsim, kullaniciSoyisim, kullaniciMail, kullaniciKey) VALUES(?,?,?,?,?,?)");
        $kullaniciEkle->execute(array($ad, $sifre, $isim1, $soyisim, $mail, $key));
        if ($kullaniciEkle == TRUE)
            $kullaniciGuncellendiMesaji = "Kayıt başarılı.";
        else
            $kullaniciGuncellendiMesaji = "Kayıt hatası.";
    }
    echo $kullaniciGuncellendiMesaji;
}
?>