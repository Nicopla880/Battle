using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {


	[Header("Buttons")]
	public Button BScore;
	public Button BMusic;
	public Button BShip;

	[Header("AudioSource")]
	public AudioSource AS;

	[Header("Others")]
	public Image FadeOut; 
	public static GameData gd;

	void Awake(){

		gd = SaveManager.LoadGame ();



		int value = 0;
		if (gd.Data.TryGetValue ("FX", out value)) {


			if (value == 0) {

				AS.enabled = false;
			} else {

				AS.enabled = true;
			}

		} else {

			AS.enabled = true;
		}
	}

	public void Playbutton(){

		BScore.gameObject.SetActive (false);
		BMusic.gameObject.SetActive (false);
		BShip.gameObject.SetActive (false);
		StartCoroutine (Fade());

	}

	public void Music()
	{	
		if (AS.enabled == true)
		{
			gd.Data ["FX"] = 0;
			AS.enabled = false;
		}
		else{
			gd.Data ["FX"] = 1;
			AS.enabled = true;
		}			

		SaveManager.SaveGame (gd);
	}

	IEnumerator Fade(){

		FadeOut.gameObject.SetActive (true);
		yield return new WaitForSeconds (2.5F);
		SceneManager.LoadScene (1); 

	}



}
