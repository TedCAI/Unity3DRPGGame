using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpamEnemy : MonoBehaviour {

	public Vector3 playerLocation;
	private GUIText[] btnTexts;
	public Font font;
	public int i = 0;
	// Use this for initialization
	void Start () {
		btnTexts = new GUIText[10000];
		startSpamming ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void startSpamming(){
		InvokeRepeating("spamNewEnemy", 1f, 1f);
	}

	void spamNewEnemy(){
		playerLocation = GameObject.Find ("Player").GetComponent<Transform> ().position;
		Vector3 randomCoordinate = playerLocation;
		randomCoordinate.x += Random.Range (-10f, 10f) ;
		randomCoordinate.z += Random.Range (-10f, 10f) ;
		//randomCoordinate.y = playerLocation.y;
		randomCoordinate.y = Terrain.activeTerrain.SampleHeight (randomCoordinate) + 1f;
		GameObject newEnemy = (GameObject)Instantiate (Resources.Load ("Enemy1"), randomCoordinate, Quaternion.identity);
	/*

*/
		i++;

	}
	/*
	void OnGUI(){
		GUI.Box (new Rect (0f, 0f, 200, 30), "Test");
	}
	*/
}
