using UnityEngine;
using System.Collections;

public class OnFire : MonoBehaviour {

	//public bool isActive;
	//public int countDown;
	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		//onFire (isActive);
	}

	/*
	void onFire(bool isActive){
		Debug.Log (isActive);
		if (isActive) {
			gameObject.SetActive (true);

		}

		if (countDown <= 0) {
			isActive = false;
			gameObject.SetActive (false);
		}
	}
	*/
}
