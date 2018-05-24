using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instruction2 : MonoBehaviour
{

    private GameObject musicManager;
    private AudioSource audioSr;
    public bool touch1, touch2;
    public GameObject[] go;
    private int firstTime = 0;

    // Use this for initialization
    void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("MusicMan");
        if (musicManager != null)
            audioSr = musicManager.GetComponent<AudioSource>();
    }


    public void OnClickSc()
    {
        if (firstTime == 0)
        {
            foreach (GameObject gb in go)
            {
                gb.GetComponent<Animator>().SetInteger("state", 1);
            }
            firstTime = 1;
        }else if(firstTime == 1)
        {
            foreach (GameObject gb in go)
            {
                gb.GetComponent<Animator>().SetInteger("state", 2);
            }
            firstTime = 2;
        }
        else
        {
			if (!PlayerPrefs.HasKey("MuteMusic")|| PlayerPrefs.GetInt("MuteMusic") == 0)
            {
                audioSr.Play();
            }
			SceneManager.LoadScene (6, LoadSceneMode.Single);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
