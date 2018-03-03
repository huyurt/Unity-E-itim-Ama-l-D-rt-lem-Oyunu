<?php
include_once ("veritabaniBaglantisi.php");
include_once("Session.php");
$session->_gc();
if (@$session->_read($_POST['kullaniciId'])) {
    if (isset($_POST['kullaniciId'])) {
        $session->_destroy($_POST['kullaniciId']);
    }
}
?>