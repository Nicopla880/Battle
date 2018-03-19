using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShips : MonoBehaviour {

	public Ships ship;

	public void SelectShip(){
		switch(ship.id){

		case 1:
			MenuManager.gd.Data ["Ship"] = ship.id;
			MenuManager.gd.Data ["Speed"] = ship.speed;
			MenuManager.gd.Data ["Armor"] = ship.armor;
		break;

		case 2:
			MenuManager.gd.Data ["Ship"] = ship.id;
			MenuManager.gd.Data ["Speed"] = ship.speed;
			MenuManager.gd.Data ["Armor"] = ship.armor;
		break;

		case 3:
			MenuManager.gd.Data ["Ship"] = ship.id;
			MenuManager.gd.Data ["Speed"] = ship.speed;
			MenuManager.gd.Data ["Armor"] = ship.armor;
		break;
			
		}

		SaveManager.SaveGame (MenuManager.gd);
	}
}
