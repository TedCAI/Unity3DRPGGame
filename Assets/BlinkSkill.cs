using UnityEngine;
using System.Collections;

public class BlinkSkill : MonoBehaviour {

	public GameObject player;
	public KeyCode key;
	// Use this for initialization
	void Start () {
		//player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (key))
			blink ();
	}

	void blink(){
		//player = GameObject.Find ("Player");
		Vector3 playerLocation = GetComponent<Transform> ().position;
		Vector3 newLocation = playerLocation;
		Vector3 mouseLocation = ClickToMove.cursorPosition;
		if (Vector3.Distance (mouseLocation, GetComponent<Transform> ().position) > 10) {
			float xOffset = 10f * (mouseLocation.x - playerLocation.x) / Vector3.Distance (mouseLocation, GetComponent<Transform> ().position);
			float zOffset = 10f * (mouseLocation.z - playerLocation.z) / Vector3.Distance (mouseLocation, GetComponent<Transform> ().position);
			newLocation.x += xOffset;
			newLocation.z += zOffset;
		} else {
			newLocation = mouseLocation;
		}

		GetComponent<Transform> ().position = newLocation;
		GetComponent<CharacterController> ().SimpleMove (transform.up * 10f * Time.deltaTime);
	}
}
