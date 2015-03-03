using UnityEngine;
using System.Collections;

public class Strike : MonoBehaviour {

	public int damage;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy") {
			other.GetComponent<Mob>().getHit (damage);
		}
	}
}
