using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


[Serializable]
public class LoadJson{

	public List<Ships> data;
}

[Serializable]
public class Ships{

	public int id;
	public int speed;
	public int armor;
	public int price;
	public string title;
}

public class LoadData : MonoBehaviour {

	public static string File = "Data/Ships";


	void Start(){

		TextAsset txt = Resources.Load<TextAsset> (File);
		ParseJson (txt.text);
	}

	void ParseJson(string datajson){

		Color Green = new Color (0,255,0,255);
		Color Red = new Color (255,0,0,255);
		Color Blue = new Color (0,0,255,255);

		LoadJson jsload = JsonUtility.FromJson<LoadJson> (datajson);
		foreach (Ships ship in jsload.data) {

			GameObject ClonShip = Instantiate (this.GetComponent<PanelManager>().ShipsPrefab) as GameObject;
			ClonShip.transform.SetParent (this.GetComponent<PanelManager>().PShips);
			ClonShip.transform.localScale = Vector3.one;
			ClonShip.transform.Find ("ShipImg").GetComponent<Image> ().preserveAspect = true;
			ClonShip.GetComponent<UIShips> ().ship = ship;
			switch (ship.id) {

			case 1:
				ClonShip.transform.Find ("ShipImg").GetComponent<Image> ().color = Green;
				ClonShip.transform.Find ("ShipName").GetComponent<Text> ().text = ship.title;
				ClonShip.transform.Find ("ArmorText").GetComponent<Text> ().text = "Armor: " + ship.armor.ToString();
				ClonShip.transform.Find ("SpeedText").GetComponent<Text> ().text = "Speed: " + ship.speed.ToString();
				ClonShip.transform.Find ("Buy").GetComponentInChildren<Text> ().text = "Buy: " + ship.price.ToString();
				break;
			case 2:
				ClonShip.transform.Find ("ShipImg").GetComponent<Image> ().color = Red;
				ClonShip.transform.Find ("ShipName").GetComponent<Text> ().text = ship.title;
				ClonShip.transform.Find ("ArmorText").GetComponent<Text> ().text = "Armor: " + ship.armor.ToString();
				ClonShip.transform.Find ("SpeedText").GetComponent<Text> ().text = "Speed: " + ship.speed.ToString();
				ClonShip.transform.Find ("Buy").GetComponentInChildren<Text> ().text = "Buy: " + ship.price.ToString();
				break;
			case 3:
				ClonShip.transform.Find ("ShipImg").GetComponent<Image> ().color = Blue;
				ClonShip.transform.Find ("ShipName").GetComponent<Text> ().text = ship.title;
				ClonShip.transform.Find ("ArmorText").GetComponent<Text> ().text = "Armor: " + ship.armor.ToString();
				ClonShip.transform.Find ("SpeedText").GetComponent<Text> ().text = "Speed: " + ship.speed.ToString();
				ClonShip.transform.Find ("Buy").GetComponentInChildren<Text> ().text = "Buy: " + ship.price.ToString();
				break;
			}

			ClonShip.GetComponentInChildren<UIShips> ().ship = ship;

		}
	}
}
