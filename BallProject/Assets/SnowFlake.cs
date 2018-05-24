using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlake : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        string nL = collider.gameObject.name;
        if (nL == "padredmd2" || nL == "padred"|| nL == "padblue" || nL == "padgreen" || nL == "padorange" || nL == "purplepad"
            || nL == "padyellow" || nL == "padorangemd2" || nL == "padbluemd2" || nL == "padgreenmd2" || nL == "padyellowmd2"
            || nL == "purplepadmd2")
        MusicManager.flakes += 1;
    }
}
