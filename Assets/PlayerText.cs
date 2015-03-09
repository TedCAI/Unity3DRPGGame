﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerText : MonoBehaviour {

	public RectTransform transformR;
	public float scale = 0.0889f;
	// Use this for initialization
	public int originalWidth;
	public int originalHeight;
	void Start () {
		//Debug.Log (GetComponent<RectTransform> ());
		//transformR = (RectTransform)GetComponent<Transform> ();
		originalHeight = 326;
		originalWidth = 464;
		//Debug.Log (originalWidth);
		//Debug.Log (originalHeight);
	}
	
	// Update is called once per frame
	void Update () {
		//transformR = (RectTransform)GetComponent<Transform> ();
		Vector2 position = transformR.anchoredPosition;
		Vector3 scaleRect = new Vector3 (1f,1f,1f);
		scaleRect.x =  Screen.width / (float)originalWidth;
		scaleRect.y = Screen.height / (float)originalHeight;
		gameObject.GetComponent<Text>().fontSize = (int)(14 * scaleRect.y);
		Debug.Log (scaleRect);
		//transformR.localScale = scaleRect;
		//transformR.rect.width = Screen.width * scale;
		//transform.position.x = (Screen.width - transform.rect.width) / 2;
		position.y = (Screen.height - transformR.rect.height) * 0.225f;
		//Debug.Log (position);
		transformR.anchoredPosition = position;
		//Debug.Log (transformR.anchoredPosition);
	}
	/*
	void OnGUI(){
		RectTransform transformR = (RectTransform)GetComponent<Transform> ();
		Vector3 position = transformR.anchoredPosition;
		//Debug.Log (position);
		//transform.position.x = (Screen.width - transform.rect.width) / 2;
		position.y = (Screen.height - transformR.rect.height) / 2;
		Debug.Log (position);
		GetComponent<RectTransform> ().anchoredPosition.Set (position.x, position.y);
		Debug.Log (GetComponent<RectTransform> ().anchoredPosition);
	}
	*/
}
