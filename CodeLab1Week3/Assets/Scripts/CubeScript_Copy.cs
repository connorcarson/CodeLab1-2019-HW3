using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CubeScript_Copy : MonoBehaviour
{
    /*this script is the same as the CubeScript except that in it I attempt to initialize all variables privately so that I can make the cubes
    (which have this script on them) into prefabs and invoke them repeatedly. Unfortunately, I cannot figure out how to instantiate the cubes 
    WITH their timers and reference the different players without breaking other parts of the game.This version, with the OnTriggerEnter2D 
    function being implemented on the PlayerController script was the closest I came... HALP*/
    
    //public GameObject player;
    public GameObject cubeTimer;
    
    public TextMeshProUGUI cubeTimerText;

    private float xOffset = 87f;
    private float yOffset = 15f;
    public float timeLeft = 10f;
    public int wholeTime;

    public Camera mainCam;
    public RectTransform cubeTimerRect;
    public Canvas canvas;
   
    // Start is called before the first frame update
    void Start()
    {           
        mainCam = FindObjectOfType<Camera>();

        canvas = FindObjectOfType<Canvas>();
        
        //player = GameObject.FindWithTag("Player");
        
        cubeTimer = GameObject.FindWithTag("Cube1Timer");
        cubeTimerText = cubeTimer.GetComponent<TextMeshProUGUI>();
        cubeTimerRect = cubeTimer.GetComponent<RectTransform>();
        ConvertUIPos();
    }

    // Update is called once per frame
    void Update()
    {
        CubeCountdown();
        CubeFail();
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("hit");
        if (other.gameObject == player)
        {
            Destroy(gameObject);
            Destroy(cubeTimer);
        }
    }*/

    private void ConvertUIPos()
    {
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();

        Vector2 viewportPos = mainCam.WorldToViewportPoint(transform.position);
        Vector2 cubeScreenPos = new Vector2(
            (((viewportPos.x*canvasRect.sizeDelta.x)-(canvasRect.sizeDelta.x*0.5f)) + xOffset),
            (((viewportPos.y*canvasRect.sizeDelta.y)-(canvasRect.sizeDelta.y*0.5f)) + yOffset));
        cubeTimerRect.anchoredPosition = cubeScreenPos;
    }

    private void CubeCountdown()
    {
        timeLeft -= Time.deltaTime;
        wholeTime = (int) timeLeft;
        cubeTimerText.text = " " + wholeTime;
    }
    
    private void CubeFail()
    {
        if (timeLeft <= 0)
        {
            Destroy(gameObject);
            Destroy(cubeTimer);
        }
    }
}
