using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Nave : MonoBehaviour {

	[Header("LoadData")]
    public float speed;
	public int armor;


	[Header("Direccion Jugador")]
    public Vector3 direccion;

	[Header("Textos")]
	public Text Puntuacion;
	public Text Level;
	public Text HyperSpeed;
	public Text ShieldText;
	public Text Warning;

	[Header("Otros")]
	public Transform isla;
	public Isla ScriptIsla;
	public GameObject escnave;
	public GameData gd;
	public Animation BossAnim;


	private int puntajetotal;
	private int diamantes;
	private int numlevel;
	private bool active;
	private bool levelboss;


	void Start () {


		gd = SaveManager.LoadGame ();
		int value = 0;



		if (gd.Data.TryGetValue ("Ship", out value)) {

			speed = gd.Data ["Speed"];
			armor = gd.Data ["Armor"];

			switch (gd.Data ["Ship"]) {
			case 1:
				this.GetComponent<SpriteRenderer> ().color = new Color (0, 255, 0, 255);
				break;

			case 2:
				this.GetComponent<SpriteRenderer> ().color = new Color (255, 0, 0, 255);
				break;

			case 3:
				this.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 255, 255);

				break;
			}
		} else {
			
			armor = 10;
			speed = 40;
			this.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 255);
		}

        this.direccion = Vector3.forward;
		numlevel = 9;
		diamantes = 0;
		puntajetotal = 0;
		active = true;
		levelboss = false;
		Level.text = "Nivel: " + numlevel.ToString();

	}
	
	void Update () {

		if (active) {
			this.transform.RotateAround (isla.position, direccion, speed * Time.deltaTime);
		}
			
	}
		
	public void Reverse() {

			this.direccion *= -1;
			this.transform.localScale *= -1;
		}

    
	void OnTriggerEnter2D(Collider2D data) {
		if (data.gameObject.tag == "Diamantes") {

			Destroy (data.gameObject);
			diamantes += 1;
			puntajetotal += 5;
			Puntuacion.text = "Puntaje: " + puntajetotal.ToString ();

		}


		if (data.gameObject.tag == "PowerUp") {

			Destroy (data.gameObject);
			diamantes += 1;
			puntajetotal += 5;
			Puntuacion.text = "Puntaje: " + puntajetotal.ToString ();

			StartCoroutine (ChangeSpeed());
			}


		if (data.gameObject.tag == "SuperAtaque") {

			Destroy (data.gameObject);
			diamantes += 1;
			puntajetotal += 5;
			Puntuacion.text = "Puntaje: " + puntajetotal.ToString ();


			ScriptIsla.MultiplesDisparos ();
			Warning.gameObject.SetActive (true);

			
			}
			

		if (data.gameObject.tag == "Escudo") {

			Destroy (data.gameObject);
			diamantes += 1;
			puntajetotal += 5;
			Puntuacion.text = "Puntaje: " + puntajetotal.ToString ();

			escnave.SetActive(true);
			ShieldText.gameObject.SetActive (true);


		}
			if (data.gameObject.tag == "Bala") {
				
			if (escnave.activeSelf == false && armor <= 0) {
					active = false;
					this.GetComponent<Animator> ().Play ("ExpAnim");
					SaveData ();
					ScriptIsla.FinishGame ();
			} else if(escnave.activeSelf == false && armor > 0)
			{
				armor -= 10;

				if (armor <= 0) {
					active = false;
					this.GetComponent<Animator> ().Play ("ExpAnim");
					SaveData ();
					ScriptIsla.FinishGame ();
				}
			}

			else if(escnave.activeSelf == true)
				
				{
					escnave.SetActive(false);
					ShieldText.gameObject.SetActive (false);
					ScriptIsla.ShieldActive = true;
				}

			Destroy (data.gameObject);

			}


		if (data.gameObject.tag == "BalaBoss") {

			if (escnave.activeSelf == false && armor <= 0) {
				active = false;
				this.GetComponent<Animator> ().Play ("ExpAnim");
				SaveData ();
				ScriptIsla.FinishGame ();
			} else if(escnave.activeSelf == false && armor > 0)
			{
				armor -= 20;

				if (armor <= 0) {
					active = false;
					this.GetComponent<Animator> ().Play ("ExpAnim");
					SaveData ();
					ScriptIsla.FinishGame ();
				}
			}

			else if(escnave.activeSelf == true)

			{
				escnave.SetActive(false);
				ShieldText.gameObject.SetActive (false);
				ScriptIsla.ShieldActive = true;
			}

			Destroy (data.gameObject);

		}


		if (diamantes == 36) {

			if (numlevel == 10 || numlevel == 20 || numlevel == 30) {
				Level.text = "Boss Level: ";
				BossAnim.Play ();
				levelboss = true;
				diamantes = 0;
				ScriptIsla.levelboss = levelboss;
				ScriptIsla.Generar (numlevel);

			} else {


				numlevel++;
				ScriptIsla.aux += 0.05f; 
				Level.text = "Nivel: " + numlevel.ToString ();
				diamantes = 0;
				Warning.gameObject.SetActive (false);
				ScriptIsla.WarningActive = true;
				ScriptIsla.PowerActive = true;

				ScriptIsla.Generar (numlevel);
			}

		}
		}




	IEnumerator ChangeSpeed(){

		HyperSpeed.gameObject.SetActive (true);
		speed += 50;
		yield return new WaitForSeconds (3f);
		speed = 50;
		HyperSpeed.gameObject.SetActive (false);
	}




	public void SaveData(){

		int[] aux = new int[20];
		bool active = true;
		for (int i = 0; i < 10; i++) {

			if (puntajetotal == gd.ScoreList [i] && active) {

				active = false;
				} 

				else if (puntajetotal > gd.ScoreList [i] && active) {
					aux[i] = gd.ScoreList [i];
					aux [i + 1] = gd.ScoreList [i + 1];
					aux [i + 2] = gd.ScoreList [i + 2];
					aux [i + 3] = gd.ScoreList [i + 3];
					aux [i + 4] = gd.ScoreList [i + 4];
					gd.ScoreList [i] = puntajetotal;
					gd.ScoreList [i + 1] = aux[i];
					gd.ScoreList [i + 2] = aux [i + 1];
					gd.ScoreList [i + 3] = aux [i + 2];
					gd.ScoreList [i + 4] = aux [i + 3];
					active = false;

				}
			}

		if (puntajetotal > 100)
		{
			gd.Coins += 500;
		}
		SaveManager.SaveGame (gd);

		}
}
