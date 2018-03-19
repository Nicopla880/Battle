using UnityEngine;
using System.Collections;

public class Corsairs : MonoBehaviour {

	public AudioSource AS;
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




}
