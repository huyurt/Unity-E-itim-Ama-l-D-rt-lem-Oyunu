<?php
include_once ("veritabaniBaglantisi.php");
include_once("Session.php");
$session->_gc();
if (@$session->_read($_POST['kullaniciId'])) {
    if (isset($_POST["kullaniciId"])) {
        $kAd = $_POST['kullaniciId'];
        $sorgu2 = $baglanti->prepare("SELECT kullaniciAd, kullaniciIsim, kullaniciSoyisim, kullaniciMail FROM kullanicilar WHERE kullaniciId = :kullaniciId AND kullaniciSilindi = 0");
        $sorgu2->bindParam(':kullaniciId', $kAd, PDO::PARAM_STR);
        $sorgu2->execute();
        if ($sorgu2->rowCount() > 0) {
            $row = $sorgu2->fetch(PDO::FETCH_ASSOC);
            $girisHataMesaj = $row['kullaniciAd'] . "|" . $row['kullaniciIsim'] . "|" . $row['kullaniciSoyisim'] . "|" . $row['kullaniciMail'] . "|";
        }
        echo $girisHataMesaj;
    }

    if (isset($_POST["kullaniciId"]) && isset($_POST["kullaniciAd"]) && isset($_POST["kullaniciSifre"]) && isset($_POST["kullaniciSifreTekrar"]) && isset($_POST["kullaniciIsim"]) && isset($_POST["kullaniciSoyisim"]) && isset($_POST["kullaniciMail"])) {
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

        $kId = $_POST['kullaniciId'];
        include_once("kontroller/kullaniciAdiKontrol2.php");
        if ($_POST['kullaniciSifre'] != NULL || $_POST['kullaniciSifreTekrar'] != NULL) {
            include_once("kontroller/sifreKontrol.php");
        }
        include_once("kontroller/mailKontrol2.php");
        include_once("kontroller/isim1Kontrol.php");
        include_once("kontroller/soyisimKontrol.php");
        if ($adKontrolu == 1)
            echo $adHataMesaji . "\n";
        if ($sifreKontrolu == 1)
            echo $sifreHataMesaji . "\n";
        if ($isim1Kontrolu == 1)
            echo $isim1HataMesaji . "\n";
        if ($soyisimKontrolu == 1)
            echo $soyisimHataMesaji . "\n";
        if ($mailKontrolu == 1)
            echo $mailHataMesaji;

        if ($_POST['kullaniciSifre'] == NULL && $_POST['kullaniciSifreTekrar'] == NULL) {
            if ($adKontrolu == 0 && $isim1Kontrolu == 0 && $soyisimKontrolu == 0 && $mailKontrolu == 0) {
                $kullaniciEkle = $baglanti->prepare("UPDATE kullanicilar SET kullaniciAd = ?, kullaniciIsim = ?, kullaniciSoyisim = ?, kullaniciMail = ? WHERE kullaniciId = ?");
                $kullaniciEkle->execute(array($ad, $isim1, $soyisim, $mail, $kId));
                if ($kullaniciEkle == TRUE)
                    $kullaniciGuncellendiMesaji = "Güncelleme başarılı.";
                else
                    $kullaniciGuncellendiMesaji = "Güncelleme hatası.";
            }
        } else {
            if ($adKontrolu == 0 && $sifreKontrolu == 0 && $isim1Kontrolu == 0 && $soyisimKontrolu == 0 && $mailKontrolu == 0) {
                $key = dechex(mt_rand(0, 2147483647)) . dechex(mt_rand(0, 2147483647));
                $sifre = hash('sha256', $sifre . $key);
                for ($round = 0; $round < 65536; $round++) {
                    $sifre = hash('sha256', $sifre . $key);
                }
                $kullaniciEkle = $baglanti->prepare("UPDATE kullanicilar SET kullaniciAd = ?, kullaniciSifre = ?, kullaniciIsim = ?, kullaniciSoyisim = ?, kullaniciMail = ?, kullaniciKey = ? WHERE kullaniciId = ?");
                $kullaniciEkle->execute(array($ad, $sifre, $isim1, $soyisim, $mail, $key, $kId));
                if ($kullaniciEkle == TRUE)
                    $kullaniciGuncellendiMesaji = "Güncelleme başarılı.";
                else
                    $kullaniciGuncellendiMesaji = "Güncelleme hatası.";
            }
        }
        echo $kullaniciGuncellendiMesaji;
    }
}
?>