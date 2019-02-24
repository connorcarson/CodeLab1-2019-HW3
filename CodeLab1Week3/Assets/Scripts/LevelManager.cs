using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	public TextMeshProUGUI timer;

	public float timeLeft = 30;
	private int wholeTime;

	// Use this for initialization
	void Start()
	{
		Spawn(); //spawn first prize at the start of our game
		//InvokeRepeating("CubeSpawn", 5, 3);
	}

	// Update is called once per frame
	void Update()
	{
		timeLeft -= Time.deltaTime; //Countdown one second, every second
		wholeTime = (int) timeLeft; //Convert float to int, round time in seconds up to whole number
		timer.text = "" + wholeTime; //display Time
		CheckForPrize();
	}

	void Spawn() //function for spawning our prize
	{
		GameObject newPrize = Instantiate(Resources.Load<GameObject>("Prefabs/Prize")); //loads prefab into game
		newPrize.transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-4, 4)); //at new, random location
	}

	/*void CubeSpawn()
	{
		GameObject newCube1 = Instantiate(Resources.Load<GameObject>("Prefabs/Cube1"));
		newCube1.transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-4, 4));
		GameObject newCube2 = Instantiate(Resources.Load<GameObject>("Prefabs/Cube2"));
		newCube2.transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-4, 4));
	}*/

	void CheckForPrize() //check if prize has been destroyed
	{
		GameObject prizesInScene = GameObject.FindWithTag("Prize"); //find all objects in scene tagged "Prize"
		if (prizesInScene == null) //if there are no objects tagged "Prize" in our scene
		{
			Spawn(); //then spawn a new prize
		}
	}
}
