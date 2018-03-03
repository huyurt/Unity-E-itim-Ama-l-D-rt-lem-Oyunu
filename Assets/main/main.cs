using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*#if UNITY_EDITOR
using UnityEditor;
#endif*/

public class main : MonoBehaviour
{
	private host h = new host();
	public Text isimSoyisim;
	public Text skor;

    void Start()
    {
		isimSoyisim.text = "Merhaba " + PlayerPrefs.GetString ("Kullanici Isim") + " " + PlayerPrefs.GetString ("Kullanici Soyisim");
		if (PlayerPrefs.GetString ("Kullanici Main Skor") != null || PlayerPrefs.GetString ("Kullanici Main Skor") != "") {
			skor.text = PlayerPrefs.GetInt ("Kullanici Main Skor").ToString ();
		}
		giris();
    }

    void Update()
    {
		
    }

	public void toplamaYap(string sceneIsmi){
		PlayerPrefs.SetString("Islem", "Toplama Yap");
		SceneManager.LoadScene (sceneIsmi);
	}
	public void cikarmaYap(string sceneIsmi){
		PlayerPrefs.SetString("Islem", "Çıkarma Yap");
		SceneManager.LoadScene(sceneIsmi);
	}
	public void carpmaYap(string sceneIsmi){
		PlayerPrefs.SetString("Islem", "Çarpma Yap");
		SceneManager.LoadScene(sceneIsmi);
	}
	public void bolmeYap(string sceneIsmi){
		PlayerPrefs.SetString("Islem", "Bölme Yap");
		SceneManager.LoadScene(sceneIsmi);
	}
	public void karisikYap(string sceneIsmi){
		PlayerPrefs.SetString("Islem", "Karışık Yap");
		SceneManager.LoadScene(sceneIsmi);
	}

	public void kullaniciAyarScene(string sceneIsmi){
		SceneManager.LoadScene(sceneIsmi);
	}

	IEnumerator puanGoster(string kId)
	{
		WWWForm form = new WWWForm ();
		form.AddField ("kullaniciId", kId);
		WWW www = new WWW (h.Sunucu + h.KullaniciPuan, form);
		yield return www;
		if (www.text != "") {
			string hataMesaj = www.text;
			int kontrol = 0;
			string[] gelenMesaj = hataMesaj.Split ('|');
			foreach (string g in gelenMesaj) {
				if (kontrol == 0)
					PlayerPrefs.SetInt ("Kullanici Soru", System.Int32.Parse (g.ToString ()));
				if (kontrol == 1)
					PlayerPrefs.SetInt ("Kullanici Puan", System.Int32.Parse (g.ToString ()));
				kontrol++;
			}
			skor.text = PlayerPrefs.GetInt ("Kullanici Puan").ToString ();
			PlayerPrefs.SetInt ("Kullanici Main Skor", PlayerPrefs.GetInt ("Kullanici Puan"));
		}
	}

	public void giris() {
		StartCoroutine(puanGoster(PlayerPrefs.GetInt("Kullanici Id").ToString()));
		skor.text = PlayerPrefs.GetInt ("Kullanici Main Skor").ToString ();
		StartCoroutine(istatistikGoster());
	}

	IEnumerator istatistikGoster()
	{
		WWWForm form = new WWWForm ();
		form.AddField ("kullaniciId", PlayerPrefs.GetInt ("Kullanici Id"));
		WWW www = new WWW (h.Sunucu + h.İstatistik, form);
		yield return www;
		if (www.text != "") {
			PlayerPrefs.SetString ("Kullanici Istatistik", www.text);
		}
	}
		
}