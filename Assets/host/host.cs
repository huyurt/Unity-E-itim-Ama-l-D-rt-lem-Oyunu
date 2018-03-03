using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class host : MonoBehaviour {
	private string sunucu = "http://denemeproje.site90.com/mobiloyun/";
	private string istatistik = "istatistik.php";
	private string kullaniciGiris = "kullaniciGiris.php";
	private string kullaniciCikis = "kullaniciCikis.php";
	private string kullaniciKayit = "kullaniciKayit.php";
	private string kullaniciDuzenle = "kullaniciDuzenle.php";
	private string kullaniciPuan = "kullaniciPuan.php";
	private string kullaniciPuanEkle = "kullaniciPuanEkle.php";
	private string kullaniciSifreYenile = "kullaniciSifreYenile.php";
	private string rekor = "rekor.php";

	public string Sunucu {
		get {
			return this.sunucu;
		}
	}

	public string İstatistik {
		get {
			return this.istatistik;
		}
	}

	public string KullaniciGiris {
		get {
			return this.kullaniciGiris;
		}
	}

	public string KullaniciCikis {
		get {
			return this.kullaniciCikis;
		}
	}

	public string KullaniciKayit {
		get {
			return this.kullaniciKayit;
		}
	}

	public string KullaniciDuzenle {
		get {
			return this.kullaniciDuzenle;
		}
	}

	public string KullaniciPuan {
		get {
			return this.kullaniciPuan;
		}
	}

	public string KullaniciPuanEkle {
		get {
			return this.kullaniciPuanEkle;
		}
	}

	public string KullaniciSifreYenile {
		get {
			return this.kullaniciSifreYenile;
		}
	}

	public string Rekor {
		get {
			return this.rekor;
		}
	}
}