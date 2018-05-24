using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    private bool firstTime = true, once = true;
    public Text text, text2, text3, text4, text5;
    public AudioClip audio;
    private SoundMan mm;
    private int numFriends = 0;
    public GameObject friendOne, holderFriends, instruction;

    // Use this for initialization
    void Start () {
        once = true;
        mm = GameObject.FindObjectOfType<SoundMan>();
        if (text != null)
        {
            text.text = MusicManager.highscoreGeneral.ToString();
            text3.text = MusicManager.highscoreMode2General.ToString();
        }
        if (text2 != null)
            text2.text = "Last Score:\n" + PlayerPrefs.GetInt("LastScore") + "\n" + "High Score:\n" + PlayerPrefs.GetInt("HighScore") + "\n" + "Games Played:\n" + PlayerPrefs.GetInt("GamesPlayed") + "\n" + "Time played:\n" + (int)(PlayerPrefs.GetFloat("GeneralTime") / 60) + ":" + (int)(PlayerPrefs.GetFloat("GeneralTime") % 60);
    }
	
	// Update is called once per frame
	void Update () {
        if (text4 != null)
            text4.text = MusicManager.lifes.ToString();
        if (text5 != null)
        {
            if (MusicManager.lifes != 5)
            {
                if (60 - ((int)MusicManager.serverTime % 60) <= 10)
                {
                    text5.text = (29-((((int)MusicManager.serverTime)  % 1800) / 60)).ToString() + ":0" +
                        (59-((int)MusicManager.serverTime % 60)).ToString();
                }
                else
                {
                    text5.text = (29-((((int)MusicManager.serverTime) % 1800) / 60)).ToString() + ":" +
                        (59-((int)MusicManager.serverTime % 60)).ToString();
                }
            }
            else if(MusicManager.serverTime == 9000)
            {
                text5.text = "Max lifes";
            }
            /*else
            {
                MusicManager.serverTime = 1800;
                MusicManager.lifes += 1;
            }*/
        }
        if (friendOne != null && holderFriends != null)
        {
            if (MusicManager.finishedFriends && once)
            {
                Friends();
                once = false;
            }
        }
        if (SceneManager.GetActiveScene().name != "Menu1")
        {
            if (gameObject.transform.localPosition.y < 20f && firstTime)
            {
                //gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, 0, gameObject.transform.position.z);
                gameObject.GetComponent<Rigidbody2D>().simulated = false;
            }
        }
        else
        {
            if (gameObject.transform.localPosition.y < 120f && firstTime)
            {
                //gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, 0, gameObject.transform.position.z);
                gameObject.GetComponent<Rigidbody2D>().simulated = false;
            }
        }
	}

    public void OnClickThis()
    {
        firstTime = false;
        gameObject.GetComponent<Rigidbody2D>().simulated = true;
		if (!PlayerPrefs.HasKey("MuteSFX")|| PlayerPrefs.GetInt("MuteSFX") == 0)
        {
            mm.gameObject.GetComponent<AudioSource>().clip = audio;
            mm.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (SceneManager.GetActiveScene().name != "Menu1")
        {
            StartCoroutine("WaitForPlay", 0.3f);
        }
        else
        {
            StartCoroutine("WaitForPlay", 0.1f);
        }
    }

    public void Friends()
    {
        numFriends = PlayerPrefs.GetInt("NumberFriends");
        //Debug.Log(numFriends);
        for(int i = 0; i<numFriends; i++)
        {
            if (i >= 2)
            {
                holderFriends.GetComponent<RectTransform>().sizeDelta.Set(holderFriends.GetComponent<RectTransform>().sizeDelta.x, holderFriends.GetComponent<RectTransform>().sizeDelta.y + (i-1)*50f) ;
            }
            var friend = Instantiate(friendOne);
            friend.transform.SetParent(holderFriends.transform);
            foreach(Text text in friend.GetComponentsInChildren<Text>())
            {
                if(text.name == "name")
                {
                    //Debug.Log(MusicManager.nameOfFriend.Count.ToString() + " i = " + i.ToString());
                    text.text = MusicManager.nameOfFriend[i];
                }
                else if(text.name == "score")
                {
                    //Debug.Log(MusicManager.nameOfFriend.Count.ToString() + " i = " + i.ToString());
                    text.text = MusicManager.friendsData[MusicManager.nameOfFriend[i]].ToString();
                }
            }
            friend.GetComponent<RectTransform>().localPosition = new Vector2(-41f, 47.5f - 54f*i);
            friend.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    private IEnumerator WaitForPlay(float time)
    {
        yield return new WaitForSeconds(time);
		SceneManager.LoadScene (0, LoadSceneMode.Single);
    }

    public void Instruction()
    {
        instruction.SetActive(true);
    }

    public void InstructionClose()
    {
        instruction.SetActive(false);
    }
    

    public void MuteSFX()
    {
		if (!PlayerPrefs.HasKey("MuteSFX")|| PlayerPrefs.GetInt("MuteSFX") == 0)
        {
            PlayerPrefs.SetInt("MuteSFX", 1);
        }
        else {
            PlayerPrefs.SetInt("MuteSFX", 0);
        }
    }

    public void MuteMusic()
    {
		if (!PlayerPrefs.HasKey("MuteMusic")|| PlayerPrefs.GetInt("MuteMusic") == 0)
        {
            PlayerPrefs.SetInt("MuteMusic", 1);
            GameObject.Find("MusicManager").GetComponent<AudioSource>().Stop();
        }
        else {
            PlayerPrefs.SetInt("MuteMusic", 0);
            GameObject.Find("MusicManager").GetComponent<AudioSource>().Play();
        }
    }
}
