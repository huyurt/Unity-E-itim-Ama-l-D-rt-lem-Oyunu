<?php
include("veritabaniBaglantisi.php");
include_once("Session.php");
$session->_gc();
if (@$session->_read($_POST['kullaniciId'])) {
    if (isset($_POST['kullaniciId'])) {
        $sonuc = NULL;
        $kullaniciId = $_POST['kullaniciId'];
        $sorgu = $baglanti->prepare("SELECT kullaniciIsim, kullaniciSoyisim, kullaniciSoru, kullaniciDogru FROM kullanicilar WHERE kullaniciId = :kullaniciId AND kullaniciSilindi = 0");
        $sorgu->bindParam(':kullaniciId', $kullaniciId, PDO::PARAM_STR);
        $sorgu->execute();
        if ($sorgu->rowCount() > 0) {
            while ($row = $sorgu->fetch(PDO::FETCH_ASSOC)) {
				if($row['kullaniciSoru'] != 0) {
					$basari = intval(($row['kullaniciDogru'] * 100) / $row['kullaniciSoru']);
				} else {
					$basari = 0;
				}
                $sonuc .= $row['kullaniciIsim'] . " " . $row['kullaniciSoyisim'] . "\n\nÇözdüğün Soru Sayısı: " . $row['kullaniciSoru'] . "\n\nDoğru Sayısı: " . $row['kullaniciDogru'] . "\n\nBaşarın: % " . $basari;
            }
        }
		$sorgu2 = $baglanti->prepare("SELECT kullaniciId, kullaniciPuan FROM kullanicilar WHERE kullaniciSilindi = 0 ORDER BY kullaniciPuan DESC");
        $sorgu2->execute();
		$siralama = 1;
        if ($sorgu2->rowCount() > 0) {
            while ($row = $sorgu2->fetch(PDO::FETCH_ASSOC)) {
				if($row['kullaniciId'] == $kullaniciId) {
					$sonuc .= "\n\nSıralaman: " . $siralama;
					break;
				}
				$siralama++;
            }
        }
		
        echo $sonuc;
    }
}

?>