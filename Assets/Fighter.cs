using UnityEngine;
using System.Collections;

public class Fighter : MonoBehaviour {
	public GameObject opponent;
	// Use this for initialization
	public AnimationClip attack;
	public AnimationClip die;

	public int damage;
	public int health;
	public int maxHealth;

	public double impactTime;

	public bool impacted;
	public double impactLength;
	public double range;

	private bool started;
	private bool ended;
	public bool inAction;

	public float combatEscapeTime;
	public float countDown;

	public bool specialAttack;
	public bool casting;

	void Start () {
		health = maxHealth;
		impactLength = (GetComponent<Animation>() [attack.name].length * impactTime);
		InvokeRepeating ("repeat",0,1);

	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead()) {
			if (Input.GetKeyDown (KeyCode.Space) && !specialAttack) {
				inAction = true;
			}

			if(inAction){
				if(attackFunction (0, 1f, KeyCode.Space, null, 0, true)){
					
				}else{
					inAction = false;
				}
			}
		} else {
			dieMethod ();
		}
	}

	void stunMob(){

	}

	public bool attackFunction(int stunSeconds, double scaledDamage, KeyCode key, GameObject particleEffect, int projectile, bool opponentBased){
		if (opponentBased) {
			if (Input.GetKey (key) && inRange ()) {
				GetComponent<Animation>().Play (attack.name);
				ClickToMove.attack = true;
			
				if (opponent != null) {
					transform.LookAt (opponent.transform.position);
										//opponent.GetComponent<Mob>().getHit(damage);
				}
			}
		} else {
			if (Input.GetKey (key)) {
				GetComponent<Animation>().Play (attack.name);
				ClickToMove.attack = true;
				casting = false;
				transform.LookAt (ClickToMove.cursorPosition);

					//opponent.GetComponent<Mob>().getHit(damage);

			}
		}



		if (GetComponent<Animation>() [attack.name].time >= GetComponent<Animation>() [attack.name].length * 0.9) {
			ClickToMove.attack = false;
			impacted = false; 
			if(specialAttack){
				specialAttack = false;
			}
			return false;
		}
		impact (stunSeconds, scaledDamage, particleEffect, projectile, opponentBased);
		return true;
	}

	public void resetAttackFunction(){
		ClickToMove.attack = false;
		impacted = false;
		GetComponent<Animation>().Stop (attack.name);
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
						GetComponent<Animation>().Play (die.name);
						started = true;
				}
		
		if (GetComponent<Animation>().IsPlaying(die.name) && started) {
			//Destroy (gameObject);
			if(!ClickToMove.die){
				Debug.Log("Died");
				ClickToMove.die = true;
				ended = true;
			}
			//ClickToMove.die = true;

		}
	}

	void impact(int stunSeconds, double scaledDamage, GameObject particleEffect, int projectile, bool opponentBased)
	{
		if ((!opponentBased || opponent != null) && GetComponent<Animation>().IsPlaying (attack.name) && !impacted) {
			if ((GetComponent<Animation>() [attack.name].time > GetComponent<Animation>() [attack.name].length * impactTime) && (GetComponent<Animation>() [attack.name].time < GetComponent<Animation>() [attack.name].length * 0.9)) {
								countDown=combatEscapeTime;
								CancelInvoke ("combatEscapeCountDown");
								InvokeRepeating("combatEscapeCountDown",1,1);
								if(opponentBased){
									opponent.GetComponent<Mob> ().getHit ((int)(damage*scaledDamage));
									opponent.GetComponent<Mob>().getStun(stunSeconds);
								}
								Quaternion rot = transform.rotation;
								rot.x = 0f;
								rot.z = 0f;
								//rot.y = transform.rotation.y + 90f;
								if(projectile>0 && !casting){
									//project projectile
									if(projectile == 1){
										Instantiate(Resources.Load("FireBall"), new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), rot);
									}if(projectile == 2){
										Quaternion rot1 = transform.rotation;
										Quaternion rot2 = transform.rotation;
										rot1.x = 0f;
										rot1.z = 0f;
										rot2.x = 0f;
										rot2.z = 0f;
										//Debug.Log(rot1.y);
										rot1.y = rot1.y + 0.1f;		
										//Debug.Log(rot1.y);
										rot2.y = rot2.y - 0.1f;
										//Quaternion.RotateTowards(new Vector3(0f, 0f,0f));
										Instantiate(Resources.Load("FireBall"), new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), rot1);
										Instantiate(Resources.Load("AcidBall"), new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), rot2);
									}if(projectile == 3){
										int numOfBalls = 36;
										float degree = 0f;
										
										for(int i = 0; i < numOfBalls; i++){
											degree += 10f;
											Instantiate(Resources.Load("DOTFireBall"), new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.Euler(new Vector3(0f, degree,0f)));
													
										}
									}if(projectile == 4){
										Instantiate(Resources.Load("FireWall"), new Vector3(ClickToMove.cursorPosition.x, 0f, ClickToMove.cursorPosition.z), Quaternion.identity);
									}
									casting = true;
								}
								if(particleEffect != null && opponent != null && opponentBased){
									Instantiate(particleEffect, new Vector3(opponent.transform.position.x, opponent.transform.position.y + 1.75f, opponent.transform.position.z), Quaternion.identity);
									//particleEffect = null;
								}
								impacted = true;
						}
				}
	}

	void combatEscapeCountDown(){
				countDown -= 1;
				if (countDown == 0) {
						CancelInvoke ("combatEscapeCountDown");
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
