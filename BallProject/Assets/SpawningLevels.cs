using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawningLevels : MonoBehaviour
{
    public int level;
    public GameObject gameOver, winScreen, ballParent, restBallsText, levelText;
    private GameObject musicMan;
    private AudioSource audioSr;
    public GameObject[] balls;
    public AudioClip ac;
    public int[] numberOfBallsToSpawn;
    private AudioSource asc;
    private bool playOnce = true;
    public static int count;
    public static float levelMultiply;
    private int levelTemp;
    private int multiplied;

    void Start()
    {
		level = (int)SceneManager.GetActiveScene ().name [SceneManager.GetActiveScene ().name.Length - 1] - 48;
		if (level % 4 == 0)
        {
            multiplied = 4;
        }
        else {
            multiplied = level % 4;
        }

        playOnce = true;
        asc = GameObject.FindObjectOfType<SoundMan>().gameObject.GetComponent<AudioSource>();
		musicMan = GameObject.FindObjectOfType<MusicManager>().gameObject;
        audioSr = musicMan.GetComponent<AudioSource>();
        levelText.GetComponent<Text>().text = "Level \n" + level.ToString();

        if (level <= 4 && level >= 1)
        {
            count = 20;
            levelMultiply = 2f;
        }
        else if (level <= 8 && level >= 5)
        {
            count = 25;
            levelMultiply = 2.5f;
        }
        else if (level <= 12 && level >= 9)
        {
            count = 30;
            levelMultiply = 2.8f;
        }
        else if (level <= 16 && level >= 13)
        {
            count = 35;
            levelMultiply = 3f;
        }
        else if (level <= 20 && level >= 17)
        {
            count = 40;
            levelMultiply = 3.3f;
        }
        else if (level <= 24 && level >= 21)
        {
            count = 45;
            levelMultiply = 3.5f;
        }
        else if (level <= 28 && level >= 25)
        {
            count = 50;
            levelMultiply = 4f;
        }

        StartCoroutine("SpawningBalls");
    }

    void Update()
    {
        restBallsText.GetComponent<Text>().text = count.ToString();
        if (PadBehaveLevels.isGameOver)
        {
            gameOver.SetActive(true);
            if (playOnce)
            {
				if (!PlayerPrefs.HasKey("MuteSFX")|| PlayerPrefs.GetInt("MuteSFX") == 0)
                {
                    asc.clip = ac;
                    asc.Play();
                    playOnce = false;
                }
            }
        }
        else
        {
            gameOver.SetActive(false);
        }
        if (!PadBehaveLevels.isGameOver)
        {
            if (count == 0)
            {
                winScreen.SetActive(true);
                if (PlayerPrefs.GetInt("Level") == level)
                {
                    PlayerPrefs.SetInt("Level", level + 1);
                    //Debug.Log(PlayerPrefs.GetInt("Level").ToString());
                }
            }
            else
            {
                winScreen.SetActive(false);
            }
        }

        //Test w pociagu strzalki

        /*foreach (BallLevels go in GameObject.FindObjectsOfType<BallLevels>())
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if(go.gameObject.transform.position.x != -1.7f )
                go.gameObject.transform.position = new Vector3(go.gameObject.transform.position.x-1.7f, go.gameObject.transform.position.y, 0);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow)){
                if(go.gameObject.transform.position.x != 1.7f)
                go.gameObject.transform.position = new Vector3(go.gameObject.transform.position.x + 1.7f, go.gameObject.transform.position.y, 0);
            }
        }*/

    }

    public void NextLevel()
    {
        ResetingLevel();
		if (!PlayerPrefs.HasKey("MuteMusic")|| PlayerPrefs.GetInt("MuteMusic") == 0)
        {
            audioSr.Play();
        }
		SceneManager.LoadScene (level + 8, LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        ResetingLevel();
		SceneManager.LoadScene (0, LoadSceneMode.Single);
    }

    public void PlayAgain()
    {
        if (MusicManager.lifes > 0)
        {
            ResetingLevel();
			if (!PlayerPrefs.HasKey("MuteMusic")|| PlayerPrefs.GetInt("MuteMusic") == 0)
            {
                audioSr.Play();
            }
			SceneManager.LoadScene (level + 7, LoadSceneMode.Single);
        }
        else
        {
            ResetingLevel();
			SceneManager.LoadScene (1, LoadSceneMode.Single);
        }
    }

    private void ResetingLevel()
    {
        /*if (PlayerPrefs.GetInt("MuteMusic") == null || PlayerPrefs.GetInt("MuteMusic") == 0)
        {
            audioSr.Stop();
        }*/
        PadBehaveLevels.isGameOver = false;
    }

    private IEnumerator SpawningBalls()
    {
        for (int i = 0; i < numberOfBallsToSpawn.Length; i++)
        {
            SpawnBall(balls[numberOfBallsToSpawn[i]]);
            yield return new WaitForSeconds(2f/(multiplied + levelMultiply));
        }
    }

    private void SpawnBall(GameObject ball)
    {
        var ballSpawned = Instantiate(ball, new Vector3(0, 6.2f,0), Quaternion.identity) as GameObject;
        ballSpawned.transform.SetParent(ballParent.transform);
    }
}
