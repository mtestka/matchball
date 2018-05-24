using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteMusic : MonoBehaviour {

    public Sprite[] sprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("MuteMusic") == 0 || !PlayerPrefs.HasKey("MuteMusic"))
        {
            gameObject.GetComponent<Image>().sprite = sprite[0];
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = sprite[1];
        }
	}
}
