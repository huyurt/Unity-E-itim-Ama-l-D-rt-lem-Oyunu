-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 08 Haz 2017, 03:41:58
-- Sunucu sürümü: 5.7.14
-- PHP Sürümü: 5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `dortislem`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanicilar`
--

CREATE TABLE `kullanicilar` (
  `kullaniciId` int(11) NOT NULL,
  `kullaniciAd` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `kullaniciSifre` varchar(2000) COLLATE utf8_turkish_ci NOT NULL,
  `kullaniciIsim` varchar(100) COLLATE utf8_turkish_ci NOT NULL,
  `kullaniciSoyisim` varchar(100) COLLATE utf8_turkish_ci NOT NULL,
  `kullaniciMail` varchar(200) COLLATE utf8_turkish_ci NOT NULL,
  `kullaniciKey` varchar(200) COLLATE utf8_turkish_ci NOT NULL,
  `kullaniciSilindi` int(1) NOT NULL DEFAULT '0',
  `kullaniciSoru` int(10) NOT NULL DEFAULT '0',
  `kullaniciPuan` int(10) NOT NULL DEFAULT '0',
  `kullaniciDogru` int(10) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `kullanicilar`
--

INSERT INTO `kullanicilar` (`kullaniciId`, `kullaniciAd`, `kullaniciSifre`, `kullaniciIsim`, `kullaniciSoyisim`, `kullaniciMail`, `kullaniciKey`, `kullaniciSilindi`, `kullaniciSoru`, `kullaniciPuan`, `kullaniciDogru`) VALUES
(5, 'admin', '46a3e1b79528b9edfef785ef1a23eab31fd28cd1fb783c0669a4afbdd24aac90', 'UName', 'USurname', 'admin@admin.com', '80d89b930de2072', 0, 270, 26, 85),
(6, 'kullanici', 'd96a19c56c5da8eb25390abf1ed919444dbfec4226b3a6222156481030fb7412', 'Kullanıcı', 'Soyismim', 'k@kullanici.com', 'd7cc75e58ba896f', 0, 0, 0, 0),
(7, 'admin2', 'f438f5f908352eff0cfadf5498c9f21e5599051d2bca8f65cb2651ce9a08858c', 'Can', 'Mmb', 'mm@hn.com', '790933d8ec117e7', 0, 650, 8, 26),
(8, 'kullaniciAdi', '1ece5e89436191809e74823de0d4158334a2572b3cdf7734b8029c309414f157', 'Nur', 'Öz', 'kullanici@mail.com', '4ec4f7692bacfad6', 0, 0, 0, 0),
(9, 'ali123', 'd06be7021c82b63dbedd3a7e98661b7607103bf3d35998c04d5403d5eedb2c26', 'Ali', 'Al', 'ali@ali..com', '41484a82506aaf1d', 0, 0, 0, 0),
(10, 'dfdff', '888fa424a940a8438b3a1b34998fb6c2bdcb2f5ecf4eaccefb83094d1d7966cf', 'Fatih', 'ün', 'fff@gg.com', '299838a55100f5a3', 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `sessions`
--

CREATE TABLE `sessions` (
  `id` int(11) NOT NULL,
  `access` int(10) UNSIGNED DEFAULT NULL,
  `lastaccess` int(10) UNSIGNED DEFAULT NULL,
  `data` text COLLATE utf8_turkish_ci,
  `data2` text COLLATE utf8_turkish_ci,
  `data3` text COLLATE utf8_turkish_ci,
  `data4` text COLLATE utf8_turkish_ci,
  `ip` varchar(32) COLLATE utf8_turkish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `sessions`
--

INSERT INTO `sessions` (`id`, `access`, `lastaccess`, `data`, `data2`, `data3`, `data4`, `ip`) VALUES
(5, 1496893248, 1496983248, '5', 'UName', 'USurname', NULL, '192.168.173.223'),
(7, 1496870215, 1496960215, '7', 'Can', 'Mmb', NULL, '::1');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `kullanicilar`
--
ALTER TABLE `kullanicilar`
  ADD PRIMARY KEY (`kullaniciId`),
  ADD UNIQUE KEY `kullaniciAd` (`kullaniciAd`);

--
-- Tablo için indeksler `sessions`
--
ALTER TABLE `sessions`
  ADD PRIMARY KEY (`id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `kullanicilar`
--
ALTER TABLE `kullanicilar`
  MODIFY `kullaniciId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
