/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UpdateScore : MonoBehaviour {

    public string inputUser;
    public string inputPassword;
    public string inputEmail;

    string CreateUserURL = "http://localhost/ballGame/UpdateScore.php";

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateScores(int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("highscorePost", score);
        WWW www = new WWW(CreateUserURL, form);
    }
}*/
