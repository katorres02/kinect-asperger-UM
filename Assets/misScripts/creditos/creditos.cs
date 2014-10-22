using UnityEngine;
using System.Collections;

public class creditos : MonoBehaviour {
	public GUITexture menufondo;
	public Rect windowRect;
	// Use this for initialization
	void Start () {
		menufondo.pixelInset = new Rect(Screen.width/-2f,Screen.height/-2f, Screen.width, Screen.height);
		windowRect = new Rect(Screen.width*0.35f, 100, Screen.width*0.3f, 100);
	}
	
	void OnGUI()
	{

		GUI.color = Color.cyan;

		if (GUI.Button (new Rect (10, 10, 100, 20), "Menu"))
		{
			DestroyImmediate(Camera.main.gameObject);
			Application.LoadLevel ("menu");
		}

		windowRect = GUI.Window(0, windowRect, DoMyWindow, "CREDITOS");
	}
	void DoMyWindow(int windowID) {
		GUI.color = Color.cyan;
		GUI.Label(new Rect(10, 20, 300, 20), "Carlos Betancourt Correa        Asesor");
		GUI.Label(new Rect(10, 40, 300, 20), "Juan Bernardo Zuluaga           Asesor");
		GUI.Label(new Rect(10, 60, 300, 20), "Carlos Andres torres cruz       Desarrollador");
		GUI.DragWindow();
	}
}
