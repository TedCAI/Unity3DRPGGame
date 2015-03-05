using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {
	public float timeKill;
	private float time;
	// Use this for initialization
	void Start () {
		this.time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > this.time + timeKill) {
			Destroy(gameObject);
		}
	}
}
