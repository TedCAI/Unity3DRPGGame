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
	public float coldDownTime;
	private bool inCD;

	public bool opponentBased;

	//public DOTSkill dotSkill;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		attack ();
	}

	public void attack(){
		if (Input.GetKeyDown (key) && !player.specialAttack && !inCD) {
			player.resetAttackFunction ();
			player.specialAttack = true;
			inAction = true;
			inCD = true;
			IEnumerator cdTimer = SkillInCD(coldDownTime);
			StartCoroutine (cdTimer);
		}
		
				//if(dotSkill != null){
				//	dotSkill.GetComponent<DOTSkill>().damage = (int)(damagePercentage*100);
				//}
		
		if (inAction ) {
			if (player.attackFunction (stunTime, damagePercentage, key, particleEffect, projectile, opponentBased)) {

				//IEnumerator cdTimer = SkillInCD(coldDownTime);
				//StartCoroutine (cdTimer);
			} else {
				inAction = false;
			}
		}
	}

	IEnumerator SkillInCD(float cd){
		yield return new WaitForSeconds (cd);
		inCD = false;

	}
}
