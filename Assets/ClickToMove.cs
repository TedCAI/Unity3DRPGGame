using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {
	private Vector3 position;
	public CharacterController controller;
	public float speed;
	//int con = 0;.
	public AnimationClip run;
	public AnimationClip idle;

	public static bool attack = false;
	public static bool die = false;
	public static bool isRunning =false;

	public static Vector3 cursorPosition;

	public static bool wDown = false;
	public static bool sDown = false;
	public static bool aDown = false;
	public static bool dDown = false;

	public bool clickButton;

	public static int numberOfKeys = 0;
	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (die);
		locateCursor ();
		controller = GetComponent<CharacterController> ();

		//if (!isGrounded) {
			if(!controller.isGrounded)
				controller.SimpleMove(transform.up*-10f);
			//else
				//isGrounded = true;
		//}

		if (!attack && !die) {
			if (Input.GetMouseButton (0) && !clickButton) {
				locatePosition ();
				isRunning = true;				//con = 1;
			}
			if(isRunning)		//if (con == 1) {
				moveToPosition ();

			if(Input.GetKeyDown(KeyCode.W) && !wDown && numberOfKeys <= 2 && !sDown){
				wDown = true;
				numberOfKeys+=1;
				if(isRunning){
					position = transform.position;
					isRunning = false;
				}
						//moveForward(KeyCode.W);
			}if(Input.GetKeyDown(KeyCode.S) && !sDown && numberOfKeys <= 2 && !wDown){
				sDown = true;
				numberOfKeys += 1;
				if(isRunning){
					position = transform.position;
					isRunning = false;
				}
				//moveForward(KeyCode.S);
			}if(Input.GetKeyDown(KeyCode.A) && !aDown && numberOfKeys <= 2 && !dDown){
				aDown = true;
				numberOfKeys+=1;
				if(isRunning){
					position = transform.position;
					isRunning = false;
				}
							//moveForward(KeyCode.A);
			}if(Input.GetKeyDown(KeyCode.D) && !dDown && numberOfKeys <= 2 && !aDown){
				dDown = true;
				numberOfKeys+=1;
				if(isRunning){
					position = transform.position;
					isRunning = false;
				}
							//moveForward(KeyCode.D);
			}

			if(!Input.GetKey(KeyCode.W) && wDown && numberOfKeys <= 2 && numberOfKeys > 0){
				wDown = false;
				numberOfKeys -= 1;
				if(isRunning){
					position = transform.position;
					isRunning = false;
				}
				//moveForward(KeyCode.W);
			}if(!Input.GetKey(KeyCode.S) && sDown && numberOfKeys <= 2 && numberOfKeys > 0){
				sDown = false;
				numberOfKeys -= 1;
				if(isRunning){
					position = transform.position;
					isRunning = false;
				}
				//moveForward(KeyCode.S);
			}if(!Input.GetKey(KeyCode.A) && aDown && numberOfKeys <= 2 && numberOfKeys > 0){
				aDown = false;
				numberOfKeys -= 1;
				if(isRunning){
					position = transform.position;
					isRunning = false;
				}
				//moveForward(KeyCode.A);
			}if(!Input.GetKey(KeyCode.D) && dDown && numberOfKeys <= 2 && numberOfKeys > 0){
				dDown = false;
				numberOfKeys -= 1;
				if(isRunning){
					position = transform.position;
					isRunning = false;
				}
				//moveForward(KeyCode.D);
			}

			moveForward();

		}

	}

	void locatePosition(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if(Physics.Raycast(ray, out hit, 1000)){
			if(hit.collider.tag!="Player" && hit.collider.tag!="Enemy"){
				position = hit.point;
			}
			//Debug.Log(position);
		}
	}

	void locateCursor(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		if(Physics.Raycast(ray, out hit, 1000)){
			if(hit.collider.tag!="Player" && hit.collider.tag!="Enemy"){
				cursorPosition = hit.point;
			}
			//Debug.Log(position);
		}
	}

	void moveToPosition()
	{
		if (Vector3.Distance (transform.position, position) > 1) {
			Quaternion newRotation = Quaternion.LookRotation (position - transform.position);

			newRotation.x = 0f;
			newRotation.z = 0f;

			transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * 10);
			controller.SimpleMove (transform.forward * speed);
						//Debug.Log (transform.position);
			isRunning = true;
			GetComponent<Animation>().CrossFade(run.name);

		} else {
			//Debug.Log("Here");
			isRunning = false;
			GetComponent<Animation>().CrossFade(idle.name);		
		}

	}

	void moveForward(){
				//Quaternion newRotation = Quaternion.Euler (new Vector3 (0f, 0f, 0f));
		/*
		if (key == KeyCode.W) {
			transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, 0f));
			controller.SimpleMove (transform.forward * 10f);
		}else if (key == KeyCode.S) {
			transform.rotation = Quaternion.Euler (new Vector3 (0f, 180f, 0f));
			controller.SimpleMove (transform.forward * 10f);
		}else if (key == KeyCode.A) {
			transform.rotation = Quaternion.Euler (new Vector3 (0f, 270f, 0f));
			controller.SimpleMove (transform.forward * 10f);
		}else if (key == KeyCode.D) {
			transform.rotation = Quaternion.Euler (new Vector3 (0f, 90f, 0f));
			controller.SimpleMove (transform.forward * 10f);
		}
		*/
		if (numberOfKeys > 0) {
						//Debug.Log (transform.position);
			Vector3 newRotation = new Vector3(0f,0f,0f);
			if(sDown)
				newRotation.y += 180f;
			if(dDown)
				newRotation.y += 90f;
			if(aDown){
				newRotation.y = -90f;
				if(wDown)
					newRotation.y = -90f;
				if(sDown)
					newRotation.y = -270f;
			}

			//Debug.Log(newRotation);
			Debug.Log(numberOfKeys);
			newRotation.y = newRotation.y / (float)numberOfKeys;
			transform.rotation = Quaternion.Euler (newRotation);
			controller.SimpleMove (transform.forward * 10f);
			//controller.Move(transform.forward * 10f);
			GetComponent<Animation> ().CrossFade (run.name);
		}

		if (numberOfKeys == 0 && !isRunning)
			GetComponent<Animation> ().CrossFade (idle.name);
	}

}
