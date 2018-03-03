<?php
include_once ("veritabaniBaglantisi.php");

if(isset($_POST["kullaniciAd"]) && isset($_POST["kullaniciMail"]) && isset($_POST["kullaniciSifre"]) && isset($_POST["kullaniciSifreTekrar"])) {
	$ad = $_POST["kullaniciAd"];
	$mail = $_POST["kullaniciMail"];
    $sifreKontrolu = 0;
	$adMailKontrolu = 1;
    $sifreHataMesaji = NULL;
    $kullaniciGuncellendiMesaji = NULL;

    include_once ("kontroller/sifreKontrol.php");
	
	$sorgu2 = $baglanti->prepare("SELECT * FROM kullanicilar WHERE kullaniciAd = ? AND kullaniciMail = ? AND kullaniciSilindi = 0");
    $sorgu2->execute(array($ad, $mail));
    if ($sorgu2->rowCount() > 0) {
        while ($row = $sorgu2->fetch(PDO::FETCH_ASSOC)) {
			$adMailKontrolu = 0;
		}
	} else {
        $kullaniciGuncellendiMesaji = "Kullanıcı adı veya mail hatalı.";
    }
	
    if ($sifreKontrolu == 0 && $adMailKontrolu == 0) {
        $key = dechex(mt_rand(0, 2147483647)) . dechex(mt_rand(0, 2147483647));
        $sifre = hash('sha256', $sifre . $key);
        for ($round = 0; $round < 65536; $round++) {
            $sifre = hash('sha256', $sifre . $key);
        }
        $kullaniciEkle = $baglanti->prepare("UPDATE kullanicilar SET kullaniciSifre = ?, kullaniciKey = ? WHERE kullaniciAd = ? AND kullaniciMail = ?");
        $kullaniciEkle->execute(array($sifre, $key, $ad, $mail));
        if ($kullaniciEkle == TRUE)
            $kullaniciGuncellendiMesaji = "Şifre güncellendi.";
        else
            $kullaniciGuncellendiMesaji = "Şifre güncelleme hatası.";
    }
    if($sifreKontrolu == 1 && $adMailKontrolu == 0)
        echo $sifreHataMesaji;
    else
        echo $kullaniciGuncellendiMesaji . "\n" . $sifreHataMesaji;
}
?>