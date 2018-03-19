using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour {

	void Awake () {

		if (Advertisement.isSupported) {

			Advertisement.Initialize ("1490150", false);
		}
	}

	public void PlayAd(){


		StartCoroutine (ShowAd ());
	}


	IEnumerator ShowAd(){

		while (!Advertisement.IsReady ()) {
			yield return null;
		}

		if (Advertisement.IsReady ("rewardedVideo")) {

			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show ("rewardedVideo", options);

		}

	}



	private void HandleShowResult(ShowResult result)
	{
		switch (result) {


		case ShowResult.Finished:

			Debug.Log ("Completo");

			break;

		case ShowResult.Skipped:

			Debug.Log ("Saltado");

			break;

		case ShowResult.Failed:

			Debug.LogError ("Falla");

			break;


		}

	}
}
