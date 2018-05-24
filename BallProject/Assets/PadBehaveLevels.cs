using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PadBehaveLevels : MonoBehaviour
{

    private SpriteRenderer sr;
    public GameObject[] gameobjects;
    public AudioClip[] ac;
    private AudioSource sm;
    public static bool isGameOver = false;


    // Use this for initialization
    void Start()
    {
        sm = GameObject.FindObjectOfType<SoundMan>().gameObject.GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
		if(collider.name.Contains("ball")){
	        SpawningLevels.count--;
	        Conditions(collider);
	        if (this.tag != collider.tag)
	        {
	            Destroy(gameObject);
	        }
		}
    }

    public void Conditions(Collider2D collider)
    {
        if (this.tag == collider.tag)
        {
			if (!PlayerPrefs.HasKey("MuteSFX") || PlayerPrefs.GetInt("MuteSFX") == 0)
            {
                sm.clip = ac[0];
                sm.Play();
            }
        }
        else
        {
			if (!PlayerPrefs.HasKey("MuteSFX") || PlayerPrefs.GetInt("MuteSFX") == 0)
            {
                sm.clip = ac[1];
                sm.Play();
            }
        }
        if (this.tag == "Blue" && collider.tag == "Red")
        {
            //Debug.Log("red touched blue");
            collider.GetComponent<CircleCollider2D>().enabled = false;
            Instantiate(gameobjects[6], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            //Destroy (gameObject);
        }
        else if (this.tag == "Red" && collider.tag == "Blue")
        {
            //Debug.Log("blue touched red");
            collider.GetComponent<CircleCollider2D>().enabled = false;
            Instantiate(gameobjects[6], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
        else if (this.tag == "Blue" && collider.tag == "Yellow")
        {
            //Debug.Log("yellow touched blue");
            collider.GetComponent<CircleCollider2D>().enabled = false;
            Instantiate(gameobjects[3], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            //Destroy (gameObject);
        }
        else if (this.tag == "Yellow" && collider.tag == "Blue")
        {
            //Debug.Log("blue touched yellow");
            collider.GetComponent<CircleCollider2D>().enabled = false;
            Instantiate(gameobjects[3], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            //Destroy (gameObject);
        }
        else if (this.tag == "Yellow" && collider.tag == "Red")
        {
            //Debug.Log("red touched yellow");
            collider.GetComponent<CircleCollider2D>().enabled = false;
            Instantiate(gameobjects[1], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            //Destroy (gameObject);
        }
        else if (this.tag == "Red" && collider.tag == "Yellow")
        {
            //Debug.Log("yellow touched red");
            collider.GetComponent<CircleCollider2D>().enabled = false;
            Instantiate(gameobjects[1], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }

        BlackCondition(collider);
    }

    private void BlackCondition(Collider2D collider)
    {
        if (this.tag == "Purple" && collider.tag == "Red")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Red" && collider.tag == "Purple")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Orange" && collider.tag == "Red")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Red" && collider.tag == "Orange")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Green" && collider.tag == "Red")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Red" && collider.tag == "Green")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Purple" && collider.tag == "Blue")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Blue" && collider.tag == "Purple")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Orange" && collider.tag == "Blue")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Blue" && collider.tag == "Orange")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Green" && collider.tag == "Blue")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Blue" && collider.tag == "Green")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Purple" && collider.tag == "Yellow")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Yellow" && collider.tag == "Purple")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Orange" && collider.tag == "Yellow")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Yellow" && collider.tag == "Orange")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Green" && collider.tag == "Yellow")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Yellow" && collider.tag == "Green")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Green" && collider.tag == "Orange")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Orange" && collider.tag == "Green")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Purple" && collider.tag == "Orange")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Orange" && collider.tag == "Purple")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Green" && collider.tag == "Purple")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
        if (this.tag == "Purple" && collider.tag == "Green")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            isGameOver = true;
            if (MusicManager.lifes > 0)
            {
                MusicManager.lifes -= 1;
                MusicManager.serverTime -= 1800f;
            }
            //Destroy (gameObject);
        }
    }
}
