using UnityEngine;
using System.Collections;

public class DOTSkill : MonoBehaviour {
	public int damage;
	public int effectTime;

	//public SpecialAttack spAttk;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (spAttk.GetComponent<SpecialAttack> ().damagePercentage);
		//damage = (int)(spAttk.GetComponent<SpecialAttack> ().damagePercentage * 100);
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy") {
			other.GetComponent<Mob>().getHitDOT (damage, effectTime);
		}
	}
}
