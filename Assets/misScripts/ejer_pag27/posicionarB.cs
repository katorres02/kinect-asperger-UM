using UnityEngine;
using System.Collections;

public class posicionarB : MonoBehaviour {

	private GameObject bosque;
	private GameObject opcion1;
	private GameObject opcion2;
	private GameObject opcion3;
	private GameObject opcion4;
	// Use this for initialization
	void Start () {
		bosque = GameObject.Find ("bosque");
		opcion1 = GameObject.Find ("oso");
		opcion2 = GameObject.Find ("pajaro");
		opcion3 = GameObject.Find ("lagarto");
		opcion4 = GameObject.Find ("perro");
		
		ubicarBosque();
		ubicarOpciones ();
	}
	
	void ubicarBosque()
	{
		bosque.guiTexture.pixelInset = new Rect(Screen.width/-2f, Screen.height/-2f, Screen.width, Screen.height);
		bosque.transform.position = new Vector3(0.5f,0.5f,-1f);
	}


	void ubicarOpciones()
	{
		opcion1.guiTexture.pixelInset = new Rect(Screen.width/-4f, (Screen.height/2f)-(Screen.height*0.6f), Screen.width/4f, Screen.height/4f);
		opcion1.transform.position = new Vector3 (0.5f, 0.5f, -0.1f);
		opcion1.guiTexture.enabled = false;
		
		opcion2.guiTexture.pixelInset = new Rect(Screen.width/-6f, (Screen.height/2f)-(Screen.height*0.25f), Screen.width/4f, Screen.height/4f);
		opcion2.transform.position = new Vector3 (0.5f, 0.5f, -0.1f);
		opcion2.guiTexture.enabled = false;

		opcion3.guiTexture.pixelInset = new Rect(0, (Screen.height/2f)-(Screen.height*0.95f), Screen.width/4f, Screen.height/4f);
		opcion3.transform.position = new Vector3 (0.5f, 0.5f, -0.1f);
		opcion3.guiTexture.enabled = false;

		opcion4.guiTexture.pixelInset = new Rect(Screen.width/3f, (Screen.height/2f)-(Screen.height*0.6f), Screen.width/4f, Screen.height/4f);
		opcion4.transform.position = new Vector3 (0.5f, 0.5f, -0.1f);
		opcion4.guiTexture.enabled = false;
	}
}
