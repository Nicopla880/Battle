using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Isla : MonoBehaviour {
	[Header("Prefabs")]
    public GameObject prefabDiamantes;
	public GameObject PowerUp;
	public GameObject Shield;
	public GameObject SuperAttack;
    public GameObject prefabBalas;
	public GameObject BalasBoss;
	public GameObject IslaSprite;
	[Header("UI")]
	public GameObject Box;

	[Header("Otros")]
	public Transform Parent;
	public bool PowerActive;
	public bool WarningActive;
	public bool ShieldActive;
	public float aux;
	public bool levelboss;

	private float tiempobala;
    private float radio;
	private int numlevel;

	void Start () {

		aux = 2;
		tiempobala = 1; 
		PowerActive = false;
		WarningActive = false;
		ShieldActive = true;
		Generar (1);
	 	levelboss = false;


	}




	public void Generar(int level){




		numlevel = level;
		CancelInvoke ();

		radio = 2;

		int total = 36;

		float separacion = 360 / total;

		for (int i=0; i<total; i++) {
			
			int r = Random.Range (1, 100);

			float angulo = i * separacion;

			Vector3 pos = ByCircle(this.transform.position, radio, angulo);

			if (r <= 85) {
				
				Instantiate (prefabDiamantes, pos, Quaternion.identity, Parent);

			} else if (r > 85 && r < 90 && numlevel >= 3 && PowerActive) {
				
				Instantiate (PowerUp, pos, Quaternion.identity, Parent);
				PowerActive = false;
			} else if (r >= 90 && r < 95 && numlevel >= 5 && WarningActive) {
				
				Instantiate (SuperAttack, pos, Quaternion.identity, Parent);
				WarningActive = false;

			} 
			else if (r >= 95 && r <= 100 && numlevel >= 10 && ShieldActive) {

				Instantiate (Shield, pos, Quaternion.identity, Parent);
				ShieldActive = false;

			} 

			else {
				Instantiate (prefabDiamantes, pos, Quaternion.identity, Parent);
			}
		}




		if (level >= 1 && level <= 3) {
			tiempobala = 1;

		}else if(level > 3 && level <= 5)
		{
			tiempobala = 0.8f;

		}else if(level > 5 && level <= 10)
		{
			tiempobala = 0.6f;

		}else if(level > 10 && level <= 15)
		{
			tiempobala = 0.5f;
		}else 
		{
			if (tiempobala > 0.1f) {
				tiempobala -= 0.01f;
			} else {
				tiempobala = 0.1f;
			}

		}
		if (levelboss == false) {
			InvokeRepeating ("Disparar", 1.5f, tiempobala);
		} else 
		{
			InvokeRepeating ("DisparosBoss", 1.5f, 1.5f);
		}

	}

	private void DisparosBoss()
	{
		int r = Random.Range (1, 4);
		GameObject[] bala = new GameObject[10];

		switch (r) 
		{
		case 1:
			
			for (int i = 0; i < 3; i++) {

				bala [i] = Instantiate (BalasBoss);
				bala [i].GetComponent<Bala> ().vel = 1f;

				float angle = Random.value * 360;
				bala [i].transform.eulerAngles = Vector3.forward * angle * (i + 2);

				Destroy (bala [i], 3f);

			}

			break;
		case 2:
			for (int i = 1; i < 6; i++) {

				bala [i] = Instantiate (BalasBoss);
				bala [i].GetComponent<Bala> ().vel = 1f + i;

				float angle = Random.value * 360;
				bala [i].transform.eulerAngles = Vector3.forward * angle;

				Destroy (bala [i], 3f);

			}

			break;

		case 3:

			for (int i = 0; i < 5; i++) {

				bala [i] = Instantiate (BalasBoss);
				bala [i].GetComponent<Bala> ().vel = 1f;

				float angle = Random.value * 360;
				bala [i].transform.eulerAngles = Vector3.forward * angle * i;

				Destroy (bala [i], 3f);

			}
			break;
		}
		
	}

	public void Disparar () {

	
			GameObject bala = Instantiate (prefabBalas);


			if (numlevel == 1) {		
				bala.GetComponent<Bala> ().vel = 1f;
			} else if (numlevel > 1 && numlevel < 5) {
				bala.GetComponent<Bala> ().vel += 1.25f;
			} else if (numlevel >= 5 && numlevel < 10) {
				bala.GetComponent<Bala> ().vel += 1.5f;
			} else if (numlevel >= 10 && numlevel <= 15) {
				bala.GetComponent<Bala> ().vel += 2f;
			} else {
				bala.GetComponent<Bala> ().vel += aux;
			}
			
			bala.transform.eulerAngles = Vector3.forward * Random.value * 360;
			Destroy (bala, 3f);
		} 

			

    Vector3 ByCircle(Vector3 centro, float radio,float angulo) {

        Vector3 pos;

        pos.x = centro.x + radio * Mathf.Sin(angulo * Mathf.Deg2Rad);
        pos.y = centro.y + radio * Mathf.Cos(angulo * Mathf.Deg2Rad);
        pos.z = centro.z;

        return pos;
    }

	public void FinishGame()
	{

		StartCoroutine (Restart());
	}


	IEnumerator Restart()
	{
		CancelInvoke ();
		Parent.gameObject.SetActive (false);
//		this.GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (0.5f);
		Box.gameObject.SetActive (true);
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene (0);
	}


	public void MultiplesDisparos () {

		for (int i = 0; i < 5; i++) {
			GameObject bala = Instantiate (prefabBalas);

			if (numlevel == 1) {		
				bala.GetComponent<Bala> ().vel = 1f;
			} else if (numlevel > 1 && numlevel < 5) {
				bala.GetComponent<Bala> ().vel += 1.25f;
			} else if (numlevel >= 5 && numlevel < 10) {
				bala.GetComponent<Bala> ().vel += 1.5f;
			} else if (numlevel >= 10) {
				bala.GetComponent<Bala> ().vel += 2f;
			}

			bala.transform.eulerAngles = Vector3.forward * Random.value * 360;
			Destroy (bala, 3f);
		}
	}


		
}
