using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*#if UNITY_EDITOR
using UnityEditor;
#endif*/

public class secim : MonoBehaviour
{
	public Text isimSoyisim;
	public Text skor;

    void Start()
    {
		isimSoyisim.text = "Merhaba " + PlayerPrefs.GetString ("Kullanici Isim") + " " + PlayerPrefs.GetString ("Kullanici Soyisim");
		skor.text = PlayerPrefs.GetInt ("Kullanici Main Skor").ToString ();
    }

    void Update()
    {
		
    }

	public void test(string sceneIsmi){
		SceneManager.LoadScene (sceneIsmi);
	}
	public void dogruYanlis(string sceneIsmi){
		SceneManager.LoadScene(sceneIsmi);
	}
	public void hangisi(string sceneIsmi){
		SceneManager.LoadScene(sceneIsmi);
	}
	public void kullaniciAyarScene(string sceneIsmi){
		SceneManager.LoadScene(sceneIsmi);
	}
	public void mainScene(string sceneIsmi){
		SceneManager.LoadScene(sceneIsmi);
	}

}