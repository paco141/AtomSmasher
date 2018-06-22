using UnityEngine;
using System.Collections;

public class TheEnemy : MonoBehaviour {
	public float hp = 20;
	public float speed;
	public float attackSpeed;
	public float DOT;
	public Rigidbody2D energySiphon;
	Vector3 orignalScale;
	Vector3 endScale;
	float lerpScale =0;
	bool b_canFire = true;
	public float fireRate = 2;
	float timer = 0;
	float moveTimer =0;
	public Vector2 newMoveDir;

	public Transform player;
	SpriteRenderer ultraeutron;
	public Sprite[] newNeutron;
	// Use this for initialization
	void Start () {
		orignalScale = this.transform.localScale;
		endScale = new Vector3(2f,2f,2f);
		ultraeutron = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		attackPlayer();
		this.transform.localScale = Vector3.Lerp(orignalScale,endScale,lerpScale);
		if(hp <= 5)
		{
			ultraeutron.sprite =newNeutron[2];
		}
		else if ( hp <= 10)
		{
			ultraeutron.sprite =newNeutron[1];
		}
		else if (hp <= 15)
		{
			ultraeutron.sprite =newNeutron[0];
		}
		move();	
	
	}

	public void loseHP (float damageDealt)
	{
		hp-= damageDealt;
	}

	void attackPlayer()
	{
		if(b_canFire)
		{
			timer += Time.deltaTime;
			if (timer >= fireRate)
			{
				Rigidbody2D clone;
				Vector2 dir;
				clone = Instantiate(energySiphon,this.transform.position,this.transform.rotation)as Rigidbody2D;
				dir = player.position - this.transform.position;
				clone.AddForce(dir * 2 , ForceMode2D.Impulse );

				timer = 0;
			}


		}

	}
	void move()
	{
		moveTimer  += Time.deltaTime;
		if (moveTimer <= Random.Range(2,3))
		{
			newMoveDir = player.position - this.transform.position;
			rigidbody2D.AddForce( newMoveDir.normalized * speed );
			moveTimer = 0;
		}

	}


	/*
	 * /////
	 * stages 3
	 * - each stage has a shell
	 * 
	 * 
	 * 
	 * 
	 * 
	 * 
	 * 
	 * 
	 * block player into a section 
	 * 
	 * fire off a shot that takes away charges
	 * 
	 * slow moving
	 */
}
