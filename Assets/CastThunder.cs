using UnityEngine;
using System.Collections;

public class CastThunder : MonoBehaviour {

	// Use this for initialization
	public Vector3 coordinate;
	public float angle;

	void Start () {
		//coordinate = GameObject.Find ("Player").GetComponent<Transform> ().position;
		angle = 0f;
		startCast ();
	}
	
	// Update is called once per frame
	void Update () {
		//coordinate = GameObject.Find ("Player").GetComponent<Transform> ().position;
	}

	void startCast(){
		InvokeRepeating("castThunder",1f,5f);
		//castThunder ();
	}

	void castThunder(){
		coordinate = GameObject.Find ("Player").GetComponent<Transform> ().position;
		//Instantiate (Resources.Load ("Thunder"), coordinate, Quaternion.identity);
		//multipleCast ();
		InvokeRepeating ("multipleCast", 1f, 0.3f);
	}

	void multipleCast(){
		Vector3 left, right, front, back;
		left = right = front = back = coordinate;
		//Debug.Log (left);
		if (angle <= 90f) {
			float rot = (float)(Mathf.PI * 2 * angle / 360);
			float rotCos = 3.5f * Mathf.Cos (rot);
			float rotSin = 3.5f * Mathf.Sin (rot);
			left.x += -rotCos;
			left.z += -rotSin;
			right.x += rotCos;
			right.z += rotSin;
			front.x += -rotSin;
			front.z += rotCos;
			back.x += rotSin;
			back.z += -rotCos;

			Instantiate (Resources.Load ("Thunder"), left, Quaternion.identity);
			Instantiate (Resources.Load ("Thunder"), right, Quaternion.identity);
			Instantiate (Resources.Load ("Thunder"), front, Quaternion.identity);
			Instantiate (Resources.Load ("Thunder"), back, Quaternion.identity);
			//Debug.Log(left);
			angle += 15f;
		}
		else {
			angle = 0f;
			//Debug.Log(left);
			Instantiate (Resources.Load ("Thunder"), left, Quaternion.identity);
			CancelInvoke("multipleCast");
		}

		//float rot = (float)(Mathf.PI * 2 * 60 / 360);
		//Debug.Log(Mathf.Cos(rot));
	}
}
