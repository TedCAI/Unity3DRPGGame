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
						//}
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
			GetComponent<Animation>().CrossFade(run.name);

		} else {
			//Debug.Log("Here");
			GetComponent<Animation>().CrossFade(idle.name);		
		}

	}


}
