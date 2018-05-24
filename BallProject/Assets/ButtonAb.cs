using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAb : MonoBehaviour {

    public float x;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveBallsToPos()
    {
        foreach (Ball go in GameObject.FindObjectsOfType<Ball>())
        {
            if (!go.touched)
            go.gameObject.transform.position = new Vector3(x, go.gameObject.transform.position.y, 0);
        }
    }
}
