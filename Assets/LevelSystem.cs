using UnityEngine;
using System.Collections;

public class LevelSystem : MonoBehaviour {

	public int level;
	public int exp;

	public Fighter player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		LevelUp ();
	}

	void LevelUp(){
		if (exp >= (100 * level)) {
			exp -= (100 * level);
			level += 1;
			//exp = 0;
			levelEffect();
		}
	}

	void levelEffect(){
		player.maxHealth += 100;
		player.damage += 50;
		player.health = player.maxHealth;
	}
}
