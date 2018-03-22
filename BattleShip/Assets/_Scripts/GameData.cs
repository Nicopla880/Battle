using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 
using System;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveManager {

	public static string fileName = "GameDataA.db";


	public static void SaveGame(GameData gd) {

		string path = Application.persistentDataPath + "/" + SaveManager.fileName;
		BinaryFormatter bf = new BinaryFormatter();
		FileStream stream = new FileStream (path, FileMode.Create);
		bf.Serialize (stream, gd);
		stream.Close ();

	}

	public static GameData LoadGame() {

		string path = Application.persistentDataPath + "/" + SaveManager.fileName;


		if (File.Exists(path)) {
			
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (path, FileMode.Open);
			GameData gd = (GameData)bf.Deserialize (stream);
			stream.Close ();

			return gd;
	
		} else {
			GameData gd = new GameData ();
			gd.Data = new Dictionary<string, int> ();
			gd.ScoreList = new int[20];
			gd.Coins = 10;
			return gd;

		}
			
	}

}

[Serializable]
public class GameData {

	public Dictionary<string,int> Data;
	public int[] ScoreList;
	public int Coins;

}
