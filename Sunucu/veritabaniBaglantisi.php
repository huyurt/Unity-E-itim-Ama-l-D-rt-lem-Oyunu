<?php

	$sunucuAdi = "localhost";
	$kullaniciAdi = "root";
	$sifre = "";
	$veritabaniAdi = "dortislem";

    try {
        $baglanti = new PDO ("mysql:host=$sunucuAdi;dbname=$veritabaniAdi;charset=utf8", $kullaniciAdi, $sifre);
    }
    catch(PDOException $e) {
        $e->getMessage();
    }

    /*
    $_POST = array_map("htmlspecialchars",$_POST);
    $_GET = array_map("htmlspecialchars",$_GET);
    */

    $baglanti->exec("SET NAMES utf8");
    $baglanti->exec("SET CHARACTER SET utf8");
    $baglanti->exec("SET COLLACTION_CONNECTION=utf8_turkish_ci");

?>