using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallStart : MonoBehaviour {

    private LevelManager levelMan;
    public AudioClip audio;
    private SoundMan mm;

	// Use this for initialization
	void Start () {
        levelMan = GameObject.FindObjectOfType<LevelManager>().GetComponent<LevelManager>();
        mm = GameObject.FindObjectOfType<SoundMan>();
	}

    // Update is called once per frame
    void Update()
    {
        if( gameObject.transform.localPosition.y >= 42)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, (gameObject.transform.localPosition.y - 160f*Time.deltaTime), gameObject.transform.localPosition.z) ;
        }
    }
    
    public void Simulate()
    {
        gameObject.GetComponent<Rigidbody2D>().simulated = true;
		if (!PlayerPrefs.HasKey("MuteSFX")|| PlayerPrefs.GetInt("MuteSFX") == 0)
        {
            mm.gameObject.GetComponent<AudioSource>().clip = audio;
            mm.gameObject.GetComponent<AudioSource>().Play();
        }
    }

   /* void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject != gameObject)
        {
            levelMan.LoadLevel();
        }

    }*/

    void OnTriggerEnter2D(Collider2D collider)
    {
		if (collider.gameObject.name == "SitPad")
        {
            StartCoroutine("WaitForPlay");
		}else if(collider.gameObject.name == "CreditPad")
        {
            StartCoroutine("WaitForCredit");
        }
        else
        {
            StartCoroutine("WaitForOptions");
        }
    }

    private IEnumerator WaitForPlay()
    {
        yield return new WaitForSeconds(0.3f);
        levelMan.LoadLevel();
    }

    private IEnumerator WaitForCredit()
    {
        yield return new WaitForSeconds(0.3f);
		SceneManager.LoadScene ("Credits", LoadSceneMode.Single);
    }
    private IEnumerator WaitForOptions()
    {
        yield return new WaitForSeconds(0.3f);
		SceneManager.LoadScene ("Options", LoadSceneMode.Single);
    }

}
