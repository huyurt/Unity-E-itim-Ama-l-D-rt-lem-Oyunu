using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*#if UNITY_EDITOR
using UnityEditor;
#endif*/

public class rekor : MonoBehaviour
{
	private host h = new host();
	public Text rekorIsim;
	public Text rekorS;

    void Start()
    {
		if ((PlayerPrefs.GetString ("Kullanici Rekor Isim") != null || PlayerPrefs.GetString ("Kullanici Rekor Isim") == "") && (PlayerPrefs.GetString ("Kullanici Rekor Skor") != null || PlayerPrefs.GetString ("Kullanici Rekor Skor") == "")) {
			rekorIsim.text = PlayerPrefs.GetString ("Kullanici Rekor Isim");
			rekorS.text = PlayerPrefs.GetString ("Kullanici Rekor Skor");
		}
		giris();
    }

    void Update()
    {
		
    }

	IEnumerator rekorGoster()
	{
		WWWForm form = new WWWForm ();
		form.AddField ("rekorGoster", "Goster");
		WWW www = new WWW (h.Sunucu + h.Rekor, form);
		yield return www;
		if (www.text != "") {
			string hataMesaj = www.text.ToString ();
			int kontrol = 0;
			string isimler = "";
			string rekorlar = "";
			string[] gelenMesaj = hataMesaj.Split ('|');
			foreach (string g in gelenMesaj) {
				if (kontrol % 2 == 0)
					isimler += g.ToString ();
				if (kontrol % 2 == 1) {
					rekorlar += g.ToString ();
				}
				kontrol++;
			}
			rekorIsim.text = isimler;
			rekorS.text = rekorlar;
			PlayerPrefs.SetString ("Kullanici Rekor Isim", isimler);
			PlayerPrefs.SetString ("Kullanici Rekor Skor", rekorlar);
		}
	}

	public void giris() {
		StartCoroutine(rekorGoster());
		rekorIsim.text = PlayerPrefs.GetString ("Kullanici Rekor Isim");
		rekorS.text = PlayerPrefs.GetString ("Kullanici Rekor Skor");
	}
		
}