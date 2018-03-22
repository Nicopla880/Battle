using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShips : MonoBehaviour {

	public Ships ship;
	public MenuManager ScriptMenu;
	public GameObject[] BuyButtons;

	void Awake(){

		ScriptMenu = GameObject.FindWithTag ("Manager").GetComponent<MenuManager>();


	}

	public void SelectShip(){
		switch(ship.id){

		case 1:
			if (MenuManager.gd.Coins >= ship.price) {
				
				MenuManager.gd.Data ["Ship"] = ship.id;
				MenuManager.gd.Data ["Speed"] = ship.speed;
				MenuManager.gd.Data ["Armor"] = ship.armor;
				MenuManager.gd.Coins -= ship.price;

				ScriptMenu.TextCoins.text = MenuManager.gd.Coins.ToString ();
				BuyButtons = GameObject.FindGameObjectsWithTag ("BuyButtons");

				foreach (GameObject B in BuyButtons) {

					B.gameObject.GetComponent<Button> ().interactable = true;
				}
				this.GetComponentInChildren<Button> ().interactable = false;
				SaveManager.SaveGame (MenuManager.gd);
			}
		break;

		case 2:
			if (MenuManager.gd.Coins >= ship.price) {

				MenuManager.gd.Data ["Ship"] = ship.id;
				MenuManager.gd.Data ["Speed"] = ship.speed;
				MenuManager.gd.Data ["Armor"] = ship.armor;
				MenuManager.gd.Coins -= ship.price;

				ScriptMenu.TextCoins.text = MenuManager.gd.Coins.ToString ();
				BuyButtons = GameObject.FindGameObjectsWithTag ("BuyButtons");

				foreach (GameObject B in BuyButtons) {

					B.gameObject.GetComponent<Button> ().interactable = true;
				}
				this.GetComponentInChildren<Button> ().interactable = false;
				SaveManager.SaveGame (MenuManager.gd);
			}
		break;

		case 3:
			if (MenuManager.gd.Coins >= ship.price) {

				MenuManager.gd.Data ["Ship"] = ship.id;
				MenuManager.gd.Data ["Speed"] = ship.speed;
				MenuManager.gd.Data ["Armor"] = ship.armor;
				MenuManager.gd.Coins -= ship.price;

				ScriptMenu.TextCoins.text = MenuManager.gd.Coins.ToString ();
				BuyButtons = GameObject.FindGameObjectsWithTag ("BuyButtons");

				foreach (GameObject B in BuyButtons) {

					B.gameObject.GetComponent<Button> ().interactable = true;
				}
				this.GetComponentInChildren<Button> ().interactable = false;
				SaveManager.SaveGame (MenuManager.gd);

			}
		break;
			
		}
	}
}
