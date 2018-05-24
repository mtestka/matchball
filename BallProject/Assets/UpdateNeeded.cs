using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateNeeded : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void OnUpdate()
    {
        Application.OpenURL("market://details?q=pname:com.BGY.matchball/");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
