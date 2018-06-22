using UnityEngine;
using System.Collections;

public class pacman : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other ){
		if(other.gameObject.tag == "Player")
		{
			//Crash.collect = true;
		}
	
	}
}
