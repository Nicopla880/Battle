using UnityEngine;
using System.Collections;


public class Bala : MonoBehaviour {

	public float vel;



	void Update () {
	
		this.transform.Translate(this.transform.up * vel * Time.deltaTime);

	}
		
}

 