using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coordinate : MonoBehaviour {

	public Transform player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 coordinate = player.position;
		gameObject.GetComponent<Text> ().text = "(" + coordinate.x.ToString("F1") + "," + coordinate.z.ToString("F1") + ")";
	}
}
