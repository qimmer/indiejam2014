using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    const int NUM_PLAYERS = 2;

    double[] playerScore = new double[NUM_PLAYERS+1];
	bool gameWon = false;

	public GUIText winText;
	public double winScore = 10000;
    public double ScoreMultiplier = 0.1;
	public GameObject restartButton;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < NUM_PLAYERS; ++i) 
        {
            playerScore[i] = 0.0;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(gameWon)
			return;
		if (playerScore[1] > winScore)
		{
			winText.enabled = true;
			restartButton.guiTexture.enabled = true;
			winText.text = "Green player wins!";
			gameWon = true;
		}
		if (playerScore[2] > winScore)
		{
			winText.enabled = true;
			restartButton.guiTexture.enabled = true;
			winText.text = "Blue player wins!";
			gameWon = true;
		}
	}

    public int GetPlayerScore(int playerIndex)
    {
        return (int)playerScore[playerIndex];
    }

    public void AddScore(int playerIndex, float score)
    {
		if(!gameWon)
        	playerScore[playerIndex] += ScoreMultiplier * score;
    }
}
