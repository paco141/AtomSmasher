using UnityEngine;
using System.Collections;

public class chargeBar : MonoBehaviour {
	RectTransform bar;
	public clickDrag getTimer;
	float maxTime;
	float currentTime;
	public float barLerp;
	float barLength;
	Vector2 barVector;

	// Use this for initialization
	void Start () {
		bar = gameObject.GetComponent<RectTransform>();
		maxTime = getTimer.chargeDuration;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(currentTime);
		currentTime = getTimer.timer;
		barLerp= currentTime/maxTime;
		barLength = Mathf.Lerp(0,100f, barLerp);
		barVector = new Vector2 (barLength,bar.sizeDelta.y);
		bar.sizeDelta = barVector;
		
	}
}
