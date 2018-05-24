using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginHandler : MonoBehaviour {

    public InputField username, password, username_friend;
    public GameObject loginWindow, friendWindow,text,textLogin, welcomeWindow, textWelcome;

    // Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("LoggedIn") == 1)
        {
            loginWindow.SetActive(false);
            friendWindow.SetActive(true);
            welcomeWindow.SetActive(true);
            textWelcome.GetComponent<Text>().text = PlayerPrefs.GetString("Username");
        }
        else
        {
            loginWindow.SetActive(true);
            friendWindow.SetActive(false);
            welcomeWindow.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddFriendRequest()
    {
        if (username_friend.text != PlayerPrefs.GetString("Username"))
        {
            StartCoroutine("AddFriend", username_friend.text);
            //Debug.Log("Wrong username, dont input ur username");
        }
    }
    
    public void LoginRequest()
    {
        if (username.text != "" && password.text != "")
        {
            StartCoroutine(Login(username.text, password.text));
        }
        else
        {
            textLogin.GetComponent<Text>().text = "Please fill fields";
        }
    }

    IEnumerator AddFriend(string fname)
    {
        WWWForm form = new WWWForm();
        form.AddField("f_username", fname);
        form.AddField("u_username", PlayerPrefs.GetString("Username")) ;
        username_friend.text = "";
		WWW www = new WWW("http://ballgamewswalters.atwebpages.com/AddFriend.php", form);
        yield return www;
        //Debug.Log(www.text);
        text.GetComponent<Text>().text = www.text;
    }

    IEnumerator Login(string uname, string pword)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", uname);
        form.AddField("password", pword);
        form.AddField("highscore", PlayerPrefs.GetInt("HighScore"));
        WWW www = new WWW("http://ballgamewswalters.atwebpages.com/LoginHandler.php", form);
        yield return www;

        textLogin.GetComponent<Text>().text = www.text;

        PlayerPrefs.SetString("Username", username.text);
        PlayerPrefs.SetString("Password", password.text);
        PlayerPrefs.SetInt("LoggedIn", 1);

        yield return new WaitForSeconds(2f);
        if (www.text != "Username already taken")
        {
            loginWindow.SetActive(false);
            friendWindow.SetActive(true);
        }
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
}
