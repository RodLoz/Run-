using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveAndLoadGame : MonoBehaviour {


	string rout;
	public Slider slider;


	void Awake(){
		rout = Application.persistentDataPath + "/playerinfo.dat";
	}


	public void Save () {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (rout);
		PlayerData dataP = new PlayerData ();
		EnemyData dataE = new EnemyData ();
		TreasuresData dataT = new TreasuresData ();
		dataP.positionX = GameObject.Find ("Player").transform.position.x;
		dataP.positionY = GameObject.Find ("Player").transform.position.y;
		dataP.positionZ = GameObject.Find ("Player").transform.position.z;
		dataP.slider = slider.GetComponent<Slider> ().value;
		dataE.positionX = GameObject.Find ("Enemy").transform.position.x;
		dataE.positionY = GameObject.Find ("Enemy").transform.position.y;
		dataE.positionZ = GameObject.Find ("Enemy").transform.position.z;
		dataT.positionX = GameObject.Find ("TreasureBig").transform.position.x;
		dataT.positionY = GameObject.Find ("TreasureBig").transform.position.y;
		dataT.positionZ = GameObject.Find ("TreasureBig").transform.position.z;;
		dataT.positionX = GameObject.Find ("TreasureMin").transform.position.x;
		dataT.positionY = GameObject.Find ("TreasureMin").transform.position.y;
		dataT.positionZ = GameObject.Find ("TreasureMin").transform.position.z;

		bf.Serialize (file, dataP);
		bf.Serialize (file, dataE);
		bf.Serialize (file, dataT);
		file.Close();
	}
	

	public void Load () {
			
		if (File.Exists (rout)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (rout,FileMode.Open);
			PlayerData dataP = (PlayerData)bf.Deserialize (file);
			EnemyData dataE = (EnemyData)bf.Deserialize (file);
			TreasuresData dataT = (TreasuresData)bf.Deserialize (file);
			file.Close ();

			GameObject.Find ("Player").transform.position = new Vector3 (dataP.positionX, dataP.positionY, dataP.positionZ);
			GameObject.Find ("Enemy").transform.position = new Vector3 (dataE.positionX, dataE.positionY, dataE.positionZ);
			slider.GetComponent<Slider> ().value = dataP.slider;
			GameObject.Find ("TreasureBig").transform.position = new Vector3 (dataT.positionX, dataT.positionY, dataT.positionZ);
			GameObject.Find ("TreasureMin").transform.position = new Vector3 (dataT.positionX, dataT.positionY, dataT.positionZ);
		}
	}
}
