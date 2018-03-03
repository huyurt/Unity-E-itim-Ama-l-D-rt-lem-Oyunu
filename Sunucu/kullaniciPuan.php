<?php
include_once("veritabaniBaglantisi.php");
include_once("Session.php");
$session->_gc();
if (@$session->_read($_POST['kullaniciId'])) {
    if (isset($_POST['kullaniciId'])) {
        $kullaniciId = $_POST['kullaniciId'];
        $sorgu = $baglanti->prepare("SELECT kullaniciSoru, kullaniciPuan FROM kullanicilar WHERE kullaniciId = :kullaniciId AND kullaniciSilindi = 0");
        $sorgu->bindParam(':kullaniciId', $kullaniciId, PDO::PARAM_STR);
        $sorgu->execute();
        if ($sorgu->rowCount() > 0) {
            $row = $sorgu->fetch(PDO::FETCH_ASSOC);
            $kSoru = $row['kullaniciSoru'];
            $kPuan = $row['kullaniciPuan'];
            echo $kSoru . "|" . $kPuan;
        }

    }
}

?>