using UnityEngine;
using System.Collections;

public class SpamEnemy : MonoBehaviour {

	public Vector3 playerLocation;
	// Use this for initialization
	void Start () {
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
		Vector3 randomCoordinate = new Vector3();
		randomCoordinate.x = Random.Range (-10f, 10f) + playerLocation.x;
		randomCoordinate.z = Random.Range (-10f, 10f) + playerLocation.z;
		randomCoordinate.y = 10f;
		Instantiate (Resources.Load ("Enemy1"), randomCoordinate, Quaternion.identity);
	}
}
