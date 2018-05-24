using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptImage : MonoBehaviour
{

    private string url = "https://files.000webhost.com/handler.php?action=download?action=download&path=%2Fpublic_html%2F";
    public string image;

    IEnumerator Start()
    {
        if (MusicManager.spriteNet[Int32.Parse(image)] == null)
        {
            if (Application.internetReachability != NetworkReachability.NotReachable)
            {
                Texture2D tex;
                tex = new Texture2D(1, 1, TextureFormat.DXT1, false);
                WWW www = new WWW(url + image + ".png");
                yield return www;
                if (false)
                {
                    www.LoadImageIntoTexture(tex);
                    MusicManager.spriteNet[Int32.Parse(image)] = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                    GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                }
                else
                {
                    GetComponent<Image>().enabled = false;
                }
            }
            else
            {
                GetComponent<Image>().enabled = false;
                Debug.Log("No internet connection");
            }
        }
        else
        {
            GetComponent<Image>().sprite = MusicManager.spriteNet[Int32.Parse(image)];
        }
    }
}

