using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class baslat : MonoBehaviour
{
    void Start()
    {
		if (PlayerPrefs.GetString ("Kullanici Ad") != "" && PlayerPrefs.GetString ("Kullanici Sifre") != "" && PlayerPrefs.GetInt ("Kullanici Id").ToString () != "" && PlayerPrefs.GetString ("Kullanici Isim") != "" && PlayerPrefs.GetString ("Kullanici Soyisim") != "" && PlayerPrefs.GetInt ("Kullanici Soru").ToString () != "" && PlayerPrefs.GetInt ("Kullanici Puan").ToString () != "") {
			oyunScene ("main");
		} else {
			oyunScene ("giris");
		}
   }

    void Update()
    {
        
    }

	public void oyunScene(string sceneIsmi){
		SceneManager.LoadScene(sceneIsmi);
	}
}