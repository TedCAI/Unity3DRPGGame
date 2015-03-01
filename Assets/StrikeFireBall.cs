﻿using UnityEngine;
using System.Collections;

public class StrikeFireBall : MonoBehaviour {

	public float speed;
	public int damage;

	// Use this for initialization
	void Start () {
		transform.Rotate(new Vector3(0f,270f,0f));
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right*speed*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		//Debug.Log ("test");
		if (other.tag == "Enemy") {
			other.GetComponent<Mob>().getHit (damage);
		}
	}
}