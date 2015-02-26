using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {
	public float speed;
	public float range;

	//public bool inRange;
	public CharacterController controller;
	public Transform player;
	private Fighter opponent;
	public LevelSystem playerLevel;

	public AnimationClip attackClip;
	public AnimationClip run;
	public AnimationClip idle;
	public AnimationClip die;

	//public Fighter fighter;
	public double impactTime;

	private bool impacted;
	public int health;
	public int damage;
	public int maxHealth;

	public int stunTime;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		opponent = player.GetComponent<Fighter> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (health);
		if (!isDead ()) {
			if (stunTime <= 0) {
				if (!inRange ()) {
					chase ();
				} else {
					//animation.CrossFade (idle.name);
					animation.Play (attackClip.name);
					attack ();

					if (animation [attackClip.name].time >= animation [attackClip.name].length * 0.9) {
						impacted = false;
					}
				}
			} else{

			}
		}else {
			//animation.Play (die.name);
			dieMethod();
		}
	}

	void attack(){
		if (animation [attackClip.name].time > animation [attackClip.name].length * impactTime && !impacted && (animation[attackClip.name].time < animation[attackClip.name].length * 0.9)) {
						opponent.getHit(damage);
						impacted=true;
				}
	}

	bool inRange(){
		if (Vector3.Distance (transform.position, player.position) < range) {
						return true;
				} else {
						return false;
				}
	}

	public void getHit(int damage){
		health -= damage;
		if (health < 0) {
						health = 0;
				}
	}

	void dieMethod(){
				animation.Play (die.name);

				if (animation [die.name].time > animation [die.name].length * 0.9) {
						playerLevel.exp += 200;
						Destroy (gameObject);
				}
		}

	bool isDead(){
		if (health <= 0) {
			return true;
		} else {
			return false;
		}
	}

	void stunCountDown(){
		stunTime -= 1;
		if (stunTime <= 0) {
			CancelInvoke("stunCountDown");
		}
	}

	void chase()
	{
		transform.LookAt (player.position);
		controller.SimpleMove (transform.forward * speed);
		animation.CrossFade (run.name);
	}

	void OnMouseOver(){
		//Debug.Log (gameObject.transform.position.x);
		//fighter = new Fighter ();
		//fighter = player.GetComponent<Fighter>();

		player.GetComponent<Fighter>().opponent = gameObject;
	}

	public void getStun(int seconds){
		CancelInvoke ("stunCountDown");
		stunTime = seconds;
		InvokeRepeating ("stunCountDown", 0f, 1f);
	}
}
