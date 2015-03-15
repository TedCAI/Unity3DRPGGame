using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CDIcon : MonoBehaviour {

	//public GameObject skill;
	public float cdTime;
	private float currentTime;
	private bool inCD;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//GetComponent<RectTransform> ().localScale = skillIcon.GetComponent<SkillBar> ().currentScale;
		if(GetComponent<Image> ().fillAmount > 0){
			if(GetComponent<Image> ().fillAmount == 1.0f && !inCD){
				currentTime = Time.time;
				inCD = true;
			}
			else{
				float percentage = 1.0f - (float)((Time.time - currentTime) / cdTime);
				//Debug.Log(currentTime);
				//Debug.Log(Time.time);
				//Debug.Log(percentage);
				GetComponent<Image> ().fillAmount = percentage;
			}
		}
		else{
			inCD = false;
		}
	}
}
