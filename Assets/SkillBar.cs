using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillBar : MonoBehaviour {
	//public RectTransform transformR;
	public float scale = 0.0889f;
	// Use this for initialization
	//public image
	public Vector3 originalPosition;
	public int originalWidth;
	public int originalHeight;
	public GameObject playerText;
	public Vector3 currentScale;
	// Use this for initialization
	void Start () {
		//originalWidth = GameObject.Find ("Text").GetComponent<PlayerText> ().originalWidth;
		//originalHeight = GameObject.Find ("Text").GetComponent<PlayerText> ().originalHeight;
	}
	
	// Update is called once per frame
	void Update () {
		originalWidth = GameObject.Find ("Text").GetComponent<PlayerText> ().originalWidth;
		originalHeight = GameObject.Find ("Text").GetComponent<PlayerText> ().originalHeight;
		float xScale = Screen.width / (float)originalWidth;
		float yScale = Screen.height / (float)originalHeight;
		//float xCurrent = GameObject.Find ("Text").GetComponent<RectTransform> ().position.x;
		Vector3 newPosition = originalPosition;
		newPosition.x = originalPosition.x * xScale;
		newPosition.y = originalPosition.y * yScale;
		currentScale = new Vector3 (yScale, yScale, 1f);
		GetComponent<RectTransform> ().localScale = currentScale;
		GetComponent<RectTransform> ().position = newPosition;
	}

}
