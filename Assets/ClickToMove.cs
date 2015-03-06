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
	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (die);
		locateCursor ();
		if (!attack && !die) {
						if (Input.GetMouseButton (0)) {
								locatePosition ();
								//con = 1;
						}
						//if (con == 1) {
						moveToPosition ();

					if(Input.GetKey(KeyCode.W)){
						//Debug.Log("triggered");
						if(isRunning){
							position = transform.position;
							isRunning = false;
						}
						moveForward(KeyCode.W);
					}else if(Input.GetKey(KeyCode.S)){
							//Debug.Log("triggered");
							if(isRunning){
								position = transform.position;
								isRunning = false;
							}
							moveForward(KeyCode.S);
						}else if(Input.GetKey(KeyCode.A)){
							//Debug.Log("triggered");
							if(isRunning){
								position = transform.position;
								isRunning = false;
							}
							moveForward(KeyCode.A);
						}else if(Input.GetKey(KeyCode.D)){
							//Debug.Log("triggered");
							if(isRunning){
								position = transform.position;
								isRunning = false;
							}
							moveForward(KeyCode.D);
						}
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

	void moveForward(KeyCode key){
				//Quaternion newRotation = Quaternion.Euler (new Vector3 (0f, 0f, 0f));
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
		//Debug.Log (transform.position);
		GetComponent<Animation>().CrossFade(run.name);
	}

}
