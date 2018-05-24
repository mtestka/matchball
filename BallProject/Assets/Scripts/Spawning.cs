using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawning : MonoBehaviour {

	public static bool bluetogreen=false, yellowtogreen=false, redtopurple=false, bluetopurple = false, yellowtoorange = false, redtoorange = false;
	public static int scoreBlue = 0, scoreRed = 0, scoreYellow = 0, scoreOrange = 0, scoreGreen = 0, scorePurple = 0;
	public static int scoreLeft =0, scoreMid = 0, scoreRight = 0, scoreGeneral = 0;
    public static float multipler = 1;
    public Text score, highScore, scoreDisplay, showMultipler, highScoreDisplay, highscoreMode2;
    public GameObject gameOver, saving, tekstweak, continueButton;
    public string[] records;
    //string CreateUserURL = "http://ballgamewswalters.atwebpages.com/UpdateScore.php";
    public static bool updating = true;
    private GameObject musicMan;
    private AudioSource audioSr;
    private float generalTime;
    public GameObject ball;
    public GameObject[] pads;
    public GameObject[] tests;
    public AudioClip ac;
    private AudioSource asc;
    private bool playOnce = true;

    void Start()
    {
        /*if(MusicManager.playedAgain == true)
        {

        }*/
        playOnce = true;
        asc = GameObject.FindObjectOfType<SoundMan>().gameObject.GetComponent<AudioSource>();
		if(!PlayerPrefs.HasKey("GamesPlayed"))
        {
            PlayerPrefs.SetInt("GamesPlayed", 0);
            PlayerPrefs.SetFloat("GeneralTime", 0);
        }
		musicMan = GameObject.FindObjectOfType<MusicManager>().gameObject;
        audioSr = musicMan.GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == "GameSC")
        {
            highScore.text = MusicManager.highscoreint.ToString();
        }
        else
        {
            highScore.text = MusicManager.highscoreMode2int.ToString();
        }
        //highscoreglobal.text = MusicManager.highscoreGeneral.ToString();
    }

    void Update()
    {
        //highscoreglobal.text = MusicManager.highscoreGeneral.ToString();
        score.text = scoreGeneral.ToString();
        if (SceneManager.GetActiveScene().name == "GameSC")
        {
            if (scoreGeneral > MusicManager.highscoreint)
            {
                PlayerPrefs.SetInt("HighScore", scoreGeneral);
                highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
            }
        }
        else
        {
            if (scoreGeneral > MusicManager.highscoreMode2int)
            {
                PlayerPrefs.SetInt("HighScoreMode2", scoreGeneral);
                highScore.text = PlayerPrefs.GetInt("HighScoreMode2").ToString();
            }
        }
        scoreDisplay.text = scoreGeneral.ToString();
        highScoreDisplay.text = highScore.text;
        if (PadBehave.isGameOver)
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
        if (!PadBehave.isGameOver)
        {
            if (SceneManager.GetActiveScene().name == "GameSC")
            {
                if (multipler <= 2f)
                {
                    multipler += 0.0002f;
                }
                else
                {
                    multipler = 2f;
                }
            }
            else
            {
                multipler += 0.0002f;
            }
        }
        showMultipler.text = "x " + System.Math.Round(multipler,1).ToString();

    }

    public void MainMenu()
    {
        generalTime = Time.timeSinceLevelLoad;
        PlayerPrefs.SetInt("LastScore", scoreGeneral);
        PlayerPrefs.SetInt("GamesPlayed", PlayerPrefs.GetInt("GamesPlayed") + 1);
        PlayerPrefs.SetFloat("GeneralTime", PlayerPrefs.GetFloat("GeneralTime") + generalTime);
        ResetingLevel();
		SceneManager.LoadScene (0, LoadSceneMode.Single);
    }

    public void PlayAgain()
    {
        PlayerPrefs.SetInt("GamesPlayed", PlayerPrefs.GetInt("GamesPlayed") + 1);
        ResetingLevel();
		if (!PlayerPrefs.HasKey("MuteMusic")|| PlayerPrefs.GetInt("MuteMusic") == 0)
        {
            audioSr.Play();
        }
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void ContinueWithAd()
    {
        
    }

    public void ShowingCounting()
    {

    }

    public void ResetingLevel()
    {
        /*if (PlayerPrefs.GetInt("MuteMusic") == null || PlayerPrefs.GetInt("MuteMusic") == 0)
        {
            audioSr.Stop();
        }*/
        PadBehave.isGameOver = false;
        multipler = 1;
        scoreLeft = 0;
        scoreMid = 0;
        scoreRight = 0;
        scoreGeneral = 0;
        bluetogreen = false;
        yellowtogreen = false;
        redtopurple = false;
        bluetopurple = false;
        yellowtoorange = false;
        redtoorange = false;
        saving.SetActive(false);
        tekstweak.SetActive(false);
        MusicManager.startedWelcome = true;
    }
}
