using UnityEngine;
using System.Collections;

public class chaser : MonoBehaviour {
	public Transform target;
	Vector3 move;
	public float speed = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	transform.position =	Vector3.MoveTowards(transform.position, target.position, speed* Time.deltaTime);
	}
}
