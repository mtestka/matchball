using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelModeButton : MonoBehaviour {

    public int level;
    public bool active;
    private LevelManager levelManager;
    public GameObject showAdPossible;
    private bool once = true;

	// Use this for initialization
	void Start () {
        MusicManager.playedAgain = false;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if (MusicManager.lifes > 0)
        {
            GetComponent<Button>().onClick.AddListener(delegate { levelManager.GoToLevel(level + 7); });
        }
        else
        {
            GetComponent<Button>().onClick.AddListener(delegate {
                showAdPossible.SetActive(true);
            });
        }
        GetComponentInChildren<Text>().text = level.ToString();
		if(PlayerPrefs.GetInt("Level") >= level && level != 1)
        {
            active = true;
        }
        if (active)
        {
            GetComponent<Button>().interactable = true;
            foreach (Image im in GetComponentsInChildren<Image>())
            {
                if (im.gameObject.name == "alpha")
                {
                    Color tmp = im.color;
                    tmp.a = 0f;
                    im.color = tmp;
                }
            }
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (MusicManager.lifes == 0)
        {
            if (60 - ((int)MusicManager.serverTime % 60) <= 10)
                showAdPossible.GetComponentInChildren<Text>().text = "Wait " + (29 - ((((int)MusicManager.serverTime) % 1800) / 60)).ToString() + ":0" + (59 - ((int)MusicManager.serverTime % 60)).ToString() + " for new ball or watch ad and refill";
            else
                showAdPossible.GetComponentInChildren<Text>().text = "Wait " + (29 - ((((int)MusicManager.serverTime) % 1800) / 60)).ToString() + ":" + (59 - ((int)MusicManager.serverTime % 60)).ToString() + " for new ball or watch ad and refill";
        }
        else
        {
            if (once)
            {
                showAdPossible.SetActive(false);
                GetComponent<Button>().onClick.AddListener(delegate { levelManager.GoToLevel(level + 7); });
                once = false;
            }
        }
    }
}
