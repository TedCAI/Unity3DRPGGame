using UnityEngine;
using System.Collections;

public class ClickToMoveCamera : MonoBehaviour {

	private Vector3 position;
	private Vector3 startingPoint;
	public CharacterController controller;
	public float speed;
	
	//int con = 0;
	
	// Use this for initialization
	void Start () {
		position = transform.position;
		startingPoint = position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			locatePosition();
			//con = 1;
		}
		//if (con == 1) {
		moveToPosition ();
		//}
		
	}
	
	void locatePosition(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		if(Physics.Raycast(ray, out hit, 1000)){
			position = new Vector3(hit.point.x, startingPoint.y, hit.point.z);
			//Debug.Log(position);
		}
	}
	
	void moveToPosition()
	{
		if (Vector3.Distance (transform.position, position) > 1) {
			Quaternion newRotation = Quaternion.LookRotation (position - transform.position);
			
			newRotation.x = 0f;
			newRotation.z = 0f;
			newRotation.y = startingPoint.y;
			
			transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * 10);
			controller.SimpleMove (transform.forward * speed);
			//Debug.Log (transform.position);
		}
		
	}
}
