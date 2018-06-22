using UnityEngine;
using System.Collections;

public class Crash : MonoBehaviour {

	Vector2 dir ;

	void OnCollisionEnter2D(Collision2D bumpedObject ){

	///	if(neutron){
	//		sprite.color = new Color(1,0,1,1);
		//}


		foreach (ContactPoint2D contact in bumpedObject.contacts) {
					
			dir = contact.normal;
			gameObject.rigidbody2D.AddForce(dir * 10 , ForceMode2D.Impulse);
		
		}


	}

	void Update(){



	}

	void Start(){
	

	}

}
