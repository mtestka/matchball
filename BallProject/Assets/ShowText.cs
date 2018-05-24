using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour {

    private bool spawned = true;

    void Awake()
    {
        if (spawned == true)
        {
            DontDestroyOnLoad(transform.root.gameObject);
            spawned = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
