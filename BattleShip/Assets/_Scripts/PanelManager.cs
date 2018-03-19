using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour {

	[Header("Prefabs")]
	public GameObject ScorePrefab;
	public GameObject ShipsPrefab;

	[Header("Panels")]
	public GameObject PanelPrincipal;
	public GameObject ParentSprites;
	public GameObject SVScore;
	public GameObject SVShips;

	[Header("Transform")]
	public Transform PScore;
	public Transform PShips;

	void Awake(){

		int pos = 0;

		for(int i = 0; i < 10; i++)
		{
			pos++;

			if (MenuManager.gd.ScoreList[i] > 0) {

				GameObject ClonScore = Instantiate (ScorePrefab);
				ClonScore.transform.SetParent (PScore);
				ClonScore.transform.localScale = Vector3.one;

				ClonScore.transform.Find ("PosText").GetComponent<Text> ().text = "#" + pos.ToString ();
				ClonScore.transform.Find ("ScoreText").GetComponent<Text> ().text = MenuManager.gd.ScoreList[i].ToString ();

			}
		}
	}


	void Update()
	{

		if (Input.GetKeyDown (KeyCode.Escape)) {

			ParentSprites.SetActive (true);
			PanelPrincipal.SetActive(false);
			SVScore.SetActive (false);
			SVShips.SetActive (false);
		}
	}

	public void PanelScore(){

		SVShips.SetActive (false);
		ParentSprites.SetActive (false);
		PanelPrincipal.SetActive (true);
		SVScore.SetActive (true);

	}

	public void PanelShips(){

		SVScore.SetActive (false);
		ParentSprites.SetActive (false);
		PanelPrincipal.SetActive (true);
		SVShips.SetActive (true);

	}


}
