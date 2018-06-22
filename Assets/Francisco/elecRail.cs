using UnityEngine;
using System.Collections;

public class elecRail : MonoBehaviour {
	public Transform target;
	Vector2 startVector;
	Vector2 endVector;
	public GameObject box;
	public float dist;
	float lerpValue;
	public float temp = .1f;
	// Use this for initialization
	void Start () {
		startVector= this.transform.position;
		//box = GetComponent<BoxCollider2D>();

	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = startVector;
		endVector = target.transform.position;
		dist = Vector2.Distance(transform.position ,endVector);

		box.transform.localScale = new Vector3(1,lerpValue,1);

		//Vector2 boxSize =  new Vector2 (box.size.x , dist);
		//box.size = boxSize;

		transform.LookAt(endVector);
		lerping();
	}
	void lerping()
	{
		if (temp <=1)
		{
			temp = (temp +Time.deltaTime* .2f ) ;
		lerpValue = Mathf.Lerp(0, dist,   temp );
		}
		else
		{
			lerpValue = dist;
		}

	}


}
