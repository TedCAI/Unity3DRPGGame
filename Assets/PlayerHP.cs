using UnityEngine;
using System.Collections;

public class PlayerHP : MonoBehaviour {
	
	public Texture2D frame;
	public Rect framePosition;
	
	public float horizontalDistance;
	public float verticalDistance;
	public float horizontalZoom;
	public float verticalZoom;
	
	public Texture2D healthBar;
	public Rect healthBarPosition;
	
	public Fighter player;
	
	//public Mob target;
	public float healthPercentage;
	
	//public bool started = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (started);
		/*
		if (player.opponent != null) {
			target = player.opponent.GetComponent<Mob> ();
			healthPercentage = (float)target.health / (float)target.maxHealth;
		} else {
			target = null;
			healthPercentage = 0;
		}*/
		healthPercentage = (float)player.health / (float)player.maxHealth;
	}
	
	void OnGUI(){
		//if (target != null && (!started || player.countDown > 0)) {
			drawFrame ();
			drawBar ();
		//0.0007
		//0.06
		//0.995
		//0.81
	}
	
	void drawFrame(){
		framePosition.x = (Screen.width - framePosition.width) / 2;
		framePosition.y = (Screen.height - framePosition.height) * 0.33f;
		float width = 0.16f;
		float height = 0.01f;
		framePosition.width = Screen.width * width;
		framePosition.height = Screen.height * height;
		GUI.DrawTexture (framePosition, frame);
	}
	
	void drawBar(){
		healthBarPosition.x = framePosition.x + framePosition.width * horizontalDistance;
		healthBarPosition.y = framePosition.y + framePosition.height * verticalDistance;
		healthBarPosition.width = framePosition.width * horizontalZoom * healthPercentage;
		healthBarPosition.height = framePosition.height * verticalZoom;
		healthBarPosition.x += framePosition.width * horizontalZoom * (1 - healthPercentage);
		GUI.DrawTexture (healthBarPosition, healthBar);
	}
}
