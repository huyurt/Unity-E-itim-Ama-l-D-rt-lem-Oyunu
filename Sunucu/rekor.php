<?php
include("veritabaniBaglantisi.php");
include_once("Session.php");
$session->_gc();
if (isset($_POST['rekorGoster'])) {
	if ($_POST['rekorGoster'] == "Goster") {
        $sayac = 0;
        $sonuc = NULL;
        $sorgu = $baglanti->prepare("SELECT kullaniciIsim, kullaniciSoyisim, kullaniciSoru, kullaniciPuan FROM kullanicilar WHERE kullaniciSilindi = 0 ORDER BY kullaniciPuan DESC");
        $sorgu->execute();
        if ($sorgu->rowCount() > 0) {
			if($sorgu->rowCount() == 1)
				$sayac = 4;
			else if($sorgu->rowCount() == 2)
				$sayac = 3;
			else if($sorgu->rowCount() == 3)
				$sayac = 2;
			else if($sorgu->rowCount() == 4)
				$sayac = 1;
            while ($row = $sorgu->fetch(PDO::FETCH_ASSOC)) {
                if ($sayac < 5) {
                    $sonuc .= mb_substr($row['kullaniciIsim'], 0, 8) . " " . mb_substr($row['kullaniciSoyisim'], 0, 7) . "\n\n|" . $row['kullaniciPuan'] . "\n\n|";
                }
                $sayac++;
            }
        }
        echo $sonuc;
    }
}