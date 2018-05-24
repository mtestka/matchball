using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TypingWait : MonoBehaviour {

    public float delay = 0.2f;
    public Text text;
    private string currentText = "Saving";

	// Use this for initialization
	void Start () {
		text.text = currentText;
        StartCoroutine(ShowText1());
    }
	
	IEnumerator ShowText1()
    {
        text.text = text.text + ".";
        yield return new WaitForSeconds(0.5f);
        text.text = text.text + ".";
        yield return new WaitForSeconds(0.5f);
        text.text = text.text + ".";
        yield return new WaitForSeconds(0.5f);
        text.text = "Saving";
        yield return new WaitForSeconds(0.5f);
        text.text = text.text + ".";
        yield return new WaitForSeconds(0.5f);
        text.text = text.text + ".";
        yield return new WaitForSeconds(0.5f);
        text.text = text.text + ".";
        yield return new WaitForSeconds(0.5f);
        text.text = "Saving";
        yield return new WaitForSeconds(0.5f);
        text.text = text.text + ".";
        yield return new WaitForSeconds(0.5f);
        text.text = text.text + ".";
        yield return new WaitForSeconds(0.5f);
        text.text = text.text + ".";
        yield return new WaitForSeconds(0.5f);
        text.text = "Saved!";
        yield return new WaitForSeconds(0.5f);
    }

    /*void RepatingRight()
    {
        InvokeRepeating("RepeatingFunction", 0.5f, 1.5f);
        text.text = "Saving";
    }

    void RepeatingFunction()
    {
         text.text = text.text + ".";
    }*/
}
