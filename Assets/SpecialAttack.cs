using UnityEngine;
using System.Collections;

public class SpecialAttack : MonoBehaviour {
	public double damagePercentage;
	public int stunTime;

	public KeyCode key;
	public Fighter player;

	//public bool inAction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (key)) {
			player.resetAttackFunction();
			player.specialAttack=true;

		}

		player.attackFunction(stunTime, damagePercentage, key);
	}
}
