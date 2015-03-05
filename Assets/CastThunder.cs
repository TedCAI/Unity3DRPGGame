using UnityEngine;
using System.Collections;

public class CastThunder : MonoBehaviour {

	// Use this for initialization
	public Vector3 coordinate;
	public float angle;
	public float time;
	public static float damage;

	void Start () {
		time = Time.time;
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
		//damage = (Time.time - time) * 250f;
		InvokeRepeating ("multipleCast", 1f, 0.3f);
	}

	public float thunderDamage(){
		damage = (Time.time - time) * 25f;
		return damage;
	}

	void multipleCast(){
		Vector3 left, right, front, back, cLeft, cRight, cFront, cBack;
		left = right = front = back = cLeft = cRight = cFront = cBack = coordinate;
		//Debug.Log (left);
		if (angle <= 90f) {
			float rot = (float)(Mathf.PI * 2 * angle / 360);
			float rotCos = 3.5f * Mathf.Cos (rot);
			float rotSin = 3.5f * Mathf.Sin (rot);
			float counterRotCos = 5f * Mathf.Cos (rot);
			float counterRotSin = 5f * Mathf.Sin (rot);
			left.x += -rotCos;
			left.z += -rotSin;
			right.x += rotCos;
			right.z += rotSin;
			front.x += -rotSin;
			front.z += rotCos;
			back.x += rotSin;
			back.z += -rotCos;
			cLeft.z += -counterRotCos;
			cLeft.x += -counterRotSin;
			cRight.z += counterRotCos;
			cRight.x += counterRotSin;
			cFront.z += -counterRotSin;
			cFront.x += counterRotCos;
			cBack.z += counterRotSin;
			cBack.x += -counterRotCos;

			cast (left);
			cast (right);
			cast (front);
			cast (back);
			cast (cLeft);
			cast (cRight);
			cast (cFront);
			cast (cBack);

			//Debug.Log(left);
			angle += 15f;
		}
		else {
			angle = 0f;
			//Debug.Log(left);
			cast (left);
			CancelInvoke("multipleCast");
		}

		//float rot = (float)(Mathf.PI * 2 * 60 / 360);
		//Debug.Log(Mathf.Cos(rot));
	}

	void cast(Vector3 vector){
		Instantiate (Resources.Load ("Thunder"), vector, Quaternion.identity);
	}
}
