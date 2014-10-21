using UnityEngine;
using System.Collections;

public class posicionarImagenes : MonoBehaviour {

	private GameObject Cascanueces;
	private GameObject Martillo;
	private GameObject Matera;
	private GameObject Nuez;
	private GameObject Planta;
	private GameObject Puntilla;
	private GameObject Radio;


	// Use this for initialization
	void Start () {

		Cascanueces = GameObject.Find("cascanueces");
		Martillo 	= GameObject.Find("martillo");
		Matera 		= GameObject.Find("matera");
		Nuez 		= GameObject.Find("nuez");
		Planta 		= GameObject.Find("planta");
		Puntilla 	= GameObject.Find("puntilla");
		Radio 		= GameObject.Find("radio");

		ubicarPlanta();
		ubicarCascanueces();
		ubicarPuntilla();
		ubicarRadio();
		ubicarMatera();
		ubicarMartillo();
		ubicarNuez();
	}


	public void ubicarCascanueces()
	{
		Cascanueces.guiTexture.pixelInset = new Rect(-64, (Screen.height/2f)-(Screen.height*0.2f), 128, 128);
		Cascanueces.transform.position = new Vector3(0.5f,0.5f,0.0f);
	}
	public void ubicarMartillo()
	{
		Martillo.guiTexture.pixelInset = new Rect(Screen.width/-2f, (Screen.height/-2f)+(Screen.height*0.1f), 128, 128);
		Martillo.transform.position = new Vector3(0.5f,0.5f,0.0f);
	}
	public void ubicarMatera()
	{
		Matera.guiTexture.pixelInset = new Rect((Screen.width/-2f)+(Screen.width*0.6f), 0 , 128, 128);
		Matera.transform.position = new Vector3(0.5f,0.5f,0.0f);
	}
	public void ubicarNuez()
	{
		Nuez.guiTexture.pixelInset = new Rect(-64, (Screen.height/-2f)+(Screen.height*0.1f), 128, 128);
		Nuez.transform.position = new Vector3(0.5f,0.5f,0.0f);
	}
	public void ubicarPlanta()
	{
		Planta.guiTexture.pixelInset = new Rect(Screen.width/-2f, (Screen.height/2f)-(Screen.height*0.2f), 128, 128);
		Planta.transform.position = new Vector3(0.5f,0.5f,0.0f);
	}	
	public void ubicarPuntilla()
	{
		Puntilla.guiTexture.pixelInset = new Rect(Screen.width/2f - 128, (Screen.height/2f)-(Screen.height*0.2f), 128, 128);
		Puntilla.transform.position = new Vector3(0.5f,0.5f,0.0f);
	}
	public void ubicarRadio()
	{
		Radio.guiTexture.pixelInset = new Rect((Screen.width/-2f)+(Screen.width*0.2f), 0, 128, 128);
		Radio.transform.position = new Vector3(0.5f,0.5f,0.0f);
	}

	public GameObject getPlanta()
	{
		return Planta;
	}
	public GameObject getCascanueces()
	{
		return Cascanueces;
	}
	public GameObject getPuntilla()
	{
		return Puntilla;
	}
	public GameObject getRadio()
	{
		return Radio;
	}
	public GameObject getMatera()
	{
		return Matera;
	}
	public GameObject getMartillo()
	{
		return Martillo;
	}
	public GameObject getNuez()
	{
		return Nuez;
	}

	public void seguirCursor(string nombre ,GameObject hand)
	{
		switch(nombre)
		{
		case "Planta":
			Planta.transform.position = hand.transform.position;
				//Vector3.Lerp(hand.transform.position, screenNormalPos, 3 * Time.deltaTime);
			break;
		case "Cascanueces":
			Cascanueces.transform.position = hand.transform.position;
			break;
		case "Puntilla":
			Puntilla.transform.position = hand.transform.position;
			break;
		case "Radio":
			Radio.transform.position = hand.transform.position;
			break;
		case "Matera":
			Matera.transform.position = hand.transform.position;
			break;
		case "Martillo":
			Martillo.transform.position = hand.transform.position;
			break;
		case "Nuez":
			Nuez.transform.position = hand.transform.position;
			break;
		}
	}

	public void reubicarImagen(string nombre)
	{
		switch(nombre)
		{
		case "Planta":
			ubicarPlanta();
			break;
		case "Cascanueces":
			ubicarCascanueces();
			break;
		case "Puntilla":
			ubicarPuntilla();
			break;
		case "Radio":
			ubicarRadio();
			break;
		case "Matera":
			ubicarMatera();
			break;
		case "Martillo":
			ubicarMartillo();
			break;
		case "Nuez":
			ubicarNuez();
			break;
		}
	}

}
