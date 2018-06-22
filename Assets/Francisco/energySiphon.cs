using UnityEngine;
using System.Collections;

public class energySiphon : MonoBehaviour {

	public Transform player;
	public float speed;
	Vector2 aimDir;
	float dist;
	bool attached;
	protonCollector protons;
	// Use this for initialization
	void Start () {
		player = centerP.centerPoint.transform;
		protons = FindObjectOfType<protonCollector>();
	}
	
	// Update is called once per frame
	void Update () {
		dist = Vector2.Distance( player.position, transform.position);
		if (dist >= 25)
		{
			aimDir = transform.position - player.position;
			rigidbody2D.AddForce(aimDir * 100);
		}
	}


	void OnTriggerEnter2D( Collider2D target)
	{
		if (target.tag == "moveN")
		{
			transform.parent = target.transform;
			GetComponent<Rigidbody2D>().isKinematic =true;
			transform.position = target.transform.position;
			attached = true;

				StartCoroutine(siphon());
		}
		if(target.tag =="wall")
		{
			Destroy(this.gameObject);
		}
	}
	IEnumerator siphon()
	{
		if (protons.totalProtonCount >=1)
			protons.totalProtonCount--;

		yield return new WaitForSeconds(2f);	

		if (attached)
				StartCoroutine(siphon());
			
		
	}
}
