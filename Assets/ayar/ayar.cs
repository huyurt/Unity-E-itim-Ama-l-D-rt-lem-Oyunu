using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ayar : MonoBehaviour
{
	private host h = new host();
	public Button buton1;
	public Button buton2;
	public Button buton3;
	public Text istatistik;

    void Start()
    {
		if (PlayerPrefs.GetString ("Kullanici Istatistik") != null || PlayerPrefs.GetString ("Kullanici Istatistik") != "") {
			istatistik.text = PlayerPrefs.GetString ("Kullanici Istatistik");
		}
		giris();
    }

    void Update()
    {
		
    }

	public void mainGoster(string sceneIsmi){
		SceneManager.LoadScene (sceneIsmi);
	}

	public void duzenleGoster(string sceneIsmi){
		SceneManager.LoadScene(sceneIsmi);
	}

	public void girisGoster(string sceneIsmi){
		StartCoroutine(cikisYap());
		PlayerPrefs.DeleteAll();
		SceneManager.LoadScene(sceneIsmi);
	}

	IEnumerator istatistikGoster()
	{
		WWWForm form = new WWWForm ();
		form.AddField ("kullaniciId", PlayerPrefs.GetInt ("Kullanici Id"));
		WWW www = new WWW (h.Sunucu + h.İstatistik, form);
		yield return www;
		if (www.text != "") {
			istatistik.text = www.text;
			PlayerPrefs.SetString ("Kullanici Istatistik", www.text);
		}
	}

	IEnumerator cikisYap()
	{
		WWWForm form = new WWWForm ();
		form.AddField ("kullaniciId", PlayerPrefs.GetInt ("Kullanici Id"));
		WWW www = new WWW (h.Sunucu + h.KullaniciCikis, form);
		yield return www;
	}

	public void giris() {
		StartCoroutine(istatistikGoster());
		istatistik.text = PlayerPrefs.GetString ("Kullanici Istatistik");
	}
		
}