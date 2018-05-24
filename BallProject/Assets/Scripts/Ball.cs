using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

	private string type;
	public Vector2 velocity;
	public float speed = 1, thrust = 1;
	public static bool right = false, left = false;
	private Rigidbody2D rb;
    public GameObject[] balls;
    public bool touched = false;

	// Use this for initialization
	void Start () {
		/*if (this.tag == "RedBall") {
			type = "Red";
		}*/
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position += Vector3.down*speed*Time.deltaTime;
        if(SceneManager.GetActiveScene().name != "GameSC")
        {
            return;
        }
		if (right) {
			if (this.transform.position.x != 1.7f){
				this.transform.Translate (new Vector3 (1.7f, 0, 0));
				//rb.MovePosition(rb.position + velocity*Time.fixedDeltaTime);
				right = false;
			}
		}
		if (left) {
			if (this.transform.position.x != -1.7f) {
				this.transform.Translate (new Vector3 (-1.7f, 0, 0));
				left = false;
			}
		}
	}

	void FixedUpdate(){
        if (SceneManager.GetActiveScene().name == "GameSC")
        {
            if (!PadBehave.isGameOver)
                rb.AddForce(-transform.up * thrust*0.7f * Time.deltaTime * Spawning.multipler);
        }
        else
        {
            if (!PadBehave.isGameOver)
                transform.position = new Vector3(transform.position.x, transform.position.y - (0.001f * Spawning.multipler * Time.deltaTime * speed), 0);
        }
		//rb.AddForce(-transform.up*thrust*Time.deltaTime*Spawning.multipler);
	}

	void OnTriggerEnter2D(Collider2D collider){
        if (SceneManager.GetActiveScene().name != "GameSC")
        {
            var numberball = Random.Range(0, 3);
            Debug.Log(numberball);
            Checkingpads(numberball);
        }
        GetComponent<CircleCollider2D>().enabled = false;
        Invoke("InvokingDestroy", 1f);
	}

    public void Checkingpads(int chosen)
    {
        if (chosen == 2 && Spawning.yellowtogreen)
        {
            Debug.Log("green ball");
            GameObject ball = Instantiate(balls[3], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "greenball";
            touched = true;
        }
        else if (chosen == 1 && Spawning.bluetopurple)
        {
            Debug.Log("purple ball");
            GameObject ball = Instantiate(balls[5], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "purpleball";
            touched = true;
        }
        else if (chosen == 1 && Spawning.bluetogreen)
        {
            Debug.Log("green ball");
            GameObject ball = Instantiate(balls[3], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "greenball";
            touched = true;
        }
        else if (chosen == 0 && Spawning.redtopurple)
        {
            Debug.Log("purple ball");
            GameObject ball = Instantiate(balls[5], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "purpleball";
            touched = true;
        }
        else if (chosen == 0 && Spawning.redtoorange)
        {
            Debug.Log("orange ball");
            GameObject ball = Instantiate(balls[4], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "orangeball";
            touched = true;
        }
        else if (chosen == 2 && Spawning.yellowtoorange)
        {
            Debug.Log("orange ball");
            GameObject ball = Instantiate(balls[4], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "orangeball";
            touched = true;
        }
        else if (chosen == 2 && !Spawning.yellowtogreen && !Spawning.yellowtoorange)
        {
            Debug.Log("yellow ball");
            GameObject ball = Instantiate(balls[0], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "yellowball";
            touched = true;
        }
        else if (chosen == 1 && !Spawning.bluetogreen && !Spawning.bluetopurple)
        {
            Debug.Log("blue ball");
            GameObject ball = Instantiate(balls[1], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "blueball";
            touched = true;
        }
        else if (chosen == 0 && !Spawning.redtoorange && !Spawning.redtopurple)
        {
            GameObject ball = Instantiate(balls[2], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 9, 0), Quaternion.identity) as GameObject;
            ball.transform.SetParent(GameObject.Find("balls").transform);
            ball.name = "redball";
            touched = true;
        }
    }

    private void InvokingDestroy(){
		Destroy (gameObject);
	}
}
