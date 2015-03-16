using UnityEngine;
using System.Collections;

public class FireWall : MonoBehaviour {
	public int damage;
	public int effectTime;
	public bool isInside;
	public Collider mob;
	public CharacterController player;
	public Collider selfCollider;
	//public SpecialAttack spAttk;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<CharacterController> ();
		Physics.IgnoreCollision (selfCollider, player);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		//Debug.Log ("start");

		if (other.tag == "Enemy" && !other.GetComponent<Mob>().inFireWall) {
			other.GetComponent<Mob>().getHitDOT (damage, effectTime);
			//other.GetComponent<Mob>().GetComponent<OnFire>().gameObject.SetActive(true);
			//Physics.IgnoreCollision (selfCollider, other, false);
			//mob = other;
			//isInside=true;
			other.GetComponent<Mob>().inFireWall = true;
		}
	}

	void OnTriggerStay(Collider other){
		//Debug.Log ("stay");

		if (other.tag == "Enemy" && other.GetComponent<Mob>().inFireWall) {
			Debug.Log ("inside");
			//other.GetComponent<Mob>().getHitDOT (damage, effectTime);
			other.GetComponent<Mob> ().effectTime = effectTime;
			//isInside=true;
		}
	}

	void OnTriggerExit(Collider other){
		//Debug.Log (other);
		if (other.tag == "Enemy") {
			//isInside=false;
			other.GetComponent<Mob>().inFireWall = false;
		}
	}
}
