using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class game2 : MonoBehaviour
{
	private host h = new host();
	public AudioClip correct;
	public AudioClip wrong;
	public Button buton1;
	public Button buton2;
	public Button buton5;
	public Text islem;
	public Text soruIzleme;
	public Text puan;
	public static int soruSayisi = 10;
	public static int soru = 1;
	public static int dogru = 0;
	public static bool paused = false;

    void Start()
    {
		islem.gameObject.SetActive (true);
		buton5.gameObject.SetActive (false);
		soru = 1;
		dogru = 0;
		fonksiyonCalistir ();
    }

    void Update()
    {
		
    }

	public void fonksiyonCalistir(){
		if (PlayerPrefs.GetString ("Islem") == "Toplama Yap") {
			toplamaIslemi ();
		}
		if (PlayerPrefs.GetString ("Islem") == "Çıkarma Yap") {
			cikarmaIslemi ();
		}
		if (PlayerPrefs.GetString ("Islem") == "Çarpma Yap") {
			carpmaIslemi ();
		}
		if (PlayerPrefs.GetString ("Islem") == "Bölme Yap") {
			bolmeIslemi ();
		}
		if (PlayerPrefs.GetString ("Islem") == "Karışık Yap") {
			karisik();
		}
	}

	public void karisik(){
		int hangisi = Random.Range (1, 5);
		if (hangisi == 1) {
			toplamaIslemi ();
		} else if(hangisi == 2) {
			cikarmaIslemi ();
		} else if(hangisi == 3) {
			carpmaIslemi ();
		} else {
			bolmeIslemi ();
		}
	}

	public void toplamaIslemi() {
		if (soru < 11) {
			soruIzleme.text = "Soru: " + soru + " / " + soruSayisi;
			int sayi1 = Random.Range (0, 1000);
			int sayi2 = Random.Range (0, 1000);
			int sonuc = sayi1 + sayi2;
			PlayerPrefs.SetInt ("Dogru Cevap", sonuc);
			int dy = Random.Range (1, 3);
			if (dy == 1)
				islem.text = sayi1.ToString () + " + " + sayi2.ToString () + " = " + sonuc.ToString();
			else {
				int deger = 10;
				int aa = Random.Range(1,3);
				if (aa == 1) {
					sonuc += deger;
					islem.text = sayi1.ToString () + " + " + sayi2.ToString () + " = " + sonuc.ToString();
				} else {
					if (sonuc - deger > 0) {
						sonuc -= deger;
						islem.text = sayi1.ToString () + " + " + sayi2.ToString () + " = " + sonuc.ToString();
					} else {
						sonuc += deger;
						islem.text = sayi1.ToString () + " + " + sayi2.ToString () + " = " + sonuc.ToString();
					}
				}
			}
			PlayerPrefs.SetInt ("Gosterilen Cevap", sonuc);
		} else {
			PlayerPrefs.SetInt ("Soru Sayisi", soruSayisi);
			PlayerPrefs.SetInt ("Dogru Cevap", dogru);
			giris();
			buton5.GetComponentInChildren<Text>().text = "Doğru: " + dogru.ToString () + "\n\nYanlış: " + (soruSayisi - dogru).ToString () + "\n\nPuan: " + Mathf.Floor (dogru / 3).ToString ();
			islem.gameObject.SetActive (false);
			buton5.gameObject.SetActive (true);
		}
		soru++;
	}

	public void cikarmaIslemi() {
		if (soru < 11) {
			soruIzleme.text = "Soru: " + soru + " / " + soruSayisi;
			int sonuc;
			int sayi1 = Random.Range (0, 1000);
			int sayi2 = Random.Range (0, 1000);
			if (sayi2 > sayi1) {
				sonuc = sayi2 - sayi1;
			} else {
				sonuc = sayi1 - sayi2;
			}
			PlayerPrefs.SetInt ("Dogru Cevap", sonuc);
			int dy = Random.Range (1,3);
			if (dy == 1) {
				if(sayi1 > sayi2)
					islem.text = sayi1.ToString() + " - " + sayi2.ToString() + " = " + sonuc.ToString();
				else
					islem.text = sayi2.ToString() + " - " + sayi1.ToString() + " = " + sonuc.ToString();
			}
			else {
				int deger = 10;
				int aa = Random.Range(1,3);
				if (aa == 1) {
					sonuc += deger;
					if(sayi1 > sayi2)
						islem.text = sayi1.ToString () + " - " + sayi2.ToString () + " = " + sonuc.ToString();
					else
						islem.text = sayi2.ToString () + " - " + sayi1.ToString () + " = " + sonuc.ToString();
				} else {
					if (sonuc - deger > 0) {
						sonuc -= deger;
						if(sayi1 > sayi2)
							islem.text = sayi1.ToString () + " - " + sayi2.ToString () + " = " + sonuc.ToString();
						else
							islem.text = sayi2.ToString () + " - " + sayi1.ToString () + " = " + sonuc.ToString();
					} else {
						sonuc += deger;
						if(sayi1 > sayi2)
							islem.text = sayi1.ToString () + " - " + sayi2.ToString () + " = " + sonuc.ToString();
						else
							islem.text = sayi2.ToString () + " - " + sayi1.ToString () + " = " + sonuc.ToString();
					}
				}
			}
			PlayerPrefs.SetInt ("Gosterilen Cevap", sonuc);
		} else {
			PlayerPrefs.SetInt ("Soru Sayisi", soruSayisi);
			PlayerPrefs.SetInt ("Dogru Cevap", dogru);
			giris();
			buton5.GetComponentInChildren<Text>().text = "Doğru: " + dogru.ToString () + "\n\nYanlış: " + (soruSayisi - dogru).ToString () + "\n\nPuan: " + Mathf.Floor (dogru / 3).ToString ();
			islem.gameObject.SetActive (false);
			buton5.gameObject.SetActive (true);
		}
		soru++;
	}

	public void carpmaIslemi() {
		if (soru < 11) {
			soruIzleme.text = "Soru: " + soru + " / " + soruSayisi;
			int sayi1 = Random.Range (0, 99);
			int sayi2 = Random.Range (0, 99);
			int sonuc = sayi1 * sayi2;
			PlayerPrefs.SetInt ("Dogru Cevap", sonuc);
			int dy = Random.Range (1, 3);
			if (dy == 1)
				islem.text = sayi1.ToString () + " x " + sayi2.ToString () + " = " + sonuc.ToString();
			else {
				int deger = 10;
				int aa = Random.Range(1,3);
				if (aa == 1) {
					sonuc += deger;
					islem.text = sayi1.ToString () + " x " + sayi2.ToString () + " = " + sonuc.ToString();
				} else {
					if (sonuc - deger > 0) {
						sonuc -= deger;
						islem.text = sayi1.ToString () + " x " + sayi2.ToString () + " = " + sonuc.ToString();
					} else {
						sonuc += deger;
						islem.text = sayi1.ToString () + " x " + sayi2.ToString () + " = " + sonuc.ToString();
					}
				}
			}
			PlayerPrefs.SetInt ("Gosterilen Cevap", sonuc);
		} else {
			PlayerPrefs.SetInt ("Soru Sayisi", soruSayisi);
			PlayerPrefs.SetInt ("Dogru Cevap", dogru);
			giris();
			buton5.GetComponentInChildren<Text>().text = "Doğru: " + dogru.ToString () + "\n\nYanlış: " + (soruSayisi - dogru).ToString () + "\n\nPuan: " + Mathf.Floor (dogru / 3).ToString ();
			islem.gameObject.SetActive (false);
			buton5.gameObject.SetActive (true);
		}
		soru++;
	}

	public void bolmeIslemi() {
		if (soru < 11) {
			soruIzleme.text = "Soru: " + soru + " / " + soruSayisi;
			char bolmeIsareti = (char)247;
			int sayi1 = Random.Range (2, 999);
			int sayi2 = Random.Range (2, sayi1);
			int sayac = 0;
			int x = Random.Range (1, 3);
			while (sayi1 % sayi2 != 0) {
				sayi2 = Random.Range (2, sayi1);
				if (sayac > 999999 && sayi1 % 2 != 0) {
					if (x == 2)
						sayi2 = sayi1;
					else
						sayi2 = 1;
				}
				sayac++;
			}
			int sonuc = sayi1 / sayi2;
			PlayerPrefs.SetInt ("Dogru Cevap", sonuc);
			int dy = Random.Range (1, 3);
			if (dy == 1)
				islem.text = sayi1.ToString () + " " + bolmeIsareti.ToString () + " " + sayi2.ToString () + " = " + sonuc.ToString();
			else {
				int deger = Random.Range(1,10);
				int aa = Random.Range(1,3);
				if (aa == 1) {
					sonuc += deger;
					islem.text = sayi1.ToString () + " " + bolmeIsareti.ToString () + " " + sayi2.ToString () + " = " + sonuc.ToString();
				} else {
					if (sonuc - deger > 0) {
						sonuc -= deger;
						islem.text = sayi1.ToString () + " " + bolmeIsareti.ToString () + " " + sayi2.ToString () + " = " + sonuc.ToString();
					} else {
						sonuc += deger;
						islem.text = sayi1.ToString () + " " + bolmeIsareti.ToString () + " " + sayi2.ToString () + " = " + sonuc.ToString();
					}
				}
			}
			PlayerPrefs.SetInt ("Gosterilen Cevap", sonuc);
		} else {
			PlayerPrefs.SetInt("Soru Sayisi", soruSayisi);
			PlayerPrefs.SetInt("Dogru Cevap", dogru);
			giris();
			buton5.GetComponentInChildren<Text>().text = "Doğru: " + dogru.ToString () + "\n\nYanlış: " + (soruSayisi - dogru).ToString () + "\n\nPuan: " + Mathf.Floor (dogru / 3).ToString ();
			islem.gameObject.SetActive (false);
			buton5.gameObject.SetActive (true);
		}
		soru++;
	}

	public void buton1Tiklandi()
	{
		buton1.interactable = false;
		buton2.interactable = false;
		if (PlayerPrefs.GetInt ("Gosterilen Cevap").ToString() == PlayerPrefs.GetInt ("Dogru Cevap").ToString()) {
			AudioSource.PlayClipAtPoint(correct, transform.position);
			buton1.GetComponentInChildren<Image>().color = Color.green;
			dogru++;
			puan.text = "Doğru: " + dogru.ToString ();
		} else {
			AudioSource.PlayClipAtPoint(wrong, transform.position);
			buton1.GetComponentInChildren<Image>().color = Color.red;
			buton2.GetComponentInChildren<Image>().color = Color.green;
		}
	}
	public void buton2Tiklandi()
	{
		buton1.interactable = false;
		buton2.interactable = false;
		if (PlayerPrefs.GetInt ("Gosterilen Cevap").ToString() != PlayerPrefs.GetInt ("Dogru Cevap").ToString()) {
			AudioSource.PlayClipAtPoint(correct, transform.position);
			buton2.GetComponentInChildren<Image>().color = Color.green;
			dogru++;
			puan.text = "Doğru: " + dogru.ToString ();
		} else {
			AudioSource.PlayClipAtPoint(wrong, transform.position);
			buton2.GetComponentInChildren<Image>().color = Color.red;
			buton1.GetComponentInChildren<Image>().color = Color.green;
		}
	}

	IEnumerator puanEkle(string kId, int kPuan, string kSoru)
	{
		WWWForm form = new WWWForm();
		form.AddField("kullaniciId", kId);
		form.AddField ("kullaniciDogru", kPuan.ToString());
		form.AddField ("kullaniciPuan", Mathf.Floor (kPuan / 3).ToString());
		form.AddField("kullaniciSoru", kSoru);
		WWW www = new WWW(h.Sunucu + h.KullaniciPuanEkle, form);
		yield return www;
	}

	public void giris()
	{
		StartCoroutine(puanEkle(PlayerPrefs.GetInt("Kullanici Id").ToString(), PlayerPrefs.GetInt("Dogru Cevap"), PlayerPrefs.GetInt("Soru Sayisi").ToString()));
		StartCoroutine(rekorGoster());
	}

	IEnumerator b(){
		paused = true;
		yield return new WaitForSeconds(2);
		paused = false;
		if (paused == false) {
			buton1.GetComponentInChildren<Image>().color = Color.white;
			buton2.GetComponentInChildren<Image>().color = Color.white;
			buton1.interactable = true;
			buton2.interactable = true;
			fonksiyonCalistir();
		}
	}

	public void bekle(){
		StartCoroutine(b());
	}

	public void oyunBitti(string sceneIsmi){
		SceneManager.LoadScene (sceneIsmi);
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
			PlayerPrefs.SetString ("Kullanici Rekor Isim", isimler);
			PlayerPrefs.SetString ("Kullanici Rekor Skor", rekorlar);
		}
	}

}