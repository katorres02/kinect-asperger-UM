using UnityEngine;
using System.Collections;

public class posicionar : MonoBehaviour {


	private GameObject tprincipal;
	private GameObject opcion1;
	private GameObject opcion2;
	private GameObject opcion3;
	// Use this for initialization
	void Start () {
		tprincipal = GameObject.Find ("Triangulo");
		opcion1 = GameObject.Find ("opcion1");
		opcion2 = GameObject.Find ("opcion2");
		opcion3 = GameObject.Find ("opcion3");


		ubicarTriangulo();
		ubicarOpciones ();
	}
	
	void ubicarTriangulo()
	{
		tprincipal.guiTexture.pixelInset = new Rect(Screen.width/-2f, Screen.height/-3f, 400, 400);
		tprincipal.transform.position = new Vector3(0.5f,0.5f,-1.0f);
	}

	void ubicarOpciones()
	{
		opcion1.guiTexture.pixelInset = new Rect(Screen.width/4f, (Screen.height/2f)-(Screen.height*0.3f), 128, 128);
		opcion1.transform.position = new Vector3 (0.5f, 0.5f, -0.1f);

		opcion2.guiTexture.pixelInset = new Rect(Screen.width/4f, (Screen.height/2f)-(Screen.height*0.6f), 128, 128);
		opcion2.transform.position = new Vector3 (0.5f, 0.5f, -0.1f);

		opcion3.guiTexture.pixelInset = new Rect(0, (Screen.height/2f)-(Screen.height*0.3f), 128, 128);
		opcion3.transform.position = new Vector3 (0.5f, 0.5f, -0.1f);
	}
}
