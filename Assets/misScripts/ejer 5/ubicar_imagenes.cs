using UnityEngine;
using System.Collections;

public class ubicar_imagenes : MonoBehaviour {


	public GUITexture fondo;
	public GUITexture imagen1;
	public GUITexture imagen2;
	public GUITexture imagen3;
	public GUITexture imagen4;
	public GUITexture imagen5;
	public GUITexture imagen6;
	// Use this for initialization
	void Start () {
		fondo.pixelInset = new Rect(Screen.width/-2f,Screen.height/-2f, Screen.width, Screen.height);
		imagen1.pixelInset = new Rect(-Screen.width+Screen.width*0.6f,Screen.height-Screen.height*0.7f, 128f,58f);
		imagen2.pixelInset = new Rect(-Screen.width+Screen.width*0.9f,Screen.height-Screen.height*0.75f, 128f,58f);
		imagen3.pixelInset = new Rect(Screen.width-Screen.width*0.65f,Screen.height-Screen.height*0.7f, 128f,58f);
		imagen4.pixelInset = new Rect(-Screen.width+Screen.width*0.5f,-Screen.height+Screen.height*0.6f, 128f,58f);
		imagen5.pixelInset = new Rect(-Screen.width+Screen.width*0.92f,-Screen.height+Screen.height*0.6f, 128f,58f);
		imagen6.pixelInset = new Rect(Screen.width-Screen.width*0.6f,-Screen.height+Screen.height*0.8f, 128f,58f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
