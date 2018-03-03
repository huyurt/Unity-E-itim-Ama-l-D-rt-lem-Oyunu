using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kullaniciGiris : MonoBehaviour
{
	private host h = new host();
	public InputField kullaniciAd;
	public InputField kullaniciSifre;
	public Text hata;

    void Start()
    {
		if (PlayerPrefs.GetString ("Kullanici Ad") != "" && PlayerPrefs.GetString ("Kullanici Sifre") != "" && PlayerPrefs.GetInt ("Kullanici Id").ToString() != "" && PlayerPrefs.GetString ("Kullanici Isim") != "" && PlayerPrefs.GetString ("Kullanici Soyisim") != "" && PlayerPrefs.GetInt ("Kullanici Soru").ToString() != "" && PlayerPrefs.GetInt ("Kullanici Puan").ToString() != "") {
			oyunScene ("main");
		}
		kullaniciSifre.inputType = InputField.InputType.Password;
    }

    void Update()
    {
        
    }

	IEnumerator Login(string kAd, string sifre)
	{
		WWWForm form = new WWWForm ();
		form.AddField ("kullaniciAd", kAd);
		form.AddField ("kullaniciSifre", sifre);
		WWW www = new WWW (h.Sunucu + h.KullaniciGiris, form);
		yield return www;
		if (www.text != "") {
			string hataMesaj = www.text;
			hata.text = "";
			int kontrol = 0;
			string[] gelenMesaj = hataMesaj.Split ('|');
			foreach (string g in gelenMesaj) {
				if (kontrol == 0)
					hataMesaj = g.ToString ();
				if (kontrol == 1)
					PlayerPrefs.SetInt ("Kullanici Id", System.Int32.Parse (g.ToString ()));
				if (kontrol == 2)
					PlayerPrefs.SetString ("Kullanici Isim", g.ToString ());
				if (kontrol == 3)
					PlayerPrefs.SetString ("Kullanici Soyisim", g.ToString ());
				if (kontrol == 4)
					PlayerPrefs.SetInt ("Kullanici Soru", System.Int32.Parse (g.ToString ()));
				if (kontrol == 5)
					PlayerPrefs.SetInt ("Kullanici Puan", System.Int32.Parse (g.ToString ()));
				kontrol++;
			}
			if (hataMesaj == "Giriş başarılı.") {
				PlayerPrefs.SetString ("Kullanici Ad", kAd);
				PlayerPrefs.SetString ("Kullanici Sifre", sifre);
				oyunScene ("main");
			} else {
				hata.text = hataMesaj;
			}
			if (www.text == "") {
				hata.text = "İnternet bağlantısı sağlanamadı.";
			}
		}
	}

	public void oyunScene(string sceneIsmi){
		SceneManager.LoadScene(sceneIsmi);
	}
		
	public void kullaniciKaydetScene(string sceneIsmi){
		SceneManager.LoadScene(sceneIsmi);
	}

    public void giris()
    {
		StartCoroutine(Login(kullaniciAd.text, kullaniciSifre.text));
    }
}