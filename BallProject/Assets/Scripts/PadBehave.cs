using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PadBehave : MonoBehaviour {

	private SpriteRenderer sr;
	public GameObject[] gameobjects;
	public GameObject[] balls;
    public AudioClip[] ac;
    private AudioSource sm;
	private GameObject text;
	public int scores = 0;
	private int random, randomball, chosen, globaly;
	private float spawnPos = 0;
    public static bool isGameOver = false;

	// Use this for initialization
	void Start () {
        sm = GameObject.FindObjectOfType<SoundMan>().gameObject.GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer> ();
        InitializeTextFields();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void InitializeTextFields()
    {
        if (this.tag == "Blue")
        {
            text = GameObject.FindGameObjectWithTag("TextLeft");
        }
        else if (this.tag == "Red")
        {
            text = GameObject.FindGameObjectWithTag("TextMid");
        }
        else if (this.tag == "Yellow")
        {
            text = GameObject.FindGameObjectWithTag("TextRight");
        }
        else if (this.tag == "Orange" && Spawning.redtoorange)
        {
            text = GameObject.FindGameObjectWithTag("TextMid");
        }
        else if (this.tag == "Orange" && Spawning.yellowtoorange)
        {
            text = GameObject.FindGameObjectWithTag("TextRight");
        }
        else if (this.tag == "Purple" && Spawning.redtopurple)
        {
            text = GameObject.FindGameObjectWithTag("TextMid");
        }
        else if (this.tag == "Purple" && Spawning.bluetopurple)
        {
            text = GameObject.FindGameObjectWithTag("TextLeft");
        }
        else if (this.tag == "Green" && Spawning.bluetogreen)
        {
            text = GameObject.FindGameObjectWithTag("TextLeft");
        }
        else if (this.tag == "Green" && Spawning.yellowtogreen)
        {
            text = GameObject.FindGameObjectWithTag("TextRight");
        }
    }

    private void ScoreConditions()
    {
        if (this.tag == "Blue")
        {
            ScoresTo10();
            text.GetComponent<Text>().text = "" + Spawning.scoreLeft;
        }
        else if (this.tag == "Red")
        {
            ScoresTo10();
            text.GetComponent<Text>().text = "" + Spawning.scoreMid;
        }
        else if (this.tag == "Yellow")
        {
            ScoresTo10();
            text.GetComponent<Text>().text = "" + Spawning.scoreRight;
        }
        else if (this.tag == "Orange" && Spawning.redtoorange)
        {
            ScoresTo10();
            text.GetComponent<Text>().text = "" + Spawning.scoreMid;
        }
        else if (this.tag == "Orange" && Spawning.yellowtoorange)
        {
            ScoresTo10();
            text.GetComponent<Text>().text = "" + Spawning.scoreRight;
        }
        else if (this.tag == "Purple" && Spawning.redtopurple)
        {
            ScoresTo10();
            text.GetComponent<Text>().text = "" + Spawning.scoreMid;
        }
        else if (this.tag == "Purple" && Spawning.bluetopurple)
        {
            ScoresTo10();
            text.GetComponent<Text>().text = "" + Spawning.scoreLeft;
        }
        else if (this.tag == "Green" && Spawning.bluetogreen)
        {
            ScoresTo10();
            text.GetComponent<Text>().text = "" + Spawning.scoreLeft;
        }
        else if (this.tag == "Green" && Spawning.yellowtogreen)
        {
            ScoresTo10();
            text.GetComponent<Text>().text = "" + Spawning.scoreRight;
        }
    }

    private void ScoresTo10()
    {
        if (Spawning.scoreLeft == 10)
        {
            Spawning.scoreGeneral += 10;
            Spawning.scoreLeft = 0;
        }
        else if (Spawning.scoreMid == 10)
        {
            Spawning.scoreGeneral += 10;
            Spawning.scoreMid = 0;
        }
        else if (Spawning.scoreRight == 10)
        {
            Spawning.scoreGeneral += 10;
            Spawning.scoreRight = 0;
        }
    }

	void OnTriggerEnter2D(Collider2D collider){
		Conditions (collider);
        if (!isGameOver)
        {
            if(SceneManager.GetActiveScene().name == "GameSC")
            SpawningBallInModeNormal();
        }
		if (this.tag != collider.tag) {
			Destroy (gameObject);
		}
	}

	public void SpawningBallInModeNormal(){
            random = Random.Range(0, 3);
            randomball = Random.Range(0, 3);
            chosen = randomball;
            if (random == 0)
            {
                spawnPos = -1.7f;
            }
            else if (random == 1)
            {
                spawnPos = 0f;
            }
            else if (random == 2)
            {
                spawnPos = 1.7f;
            }
            Checkingpads(chosen);
	}

    public void SpawningBallInAnotherMode()
    {

    }

	public void Checkingpads(int randomball){
		if (chosen == 2 && Spawning.yellowtogreen) {
			Debug.Log ("green ball");
            //chosen = 3;
            Instantiate (balls[3], new Vector3 (spawnPos, 6.2f), Quaternion.identity);
			//yellowtogreen = false;
		}
		if (chosen == 1 && Spawning.bluetopurple) {
			Debug.Log ("purple ball");
			//chosen = 5;
			Instantiate (balls[5], new Vector3 (spawnPos, 6.2f), Quaternion.identity);
			//bluetopurple = false;
		}
		if (chosen == 1 && Spawning.bluetogreen) {
			Debug.Log ("green ball");
			//chosen = 3;
			Instantiate (balls[3], new Vector3 (spawnPos, 6.2f), Quaternion.identity);
			//bluetogreen = false;
		}
		if (chosen == 0 && Spawning.redtopurple) {
			Debug.Log ("purple ball");
			//chosen = 5;
			Instantiate (balls[5], new Vector3 (spawnPos, 6.2f), Quaternion.identity);
			//redtopurple = false;
		}
		if (chosen == 0 && Spawning.redtoorange) {
			Debug.Log ("orange ball");
			//chosen = 4;
			Instantiate (balls[4], new Vector3 (spawnPos, 6.2f), Quaternion.identity);
			//redtoorange = false;
		}
		if (chosen == 2 && Spawning.yellowtoorange) {
			Debug.Log ("orange ball");
			//chosen = 4;
			Instantiate (balls[4], new Vector3 (spawnPos, 6.2f), Quaternion.identity);
			//yellowtoorange = false;
		}
		if (chosen == 2 && !Spawning.yellowtogreen && !Spawning.yellowtoorange) {
			Debug.Log ("yellow ball");
			//chosen = 2;
			Instantiate (balls[2], new Vector3 (spawnPos, 6.2f), Quaternion.identity);
			//yellowtogreen = false;
			//yellowtogreen = false;
		}
		if (chosen == 1 && !Spawning.bluetogreen && !Spawning.bluetopurple) {
			Debug.Log ("blue ball");
			//chosen = 1;
			Instantiate (balls[1], new Vector3 (spawnPos, 6.2f), Quaternion.identity);
			//bluetogreen = false;
			//bluetopurple = false;
		}
		if (chosen == 0 && !Spawning.redtoorange && !Spawning.redtopurple) {
			Debug.Log ("red ball");
			//chosen = 0;
			Instantiate (balls[0], new Vector3 (spawnPos, 6.2f), Quaternion.identity);
			//redtoorange = false;
			//redtopurple = false;
		}
	}

	public void Conditions(Collider2D collider){
        if (this.tag == collider.tag)
        {
			if (!PlayerPrefs.HasKey("MuteSFX") || PlayerPrefs.GetInt("MuteSFX") == 0)
            {
                sm.clip = ac[0];
                sm.Play();
            }
            if (this.tag == "Blue")
            {
                Spawning.scoreLeft += 1;
                Spawning.scoreGeneral += 1;
            }
            else if (this.tag == "Red")
            {
                Spawning.scoreMid += 1;
                Spawning.scoreGeneral += 1;
            }
            else if (this.tag == "Yellow")
            {
                Spawning.scoreRight += 1;
                Spawning.scoreGeneral += 1;
            }
            else if (this.tag == "Orange" && Spawning.redtoorange)
            {
                Spawning.scoreMid += 1;
                Spawning.scoreGeneral += 1;
            }
            else if (this.tag == "Orange" && Spawning.yellowtoorange)
            {
                Spawning.scoreRight += 1;
                Spawning.scoreGeneral += 1;
            }
            else if (this.tag == "Purple" && Spawning.redtopurple)
            {
                Spawning.scoreMid += 1;
                Spawning.scoreGeneral += 1;
            }
            else if (this.tag == "Purple" && Spawning.bluetopurple)
            {
                Spawning.scoreLeft += 1;
                Spawning.scoreGeneral += 1;
            }
            else if (this.tag == "Green" && Spawning.bluetogreen)
            {
                Spawning.scoreLeft += 1;
                Spawning.scoreGeneral += 1;
            }
            else if (this.tag == "Green" && Spawning.yellowtogreen)
            {
                Spawning.scoreRight += 1;
                Spawning.scoreGeneral += 1;
            }
            ScoreConditions();
        }
        else
        {
			if (!PlayerPrefs.HasKey("MuteSFX") || PlayerPrefs.GetInt("MuteSFX") == 0)
            {
                sm.clip = ac[1];
                sm.Play();
            }
        }
        if (this.tag == "Blue" && collider.tag == "Red") {
			Debug.Log ("red touched blue");
			collider.GetComponent<CircleCollider2D> ().enabled = false;
            if (SceneManager.GetActiveScene().name != "GameSC")
                DestroyingUnmatchable("Blue", balls[5]);
            Spawning.scoreLeft = 0;
			Spawning.bluetopurple = true;
			Instantiate(gameobjects[6],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
			//Destroy (gameObject);
		}
		else if (this.tag == "Red" && collider.tag == "Blue") {
			Debug.Log ("blue touched red");
			collider.GetComponent<CircleCollider2D> ().enabled = false;
            if (SceneManager.GetActiveScene().name != "GameSC")
                DestroyingUnmatchable("Red", balls[5]);
            Spawning.scoreMid = 0;
			Spawning.redtopurple = true;
			Instantiate(gameobjects[6],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
		}
		else if (this.tag == "Blue" && collider.tag == "Yellow") {
			Debug.Log ("yellow touched blue");
			collider.GetComponent<CircleCollider2D> ().enabled = false;
            if (SceneManager.GetActiveScene().name != "GameSC")
                DestroyingUnmatchable("Blue", balls[3]);
            Spawning.scoreLeft = 0;
			Spawning.bluetogreen = true;
			Instantiate(gameobjects[3],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
			//Destroy (gameObject);
		}
		else if (this.tag == "Yellow" && collider.tag == "Blue") {
			Debug.Log ("blue touched yellow");
			collider.GetComponent<CircleCollider2D> ().enabled = false;
            if (SceneManager.GetActiveScene().name != "GameSC")
                DestroyingUnmatchable("Yellow",balls[3]);
            Spawning.scoreRight = 0;
			Spawning.yellowtogreen = true;
			Instantiate(gameobjects[3],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
			//Destroy (gameObject);
		}
		else if (this.tag == "Yellow" && collider.tag == "Red") {
			Debug.Log ("red touched yellow");
			collider.GetComponent<CircleCollider2D> ().enabled = false;
            if (SceneManager.GetActiveScene().name != "GameSC")
                DestroyingUnmatchable("Yellow", balls[4]);
            Spawning.scoreRight = 0;
			Spawning.yellowtoorange = true;
			Instantiate(gameobjects[1],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
			//Destroy (gameObject);
		} 
		else if (this.tag == "Red" && collider.tag == "Yellow") {
			Debug.Log ("yellow touched red");
			collider.GetComponent<CircleCollider2D> ().enabled = false;
            if(SceneManager.GetActiveScene().name != "GameSC")
                DestroyingUnmatchable("Red", balls[4]);
            Spawning.scoreMid = 0;
			Spawning.redtoorange = true;
			Instantiate(gameobjects[1],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
		}

		BlackCondition (collider);
	}

	private void BlackCondition(Collider2D collider){
		if (this.tag == "Purple" && collider.tag == "Red") {
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextLeft").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
			//Destroy (gameObject);
		}
		if(this.tag == "Red" && collider.tag == "Purple"){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextMid").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Orange" && collider.tag == "Red"){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextRight").GetComponent<Text> ().enabled = false;
		    Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Red" && collider.tag == "Orange"){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextMid").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Green" && collider.tag == "Red" && Spawning.bluetogreen){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextLeft").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Green" && collider.tag == "Red" && Spawning.yellowtogreen){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextRight").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Red" && collider.tag == "Green"){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextMid").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Purple" && collider.tag == "Blue"){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextMid").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Blue" && collider.tag == "Purple"){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextLeft").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Orange" && collider.tag == "Blue" && Spawning.yellowtoorange){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextRight").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Orange" && collider.tag == "Blue" && Spawning.redtoorange){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextMid").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Blue" && collider.tag == "Orange"){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextLeft").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Green" && collider.tag == "Blue"){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextRight").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Blue" && collider.tag == "Green"){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextLeft").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Purple" && collider.tag == "Yellow" && Spawning.redtopurple){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextMid").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Purple" && collider.tag == "Yellow" && Spawning.bluetopurple){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextLeft").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Yellow" && collider.tag == "Purple"){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextRight").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Orange" && collider.tag == "Yellow"){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextMid").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Yellow" && collider.tag == "Orange"){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextRight").GetComponent<Text> ().enabled = false;
		    Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Green" && collider.tag == "Yellow"){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.FindGameObjectWithTag ("TextLeft").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
		if(this.tag == "Yellow" && collider.tag == "Green"){
			collider.GetComponent<CircleCollider2D> ().enabled = false;
		    GameObject.FindGameObjectWithTag ("TextRight").GetComponent<Text> ().enabled = false;
			Instantiate(gameobjects[0],new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
        if (this.tag == "Green" && collider.tag == "Orange")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            GameObject.FindGameObjectWithTag("TextLeft").GetComponent<Text>().enabled = false;
            Instantiate(gameobjects[0], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
        /*if (this.tag == "Orange" && collider.tag == "Green" && !GameObject.FindGameObjectWithTag("Red"))
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            GameObject.FindGameObjectWithTag("TextMid").GetComponent<Text>().enabled = false;
            Instantiate(gameobjects[0], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }*/
        if (this.tag == "Orange" && collider.tag == "Green")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            GameObject.FindGameObjectWithTag("TextRight").GetComponent<Text>().enabled = false;
            Instantiate(gameobjects[0], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
        if (this.tag == "Purple" && collider.tag == "Orange")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            GameObject.FindGameObjectWithTag("TextRight").GetComponent<Text>().enabled = false;
            Instantiate(gameobjects[0], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
        if (this.tag == "Orange" && collider.tag == "Purple")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            GameObject.FindGameObjectWithTag("TextRight").GetComponent<Text>().enabled = false;
            Instantiate(gameobjects[0], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
        if (this.tag == "Green" && collider.tag == "Purple")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            GameObject.FindGameObjectWithTag("TextRight").GetComponent<Text>().enabled = false;
            Instantiate(gameobjects[0], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
        if (this.tag == "Purple" && collider.tag == "Green")
        {
            collider.GetComponent<CircleCollider2D>().enabled = false;
            GameObject.FindGameObjectWithTag("TextRight").GetComponent<Text>().enabled = false;
            Instantiate(gameobjects[0], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            isGameOver = true;
            //Destroy (gameObject);
        }
    }

    private void DestroyingUnmatchable(string name, GameObject go)
    {
        foreach (Ball bo in GameObject.FindObjectsOfType<Ball>())
        {
            if (bo.gameObject.tag == name)
            {
                var position = bo.gameObject.transform.position;
                Destroy(bo.gameObject);
                GameObject ball = Instantiate(go, new Vector3(position.x, position.y, 0), Quaternion.identity) as GameObject;
                ball.transform.parent = GameObject.Find("balls").transform;
            }
        }
    }
}
