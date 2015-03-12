using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour {

	public int level;
	public int exp;

	public Fighter player;

	public string records;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		LevelUp ();
	}

	void LevelUp(){
		if (exp >= (100 * level)) {
			exp -= (100 * level);
			level += 1;
			//GameObject.Find("Records").GetComponent<Text>().text += "\nLevel up!";
			//exp = 0;
			levelEffect();
		}
	}

	void levelEffect(){
		if(level > 1)
			GameObject.Find("Records").GetComponent<Text>().text += "\nLevel up!";
		player.maxHealth += 100;
		player.damage += 50;
		player.health = player.maxHealth;
	}

	void OnGUI(){
		Vector3 screenCoordinate = Camera.main.WorldToScreenPoint (player.GetComponent<Transform>().position);
		GUIStyle myStyle = new GUIStyle ();
		//Debug.Log (screenCoordinate);
		myStyle.fontSize = 16;
		myStyle.normal.textColor = Color.white;
		myStyle.alignment = TextAnchor.MiddleLeft;
		Rect hpLocation = GameObject.Find ("Player HP").GetComponent<PlayerHP> ().framePosition;

		//float scale = GameObject.Find ("Text").GetComponent<PlayerText> ().scaleX;
		//GUI.Label (new Rect (screenCoordinate.x - 13f, Screen.height - screenCoordinate.y, 26f, 25f), level.ToString(), myStyle);
		//GUI.Label (new Rect (hpLocation.x - hpLocation.width/2, hpLocation.y - hpLocation.height/2, 26f, 25f), level.ToString(), myStyle);
		GUI.Label (new Rect (hpLocation.x - 20f, hpLocation.y - 10f, 26f, 25f), level.ToString(), myStyle);
		//GUI.Box (new Rect (Screen.width - 350f, Screen.height - 300f, 350f, 300f), records);
	}
}
