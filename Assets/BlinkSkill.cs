using UnityEngine;
using System.Collections;

public class BlinkSkill : MonoBehaviour {

	public GameObject player;
	public KeyCode key;
	public bool isRunning;
	//public bool stopCasting;
	private IEnumerator coroutine;

	public float particalSize = 0.25f;
	// Use this for initialization
	void Start () {
		//player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		isRunning = ClickToMove.isRunning;
		if (Input.GetKeyDown (key))
			blink ();
		if(isRunning){
	//		stopCasting = true;
			StopCoroutine(coroutine);
			CancelInvoke ("scaleSize");
			particalSize = 0.25f;
			GameObject.Find ("BlinkEffect2").GetComponent<ParticleRenderer> ().maxParticleSize = particalSize;
			GameObject.Find ("BlinkEffect").GetComponent<MeshRenderer> ().enabled = false;
			GameObject.Find ("BlinkEffect2").GetComponent<ParticleRenderer> ().enabled = false;
		}else{
			//stopCasting = false;
		}
	}

	void blink(){
		//player = GameObject.Find ("Player");
		//activateEffect ();
		Vector3 playerLocation = GetComponent<Transform> ().position;
		Vector3 newLocation = playerLocation;
		Vector3 mouseLocation = ClickToMove.cursorPosition;
		if (Vector3.Distance (mouseLocation, GetComponent<Transform> ().position) > 10) {
			float xOffset = 10f * (mouseLocation.x - playerLocation.x) / Vector3.Distance (mouseLocation, GetComponent<Transform> ().position);
			float zOffset = 10f * (mouseLocation.z - playerLocation.z) / Vector3.Distance (mouseLocation, GetComponent<Transform> ().position);
			newLocation.x += xOffset;
			newLocation.z += zOffset;
		} else {
			newLocation = mouseLocation;
		}

		newLocation.y = Terrain.activeTerrain.SampleHeight (newLocation) + 0.1f;
		//activateEffect ();
		coroutine = Activation (1.5f, newLocation);
		InvokeRepeating ("scaleSize", 0f, 0.1f);
		GameObject.Find ("BlinkEffect2").GetComponent<ParticleRenderer> ().enabled = true;
		StartCoroutine (coroutine);

		//GetComponent<Transform> ().position = newLocation;
		//GetComponent<CharacterController> ().SimpleMove (transform.up * 10f * Time.deltaTime);
	}

	IEnumerator Activation(float waitTime, Vector3 newLocation){
		//yield return new WaitForSeconds (waitTime);
		GameObject.Find ("BlinkEffect").GetComponent<MeshRenderer> ().enabled = true;
		//InvokeRepeating ("scaleSize", 1f, 0.1f);
		yield return new WaitForSeconds (waitTime);
		//if(!stopCasting){
			GetComponent<Transform> ().position = newLocation;
			GetComponent<CharacterController> ().SimpleMove (transform.up * 10f * Time.deltaTime);
			CancelInvoke ("scaleSize");
		//}
	//	stopCasting = false;
		particalSize = 0.25f;
		GameObject.Find ("BlinkEffect2").GetComponent<ParticleRenderer> ().maxParticleSize = particalSize;
		GameObject.Find ("BlinkEffect").GetComponent<MeshRenderer> ().enabled = false;
		GameObject.Find ("BlinkEffect2").GetComponent<ParticleRenderer> ().enabled = false;
	}

	void scaleSize(){
		particalSize += 0.1f;
		Debug.Log (particalSize);
		GameObject.Find ("BlinkEffect2").GetComponent<ParticleRenderer> ().maxParticleSize = particalSize;
	}
}
