using UnityEngine;
using System.Collections;

public class clickDrag : MonoBehaviour {

	// Use this for initialization
	public GameObject clicked;
	public Rigidbody2D chargedShoot;

	[HideInInspector]public float timer = 0;

	public float chargeDuration;
	Vector2 mouseposition;
	//still check
	Vector2 oldPos;
	Vector2 newPos;
	Vector2 diffencPos;
	bool clickActive=false;
	bool canFire;
	public Transform maxDistTopLeft;
	public Transform maxDistBottomRight;
	//bool cap =false;
	protonCollector collector;
	public int  tap = 0;


	//float timer2 = 0;
	void Start () {
		collector = FindObjectOfType<protonCollector>();
	}
	
	// Update is called once per frame
	void Update() {
		Vector3 dir = clicked.transform.position- transform.position;
//		Debug.Log(diffencPos.magnitude);


		clicking();
		DoubleTapCountDown();

		rigidbody2D.AddForce( dir.normalized  *2000);
	}


	void clicking(){
	
		if (Input.GetMouseButton(0))
		{
			float mousex = (Input.mousePosition.x);
			float mousey = (Input.mousePosition.y);
			Vector2 mouseposition = Camera.main.ScreenToWorldPoint(new Vector3 (mousex,mousey,0));
			movementCap(mouseposition);
//			print(mouseposition.normalized);
			


			// make sure that there are proton to fire
			if (collector.totalProtonCount >= 1)
			{
				// check if holding down charge
				if(clickActive)
				{
					//Debug.Log(timer);
					if(timer <= chargeDuration)
					{
						timer+= Time.deltaTime;
					}
					else
					{
						canFire = true;
						timer =chargeDuration;
					}

				}
			//move this to click release and make sure it is working.
				// check  for flick/swipe direction  than fire electron in that directionn
				if(diffencPos.magnitude >= 4f && canFire  ){

					collector.totalProtonCount--;
					Vector2 dir = diffencPos.normalized;
					Rigidbody2D clone;
					clone =Instantiate(chargedShoot,clicked.transform.position,clicked.transform.rotation) as Rigidbody2D;
					clone.AddForce( dir *30,ForceMode2D.Impulse);
					timer= 0;
					canFire =false;	
				}
			}



		}
		if (Input.GetMouseButtonUp(0))
		{
			if(clickActive)
				tap = 0;

			clickActive = false;
		}
		if (Input.GetMouseButtonDown(0))
		{
			StartCoroutine(checkIfStill());
			StartCoroutine(tapReset());
			tap++;

		}
	}
	void DoubleTapCountDown()
	{
		if(tap == 2)
		{
			clickActive = true;
		}
	}


	void movementCap(Vector2 mousePos)
	{
		float mouseX = mousePos.x;
		float mouseY = mousePos.y;


		if( mouseX >= maxDistBottomRight.transform.position.x)
		{

			mouseX = maxDistBottomRight.transform.position.x;
			Debug.Log("right");
		}
		 if(mouseX <= maxDistTopLeft.transform.position.x)
		{

			mouseX = maxDistTopLeft.transform.position.x;
			Debug.Log("left");
		}



		if( mouseY >= maxDistTopLeft.transform.position.y)
		{

			mouseY = maxDistTopLeft.transform.position.y;
			Debug.Log("up");
		}
		 if(mouseY <= maxDistBottomRight.transform.position.y)
		{

			mouseY = maxDistBottomRight.transform.position.y;
			Debug.Log("down");
		}



		mouseposition = new Vector2(mouseX,mouseY );
		if(clicked !=null)
			clicked.transform.position= mouseposition;
			
		
	}

	IEnumerator checkIfStill()
	{
		oldPos = clicked.transform.position;
		yield return new WaitForSeconds(.1f);
		newPos = clicked.transform.position;
		diffencPos =newPos - oldPos;

		if(clickActive)
		{
			StartCoroutine(checkIfStill());
		}
	
	}

	IEnumerator tapReset()
	{
		yield return new WaitForSeconds (.2f);
		if(tap==1)
			tap = 0;
	}



}
