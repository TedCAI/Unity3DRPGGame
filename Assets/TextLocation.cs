using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextLocation : MonoBehaviour {

	//public GameObject mainCamera;
	public GameObject enemy;
	//public GameObject text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Camera.main.WorldToScreenPoint(enemy.transform.position));
		GetComponent<Text>().text = "Enemy";
		GetComponent<RectTransform> ().position = Camera.main.WorldToScreenPoint (enemy.transform.position);
	}
}
