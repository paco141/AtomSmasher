using UnityEngine;
using System.Collections;

public class camMove : MonoBehaviour {
	public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		Vector3 cammPos = new Vector3(target.position.x,target.position.y,transform.position.z);

		transform.position = Vector3.Lerp(transform.position, cammPos , 4 * Time.deltaTime);

		if(Input.GetKey(KeyCode.W)){
				transform.position += transform.up * 10 * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.S)){
			transform.position -= transform.up * 10 * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.D)){
			transform.position += transform.right * 10 * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.A)){
			transform.position -= transform.right * 10 * Time.deltaTime;
		}
	}
	}


