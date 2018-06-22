using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class hud : MonoBehaviour {
	public Text protonCount;
	public protonCollector collected;

	void Update()
	{
		protonCount.text = collected.totalProtonCount.ToString();
	}

}
