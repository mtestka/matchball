using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private GameObject musicManager;
    private AudioSource audioSr;
    public GameObject titles, instruction;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("Level") == 0 || !PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 1);
        }
		musicManager = GameObject.FindObjectOfType<MusicManager>().gameObject;
		Debug.Log (musicManager + " found");
		if (musicManager != null) {
			audioSr = musicManager.GetComponent<AudioSource> ();
		}
        if (PlayerPrefs.GetInt("MuteMusic") == 0 && !audioSr.isPlaying)
        {
            audioSr.Play();
        }
        StartCoroutine("ForStart");
	}

    IEnumerator ForStart()
    {
        yield return new WaitForSeconds(1.2f);
        if(titles != null)
        titles.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevel()
    {
        /*if (PlayerPrefs.GetInt("MuteMusic") == null || PlayerPrefs.GetInt("MuteMusic") == 0)
        {
            audioSr.Play();
        }*/
        MusicManager.startedWelcome = false;
		SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    /*public void BlackVersion()
    {
        PlayerPrefs.SetString("Color", "Black");
    }

    public void WhiteVersion()
    {
        PlayerPrefs.SetString("Color", "White");
    }*/

    public void GoToLevel(int level)
    {
        if (level == 5 || level == 6)
        {
            StartCoroutine("WaitForPlay", level);
        }
        else
        {
			SceneManager.LoadScene(level, LoadSceneMode.Single);
            //Debug.Log(level.ToString());
        }
    }

    public void CloseInstruction()
    {
        instruction.SetActive(false);
    }

    public void OpenInstruction()
    {
        instruction.SetActive(true);
    }

    private IEnumerator WaitForPlay(int level)
    {
        if (level == 5)
        {
            if (PlayerPrefs.GetInt("first") != 2)
            {
				
				SceneManager.LoadScene(4, LoadSceneMode.Single);
                PlayerPrefs.SetInt("first", 2);
            }
            else {
                yield return new WaitForSeconds(0.1f);
				SceneManager.LoadScene(level, LoadSceneMode.Single);
            }
        }else if(level == 6)
        {
            if (PlayerPrefs.GetInt("firstmode") != 1)
            {
				SceneManager.LoadScene(7, LoadSceneMode.Single);
                PlayerPrefs.SetInt("firstmode", 1);
            }
            else {
                yield return new WaitForSeconds(0.1f);
				SceneManager.LoadScene(level, LoadSceneMode.Single);
            }
        }
    }
}
