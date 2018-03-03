<?php
include_once("veritabaniBaglantisi.php");
include_once("Session.php");
$session->_gc();
if (@$session->_read($_POST['kullaniciId'])) {
    if (isset($_POST['kullaniciId']) && isset($_POST['kullaniciPuan']) && isset($_POST['kullaniciDogru']) && isset($_POST['kullaniciSoru'])) {
        $kullaniciId = $_POST['kullaniciId'];
        $kullaniciPuan = $_POST['kullaniciPuan'];
        $kullaniciDogru = $_POST['kullaniciDogru'];
        $kullaniciSoru = $_POST['kullaniciSoru'];

        if ($kullaniciPuan < 4 && $kullaniciSoru == 10) {
            $sorgu = $baglanti->prepare("SELECT kullaniciSoru, kullaniciPuan, kullaniciDogru FROM kullanicilar WHERE kullaniciId = :kullaniciId AND kullaniciSilindi = 0");
            $sorgu->bindParam(':kullaniciId', $kullaniciId, PDO::PARAM_STR);
            $sorgu->execute();
            if ($sorgu->rowCount() > 0) {
                $row = $sorgu->fetch(PDO::FETCH_ASSOC);
                $kSoru = $row['kullaniciSoru'];
                $kPuan = $row['kullaniciPuan'];
                $kDogru = $row['kullaniciDogru'];
                $kSoru += $kullaniciSoru;
                $kPuan += $kullaniciPuan;
                $kDogru += $kullaniciDogru;
            }
            $k = $baglanti->prepare("UPDATE kullanicilar SET kullaniciSoru = ?, kullaniciPuan = ?, kullaniciDogru = ? WHERE kullaniciId = ? AND kullaniciSilindi = 0");
            $k->execute(array($kSoru, $kPuan, $kDogru, $kullaniciId));
        }

        $sorgu2 = $baglanti->prepare("SELECT kullaniciPuan FROM kullanicilar WHERE kullaniciId = :kullaniciId AND kullaniciSilindi = 0");
        $sorgu2->bindParam(':kullaniciId', $kullaniciId, PDO::PARAM_STR);
        $sorgu2->execute();
        if ($sorgu2->rowCount() > 0) {
            $row2 = $sorgu2->fetch(PDO::FETCH_ASSOC);
            $kPuan2 = $row2['kullaniciPuan'];
        }
        echo $kPuan2;
    }
}