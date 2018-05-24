using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("1612064", false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowRewardedVideo()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;

        Advertisement.Show("rewardedVideo", options);
    }

    public void ShowShortVideo()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResultInGame;

        Advertisement.Show("video", options);
    }

    void HandleShowResultInGame(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            if (SceneManager.GetActiveScene().name == "GameSC" && !MusicManager.playedAgain)
            {
                PadBehave.isGameOver = false;
				SceneManager.LoadScene(5, LoadSceneMode.Single);
                MusicManager.playedAgain = true;
            }
            else
            {
                PadBehave.isGameOver = false;
				SceneManager.LoadScene(6, LoadSceneMode.Single);
                MusicManager.playedAgain = true;
            }
            Debug.Log("Video completed - Offer a reward to the player");

        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("Video was skipped - Do NOT reward the player");

        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video failed to show");
        }
    }

    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            MusicManager.lifes = 5;
            MusicManager.serverTime = 9000;
            Debug.Log("Video completed - Offer a reward to the player");

        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("Video was skipped - Do NOT reward the player");

        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video failed to show");
        }
    }

}
