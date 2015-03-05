using UnityEngine;
using System.Collections;

public class Strike : MonoBehaviour {

	public int damage;
	public GameObject particleEffect;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy") {
			other.GetComponent<Mob>().getHit (damage);
			if(particleEffect !=null){
				Instantiate(particleEffect, GetComponent<Transform>().position, Quaternion.identity);
			}
		}
	}
}
