using UnityEngine;
using System.Collections;

public class restart : MonoBehaviour {

	bool gameDone = false;
	protonCollector collector;
	TheEnemy enemy;

	void Start() 
	{
		Time.timeScale = 1;

		collector = FindObjectOfType<protonCollector>();
		enemy = FindObjectOfType<TheEnemy>();
	}
	void Update()
	{
		if(collector.totalProtonCount == 0)
		{
			gameDone = true;
			Time.timeScale = 0f;
		}
		if(enemy.hp == 0)
		{
			gameDone = true;
			Time.timeScale = 0f;
		}

	}
	void OnGUI() {

		//GUI.Box (new Rect (10, 30, 100, 20), "Time" + TextTime);
		if(gameDone==true){
			if (GUI.Button (new Rect (200, 200, 150, 100), "resart game") ) {
				


				Time.timeScale = 1;

				Application.LoadLevel ("test");
				
				
			}
		}
	}
}
