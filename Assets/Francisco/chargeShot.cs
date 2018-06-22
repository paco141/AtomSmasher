using UnityEngine;
using System.Collections;

public class chargeShot : MonoBehaviour {
	public float damage = 2;

	void OnCollisionEnter2D(Collision2D Enemy)
	{

		if(Enemy.transform.tag == "Enemy")
		{

			Enemy.gameObject.GetComponent<TheEnemy>().loseHP(damage);
			Destroy(this.gameObject);
		}
	}
}
