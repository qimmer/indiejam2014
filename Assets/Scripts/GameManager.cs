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
	public GameObject gameMenuButton;
    public GameObject explosionPrefab;
    public AudioClip[] farExplosions;
    public AudioClip[] nearExplosions;

    void OnLevelWasLoaded(int level)
    {
        winScore = (double)PlayerPrefs.GetFloat("WinScore");
        gameWon = false;
        winText.enabled = false;
        audio.Stop();

    }
	// Use this for initialization
	void Start () {
        
        for (int i = 0; i < NUM_PLAYERS; ++i) 
        {
            playerScore[i] = 0.0;
        }

        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameWon)
			return;
		if (playerScore[1] > winScore)
		{
			winText.enabled = true;
			restartButton.guiTexture.enabled = true;
			gameMenuButton.guiText.enabled = true;
			winText.text = "Green player wins!";
			gameWon = true;
		}
		if (playerScore[2] > winScore)
		{
			winText.enabled = true;
			restartButton.guiTexture.enabled = true;
			gameMenuButton.guiText.enabled = true;
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

    public void CreateExplosion(Vector3 position, float size)
    {
        GameObject explosion = (GameObject)Instantiate(explosionPrefab, position, Quaternion.identity);
        
        if( position.z > 30.0f )
        {
            AudioClip clip = farExplosions[Random.Range(0, farExplosions.Length - 1)];
            explosion.audio.clip = clip;
        }
        else
        {
            AudioClip clip = nearExplosions[Random.Range(0, nearExplosions.Length - 1)];
            explosion.audio.clip = clip;
        }

        explosion.audio.Play();

        Destroy(explosion, 5.0f);

        Camera.main.GetComponent<FollowPlayers>().Stress += 15.0f / ((position.z+1.0f)*0.2f);
    }
}
