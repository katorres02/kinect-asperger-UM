using UnityEngine;
using System.Collections;

public class miGestureDemo : MonoBehaviour 
{
	public GameObject[] selectableObjects;
	//public Material selectedObjectMaterial;
	//public float hitForce = 300f;
	
	private KinectManager manager;
	private GameObject handCursor;
	
	//private Material[] objectMaterials;
	private GameObject selectedObject;
	
	private GameObject infoGUI;
	private GameObject objSleccionadoText;
	private GameObject objSleccionadoText2;

	private string detectedGesture;

	private string ObjetoSeleccioado 	= "Esperando";
	private string ObjetoSeleccioado2 	= "Esperando";
	private bool arrastrar = false;

	private int ordenSeleccion =0; // si es 0 se le asiganara el objeto a la mano 1, si es 1 a la mano 2

	public GameObject imagenes;

	private posicionarImagenes posIm;
	
	void Awake() 
	{
		// get needed objects´ references
		manager 			= Camera.main.GetComponent<KinectManager>();
		posIm 				= Camera.main.GetComponent<posicionarImagenes>();

		handCursor 			= GameObject.Find("HandCursor");
		infoGUI 			= GameObject.Find("HandGuiText");
		objSleccionadoText 	= GameObject.Find("objetoSeleccionado");
		objSleccionadoText2 = GameObject.Find("objetoSeleccionado2");


	
	}
	
	
	void Update() 
	{
		if(manager != null && KinectManager.IsKinectInitialized() && manager.GetPlayer1ID() > 0)
		{
			uint userId = manager.GetPlayer1ID();
			Vector3 screenNormalPos = Vector3.zero;
			
			// cursor control
			if(manager.GetGestureProgress(userId, KinectWrapper.Gestures.RightHandCursor) >= 0.1f)
			{
				if(handCursor)
				{
					screenNormalPos = manager.GetGestureScreenPos(userId, KinectWrapper.Gestures.RightHandCursor);
					handCursor.transform.position = Vector3.Lerp(handCursor.transform.position, screenNormalPos, 3 * Time.deltaTime);
				}
			}
			else if(manager.GetGestureProgress(userId, KinectWrapper.Gestures.LeftHandCursor) >= 0.1f)
			{
				if(handCursor)
				{
					screenNormalPos = manager.GetGestureScreenPos(userId, KinectWrapper.Gestures.LeftHandCursor);
					handCursor.transform.position = Vector3.Lerp(handCursor.transform.position, screenNormalPos, 3 * Time.deltaTime);
				}
			}

			if(arrastrar)
			{
				posIm.seguirCursor(ObjetoSeleccioado,handCursor);
			}

			// bloque de seleccion de dibujos
			if(manager.IsGestureComplete(userId, KinectWrapper.Gestures.Click, true))
			{
				screenNormalPos= manager.GetGestureScreenPos(userId, KinectWrapper.Gestures.Click);
				//Debug.Log(screenNormalPos );

				if(screenNormalPos.x > 0.0f && screenNormalPos.x < 0.15f)
				{
					if(screenNormalPos.y > 0.7f && screenNormalPos.y < 1f)
					{	
						if(ordenSeleccion == 0)
						{
							ObjetoSeleccioado = "Planta";
							//Debug.Log(screenNormalPos + " Estoy en zona de planta");
							ordenSeleccion = 1;

							posIm.getPlanta().transform.guiTexture.pixelInset = 
								new Rect(handCursor.transform.guiTexture.pixelInset.x,
								         handCursor.transform.guiTexture.pixelInset.y, 128,128); 
							arrastrar = true;


						}
						else
						{
							ObjetoSeleccioado2 = "Planta";
							//Debug.Log(screenNormalPos + " Estoy en zona de planta");
							posIm.reubicarImagen(ObjetoSeleccioado);
							arrastrar = false;
							ordenSeleccion = 0;
						}
					}
				}
				if(screenNormalPos.x > 0.45f && screenNormalPos.x < 0.6)
				{
					if(screenNormalPos.y > 0.7f && screenNormalPos.y < 1f)
					{
						if(ordenSeleccion == 0)
						{
							ObjetoSeleccioado = "Cascanueces";
							//Debug.Log(screenNormalPos + " Estoy en zona de Cascanueces");
							ordenSeleccion = 1;
							posIm.getCascanueces().transform.guiTexture.pixelInset = 
								new Rect(handCursor.transform.guiTexture.pixelInset.x,
								         handCursor.transform.guiTexture.pixelInset.y, 128,128); 
							arrastrar = true;
						}
						else
						{
							ObjetoSeleccioado2 = "Cascanueces";
							//Debug.Log(screenNormalPos + " Estoy en zona de Cascanueces");
							posIm.reubicarImagen(ObjetoSeleccioado);
							arrastrar = false;
							ordenSeleccion = 0;
						}
					}
				}
				if(screenNormalPos.x > 0.75f && screenNormalPos.x < 1)
				{
					if(screenNormalPos.y > 0.7f && screenNormalPos.y < 1f)
					{
						if(ordenSeleccion == 0)
						{
							ObjetoSeleccioado = "Puntilla";
							//Debug.Log(screenNormalPos + " Estoy en zona de Puntilla");
							ordenSeleccion = 1;
							posIm.getPuntilla().transform.guiTexture.pixelInset = 
								new Rect(handCursor.transform.guiTexture.pixelInset.x,
								         handCursor.transform.guiTexture.pixelInset.y, 128,128); 
							arrastrar = true;
						}
						else
						{
							ObjetoSeleccioado2 = "Puntilla";
							//Debug.Log(screenNormalPos + " Estoy en zona de Puntilla");
							posIm.reubicarImagen(ObjetoSeleccioado);
							arrastrar = false;
							ordenSeleccion = 0;
						}
					}
				}
				if(screenNormalPos.x > 0.15f && screenNormalPos.x < 0.3f)
				{
					if(screenNormalPos.y > 0.45f && screenNormalPos.y < 6f)
					{
						if(ordenSeleccion == 0)
						{
							ObjetoSeleccioado = "Radio";
							//Debug.Log(screenNormalPos + " Estoy en zona de Radio");
							ordenSeleccion = 1;
							posIm.getRadio().transform.guiTexture.pixelInset = 
								new Rect(handCursor.transform.guiTexture.pixelInset.x,
								         handCursor.transform.guiTexture.pixelInset.y, 128,128); 
							arrastrar = true;
						}
						else
						{
							ObjetoSeleccioado2 = "Radio";
							//Debug.Log(screenNormalPos + " Estoy en zona de Radio");
							posIm.reubicarImagen(ObjetoSeleccioado);
							arrastrar = false;
							ordenSeleccion = 0;
						}
					}
				}
				if(screenNormalPos.x > 0.6f && screenNormalPos.x < 0.75f)
				{
					if(screenNormalPos.y > 0.45f && screenNormalPos.y < 6f)
					{
						if(ordenSeleccion == 0)
						{
							ObjetoSeleccioado = "Matera";
							//Debug.Log(screenNormalPos + " Estoy en zona de Matera");
							ordenSeleccion = 1;
							posIm.getMatera().transform.guiTexture.pixelInset = 
								new Rect(handCursor.transform.guiTexture.pixelInset.x,
								         handCursor.transform.guiTexture.pixelInset.y, 128,128); 
							arrastrar = true;
						}
						else
						{
							ObjetoSeleccioado2 = "Matera";
							//Debug.Log(screenNormalPos + " Estoy en zona de Matera");
							posIm.reubicarImagen(ObjetoSeleccioado);
							arrastrar = false;
							ordenSeleccion = 0;
						}
					}
				}			 	
				if(screenNormalPos.x > 0.0f && screenNormalPos.x < 0.3f)
				{
					if(screenNormalPos.y > 0.1f && screenNormalPos.y < 0.3f)
					{
						if(ordenSeleccion == 0)
						{
							ObjetoSeleccioado = "Martillo";
							//Debug.Log(screenNormalPos + " Estoy en zona de Martillo");
							ordenSeleccion = 1;
							posIm.getMartillo().transform.guiTexture.pixelInset = 
								new Rect(handCursor.transform.guiTexture.pixelInset.x,
								         handCursor.transform.guiTexture.pixelInset.y, 128,128); 
							arrastrar = true;
						}
						else
						{
							ObjetoSeleccioado2 = "Martillo";
							//Debug.Log(screenNormalPos + " Estoy en zona de Martillo");
							posIm.reubicarImagen(ObjetoSeleccioado);
							arrastrar = false;
							ordenSeleccion = 0;
						}
					}
				}
				if(screenNormalPos.x > 0.45f && screenNormalPos.x < 0.6f)
				{
					if(screenNormalPos.y > 0.1f && screenNormalPos.y < 0.3f)
					{
						if(ordenSeleccion == 0)
						{
							ObjetoSeleccioado = "Nuez";
							//Debug.Log(screenNormalPos + " Estoy en zona de Nuez");
							ordenSeleccion = 1;
							posIm.getNuez().transform.guiTexture.pixelInset = 
								new Rect(handCursor.transform.guiTexture.pixelInset.x,
								         handCursor.transform.guiTexture.pixelInset.y, 128,128); 
							arrastrar = true;
						}
						else
						{
							ObjetoSeleccioado2 = "Nuez";
							//Debug.Log(screenNormalPos + " Estoy en zona de Nuez");
							posIm.reubicarImagen(ObjetoSeleccioado);
							arrastrar = false;
							ordenSeleccion = 0;
						}
					}
				}
						
			}

			//Bloque de validacion de parejas

			switch (ObjetoSeleccioado)
			{
			case "Planta":
				if(ObjetoSeleccioado2 != "Esperando" )
				{
					if(ObjetoSeleccioado2 == "Matera")
					{
						Debug.Log("BIEN HECHO");
						imagenes.transform.GetChild(4).gameObject.SetActive(false); //planta
						imagenes.transform.GetChild(2).gameObject.SetActive(false); // matera

						ObjetoSeleccioado2 = "Planta y Matera";
						ObjetoSeleccioado  = "BIEN HECHO";
						GameObject sonido = GameObject.Find ("sonido_seleccion");
						sonido.audio.Play();
					}
					else{
						//ObjetoSeleccioado2 = "Esperando";
						//ObjetoSeleccioado  = "Esperando";
					}
				}
				break;
			case "Cascanueces":
				if(ObjetoSeleccioado2 != "Esperando" )
				{
					if(ObjetoSeleccioado2 == "Nuez")
					{
						Debug.Log("BIEN HECHO");
						imagenes.transform.GetChild(3).gameObject.SetActive(false); //puntilla
						imagenes.transform.GetChild(0).gameObject.SetActive(false); // matera
						
						ObjetoSeleccioado2 = "Cascanueces y Nuez";
						ObjetoSeleccioado  = "BIEN HECHO";
						GameObject sonido = GameObject.Find ("sonido_seleccion");
						sonido.audio.Play();
					}
					else{
						//ObjetoSeleccioado2 = "Esperando";
						//ObjetoSeleccioado  = "Esperando";
					}
				}
				break;
			case "Puntilla":
				if(ObjetoSeleccioado2 != "Esperando" )
				{
					if(ObjetoSeleccioado2 == "Martillo")
					{
						Debug.Log("BIEN HECHO");
						imagenes.transform.GetChild(5).gameObject.SetActive(false); //puntilla
						imagenes.transform.GetChild(1).gameObject.SetActive(false); // matera
						
						ObjetoSeleccioado2 = "Puntilla y Martillo";
						ObjetoSeleccioado  = "BIEN HECHO";
						GameObject sonido = GameObject.Find ("sonido_seleccion");
						sonido.audio.Play();
					}
					else{
						//ObjetoSeleccioado2 = "Esperando";
						//ObjetoSeleccioado  = "Esperando";
					}
				}
				break;
			case "Martillo":
				if(ObjetoSeleccioado2 != "Esperando" )
				{
					if(ObjetoSeleccioado2 == "Puntilla")
					{
						Debug.Log("BIEN HECHO");
						imagenes.transform.GetChild(5).gameObject.SetActive(false); //puntilla
						imagenes.transform.GetChild(1).gameObject.SetActive(false); // matera
						
						ObjetoSeleccioado2 = "Martillo y Puntilla";
						ObjetoSeleccioado  = "BIEN HECHO";
						GameObject sonido = GameObject.Find ("sonido_seleccion");
						sonido.audio.Play();
					}
					else{
						//ObjetoSeleccioado2 = "Esperando";
						//ObjetoSeleccioado  = "Esperando";
					}
				}
				break;
			case "Nuez":
				if(ObjetoSeleccioado2 != "Esperando" )
				{
					if(ObjetoSeleccioado2 == "Cascanueces")
					{
						Debug.Log("BIEN HECHO");
						imagenes.transform.GetChild(3).gameObject.SetActive(false); //puntilla
						imagenes.transform.GetChild(0).gameObject.SetActive(false); // matera
						
						ObjetoSeleccioado2 = "Nuez y Cascanueces";
						ObjetoSeleccioado  = "BIEN HECHO";
						GameObject sonido = GameObject.Find ("sonido_seleccion");
						sonido.audio.Play();

					}
					else{
						//ObjetoSeleccioado2 = "Esperando";
						//ObjetoSeleccioado  = "Esperando";
					}
				}
				break;
			case "Matera":
				if(ObjetoSeleccioado2 != "Esperando" )
				{
					if(ObjetoSeleccioado2 == "Planta")
					{
						Debug.Log("BIEN HECHO");
						imagenes.transform.GetChild(4).gameObject.SetActive(false); //planta
						imagenes.transform.GetChild(2).gameObject.SetActive(false); // matera
						
						ObjetoSeleccioado2 = "Matera y PLanta";
						ObjetoSeleccioado  = "BIEN HECHO";
						GameObject sonido = GameObject.Find ("sonido_seleccion");
						sonido.audio.Play();
					}
					else{
						//ObjetoSeleccioado2 = "Esperando";
						//ObjetoSeleccioado  = "Esperando";
					}
				}
				break;

			}

			
		} 
	} 

	

	
	void OnGUI()
	{
		if (GUI.Button (new Rect (10, 10, 100, 20), "Menu")) {
			DestroyImmediate(Camera.main.gameObject);
			Application.LoadLevel("menu");
		}

		if(infoGUI != null && manager != null && KinectManager.IsKinectInitialized())
		{
			string sInfo = string.Empty;
			
			uint userID = manager.GetPlayer1ID();
			if(userID != 0)
			{
				if(selectedObject != null && selectedObject.rigidbody != null && selectedObject.rigidbody.velocity != Vector3.zero)
					sInfo = detectedGesture + " detected.";
				else if(selectedObject != null)
					sInfo = "You selected " + selectedObject.name + ". Swipe to move it left or right.";
				else
					sInfo = "Hold the cursor over an object to select it.";
			}
			else
			{
				sInfo = "Waiting for Users...";
			}
			
			infoGUI.guiText.text = sInfo;
		}
		if (objSleccionadoText != null && objSleccionadoText2 != null) {
			objSleccionadoText.guiText.text = ObjetoSeleccioado; 
			objSleccionadoText2.guiText.text = ObjetoSeleccioado2;	
		}

	}
	
}
