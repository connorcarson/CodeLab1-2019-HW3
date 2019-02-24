using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

	private GameObject GameManager;
	
	private GameManager _gameManager;

	private Animator anim;

	public GameObject levelTimer;
	public float restartTimer;
	public float restartDelay = 8;
	
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		GameManager = GameObject.FindWithTag("GameController"); //Get reference to GameManager object
		_gameManager = GameManager.GetComponent<GameManager>(); //Get reference to GameManager's script
	}
	
	// Update is called once per frame
	void Update () {
		if (_gameManager.timeLeft <= 0) //if the timer runs out
		{
			GameOver(); //game over
		}
	}

	public void GameOver()
	{
		levelTimer.SetActive(false);
		anim.SetTrigger("GameOver"); //start Game Over animation
		restartTimer += Time.deltaTime; //count up in seconds
		if (restartTimer >= restartDelay) //if restart timer is equal to our restart delay
		{
			SceneManager.LoadScene("LoveConnection"); //restart the game
		}
	}
}
