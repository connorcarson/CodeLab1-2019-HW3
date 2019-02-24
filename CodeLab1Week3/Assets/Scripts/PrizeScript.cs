using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PrizeScript : MonoBehaviour
{

	private bool playerIsTouchingPrize;

	public GameObject ScoreText;

	public ScoreManager ScoreManager;
	
	// Use this for initialization
	void Start () {
		ScoreText = GameObject.FindWithTag("ScoreText"); //initialize ScoreText as our TextMeshProUGUI object
		ScoreManager = ScoreText.GetComponent<ScoreManager>(); //get script from ScoreText
	}
	
	// Update is called once per frame
	void Update () {
		
	}

private void OnTriggerEnter(Collider other)
{
	//Debug.Log("I've been hit by something!");
		if (other.CompareTag("Player") && playerIsTouchingPrize) //if a player is currently touching this prize and another player also touches this prize
		{
			//Debug.Log("Two players collided with me!");
			Destroy(gameObject); //then destroy this prize
			ScoreManager.score++; //and get the ScoreManager and add 1 to its score
		}
		
		else if (other.CompareTag("Player")) //if just one player is touching this prize
		{
			//Debug.Log("A single player is colliding with me!");
			playerIsTouchingPrize = true; //then a player is currently touching this prize
		}
	}
	
private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player")) //if a player stops touching this prize
		{
			//Debug.Log("A player stopped colliding with me!");
			playerIsTouchingPrize = false; //then no one is touching this prize
		}
	}
}

