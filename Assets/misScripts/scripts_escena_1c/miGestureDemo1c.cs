using UnityEngine;
using System.Collections;

public class miGestureDemo1c : MonoBehaviour 
{

	
	private KinectManager manager;
	private GameObject handCursor;
	

	private GameObject selectedObject;
	
	private GameObject infoGUI;
	private GameObject objSleccionadoText;
	
	private string detectedGesture;
	
	private string ObjetoSeleccionado 	= "Esperando";


	public Texture2D[] imagenesX;
	public GameObject imagenes;
	
	void Awake() 
	{
		// get needed objects´ references
		manager = Camera.main.GetComponent<KinectManager>();
		handCursor = GameObject.Find("HandCursor");
		infoGUI = GameObject.Find("HandGuiText");
		objSleccionadoText = GameObject.Find("objetoSeleccionado");

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
			
			// bloque de seleccion de dibujos
			if(manager.IsGestureComplete(userId, KinectWrapper.Gestures.Click, true))
			{
				screenNormalPos= manager.GetGestureScreenPos(userId, KinectWrapper.Gestures.Click);
				//Debug.Log(screenNormalPos );
				
				if(screenNormalPos.x > 0.0f && screenNormalPos.x < 0.15f)
				{
					if(screenNormalPos.y > 0.7f && screenNormalPos.y < 1f)
					{	
						// Planta
						imagenes.transform.GetChild(5).gameObject.guiTexture.texture = imagenesX[4];
						ObjetoSeleccionado = "Planta";

					}
				}
				if(screenNormalPos.x > 0.45f && screenNormalPos.x < 0.6)
				{
					if(screenNormalPos.y > 0.7f && screenNormalPos.y < 1f)
					{
						// CASCANUECES
						imagenes.transform.GetChild(0).gameObject.guiTexture.texture = imagenesX[0];
						ObjetoSeleccionado = "Cascanueces";
					}
				}
				if(screenNormalPos.x > 0.75f && screenNormalPos.x < 1)
				{
					if(screenNormalPos.y > 0.7f && screenNormalPos.y < 1f)
					{
						//Puntilla
						imagenes.transform.GetChild(6).gameObject.guiTexture.texture = imagenesX[5];
						ObjetoSeleccionado = "Puntilla";
					}
				}
				if(screenNormalPos.x > 0.15f && screenNormalPos.x < 0.3f)
				{
					if(screenNormalPos.y > 0.45f && screenNormalPos.y < 6f)
					{
						// Radio
						imagenes.transform.GetChild(7).gameObject.guiTexture.texture = imagenesX[6];
						ObjetoSeleccionado = "Radio";
					}
				}
				if(screenNormalPos.x > 0.6f && screenNormalPos.x < 0.75f)
				{
					if(screenNormalPos.y > 0.45f && screenNormalPos.y < 6f)
					{
						//Matera
						imagenes.transform.GetChild(3).gameObject.guiTexture.texture = imagenesX[2];
						ObjetoSeleccionado = "Matera";
					}
				}			 	
				if(screenNormalPos.x > 0.0f && screenNormalPos.x < 0.3f)
				{
					if(screenNormalPos.y > 0.1f && screenNormalPos.y < 0.3f)
					{
						// Martillo
						imagenes.transform.GetChild(2).gameObject.guiTexture.texture = imagenesX[1];
						ObjetoSeleccionado = "Martillo";
					}
				}
				if(screenNormalPos.x > 0.45f && screenNormalPos.x < 0.6f)
				{
					if(screenNormalPos.y > 0.1f && screenNormalPos.y < 0.3f)
					{
						// Nuez
						imagenes.transform.GetChild(4).gameObject.guiTexture.texture = imagenesX[3];
						ObjetoSeleccionado = "Nuez";
					}
				}
				
			}

			
		} 
	} 

	
	void OnGUI()
	{
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
		
		objSleccionadoText.guiText.text = ObjetoSeleccionado; 
	
	}
	
}
