using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {
	
	public GUITexture menufondo;
	public Rect windowRect;

	// Use this for initialization
	void Start () {
		menufondo.pixelInset = new Rect(Screen.width/-2f,Screen.height/-2f, Screen.width, Screen.height);
		windowRect = new Rect(Screen.width*0.45f, 100, Screen.width*0.1f, 350);
	}

	void DoMyWindow(int windowID) {
		GUI.color = Color.cyan;

		if (GUI.Button (new Rect (10, 30, 100, 20), "Ejercicio 1"))
		{
			Application.LoadLevel("ejer_pag27");
		}
		if (GUI.Button (new Rect (10, 70, 100, 20), "Ejercicio 2"))
		{
			Application.LoadLevel("ejer1_pag21");
		}
		if (GUI.Button (new Rect (10, 110, 100, 20), "Ejercicio 3"))
		{
			Application.LoadLevel("Ejercicio_1a");
		}
		if (GUI.Button (new Rect (10, 150, 100, 20), "Ejercicio 4"))
		{
			Application.LoadLevel("ejer_4");
		}
		if (GUI.Button (new Rect (10, 190, 100, 20), "Ejercicio 5"))
		{
			Application.LoadLevel("ejer_5");
		}
		if (GUI.Button (new Rect (10, 230, 100, 20), "Ejercicio 6 x"))
		{
			Application.LoadLevel("Ejercicio_1c");
		}
		if (GUI.Button (new Rect (10, 270, 100, 20), "Ejercicio 7"))
		{
			Application.LoadLevel("ejer1_pag11");
		}
		if (GUI.Button (new Rect (10, 310, 100, 20), "CREDITOS"))
		{
			Application.LoadLevel("creditos");
		}
	}

	void OnGUI()
	{	
		GUI.color = Color.cyan;

		if (GUI.Button (new Rect (Screen.width*0.8f, 10, 100, 20), "Salir"))
		{
			Application.Quit();
		}

		windowRect = GUI.Window(0, windowRect, DoMyWindow, "EJERCICIOS");




	}
}
