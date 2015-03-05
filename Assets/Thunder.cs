using UnityEngine;
using System.Collections;

public class Thunder : MonoBehaviour {

	// Use this for initialization
	public int damage;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.down*26f*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		//Debug.Log (other);
		
		if (other.tag == "Enemy") {
			other.GetComponent<Mob>().getHit (damage);
		}else if(other.tag == "Player"){
			other.GetComponent<Fighter>().getHit(damage);
		}
	}
	/*
	void OnTriggerStay(Collider other){
		//Debug.Log ("stay");
		
		if (other.tag == "Enemy") {
			Debug.Log ("inside");
			other.GetComponent<Mob>().getHit (damage);
			Physics.IgnoreCollision (GetComponent<MeshCollider>(), other);
			//isInside=true;
		}
	}
*/
}
