using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {

    public int PlayerIndex;
    GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        string scoreString = gameManager.GetPlayerScore(PlayerIndex).ToString();

        guiText.text = "Score: " + scoreString;
	}
}
