using UnityEngine;
using System.Collections;

public class Fighter : MonoBehaviour {
	public GameObject opponent;
	// Use this for initialization
	public AnimationClip attack;
	public AnimationClip die;

	public int damage;
	public int health;

	public double impactTime;

	public bool impacted;
	public double range;

	private bool started;
	private bool ended;

	public float escapeTime;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(health);
		if (!isDead ()) {
						if (Input.GetKey (KeyCode.Space) && inRange ()) {
								animation.Play (attack.name);
								ClickToMove.attack = true;

								if (opponent != null) {
										transform.LookAt (opponent.transform.position);
										//opponent.GetComponent<Mob>().getHit(damage);
								}
						}

						if (animation [attack.name].time >= animation [attack.name].length * 0.9) {
								ClickToMove.attack = false;
								impacted = false; 
						}
						impact ();
				} else {
					//if(animation[die.name].time < animation[die.name].length * 0.9){
						
						dieMethod ();
					//}
				}
	}

	public void getHit(int damage){
		health -= damage;
		if (health < 0) {
			health = 0;
		}
	}

	bool isDead(){
		if (health <= 0) {
			return true;
		} else {
			return false;
		}
	}

	void dieMethod(){

		if (!started && !ended) {
						animation.Play (die.name);
						started = true;
				}
		
		if (animation.IsPlaying(die.name) && started) {
			//Destroy (gameObject);
			if(!ClickToMove.die){
				Debug.Log("Died");
				ClickToMove.die = true;
				ended = true;
			}
			//ClickToMove.die = true;

		}
	}

	void impact()
	{
		if (opponent != null && animation.IsPlaying (attack.name) && !impacted) {
			if ((animation [attack.name].time > animation [attack.name].length * impactTime) && (animation [attack.name].time < animation [attack.name].length * 0.9)) {
								opponent.GetComponent<Mob> ().getHit (damage);
								impacted = true;
						}
				}
	}

	bool inRange(){
		if (Vector3.Distance (opponent.transform.position, transform.position) <= range) {
						return true;
				} else {
						return false;
				}

		//return (Vector3.Distance (opponent.transform.position, transform.position) <= range);
	}
}
