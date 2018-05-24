using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour {

    private string versionAlpha = "1.2";
    public string[] records;
    private string[] recordSocial;
    public static Dictionary<string, int> friendsData = new Dictionary<string, int>();
    public static List<string> nameOfFriend = new List<string>();
    public static List<int> recordOfFriend = new List<int>();
    public static int flakes = 0, highscoreGeneral = 0, highscoreint = 0, highscoreMode2General = 0, highscoreMode2int = 0, numberOfFriends = 0, lifes;
    private GameObject inp, text;
    public String namePlayer = null;
    private String welcoming;
    public static bool startedWelcome = true, finishedFriends = false;
    private BallStart[] ballStart;
    public GameObject updateNeeded, textDate;
    private String unique_ID;
    public static Sprite[] spriteNet = new Sprite[20];
    public static bool doItOnce;
    public static float serverTime, timeDifference;
    DateTime currentDate;
    DateTime oldDate;
    public static bool playedAgain = false;

    void Awake()
    {
        //Delete after testing
        //PlayerPrefs.SetInt("NumberFriends", 0);
        PlayerPrefs.SetString("IdOfFriends", "");
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
		if (!PlayerPrefs.HasKey("GamesPlayed"))
        {
            PlayerPrefs.SetInt("GamesPlayed", 0);
            PlayerPrefs.SetFloat("GeneralTime", 0);
        }
        //Getting friends
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            StartCoroutine("GetFriends");
        }
    }

    IEnumerator Start()
    {
        /*myDateResult = myDate2 - myDate1;

        int seconds = (int)myDateResult.TotalSeconds;
        textDate.GetComponent<Text>().text = seconds.ToString();*/
        if(PlayerPrefs.GetInt("CheckFirst") == 7)
        {
            //Store the current time when it starts
            currentDate = DateTime.Now;

            //Grab the old time from the player prefs as a long

            Debug.Log("System time aaaaa : "+ PlayerPrefs.GetString("sysString"));
            long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));

            //Convert the old time from binary to a DataTime variable
            DateTime oldDate = DateTime.FromBinary(temp);
            print("oldDate: " + oldDate);

            //Use the Subtract method and store the result as a timespan variable
            TimeSpan difference = currentDate.Subtract(oldDate);
            print("Difference: " + difference);

            TimeSpan span = currentDate - oldDate;
            timeDifference = (float)span.TotalSeconds;

            var timeLeft = PlayerPrefs.GetFloat("GetTime") + timeDifference;

            if (timeLeft >= 9000)
            {
                serverTime = 9000;
                lifes = 5;
            }
            else {
                serverTime = timeLeft;
                lifes = (int)(timeLeft / 1800);
            }
        }
        else
        {
            if (PlayerPrefs.GetFloat("GetTime") == 0)
            {
                serverTime = 9000;
                lifes = 5;
            }
            else
            {
                serverTime = PlayerPrefs.GetFloat("GetTime");
                if(serverTime <= 1800)
                {
                    lifes = 0;
                }else if(serverTime <= 3600)
                {
                    lifes = 1;
                }else if(serverTime <= 5400)
                {
                    lifes = 2;
                }else if(serverTime <= 7200)
                {
                    lifes = 3;
                }else if(serverTime < 9000)
                {
                    lifes = 4;
                }if(serverTime == 9000)
                {
                    lifes = 5;
                }
            }
        }

        ballStart = GameObject.FindObjectsOfType<BallStart>();
        Debug.Log(PlayerPrefs.GetString("PlayerName"));
        highscoreint = PlayerPrefs.GetInt("HighScore");
        highscoreMode2int = PlayerPrefs.GetInt("HighScoreMode2");
        //WWW itemsData = new WWW("http://localhost/ballGame/HighscoresData.php");
        //Getting Highscores
        WWW itemsData = new WWW("http://ballgamewswalters.atwebpages.com/HighscoresData.php");
        //Getting version
        WWW version = new WWW("http://ballgamewswalters.atwebpages.com/version.php");
        //Getting friends
        //StartCoroutine("GetFriends");
        yield return itemsData;
        yield return version;
        string itemsDataString = itemsData.text;
        string versionString = version.text;

        if (versionAlpha == versionString || Application.internetReachability == NetworkReachability.NotReachable)
        {
            foreach (BallStart bs in ballStart)
            {
                if (bs != null)
                {
                    bs.gameObject.GetComponent<Button>().interactable = true;
                }
            }
            if (updateNeeded != null)
            {
                updateNeeded.SetActive(false);
            }
        }
        else
        {

            foreach (BallStart bs in ballStart)
            {
                bs.gameObject.GetComponent<Button>().interactable = false;
            }
            updateNeeded.SetActive(true);
        }
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            //Debug.Log(itemsDataString + " version: " + versionString);
            records = itemsDataString.Split(';');
            highscoreGeneral = Int32.Parse(GetDataValue(records[0], "Highscore"));
            highscoreMode2General = Int32.Parse(GetDataValue(records[0], "HighscoreMode2"));
            //Debug.Log("Highscore 2 is " + highscoreMode2General);
            if (highscoreint > highscoreGeneral && highscoreint > 30f)
                {
                    UpdateScore(highscoreint, highscoreMode2General);
                }
            if(highscoreMode2int > highscoreMode2General && highscoreMode2int > 30f)
                {
                    UpdateScore(highscoreGeneral, highscoreMode2int);
                }
        }
        /*if (inp)
        {
            inp.GetComponent<InputField>().onEndEdit.AddListener(SubmitName);
        }
        Debug.Log(PlayerPrefs.GetString("PlayerName"));
        if (inp != null)
        {
            inp.GetComponent<InputField>().onEndEdit.AddListener(SubmitName);
        }*/
    }

    // Update is called once per frame
    void Update () {
        if (PadBehave.isGameOver)
        {
            highscoreint = PlayerPrefs.GetInt("HighScore");
            highscoreMode2int = PlayerPrefs.GetInt("HighScoreMode2");
        }

        if (serverTime < 9000 && lifes != 5) {
            serverTime += Time.deltaTime;
            if (serverTime % 1800 == 0)
            {
                lifes += 1;
            }
        }
        else
            serverTime = 9000;
    }

    /*IEnumerator Welcome()
    {
            for (int i = 0; i < welcoming.Length; i++)
            {
                if (text != null)
                {
                    text.GetComponent<Text>().text = text.GetComponent<Text>().text + welcoming[i];
                }
                yield return new WaitForSeconds(0.15f);
            }
            for (int i = 0; i < 30; i++)
            {
                if (text != null)
                {
                    text.GetComponent<Text>().text = text.GetComponent<Text>().text + " ";
                }
                yield return new WaitForSeconds(0.15f);
            }
    }*/

    IEnumerator GetFriends()
    {
        WWWForm form = new WWWForm();
        form.AddField("playerName", PlayerPrefs.GetString("Username"));
        WWW getFriends = new WWW("http://ballgamewswalters.atwebpages.com/GetFriends.php", form);
        yield return getFriends;
        string getFriendsString = getFriends.text;
        //Debug.Log(getFriendsString);
        recordSocial = getFriendsString.Split(';');
        //Debug.Log(recordSocial[1] + " - Rekord social");
        numberOfFriends = int.Parse(recordSocial[0].Remove(0,"NoFriends".Length));
        //Debug.Log(numberOfFriends);
        for (int i = 1; i <= (numberOfFriends*2); i+=2)
        {
                //Debug.Log("Number of friends is " + numberOfFriends.ToString() + " and its ID is " + idOfFriend[i - 1].ToString());
                nameOfFriend.Add(recordSocial[i].Remove(0, "Friend".Length));
                friendsData.Add(nameOfFriend[(i - 1) / 2], int.Parse(recordSocial[i + 1]));
                Debug.Log("Number of friends is " + numberOfFriends.ToString() + " and its ID is " + nameOfFriend[(i - 1) / 2]);
        }
        
        //Debug.Log(PlayerPrefs.GetString("IdOfFriends"));
        PlayerPrefs.SetInt("NumberFriends", numberOfFriends);
        finishedFriends = true;
    }

    public static void UpdateScore(int score, int score2)
    {
        WWWForm form = new WWWForm();
        form.AddField("highscorePost", score);
        form.AddField("highscoreMode2Post", score2);
        WWW www = new WWW("http://ballgamewswalters.atwebpages.com/UpdateScore.php", form);
    }

    public void OpenUpdate()
    {
        Application.OpenURL("http://play.google.com/store/apps/details?id=com.BGY.Matchball");
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }

    private void SubmitName(string arg0)
    {
        namePlayer = arg0;
    }

    /*void OnApplicationPause()
    {
        PlayerPrefs.SetFloat("GetTime", serverTime);
        var timeNow = DateTime.Now.ToBinary().ToString();
        PlayerPrefs.SetString("sysString", timeNow);
        Application.Quit;
    }*/


    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Debug.Log("Paused");
            PlayerPrefs.SetFloat("GetTime", serverTime);
            var timeNow = DateTime.Now.ToBinary().ToString();
            PlayerPrefs.SetString("sysString", timeNow);
        }
        else
        {
            if (PlayerPrefs.GetInt("CheckFirst") == 7)
            {
                //Store the current time when it starts
                currentDate = DateTime.Now;

                //Grab the old time from the player prefs as a long

                Debug.Log("System time aaaaa : " + PlayerPrefs.GetString("sysString"));
                long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));

                //Convert the old time from binary to a DataTime variable
                DateTime oldDate = DateTime.FromBinary(temp);
                print("oldDate: " + oldDate);

                //Use the Subtract method and store the result as a timespan variable
                TimeSpan difference = currentDate.Subtract(oldDate);
                print("Difference: " + difference);

                TimeSpan span = currentDate - oldDate;
                timeDifference = (float)span.TotalSeconds;

                var timeLeft = PlayerPrefs.GetFloat("GetTime") + timeDifference;

                if (timeLeft >= 9000)
                {
                    serverTime = 9000;
                    lifes = 5;
                }
                else {
                    serverTime = timeLeft;
                    lifes = (int)(timeLeft / 1800);
                }
            }
            else
            {
                if (PlayerPrefs.GetFloat("GetTime") == 0)
                {
                    serverTime = 9000;
                    lifes = 5;
                }
                else
                {
                    serverTime = PlayerPrefs.GetFloat("GetTime");
                    if (serverTime <= 1800)
                    {
                        lifes = 0;
                    }
                    else if (serverTime <= 3600)
                    {
                        lifes = 1;
                    }
                    else if (serverTime <= 5400)
                    {
                        lifes = 2;
                    }
                    else if (serverTime <= 7200)
                    {
                        lifes = 3;
                    }
                    else if (serverTime < 9000)
                    {
                        lifes = 4;
                    }
                    if (serverTime == 9000)
                    {
                        lifes = 5;
                    }
                }
            }
        }
    }



    /*void OnApplicationFocus()
    {
        if (PlayerPrefs.GetInt("CheckFirst") == 7)
        {
            //Store the current time when it starts
            currentDate = DateTime.Now;

            //Grab the old time from the player prefs as a long

            Debug.Log("System time aaaaa : " + PlayerPrefs.GetString("sysString"));
            long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));

            //Convert the old time from binary to a DataTime variable
            DateTime oldDate = DateTime.FromBinary(temp);
            print("oldDate: " + oldDate);

            //Use the Subtract method and store the result as a timespan variable
            TimeSpan difference = currentDate.Subtract(oldDate);
            print("Difference: " + difference);

            TimeSpan span = currentDate - oldDate;
            timeDifference = (float)span.TotalSeconds;

            var timeLeft = PlayerPrefs.GetFloat("GetTime") + timeDifference;

            if (timeLeft >= 9000)
            {
                serverTime = 9000;
                lifes = 5;
            }
            else {
                serverTime = timeLeft;
                lifes = (int)(timeLeft / 1800);
            }
        }
        else
        {
            if (PlayerPrefs.GetFloat("GetTime") == 0)
            {
                serverTime = 9000;
                lifes = 5;
            }
            else
            {
                serverTime = PlayerPrefs.GetFloat("GetTime");
                if (serverTime <= 1800)
                {
                    lifes = 0;
                }
                else if (serverTime <= 3600)
                {
                    lifes = 1;
                }
                else if (serverTime <= 5400)
                {
                    lifes = 2;
                }
                else if (serverTime <= 7200)
                {
                    lifes = 3;
                }
                else if (serverTime < 9000)
                {
                    lifes = 4;
                }
                if (serverTime == 9000)
                {
                    lifes = 5;
                }
            }
        }
    }*/

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("CheckFirst", 7);
        //Savee the current system time as a string in the player prefs class
        PlayerPrefs.SetFloat("GetTime", serverTime);
        var timeNow = DateTime.Now.ToBinary().ToString();
        PlayerPrefs.SetString("sysString", timeNow);

        print("Saving this time: " + serverTime);
    }
}
