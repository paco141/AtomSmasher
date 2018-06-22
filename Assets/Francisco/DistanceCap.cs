using UnityEngine;
using System.Collections;

public class DistanceCap : MonoBehaviour {
	public GameObject center;
	public Rigidbody2D neutron;
	public float capDist;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector2.Distance (center.transform.position, neutron.transform.position);

		if (dist >= capDist)
		{
			//Debug.Log("WELL Then");
			Vector2 dir = center.transform.position - neutron.transform.position;
			neutron.AddForce(dir.normalized  * 100,  ForceMode2D.Impulse);
			Debug.DrawLine(neutron.transform.position, dir*30);
		}

	}
}
