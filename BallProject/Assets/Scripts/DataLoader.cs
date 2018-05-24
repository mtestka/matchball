/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour {

    public string[] records;
    public static int highscore = 0;

	// Use this for initialization
	IEnumerator Start () {
        WWW itemsData = new WWW("http://localhost/ballGame/HighscoresData.php");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        print(itemsDataString);
        records = itemsDataString.Split(';');
        highscore = Int32.Parse(GetDataValue(records[0], "Highscore"));

    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if(value.Contains("|"))value = value.Remove(value.IndexOf("|"));
        return value;
    }
}*/
