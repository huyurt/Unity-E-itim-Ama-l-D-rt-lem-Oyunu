<?php
include_once("veritabaniBaglantisi.php");
include_once("Session.php");
$girisHataMesaj = NULL;
if(isset($_POST['kullaniciAd']) && isset($_POST['kullaniciSifre'])) {
    $girisKullaniciAd = $_POST['kullaniciAd'];
    $girisKullaniciSifre = $_POST['kullaniciSifre'];
    $girisHataKontrol = 0;
    $girisHataMesaj = NULL;

    $izin = false;
    $sorgu = $baglanti->prepare("SELECT kullaniciAd, kullaniciSifre, kullaniciKey FROM kullanicilar WHERE kullaniciAd = :kullaniciAd AND kullaniciSilindi = 0");
    $sorgu->bindParam(':kullaniciAd', $girisKullaniciAd, PDO::PARAM_STR);
    $sorgu->execute();
    if ($sorgu->rowCount() > 0) {
        $row = $sorgu->fetch(PDO::FETCH_ASSOC);

        $check_password = hash('sha256', $girisKullaniciSifre . $row['kullaniciKey']);
        for ($round = 0; $round < 65536; $round++) {
            $check_password = hash('sha256', $check_password . $row['kullaniciKey']);
        }
        if (md5($check_password) == md5($row['kullaniciSifre'])) {
            $izin = true;
        }
    }

    if ($izin) {
        $sorgu = $baglanti->prepare("SELECT kullaniciId, kullaniciIsim, kullaniciSoyisim, kullaniciSoru, kullaniciPuan FROM kullanicilar WHERE kullaniciAd = :kullaniciAd AND kullaniciSilindi = 0");
        $sorgu->bindParam(':kullaniciAd', $girisKullaniciAd, PDO::PARAM_STR);
        $sorgu->execute();
        if ($sorgu->rowCount() > 0) {
            $row = $sorgu->fetch(PDO::FETCH_ASSOC);

            $access = time();
            $lastaccess = $access + (90000);
            if (!empty($_SERVER['HTTP_CLIENT_IP'])) {
                $ip = $_SERVER['HTTP_CLIENT_IP'];
            } elseif (!empty($_SERVER['HTTP_X_FORWARDED_FOR'])) {
                $ip = $_SERVER['HTTP_X_FORWARDED_FOR'];
            } else {
                $ip = $_SERVER['REMOTE_ADDR'];
            }
            $data4 = NULL;
            $sorgu2 = $baglanti->prepare("REPLACE INTO sessions VALUES (?, ?, ?, ?, ?, ?, ?, ?)");
            $sorgu2->execute(array($row['kullaniciId'], $access, $lastaccess, $row['kullaniciId'], $row['kullaniciIsim'], $row['kullaniciSoyisim'], $data4, $ip));

            $girisHataMesaj = "Giriş başarılı.|" . $row['kullaniciId'] . "|" . $row['kullaniciIsim'] . "|" . $row['kullaniciSoyisim'] . "|" . $row['kullaniciSoru'] . "|" . $row['kullaniciPuan'];

        } else {
            $girisHataMesaj = "Kullanıcı adı veya şifre yanlış.";
            $girisHataKontrol = 1;
        }
    } else {
        $girisHataMesaj = "Kullanıcı adı veya şifre yanlış.";
        $girisHataKontrol = 1;
    }
}
echo $girisHataMesaj;

?>