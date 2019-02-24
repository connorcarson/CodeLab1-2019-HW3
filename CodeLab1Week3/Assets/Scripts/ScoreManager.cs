using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

	public TextMeshProUGUI loveScore;
	public int score;
	
	// Use this for initialization
	void Start ()
	{
		loveScore = GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		loveScore.text = "Score: " + score;
	}
}
