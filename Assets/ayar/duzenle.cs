using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class duzenle : MonoBehaviour
{
	private host h = new host();
	public Button buton1;
	public Button buton2;
	public InputField kullaniciAd;
	public InputField kullaniciSifre;
	public InputField kullaniciSifreTekrar;
	public InputField kullaniciIsim;
	public InputField kullaniciSoyisim;
	public InputField kullaniciMail;
	public Text mesaj;

    void Start()
    {
		giris2();
		kullaniciSifre.inputType = InputField.InputType.Password;
		kullaniciSifreTekrar.inputType = InputField.InputType.Password;
    }

    void Update()
    {
		
    }

	public void ayarGoster(string sceneIsmi){
		SceneManager.LoadScene (sceneIsmi);
	}

	IEnumerator kullaniciDuzenle()
	{
		WWWForm form = new WWWForm();
		form.AddField ("kullaniciId", PlayerPrefs.GetInt("Kullanici Id"));
		form.AddField ("kullaniciAd", kullaniciAd.text);
		form.AddField ("kullaniciSifre", kullaniciSifre.text);
		form.AddField ("kullaniciSifreTekrar", kullaniciSifreTekrar.text);
		form.AddField ("kullaniciIsim", kullaniciIsim.text);
		form.AddField ("kullaniciSoyisim", kullaniciSoyisim.text);
		form.AddField ("kullaniciMail", kullaniciMail.text);
		WWW www = new WWW (h.Sunucu + h.KullaniciDuzenle, form);
		yield return www;
		if (www.text != "") {
			string hataMesaj = www.text;
			mesaj.text = "";
			int kontrol = 0;
			string[] gelenMesaj = hataMesaj.Split ('|');
			string x = "";
			foreach (string g in gelenMesaj) {
				if (kontrol == 4)
					x += g.ToString () + "\n";
				if (kontrol == 5)
					x += g.ToString () + "\n";
				if (kontrol == 6)
					x += g.ToString () + "\n";
				if (kontrol == 7)
					x += g.ToString () + "\n";
				kontrol++;
			}
			mesaj.text = x;
		}
		if (mesaj.text == "Güncelleme başarılı.\n") {
			PlayerPrefs.SetString ("Kullanici Isim", kullaniciIsim.text);
			PlayerPrefs.SetString ("Kullanici Soyisim", kullaniciSoyisim.text);
		}
		if (www.text == "") {
			mesaj.text = "İnternet bağlantısı sağlanamadı.";
		}
	}

	public void giris() {
		StartCoroutine(kullaniciDuzenle());
	}


	IEnumerator kullaniciGoster()
	{
		WWWForm form = new WWWForm();
		form.AddField ("kullaniciId", PlayerPrefs.GetInt("Kullanici Id"));
		WWW www = new WWW (h.Sunucu + h.KullaniciDuzenle, form);
		yield return www;
		if (www.text != "") {
			string hataMesaj = www.text;
			mesaj.text = "";
			int kontrol = 0;
			string[] gelenMesaj = hataMesaj.Split ('|');
			foreach (string g in gelenMesaj) {
				if (kontrol == 0)
					kullaniciAd.text = g.ToString ();
				if (kontrol == 1)
					kullaniciIsim.text = g.ToString ();
				if (kontrol == 2)
					kullaniciSoyisim.text = g.ToString ();
				if (kontrol == 3)
					kullaniciMail.text = g.ToString ();
				kontrol++;
			}
		}
		if (www.text == "") {
			mesaj.text = "İnternet bağlantısı sağlanamadı.";
		}
	}

	public void giris2() {
		StartCoroutine(kullaniciGoster());
	}
		
}