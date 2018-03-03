using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kullaniciSifreYenile : MonoBehaviour
{
	private host h = new host();
	public InputField kullaniciAd;
	public InputField kullaniciMail;
	public InputField kullaniciSifre;
	public InputField kullaniciSifreTekrar;
	public Text hata;

    void Start()
    {
		kullaniciSifre.inputType = InputField.InputType.Password;
		kullaniciSifreTekrar.inputType = InputField.InputType.Password;
    }

    void Update()
    {
        
    }

	IEnumerator SifreYenile(string kAd, string kMail, string sifre, string sifreTekrar)
	{
		WWWForm form = new WWWForm ();
		form.AddField ("kullaniciAd", kAd);
		form.AddField ("kullaniciMail", kMail);
		form.AddField ("kullaniciSifre", sifre);
		form.AddField ("kullaniciSifreTekrar", sifreTekrar);
		WWW www = new WWW (h.Sunucu + h.KullaniciSifreYenile, form);
		yield return www;
		if (www.text != "") {
			string hataMesaj = www.text;
			hata.text = hataMesaj;
			if (hataMesaj == "Şifre güncellendi.") {
				PlayerPrefs.SetString ("Kullanici Sifre", sifre);
			}
			if (www.text == "") {
				hata.text = "İnternet bağlantısı sağlanamadı.";
			}
		}
	}

	public void oyunScene(string sceneIsmi){
		SceneManager.LoadScene(sceneIsmi);
	}
		
    public void giris()
    {
		StartCoroutine(SifreYenile(kullaniciAd.text, kullaniciMail.text, kullaniciSifre.text, kullaniciSifreTekrar.text));
    }
}