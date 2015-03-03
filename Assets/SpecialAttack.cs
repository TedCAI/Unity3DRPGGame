using UnityEngine;
using System.Collections;

public class SpecialAttack : MonoBehaviour {
	public double damagePercentage;
	public int stunTime;

	public KeyCode key;
	public Fighter player;
	public bool inAction;
	public GameObject particleEffect;
	public int projectile;

	public bool opponentBased;

	//public DOTSkill dotSkill;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (key) && !player.specialAttack) {
			player.resetAttackFunction();
			player.specialAttack=true;
			inAction=true;
		}

		//if(dotSkill != null){
		//	dotSkill.GetComponent<DOTSkill>().damage = (int)(damagePercentage*100);
		//}

		if (inAction) {
			if(player.attackFunction (stunTime, damagePercentage, key, particleEffect, projectile, opponentBased)){

			}else{
				inAction = false;
			}
		}
	}
}
