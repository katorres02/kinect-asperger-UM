using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {
	

	// Use this for initialization
	void Start () {

	}

	void Update()
	{
		//Debug.Log ("width : "+Screen.width+"   Heigth : "+Screen.height);
	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (130, 10, 100, 20), "Salir"))
		{
			Application.Quit();
		}
		if (GUI.Button (new Rect (10, 10, 100, 20), "Ejercicio 1"))
		{
			Application.LoadLevel("ejer_pag27");
		}
		if (GUI.Button (new Rect (10, 50, 100, 20), "Ejercicio 2"))
		{
			Application.LoadLevel("ejer1_pag21");
		}
		if (GUI.Button (new Rect (10, 90, 100, 20), "Ejercicio 3"))
		{
			Application.LoadLevel("Ejercicio_1a");
		}
		if (GUI.Button (new Rect (10, 130, 100, 20), "Ejercicio 4"))
		{
			Application.LoadLevel("ejer_4");
		}



	}
}
