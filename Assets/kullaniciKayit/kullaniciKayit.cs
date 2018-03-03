using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kullaniciKayit : MonoBehaviour
{
	private host h = new host();
	public InputField kullaniciAd;
	public InputField kullaniciSifre;
	public InputField kullaniciSifreTekrar;
	public InputField kullaniciIsim;
	public InputField kullaniciSoyisim;
	public InputField kullaniciMail;
	public Text hata1;

    void Start()
    {
		kullaniciSifre.inputType = InputField.InputType.Password;
		kullaniciSifreTekrar.inputType = InputField.InputType.Password;
    }

    void Update()
    {
        
    }

	IEnumerator Kaydet (string kAdi, string sifre, string sifreTekrar, string isim, string soyisim, string mail)
	{
		WWWForm form = new WWWForm ();
		form.AddField ("kullaniciAd", kAdi);
		form.AddField ("kullaniciSifre", sifre);
		form.AddField ("kullaniciSifreTekrar", sifreTekrar);
		form.AddField ("kullaniciIsim", isim);
		form.AddField ("kullaniciSoyisim", soyisim);
		form.AddField ("kullaniciMail", mail);
		WWW www = new WWW (h.Sunucu + h.KullaniciKayit, form);
		yield return www;
		string hataMesaj = null;
		if (www.text != "") {
			hataMesaj = www.text;
		}
		if (hataMesaj == "Kayıt başarılı.") {
			kullaniciGirisScene ("giris");
		} else {
			hata1.text = hataMesaj;
		}
		if (www.text == "") {
			hata1.text = "İnternet bağlantısı sağlanamadı.";
		}
	}

	public void kullaniciGirisScene(string sceneIsmi){
		SceneManager.LoadScene (sceneIsmi);
	}

    public void kaydet()
    {
		StartCoroutine(Kaydet(kullaniciAd.text, kullaniciSifre.text, kullaniciSifreTekrar.text, kullaniciIsim.text, kullaniciSoyisim.text, kullaniciMail.text));
    }
}