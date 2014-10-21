using UnityEngine;
using System.Collections;

public class posicionar_4 : MonoBehaviour {

	public GUITexture imagen1;
	public GUITexture imagen2;

	public GUITexture dif1;
	public GUITexture dif2;
	public GUITexture dif3;
	public GUITexture dif4;
	public GUITexture dif5;
	public GUITexture dif6;

	// Use this for initialization
	void Start () {
		imagen1.guiTexture.pixelInset = new Rect(0, -Screen.height/2, 
		                                         -Screen.width/2, Screen.height);
		imagen2.guiTexture.pixelInset = new Rect(Screen.width/2, -Screen.height/2, 
		                                         -Screen.width/2, Screen.height);

		dif1.guiTexture.pixelInset = new Rect(Screen.width-Screen.width*0.85f, -20, 128f, 58f);

		dif2.guiTexture.pixelInset = new Rect(Screen.width-Screen.width*0.92f, -Screen.height+Screen.height*0.6f, 128f, 58f);

		dif3.guiTexture.pixelInset = new Rect(Screen.width-Screen.width*0.99f, Screen.height-Screen.height*0.75f, 128f, 58f); 

		dif4.guiTexture.pixelInset = new Rect(Screen.width-Screen.width*0.8f, Screen.height-Screen.height*0.8f, 128f, 58f); 
	
		dif5.guiTexture.pixelInset = new Rect(Screen.width-Screen.width*0.92f, Screen.height-Screen.height*0.9f, 128f, 58f); 
	
		dif6.guiTexture.pixelInset = new Rect(Screen.width-Screen.width*0.65f, Screen.height-Screen.height*0.9f, 128f, 58f); 
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("width : "+Screen.width+"   Heigth : "+Screen.height);

	}
}
