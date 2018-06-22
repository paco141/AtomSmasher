using UnityEngine;
using System.Collections;

public class vekocityBar : MonoBehaviour {

	RectTransform bar;
	public float velocity;
	public float  maxVelocity;
	public Crash absorb;
	public SpringJoint2D spring;
	float barRate =1;
	float barLerp;
	float barLength;
	Vector2 barVector;
	public bool maxVelocityReached = false;

	
	public Rigidbody2D neutron;
	// Use this for initialization
	void Start () {
		bar = gameObject.GetComponent<RectTransform>();
		//maxHP = hp;
	}
	
	// Update is called once per frame
	void Update () {
		if( 40 <= neutron.velocity.magnitude && !maxVelocityReached )
		{
			if (velocity <= maxVelocity)
			velocity += barRate;

			if ( velocity == maxVelocity)
			{
				maxVelocityReached = true;
				//absorb.collect = true;
			}
		}
		else
		{
			if (velocity >= 0)
			velocity-=barRate/2;

			if (velocity == 0) 
			maxVelocityReached =false;
		}

		
		barLerp= velocity/maxVelocity;
		barLength = Mathf.Lerp(0,221.8f, barLerp);
		barVector = new Vector2 (barLength,bar.sizeDelta.y);
		bar.sizeDelta = barVector;
	}

}
