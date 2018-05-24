using UnityEngine;

public class TloScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(PlayerPrefs.GetString("Color") == "Black")
        {
            this.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
