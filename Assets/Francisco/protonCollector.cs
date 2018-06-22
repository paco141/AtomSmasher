using UnityEngine;
using System.Collections;

public class protonCollector : MonoBehaviour {
	public int totalProtonCount=5;
	vekocityBar gauge;
	SpriteRenderer electron;

	void OnCollisionEnter2D(Collision2D proton )
	{
		if(proton.gameObject.GetComponent<Crash>() != null && gauge.maxVelocityReached)
		{
			Destroy(proton.gameObject);
			totalProtonCount++;

		}

	}
	void Start()
	{
		gauge = FindObjectOfType<vekocityBar>();
		electron = this.gameObject.GetComponent<SpriteRenderer>();
	}
	void Update()
	{

		if (totalProtonCount >= 15)
		{
			totalProtonCount= 15;
		}
		if(gauge.maxVelocityReached)
		{
			electron.color = Color.blue;
		}
		else
		{
			electron.color = Color.white;
		}
	}
}
