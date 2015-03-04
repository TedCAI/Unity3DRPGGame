using UnityEngine;
using System.Collections;

public class FireWallSkill : MonoBehaviour {
	public float timeKill;
	// Use this for initialization
	void Start () {
		timeKill = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if ( Time.time > timeKill + 3 ) Destroy (gameObject);
	}
}
