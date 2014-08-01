using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    const int NUM_PLAYERS = 2;

    double[] playerScore = new double[NUM_PLAYERS+1];

    public double ScoreMultiplier = 0.1;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < NUM_PLAYERS; ++i) 
        {
            playerScore[i] = 0.0;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int GetPlayerScore(int playerIndex)
    {
        return (int)playerScore[playerIndex];
    }

    public void AddScore(int playerIndex, float score)
    {
        playerScore[playerIndex] += ScoreMultiplier * score;
    }
}
