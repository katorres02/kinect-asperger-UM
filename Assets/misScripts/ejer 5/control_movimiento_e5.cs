using UnityEngine;
using System.Collections;

public class control_movimiento_e5 : MonoBehaviour {
	
	private KinectManager manager;
	private GameObject handCursor;
	
	private GameObject selectedObject;
	
	private GameObject infoGUI;
	private GameObject objSleccionadoText;
	
	private string detectedGesture;
	
	private string ObjetoSeleccionado 	= "Esperando";
	
	
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
				//ObjetoSeleccionado= "X = "+screenNormalPos.x+" Y = "+screenNormalPos.y;
				if(screenNormalPos.x > 0.05f && screenNormalPos.x < 0.2f)
				{
					if(screenNormalPos.y > 0.75f && screenNormalPos.y < 0.9f)
					{	
						ObjetoSeleccionado = "ESPALDAR";
						GameObject imagen1 = GameObject.Find ("imagen_1");
						imagen1.guiTexture.enabled = true;
						GameObject sonido = GameObject.Find ("sonido_seleccion");
						sonido.audio.Play();
					}
				}
				if(screenNormalPos.x > 0.35f && screenNormalPos.x < 0.55f)
				{
					if(screenNormalPos.y > 0.7f && screenNormalPos.y < 0.85f)
					{	
						ObjetoSeleccionado = "CORDON";
						GameObject imagen_2 = GameObject.Find ("imagen_2");
						imagen_2.guiTexture.enabled = true;
						GameObject sonido = GameObject.Find ("sonido_seleccion");
						sonido.audio.Play();
					}
				}
				if(screenNormalPos.x > 0.75f && screenNormalPos.x < 0.9f)
				{
					if(screenNormalPos.y > 0.7f && screenNormalPos.y < 0.85f)
					{	
						ObjetoSeleccionado = "COJIN";
						GameObject imagen_3 = GameObject.Find ("imagen_3");
						imagen_3.guiTexture.enabled = true;
						GameObject sonido = GameObject.Find ("sonido_seleccion");
						sonido.audio.Play();
					}
				}
				if(screenNormalPos.x > 0f && screenNormalPos.x < 0.2f)
				{
					if(screenNormalPos.y > 0f && screenNormalPos.y < 0.2f)
					{	
						ObjetoSeleccionado = "HOJA";
						GameObject imagen_4 = GameObject.Find ("imagen_4");
						imagen_4.guiTexture.enabled = true;
						GameObject sonido = GameObject.Find ("sonido_seleccion");
						sonido.audio.Play();
					}
				}
				if(screenNormalPos.x > 0.4f && screenNormalPos.x < 0.6f)
				{
					if(screenNormalPos.y > 0.1f && screenNormalPos.y < 0.3f)
					{	
						ObjetoSeleccionado = "BOTONES";
						GameObject imagen_5 = GameObject.Find ("imagen_5");
						imagen_5.guiTexture.enabled = true;
						GameObject sonido = GameObject.Find ("sonido_seleccion");
						sonido.audio.Play();
					}
				}
				if(screenNormalPos.x > 0.8f && screenNormalPos.x < 1f)
				{
					if(screenNormalPos.y > 0.2f && screenNormalPos.y < 0.4f)
					{	
						ObjetoSeleccionado = "CHIMENEA";
						GameObject imagen_6 = GameObject.Find ("imagen_6");
						imagen_6.guiTexture.enabled = true;
						GameObject sonido = GameObject.Find ("sonido_seleccion");
						sonido.audio.Play();
					}
				}
				
			}
			
			
		} 
	} 
	
	
	void OnGUI()
	{	
		if (GUI.Button (new Rect (10, 10, 100, 20), "Menu"))
		{
			DestroyImmediate(Camera.main.gameObject);
			Application.LoadLevel ("menu");
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
		if(objSleccionadoText!= null)
			objSleccionadoText.guiText.text = ObjetoSeleccionado; 
		
	}
	
}